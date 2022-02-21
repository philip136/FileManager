using System.IO;
using System.Linq;
using System.Collections.ObjectModel;

namespace FileManager.Models
{
    /// <summary>
    /// Represenation for windows directory
    /// </summary>
    public class WindowsDirectory: IFolder
    {
        public string Name => directoryInfo.Name;
        public string Path => directoryInfo.FullName;
        public string Date => directoryInfo.LastWriteTime.ToString();

        private DirectoryInfo directoryInfo;
        
        public WindowsDirectory(DirectoryInfo directoryInfo)
        {
            this.directoryInfo = directoryInfo;

        }

        /// <summary>
        /// Open directory and render directories with files from current directory
        /// </summary>
        /// <param name="list">List with current directories or files</param>
        /// <returns></returns>
        public bool Open(ref ObservableCollection<IFolder> list)
        {
            list.Clear();
            if (directoryInfo.Parent != null)
            {
                list.Add(new RootDirectory(directoryInfo.Parent.FullName));
            }
            foreach(IFolder folder in directoryInfo.GetDirectories().Select(x => new WindowsDirectory(x)))
            {
                list.Add(folder);
            }
            foreach(IFolder file in directoryInfo.GetFiles().Select(x => new WindowsFile(x)))
            {
                list.Add(file);
            }
            return true;
        }
    }
}
