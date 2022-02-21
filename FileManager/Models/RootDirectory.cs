using System.Collections.ObjectModel;
using System.IO;

namespace FileManager.Models
{
    /// <summary>
    /// Represenation for root directory
    /// </summary>
    public class RootDirectory : IFolder
    {
        private string path;

        public string Name => "..";
        public string Path => path;

        public string? Date => null;

        public RootDirectory(string path)
        {
            this.path = path;
        }
        public bool Open(ref ObservableCollection<IFolder> list)
        {
            return new WindowsDirectory(new DirectoryInfo(path)).Open(ref list);
        }
    }
}
