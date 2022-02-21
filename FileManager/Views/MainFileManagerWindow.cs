using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using FileManager.Models;

namespace FileManager.Views
{
    public class MainFileManagerWindow: INotifyPropertyChanged
    {
        private ObservableCollection<IFolder> currentFolders;
        private IFolder currentSelectedFolder;
        private string selectedDrive;
        /// <summary>
        /// Property for get and set logical drives
        /// </summary>
        public ObservableCollection<string> Drives { get; set; }

        /// <summary>
        /// Property for get and set current folders in current directory
        /// </summary>
        public ObservableCollection<IFolder> CurrentFolders { 
            get { return currentFolders; }
            set
            {
                currentFolders = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Property for get and set current folder in selected folder
        /// </summary>
        public IFolder CurrentSelectedFolder
        {
            get { return currentSelectedFolder; }
            set
            {
                currentSelectedFolder = value;
                if (currentSelectedFolder != null)
                {
                    currentSelectedFolder.Open(ref currentFolders);
                }
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Property for get and set selected drives for current logical drive
        /// </summary>
        public string SelectedDrives {
            get { return selectedDrive; }
            set
            {
                selectedDrive = value;
                new WindowsDirectory(new DirectoryInfo(value)).Open(ref currentFolders);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Rendering ComboBox with logical drives
        /// </summary>
        public MainFileManagerWindow()
        {
            currentFolders = new ObservableCollection<IFolder>();
            Drives = new ObservableCollection<string>(Environment.GetLogicalDrives());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
