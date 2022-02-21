using NUnit.Framework;
using FileManager.Models;
using FileManagerTests.Utilities;
using System.IO;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;

namespace FileManagerTests.Unit
{
    public class FolderTest
    {
        private readonly string rootPath = Constants.RootPath;
        private ObservableCollection<IFolder> emptyFolder = new ObservableCollection<IFolder>();
        private string pathToNewFile = Constants.RootPath + Path.DirectorySeparatorChar + Constants.TestFileName;

        /// <summary>
        /// Create new file with some data and add folders and files in emptyFolder collection
        /// </summary>
        [SetUp]
        public void BeforeTest()
        {
            using (var fileStream = File.Create(pathToNewFile))
            {
                byte[] buffer = Encoding.Default.GetBytes(Constants.TextForNewFile);
                fileStream.Write(buffer, 0, buffer.Length);
            }
            IFolder rootDirectory = new RootDirectory(rootPath);
            rootDirectory.Open(ref emptyFolder);
        }

        /// <summary>
        /// Delete new test file
        /// </summary>
        [TearDown]
        public void AfterTest()
        {
            File.Delete(pathToNewFile);
        }

        /// <summary>
        /// Create root directory and check that name is equal root path
        /// </summary>
        [Test]
        public void CreateRootDirectoryAndCheckName()
        {
            IFolder rootDir = new RootDirectory(rootPath);
            Assert.AreEqual(rootDir.Name, rootPath);
        }

        /// <summary>
        /// Create root directory and check that new test file is exist
        /// </summary>
        [Test]
        public void CreateDirectoryAndCheckThatFileExist()
        {
            IEnumerable<bool> fileExistsStatus = emptyFolder.ToArray().Select(file => file.Name.Equals(Constants.TestFileName));
            Assert.Contains(true, fileExistsStatus.ToList());
        }
    }
}
