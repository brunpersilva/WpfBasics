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

            DataContext = new DirectoryStructureViewModel();
        }
        #endregion    

    }
}
