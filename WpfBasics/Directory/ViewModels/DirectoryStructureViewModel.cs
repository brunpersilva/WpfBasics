using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WpfBasics
{
    /// <summary>
    /// The view model for the application main directory view
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties
            
        /// <summary>
        /// List of all directories in the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        #endregion

        #region Constructor
        public DirectoryStructureViewModel()
        {
            //Get logical drivers
            var children = DirectoryStructure.GetLogicalDrives();

            //Create the viewmodels from the data
            Items = new ObservableCollection<DirectoryItemViewModel>(
                    children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
        #endregion

    }
}
