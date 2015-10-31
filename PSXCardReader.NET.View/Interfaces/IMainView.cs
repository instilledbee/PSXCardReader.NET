using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PSXCardReader.NET.View.Interfaces
{
    public interface IMainView : IBaseView
    {
        void UpdateOpenedFile(string fileName);
        void UpdateBlockList(List<String> blockNames, List<Bitmap> blockIcons);
        void ShowBlockDetails(string blockName, int blocksUsed);

        event OnFileOpenHandler OnFileOpen;
        event OnItemSelectHandler OnItemSelect;
    }

    public delegate void OnFileOpenHandler(object sender, OnFileOpenArgs e);
    public delegate void OnItemSelectHandler(object sender, OnItemSelectArgs e);

    public class OnFileOpenArgs : EventArgs
    {
        public string FilePath { get; set; }
    }

    public class OnItemSelectArgs : EventArgs
    {
        public int BlockIndex { get; set; }
    }
}
