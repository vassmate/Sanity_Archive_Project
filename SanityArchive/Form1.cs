using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace SanityArchive
{
    public partial class SanityArchiveForm : Form
    {
        private static readonly FileBrowser fileBrowser = new FileBrowser();
        private readonly DriveInfo[] availableDrives = fileBrowser.GetAvailableDrives();

		List<FileSystemInfo> selectedItems;
		FileHandler fileHandler;
		bool toCopy;
		bool toMove;


		public SanityArchiveForm()
        {
            InitializeComponent();
        }


        private void SanityArchiveForm_Load(object sender, EventArgs e)
        {
			saveButton.Enabled = false;
			cancelButton.Enabled = false;

			sizeTextBox.Text = "0";

            foreach (DriveInfo drive in availableDrives)
            {
                drivesBox.Items.Add(drive.Name);
            }
            drivesBox.SelectedIndex = 0;
        }


        private void propertiesButton_Click(object sender, EventArgs e)
        {
            string selectedItem = contentListBox.SelectedItem != null ? contentListBox.SelectedItem.ToString() : "";
            string filePath = pathTextBox.Text + "\\" + selectedItem;

            PropertiesForm propertiesForm = new PropertiesForm();
            if (Path.HasExtension(filePath))
            {
                propertiesForm.SetPropertiesPath(filePath);
            }
            else if(Directory.Exists(selectedItem))
            {
                propertiesForm.SetPropertiesPath(selectedItem);
            }
            propertiesForm.Show();
        }


		private void copyButton_Click(object sender, EventArgs e)
		{
			copyButton.Enabled = false;
			copyButton.BackColor = Color.Aqua;
			toCopy = true;

			moveButton.Enabled = false;
			toMove = false;

			saveButton.Enabled = true;
			cancelButton.Enabled = true;

			selectedItems = new List<FileSystemInfo>();
			foreach (var item in contentListBox.SelectedItems)
			{
				selectedItems.Add(new FileInfo(Path.Combine(fileBrowser.GetDrivePath(), item.ToString())));
			}
			fileHandler = new FileHandler(selectedItems);
		}


		private void moveButton_Click(object sender, EventArgs e)
		{
			copyButton.Enabled = false;
			toMove = true;

			moveButton.Enabled = false;
			moveButton.BackColor = Color.Aqua;
			toCopy = false;

			saveButton.Enabled = true;
			cancelButton.Enabled = true;

			selectedItems = new List<FileSystemInfo>();
			foreach (var item in contentListBox.SelectedItems)
			{
				selectedItems.Add(new FileInfo(Path.Combine(fileBrowser.GetDrivePath(), item.ToString())));
			}
			fileHandler = new FileHandler(selectedItems);
		}


		private void saveButton_Click(object sender, EventArgs e)
		{
			if (toCopy)
			{
				try
				{
					fileHandler.CopyFilesTo(fileBrowser.GetDrivePath());
				}
				catch (DirectoryIsChosenException ex)
				{
					MessageBox.Show(ex.ToString(), "Warning!");
				}
			}
			else if (toMove)
			{
				try
				{
					fileHandler.MoveFilesTo(fileBrowser.GetDrivePath());
				}
				catch (DirectoryIsChosenException ex)
				{
					MessageBox.Show(ex.ToString(), "Warning!");
				}
			}

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

        private void contentListBox_DoubleClick(object sender, EventArgs e)
        {
            string selectedItem = contentListBox.SelectedItem != null ? contentListBox.SelectedItem.ToString() : "";
			string filePath = pathTextBox.Text + "\\" + selectedItem;

            OpenFolder(selectedItem);
            OpenFile(filePath);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            fileBrowser.SetDrivePath(GetPreviousPath());
            pathTextBox.Text = fileBrowser.GetDrivePath();

            contentListBox.Items.Clear();
            AddItemsToList();
        }

        private void AddItemsToList()
        {
            DirectoryInfo[] directories = fileBrowser.GetDirectories();
            foreach (DirectoryInfo directory in directories)
            {
                contentListBox.Items.Add(directory.FullName);
            }

            FileInfo[] files = fileBrowser.GetFiles();
            foreach (FileInfo file in files)
            {
                contentListBox.Items.Add(file.Name);
            }
        }

        private string GetPreviousPath()
        {
            string previousPath = pathTextBox.Text;
            int indexOfSeparator = pathTextBox.Text.LastIndexOf("\\");
            int lengthOfPrevPath = pathTextBox.Text.Length - (pathTextBox.Text.Length - indexOfSeparator);

            if (Directory.Exists(pathTextBox.Text) && indexOfSeparator != 2)
            {
                previousPath = pathTextBox.Text.Substring(0, lengthOfPrevPath);
            }
            else if (indexOfSeparator == 2)
            {
                previousPath = pathTextBox.Text.Substring(0, lengthOfPrevPath+1);
            }
            return previousPath;
        }

        private void OpenFolder(string selectedItem)
        {
            if (Directory.Exists(selectedItem))
            {
                fileBrowser.SetDrivePath(selectedItem);
                pathTextBox.Text = fileBrowser.GetDrivePath();

                contentListBox.Items.Clear();
                AddItemsToList();
            }
        }

        private void OpenFile(string filePath)
        {
            if (Path.GetExtension(filePath) == ".txt")
            {
                string[] lines = File.ReadAllLines(filePath);
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.Append("\n" + line);
                }
                string text = sb.ToString();
                MessageBox.Show(text, "Content of selected '.txt' file:", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if(Path.GetExtension(filePath) != ".txt" && Path.HasExtension(filePath))
            {
                MessageBox.Show("Only .txt files are supported!", "Incompatible file format!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void drivesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string drivePath = drivesBox.SelectedItem.ToString();
            fileBrowser.SetDrivePath(drivePath);
            pathTextBox.Text = drivePath;

            contentListBox.Items.Clear();
            AddItemsToList();
        }

		private void calculateButton_Click(object sender, EventArgs e)
		{
			long size = 0;
			FileInfo fileinfo;

			if (contentListBox.SelectedItems == null)
			{
				MessageBox.Show("It is null!", "NULL");
				return;
			}

			foreach (var item in contentListBox.SelectedItems)
			{
				fileinfo = new FileInfo(Path.Combine(fileBrowser.GetDrivePath(), item.ToString()));
				if ((fileinfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
				{
					MessageBox.Show("You can not select directory!", "Warning!");
					sizeTextBox.Text = "0";
					return;
				}
				size += fileinfo.Length;
			}

			if (size < 1024)
				sizeTextBox.Text = size.ToString();
			else if (size < 1024*1024)
			{
				sizeTextBox.Text = string.Format("{0:F2}", size/1024.0);
				sizeUnitLabel.Text = "KB";
			}
			else if (size < 1024*1024*1024)
			{
				sizeTextBox.Text = string.Format("{0:F2}", size/(1024*1024.0));
				sizeUnitLabel.Text = "MB";
			}
			else
			{
				sizeTextBox.Text = string.Format("{0:F2}", size/(1024*1024*1024.0));
				sizeUnitLabel.Text = "GB";
			}
		}
	}
}
