namespace WpfBasics
{
    /// <summary>
    /// Information about a directory item such as a drive, folder or folder.
    /// </summary>
   public class DirectoryItem
    {
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// Path to this item
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// Name of this directory item
        /// </summary>
        public string Name { get { return Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath); }}
    }
}
