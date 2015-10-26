using PSXCardReader.NET.Presenter.Interfaces;
using PSXCardReader.NET.View.Interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace PSXCardReader.NET.Presenter
{
    public class TextBoxTracePresenter : TraceListener, ITracePresenter
    {
        protected ITraceView _view;

        public TextBoxTracePresenter(ITraceView view)
        {
            _view = view;
        }

        public override void Write(string message)
        {
            WriteToOutput(message);
        }

        public override void WriteLine(string message)
        {
            WriteToOutput(message + Environment.NewLine);
        }

        public void WriteToOutput(string message)
        {
            _view.ShowTrace(Environment.NewLine + DateTime.Now.ToString() + ": " + message);
        }

        public void SaveToFile(string logs)
        {
            try
            {
                File.WriteAllText("PSXCardReader.log", logs);
            }
            catch (Exception ex)
            {
                _view.HandleError(ex);
            }
        }
    }
}
