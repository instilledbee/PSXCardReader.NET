using PSXCardReader.NET.View;
using PSXCardReader.NET.View.Interfaces;
using PSXCardReader.NET.Presenter.Interfaces;
using System;
using System.Windows.Forms;
using PSXCardReader.NET.Presenter;
using System.Diagnostics;

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

#if DEBUG
            ITraceView traceView = new TextBoxTraceView();
            ITracePresenter tracePresenter = new TextBoxTracePresenter(traceView);
            traceView.ShowView();
            Trace.Listeners.Add((TraceListener)tracePresenter);

            Trace.Listeners.Add(new TextWriterTraceListener("PSXCardReader-" + DateTime.Now.ToFileTime() + ".log") { TraceOutputOptions = TraceOptions.DateTime });
#endif

            IMainView mainView = new FormMain();
            IMainPresenter mainPresenter = new MainPresenter(mainView);
            mainView.ShowView();

#if DEBUG
            Trace.Flush();
#endif 
        }
    }
}
