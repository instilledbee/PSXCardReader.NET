using PSXCardReader.NET.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PSXCardReader.NET
{
    public partial class FormMain : Form, IMainView
    {
        public event OnFileOpenHandler OnFileOpen;
        public event OnItemSelectHandler OnItemSelect;

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
                    OnFileOpen(this.FindForm(), new OnFileOpenArgs() { FilePath = openDialog.FileName });
                }
            }
        }

        public void UpdateOpenedFile(string fileName)
        {
            lblFile.Text = "Memory Card File: " + fileName;
        }

        public void UpdateBlockList(List<string> blockNames, List<Bitmap> blockIcons)
        {
            ImageList iconImages = new ImageList();
            iconImages.Images.AddRange(blockIcons.ToArray());
            listSaves.LargeImageList = iconImages;

            listSaves.Items.Clear();
            for (int i = 0; i < 15; ++i)
            {
                listSaves.Items.Add(blockNames[i]);
                listSaves.Items[i].ImageIndex = i;
            }
        }

        public void HandleError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowView()
        {
            this.ShowDialog();
        }

        public void ShowBlockDetails(string blockName, int blocksUsed)
        {
            MessageBox.Show("Full title: " + blockName + Environment.NewLine + "Blocks used: " + blocksUsed);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Removing image margins (space for icons on left) from menubar items:
            foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
                ((ToolStripDropDownMenu)menuItem.DropDown).ShowImageMargin = false;
        }

        private void listSaves_DoubleClick(object sender, EventArgs e)
        {
            OnItemSelect(sender, new OnItemSelectArgs() { BlockIndex = listSaves.SelectedIndices[0] });
        }
    }
}
