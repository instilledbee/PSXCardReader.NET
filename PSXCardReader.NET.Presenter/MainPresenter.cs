using PSXCardReader.NET.Presenter.Interfaces;
using PSXCardReader.NET.View.Interfaces;
using PSXMMCLibrary;
using PSXMMCLibrary.Models;
using PSXMMCLibrary.Utilities;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PSXCardReader.NET.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        protected IMainView _view;
        protected MemoryCard _memoryCard;
        protected string _filePath;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.OnFileOpen += _view_OnFileOpen;
            _view.OnItemSelect += _view_OnItemSelect;
            _view.OnAboutSelect += _view_OnAboutSelect;
        }

        void _view_OnAboutSelect(object sender, EventArgs e)
        {
            try 
            {
                Assembly runningApp = Assembly.GetEntryAssembly();
                AssemblyCompanyAttribute developer = runningApp.GetCustomAttribute<AssemblyCompanyAttribute>();
                AssemblyFileVersionAttribute fileVersion = runningApp.GetCustomAttribute<AssemblyFileVersionAttribute>();
                AssemblyCopyrightAttribute copyright = runningApp.GetCustomAttribute<AssemblyCopyrightAttribute>();

                _view.ShowProgramInfo(runningApp.GetName().Name, developer.Company, fileVersion.Version, copyright.Copyright);
            }
            catch (Exception ex)
            {
                _view.HandleError(ex);
            }
        }

        private void _view_OnItemSelect(object sender, OnItemSelectArgs e)
        {
            Trace.Write("Selected item index: " + e.BlockIndex);

            Block selectedBlock = _memoryCard.Blocks[e.BlockIndex];
            _view.ShowBlockDetails(selectedBlock.Title, selectedBlock.BlocksUsed);
        }

        private void _view_OnFileOpen(object sender, OnFileOpenArgs e)
        {
            Trace.Write("Opening memory card file: " + e.FilePath);
            OpenMemoryCard(e.FilePath);
        }

        public void OpenMemoryCard(string filePath)
        {
            try
            {
                _filePath = filePath;
                ParseFileData();

                if (_memoryCard != null)
                {
                    _view.UpdateOpenedFile(Path.GetFileName(filePath));
                    _view.UpdateBlockList(_memoryCard.Blocks.Select(x => FormatBlockTitle(x)).ToList(), 
                        _memoryCard.Blocks.Select(x => x.Icon != null ? ParseBitmap(x.Icon) : new Bitmap(16, 16)).ToList());
                }
            }
            catch (Exception ex)
            {
                // Undo memory card loading
                _memoryCard = null;
                _filePath = null;

                Trace.Write(ex.Message);
                Trace.Write(ex.StackTrace);

                _view.HandleError(ex);
            }
        }

        private string FormatBlockTitle(Block b)
        {
            if (b.IsLinkBlock)
            {
                return "Link block of block #" + _memoryCard.Blocks.IndexOf(b);
            }
            else
            {
                return b.Title;
            }
        }

        private Bitmap ParseBitmap(BlockIcon icon)
        {
            Bitmap parsedBitmap = new Bitmap(16, 16);

            for(int i = 0; i < icon.Frames[0].Length; ++i)
            {
                int y = i / 16;
                int x = i % 16;
                parsedBitmap.SetPixel(x, y, icon.Colors[icon.Frames[0][i]]);
            }

            return parsedBitmap;
        }

        private void ParseFileData()
        {
            byte[] _data;

            try
            {
                using (FileStream fs = File.Open(_filePath, FileMode.Open))
                {
                    _data = new byte[fs.Length];
                    fs.Read(_data, 0, (int)fs.Length);
                }

                if (DirectoryFrameParser.IsValidHeaderFrame(_data.SubArray(0, 128)))
                {
                    _memoryCard = new MemoryCard();
                    _memoryCard.FileName = Path.GetFileName(_filePath);

                    for (int i = 1; i < 16; ++i)
                    {
                        _memoryCard.DirectoryFrames.Add(DirectoryFrameParser.Parse(_data.SubArray(128 * i, 128)));
                        _memoryCard.Blocks.Add(BlockParser.Parse(_data.SubArray(8192 * i, 8192)));
                    }
                }
                else
                {
                    throw new InvalidDataException("Selected file is not a valid PSX memory card.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
