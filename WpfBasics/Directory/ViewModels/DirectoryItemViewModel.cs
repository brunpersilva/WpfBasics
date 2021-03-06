using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfBasics
{
    /// <summary>
    /// A ViewModel for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public Property
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// The full path to the directory
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of the directory item
        /// </summary>
        public string Name { get { return Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath); } }

        /// <summary>
        /// List of all children in this item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// Indicates if this item can be expanded
        /// </summary>
        public bool CanExpand { get { return Type != DirectoryItemType.File; } }

       
        public bool IsExpanded
        {
            get
            {
                return Children?.Count(f => f != null) > 0;
            }
            set
            {
                //If the UI tell us to expand
                if (value == true)
                    //Find thr children
                    Expand();
                //if the UI tell us to close
                else
                    ClearChildren();
            }

        }
        #endregion

        #region Constrctor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fullPath">The full path of this item</param>
        /// <param name="type">The type of this item</param>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            //Create commands
            ExpandCommand = new RelayCommand(Expand);

            //Set path and type
            FullPath = fullPath;
            Type = type;
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// The Command to expand this item 
        /// </summary>
        public ICommand ExpandCommand { get; set; }
            
        #endregion

        #region Helper Methods
        /// <summary>
        /// Removes all children from the list,
        /// adding a dummy item to show the expand icon if required
        /// </summary>
        private void ClearChildren()
        {
            //Clear Items
            Children = new ObservableCollection<DirectoryItemViewModel>();

            //Show the expand arrow if we are not a file
            if (Type != DirectoryItemType.File)
                Children.Add(null);

        }
        #endregion

        /// <summary>
        /// Expands this directory and finds all children
        /// </summary>
        private void Expand()
        {
            if (Type == DirectoryItemType.File)
                return;
            var children = DirectoryStructure.GetDirectoryContents(FullPath);
            Children = new ObservableCollection<DirectoryItemViewModel>(
                        children.Select(content => new DirectoryItemViewModel(FullPath, Type)));
        }
    }
}
