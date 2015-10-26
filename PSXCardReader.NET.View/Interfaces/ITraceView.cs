using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSXCardReader.NET.View.Interfaces
{
    public interface ITraceView : IBaseView
    {
        void ShowTrace(string message);
    }
}
