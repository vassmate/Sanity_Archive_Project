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

namespace SanityArchive
{
    public partial class SanityArchiveForm : Form
    {
        public SanityArchiveForm()
        {
            InitializeComponent();
        }


        private void SanityArchiveForm_Load(object sender, EventArgs e)
        {
			pathTextBox.Text = @"C:\";
			saveButton.Enabled = false;
			cancelButton.Enabled = false;
        }


        private void propertiesButton_Click(object sender, EventArgs e)
        {
			PropertiesForm propertiesForm = new PropertiesForm();
			propertiesForm.Show();
        }


		private void copyButton_Click(object sender, EventArgs e)
		{
			copyButton.Enabled = false;
			copyButton.BackColor = Color.Aqua;

			moveButton.Enabled = false;

			saveButton.Enabled = true;
			cancelButton.Enabled = true;


		}


		private void moveButton_Click(object sender, EventArgs e)
		{
			copyButton.Enabled = false;

			moveButton.Enabled = false;
			moveButton.BackColor = Color.Aqua;

			saveButton.Enabled = true;
			cancelButton.Enabled = true;

		}


		private void saveButton_Click(object sender, EventArgs e)
		{
			copyButton.Enabled = true;
			copyButton.BackColor = SystemColors.Control;

			moveButton.Enabled = true;
			moveButton.BackColor = SystemColors.Control;

			saveButton.Enabled = false;
			cancelButton.Enabled = false;
		}


		private void cancelButton_Click(object sender, EventArgs e)
		{
			copyButton.Enabled = true;
			copyButton.BackColor = SystemColors.Control;

			moveButton.Enabled = true;
			moveButton.BackColor = SystemColors.Control;

			saveButton.Enabled = false;
			cancelButton.Enabled = false;
		}
	}
}
