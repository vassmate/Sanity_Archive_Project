using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace SanityArchive
{
    public partial class PropertiesForm : Form
    {
		string path;
		//string path = @"C:\DEV\Interperszonális ütvefúrógép\Sainty Archive Test\sentences másolata másolata (6).txt";

		public PropertiesForm()
        {
            InitializeComponent();
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

            FileAttributes attributes = File.GetAttributes(path);

            MessageBox.Show(attributes.ToString());
        }
    }
}
