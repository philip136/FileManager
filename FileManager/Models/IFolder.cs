using System.Collections.ObjectModel;

namespace FileManager.Models
{
    public interface IFolder
    {
        string Name { get; }
        string Path { get; }
        string ?Date { get; }
        bool Open(ref ObservableCollection<IFolder> list);
    }
}
