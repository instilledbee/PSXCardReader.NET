using PSXCardReader.NET.Presenter.Interfaces;
using PSXCardReader.NET.View.Interfaces;
using PSXMMCLibrary.Models;
using System.IO;

namespace PSXCardReader.NET.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        protected IMainView _view;
        protected MemoryCard _memoryCard;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.OnFileOpen += _view_OnFileOpen;
        }

        private void _view_OnFileOpen(object sender, OnFileOpenArgs e)
        {
            OpenMemoryCard(e.FilePath);
        }

        public void OpenMemoryCard(string filePath)
        {
            _view.UpdateOpenedFile(Path.GetFileName(filePath));
        }
    }
}
