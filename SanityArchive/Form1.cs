using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void propertiesButton_Click(object sender, EventArgs e)
        {
           PropertiesForm propertiesForm = new PropertiesForm();
           propertiesForm.Show();
        }
    }
}
