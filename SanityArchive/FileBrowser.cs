using System;
using System.IO;

namespace SanityArchive
{
    public class FileBrowser
    {

        private static string drivePath;
        private DirectoryInfo directoryInf;
        private DirectoryInfo[] directories;
        private FileInfo[] files;
        private DriveInfo[] drives = DriveInfo.GetDrives();

        public void SetDrivePath(string inputDrivePath)
        {
            drivePath = inputDrivePath;
        }

        public string GetDrivePath()
        {
            return drivePath;
        }

        public DriveInfo[] GetAvailableDrives()
        {
            return drives;
        }

        public DirectoryInfo[] GetDirectories()
        {
            directories = new DirectoryInfo[0];
            if (Directory.Exists(drivePath))
            {
                try
                {
                    directoryInf = new DirectoryInfo(drivePath);
                    directories = directoryInf.GetDirectories();
                }
                catch (Exception e)
                {
                    return directories;
                }
            }
            return directories;
        }

        public FileInfo[] GetFiles()
        {
            files = new FileInfo[0];
            DirectoryInfo dir = new DirectoryInfo(drivePath);
            try
            {
                int numberOfFiles = dir.GetFiles().Length;

                if (numberOfFiles > 0)
                {
                    files = new FileInfo[numberOfFiles];
                    files = dir.GetFiles();
                }
            }
            catch (Exception e)
            {
                return files;
            }
            return files;
        }
    }
}
