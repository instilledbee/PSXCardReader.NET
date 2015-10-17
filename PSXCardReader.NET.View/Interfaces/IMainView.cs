using System;
using System.IO;

namespace PSXCardReader.NET.View.Interfaces
{
    public interface IMainView
    {
        void UpdateOpenedFile(string fileName);
        void ShowView();

        event OnFileOpenHandler OnFileOpen;
    }

    public delegate void OnFileOpenHandler(object sender, OnFileOpenArgs e);

    public class OnFileOpenArgs : EventArgs
    {
        public string FilePath { get; set; }
    }
}
