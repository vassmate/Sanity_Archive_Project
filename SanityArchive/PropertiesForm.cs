using System;
using System.Windows.Forms;
using System.IO;

namespace SanityArchive
{
    public partial class PropertiesForm : Form
    {
		private string path;

		public PropertiesForm()
        {
            InitializeComponent();
        }

        public void SetPropertiesPath(string newPath)
        {
            path = newPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.Hidden);
            else
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.ReadOnly);
            else
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.ReadOnly);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.Archive) == FileAttributes.Archive)
                File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.Archive);
            else
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Archive);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.System) == FileAttributes.System)
                File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.System);
            else
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.System);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.Temporary) == FileAttributes.Temporary)
                File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.Temporary);
            else
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Temporary);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                FileAttributes attributes = File.GetAttributes(path);
                MessageBox.Show(attributes.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("File or directory is not accessible!\nException info: " + ex.Message, "Exception occured!", MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
            }
        }
    }
}
