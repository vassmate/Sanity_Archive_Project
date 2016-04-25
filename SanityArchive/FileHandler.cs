using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SanityArchive
{
    public class FileHandler
    {

        public List<FileSystemInfo> FilesList { get; set; }


		public FileHandler(List<string> files)
		{
			FilesList = new List<FileSystemInfo>();
			foreach (string filePath in files)
			{
				FileInfo file = new FileInfo(filePath);
				FilesList.Add(file);
			}
		}


        public FileHandler(List<FileSystemInfo> files)
        {
            this.FilesList = files;
        }


        public void MoveFilesTo(string destDir)
        {
            foreach (FileSystemInfo item in FilesList)
            {
                if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    throw new DirectoryIsChosenException("You can not move directory");
                FileInfo file = (FileInfo)item;
				if (File.Exists(Path.Combine(destDir, file.Name)))
				{
					DialogResult msg = MessageBox.Show("In this directory there is a file with same name:\n"
										+ file.Name + "\nDo you want to override this file?", "Warning!",
										MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
					if (msg == DialogResult.Yes)
					{
						File.Delete(Path.Combine(destDir, file.Name));
						file.MoveTo(Path.Combine(destDir, file.Name));
					}
					else if (msg == DialogResult.No)
						continue;
					else if (msg == DialogResult.Cancel)
						return;
				}
				file.MoveTo(Path.Combine(destDir, file.Name));
            }
        }


        public void CopyFilesTo(string destDir)
        {
            foreach (FileSystemInfo item in FilesList)
            {
                if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    throw new DirectoryIsChosenException("You can not copy directory");
                FileInfo file = (FileInfo)item;
				if (File.Exists(Path.Combine(destDir, file.Name)))
				{
					DialogResult msg = MessageBox.Show("In this directory there is a file with same name:\n"
										+file.Name+"\nDo you want to override this file?", "Warning!",
										MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
					if (msg == DialogResult.Yes)
					{
						File.Delete(Path.Combine(destDir, file.Name));
						file.CopyTo(Path.Combine(destDir, file.Name));
					}
					else if (msg == DialogResult.No)
						continue;
					else if (msg == DialogResult.Cancel)
						return;
				}
				file.CopyTo(Path.Combine(destDir, file.Name));
			}
		}


        //static void Main(string[] args)
        //{
        //    string filePath = @"C:\DEV\Interperszonális ütvefúrógép\Sainty Archive Test\sentence";
        //    string filePath4 = @"C:\DEV\Interperszonális ütvefúrógép\Sainty Archive Test\helloka.txt";
        //    string filePath2 = @"C:\DEV\Interperszonális ütvefúrógép\Sainty Archive Test\sentences másolata.txt";
        //    string filePath3 = @"C:\DEV\Interperszonális ütvefúrógép\Sainty Archive Test\sentences másolata másolata.txt";

        //    string copyto = @"C:\DEV\Interperszonális ütvefúrógép\Sainty Archive Test\copyto";
        //    string moveto = @"C:\DEV\Interperszonális ütvefúrógép\Sainty Archive Test\moveto";


        //    List<FileSystemInfo> listFiles = new List<FileSystemInfo>()
        //    {
        //        new FileInfo(filePath),
        //        new FileInfo(filePath2),
        //        new FileInfo(filePath3),
        //        new FileInfo(filePath4)
        //    };

        //    FileHandler fh = new FileHandler(listFiles);
        //    try
        //    {
        //        fh.CopyFilesTo(copyto);
        //        fh.MoveFilesTo(moveto);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //    Console.ReadLine();
        //}
    }

    public class DirectoryIsChosenException : Exception
    {
        public DirectoryIsChosenException(string message) : base(message)
        {
        }
    }
}
