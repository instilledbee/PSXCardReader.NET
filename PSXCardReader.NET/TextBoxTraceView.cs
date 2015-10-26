using PSXCardReader.NET.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSXCardReader.NET
{
    public partial class TextBoxTraceView : Form, ITraceView
    {
        private StringSendDelegate _invokeWrite;

        public TextBoxTraceView()
        {
            InitializeComponent();
            _invokeWrite = new StringSendDelegate(SendString);
        }

        private delegate void StringSendDelegate(string message);
        private void SendString(string message)
        {
            txtboxTrace.Text += message;
        }

        public void ShowTrace(string message)
        {
            _invokeWrite(message);
        }

        public void ShowView()
        {
            this.Show();
        }

        public void HandleError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
