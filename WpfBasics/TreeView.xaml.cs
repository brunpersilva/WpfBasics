using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfBasics
{
    /// <summary>
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeView : Window
    {
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public TreeView()
        {
            InitializeComponent();
        }
        #endregion

        #region Onloaded
        /// <summary>
        /// Load When the Application First Opens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get every logical drive in the machine
            foreach (var drive in Directory.GetLogicalDrives())
            {
                //Create a new item for it
                var item = new TreeViewItem
                {

                    //Set the header 
                    Header = drive,
                    //Set full path
                    Tag = drive
                };

                //Adds a dummy item
                item.Items.Add(null);

                //Listen out for item being expanded
                item.Expanded += Folder_Expanded;

                //Add it to the main tree-view
                FolderView.Items.Add(item);
            } 
        }


        #endregion

        #region Folder Expanded
        /// <summary>
        /// When a folder is expanded, find the subfolders/files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Initial Checks

            var item = (TreeViewItem)sender;
            //if the item only contains dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            //clear Dummy data
            item.Items.Clear();

            //get folder name
            var fullPath = (string)item.Tag;
            #endregion

            #region Get Folders
            //Create blank list
            var directories = new List<string>();

            //Try and get directories from the folder
            //ignoring any issue doing so
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch { }
            //For each Directory
            directories.ForEach(directoriesPath =>
            {
                //Create Directory item
                var subItem = new TreeViewItem()
                {
                    //Set header as folder name
                    Header = GetFileFolderName(directoriesPath),
                    //And tag as full path
                    Tag = directoriesPath

                };
                //Adds dummy item so we can expand folder
                subItem.Items.Add(null);

                subItem.Expanded += Folder_Expanded;

                //Adds this item to the parent
                item.Items.Add(subItem);
            });
            #endregion

            #region Get Files
            //Create blank list for files
            var files = new List<string>();

            //Try and get files from the folder
            //ignoring any issue doing so
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch { }
            //For each file
            files.ForEach(filePath =>
            {
                //Create file item
                var subItem = new TreeViewItem()
                {
                    //Set header as file name
                    Header = GetFileFolderName(filePath),
                    //And tag as full path
                    Tag = filePath

                };
                //Adds this item to the parent
                item.Items.Add(subItem);
            });
            #endregion

        }
        #endregion

        #region Helpers
        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // C:\Something\a Folder

            //if we have no path return empty
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }
            //Make all slashes backslashes
            var normalizedPath = path.Replace('/', '\\');

            //find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            //if we dont find a backslash, return the path itself
            if (lastIndex <= 0)
                return path;

            //return the name after the last backslash
            return path.Substring(lastIndex + 1);

        }
        #endregion

    }
}
