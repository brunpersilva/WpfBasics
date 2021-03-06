using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



namespace WpfBasics
{
    /// <summary>
    /// A helper class to query information about directories.
    /// </summary>
    public class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drivers on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // Get every logical drive in the machine


            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
            
        }
        /// <summary>
        /// Gets the directory top level content
        /// </summary>
        /// <param name="fullPath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            //Create empty list
            var items = new List<DirectoryItem>();

             #region Get Folders

            //Try and get directories from the folder
            //ignoring any issue doing so
            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(file => new DirectoryItem {FullPath = file, Type = DirectoryItemType.Folder }));
            }
            catch { }
            
            #endregion

            #region Get Files

            //Try and get files from the folder
            //ignoring any issue doing so
            try
            {
                var fs = System.IO.Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    items.AddRange(fs.Select(f=> new DirectoryItem { FullPath = f, Type = DirectoryItemType.File}));
            }
            catch { }

            return items;
            #endregion  
        }

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
