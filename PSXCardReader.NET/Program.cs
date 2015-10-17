using PSXCardReader.NET.View;
using PSXCardReader.NET.View.Interfaces;
using PSXCardReader.NET.Presenter.Interfaces;
using System;
using System.Windows.Forms;
using PSXCardReader.NET.Presenter;

namespace PSXCardReader.NET
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());

            IMainView mainView = new FormMain();
            IMainPresenter mainPresenter = new MainPresenter(mainView);
            mainView.ShowView();
        }
    }
}
