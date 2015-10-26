using PSXCardReader.NET.Presenter.Interfaces;
using PSXCardReader.NET.View.Interfaces;
using PSXMMCLibrary;
using PSXMMCLibrary.Models;
using PSXMMCLibrary.Utilities;
using System;
using System.Diagnostics;
using System.IO;

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
                _view.UpdateOpenedFile(Path.GetFileName(filePath));
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
