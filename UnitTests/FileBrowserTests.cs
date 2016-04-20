using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FileBrowser.Tests
{
    [TestClass()]
    public class FileBrowserTests
    {
        [TestMethod()]
        public void GetDirectories_InvalidPath_ReturnEmptyArray()
        {
            FileBrowser testBrowser = new FileBrowser();
            DirectoryInfo[] resultArray = testBrowser.GetDirectories();

            int expected = 0;
            int result = resultArray.Length;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetDirectories_EmptyStringPath_ReturnEmptyArray()
        {
            string drivePath = "";

            FileBrowser testBrowser = new FileBrowser();
            testBrowser.SetDrivePath(drivePath);
            DirectoryInfo[] resultArray = testBrowser.GetDirectories();

            int expected = 0;
            int result = resultArray.Length;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetDirectories_ValidPath_ReturnArrayWithOneElement()
        {
            string drivePath = "C:\\testfiles";

            FileBrowser testBrowser = new FileBrowser();
            testBrowser.SetDrivePath(drivePath);
            DirectoryInfo[] resultArray = testBrowser.GetDirectories();

            DirectoryInfo[] expectedArray = new DirectoryInfo(drivePath).GetDirectories();

            int expected = expectedArray.Length;
            int result = resultArray.Length;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetDirectories_ValidPath_ReturnArrayWithMoreElements()
        {
            string drivePath = "C:\\";

            FileBrowser testBrowser = new FileBrowser();
            testBrowser.SetDrivePath(drivePath);
            DirectoryInfo[] resultArray = testBrowser.GetDirectories();

            DirectoryInfo[] expectedArray = new DirectoryInfo(drivePath).GetDirectories();

            int expected = expectedArray.Length;
            int result = resultArray.Length;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetFiles_InvalidPath_ReturnEmptyArray()
        {
            string dirPath = "";

            FileBrowser testBrowser = new FileBrowser();
            testBrowser.SetDrivePath(dirPath);
            FileInfo[] resultArray = testBrowser.GetFiles();

            int expected = 0;
            int result = resultArray.Length;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetFiles_ValidPath_ReturnArrayWithElements()
        {
            string dirPath = "C:\\testfiles";

            FileBrowser testBrowser = new FileBrowser();
            testBrowser.SetDrivePath(dirPath);
            FileInfo[] resultArray = testBrowser.GetFiles();
            
            int result = resultArray.Length;

            Assert.IsTrue(result > 0);
        }
    }
}