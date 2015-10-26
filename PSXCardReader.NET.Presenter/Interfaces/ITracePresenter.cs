using System.Diagnostics;
namespace PSXCardReader.NET.Presenter.Interfaces
{
    public interface ITracePresenter
    {
        void WriteToOutput(string message);
        void SaveToFile(string logs);
    }
}
