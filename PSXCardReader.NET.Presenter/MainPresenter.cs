using PSXCardReader.NET.Presenter.Interfaces;
using PSXCardReader.NET.View.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSXCardReader.NET.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        protected IMainView _view;

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
