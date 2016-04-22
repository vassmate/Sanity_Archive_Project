﻿using System;
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
        private int currentSelectedIndex = 0;
        private string[] previousSelectedItems = new string[100];

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
			pathTextBox.Text = @"C:\";
			saveButton.Enabled = false;
			cancelButton.Enabled = false;

            previousSelectedItems[currentSelectedIndex] = pathTextBox.Text;
            fileBrowser.SetDrivePath(pathTextBox.Text);
            AddItemsToList();
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
					fileHandler.CopyFilesTo(previousSelectedItems[currentSelectedIndex]);
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
					fileHandler.MoveFilesTo(previousSelectedItems[currentSelectedIndex]);
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

			if (Directory.Exists(selectedItem))
            {
                fileBrowser.SetDrivePath(selectedItem);
                pathTextBox.Text = fileBrowser.GetDrivePath();

                contentListBox.Items.Clear();
                AddItemsToList();

                currentSelectedIndex++;
                previousSelectedItems[currentSelectedIndex] = selectedItem;
            }

			if (Path.GetExtension(filePath) == ".txt")
			{
				string[] lines = File.ReadAllLines(filePath);
				StringBuilder sb = new StringBuilder();
				foreach (string line in lines)
				{
					sb.Append("\n" + line);
				}
				string text = sb.ToString();
				MessageBox.Show(text, "Content of selected '.txt' file:", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

        private void backButton_Click(object sender, EventArgs e)
        {
            if (currentSelectedIndex > 0)
            {
                currentSelectedIndex--;

                fileBrowser.SetDrivePath(previousSelectedItems[currentSelectedIndex]);
                pathTextBox.Text = fileBrowser.GetDrivePath();

                contentListBox.Items.Clear();
                AddItemsToList();
            }
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
	}
}
