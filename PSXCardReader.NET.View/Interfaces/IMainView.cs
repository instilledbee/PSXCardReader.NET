using System;
using System.IO;

namespace PSXCardReader.NET.View.Interfaces
{
    public interface IMainView : IBaseView
    {
        void UpdateOpenedFile(string fileName);

        event OnFileOpenHandler OnFileOpen;
    }

    public delegate void OnFileOpenHandler(object sender, OnFileOpenArgs e);

    public class OnFileOpenArgs : EventArgs
    {
        public string FilePath { get; set; }
    }
}
