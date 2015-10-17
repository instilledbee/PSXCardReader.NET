using PSXCardReader.NET.View.Interfaces;
using System;
using System.IO;
using System.Windows.Forms;

namespace PSXCardReader.NET
{
    public partial class FormMain : Form, IMainView
    {
        public event OnFileOpenHandler OnFileOpen;

        public FormMain()
        {
            InitializeComponent();
        }

        private void mmItemFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mmItemFileOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "ePSXe memory card (*.mcr)|*.mcr|All files (*.*)|*.*";
                openDialog.FilterIndex = 1;
                openDialog.Multiselect = false;
                openDialog.ShowHelp = false;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(openDialog.FileName);

                    OnFileOpen(this.FindForm(), new OnFileOpenArgs() { FilePath = openDialog.FileName });
                }
            }
        }

        public void UpdateOpenedFile(string fileName)
        {
            lblFile.Text = "Memory Card File: " + fileName;
        }

        public void ShowView()
        {
            this.ShowDialog();
        }
    }
}
