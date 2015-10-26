using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSXCardReader.NET.View.Interfaces
{
    public interface IBaseView
    {
        void ShowView();
        void HandleError(Exception ex);
    }
}
