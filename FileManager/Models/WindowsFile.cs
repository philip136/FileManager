using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace FileManager.Models
{
    public class WindowsFile : IFolder
    {
        private FileInfo fileInfo;
        public string Name => fileInfo.Name;
        public string Path => fileInfo.FullName;
        public string Date => fileInfo.LastWriteTime.ToString();

        public WindowsFile(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
        }
        /// <summary>
        /// Start new process for any file with extension
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Open(ref ObservableCollection<IFolder> list)
        {
            var proc = new Process();
            proc.StartInfo.FileName = Path;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
            return true;
        }
    }
}
