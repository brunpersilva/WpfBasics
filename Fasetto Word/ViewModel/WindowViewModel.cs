using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Fasetto_Word
{
    /// <summary>
    /// The view model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private member
        private readonly Window _window;
        /// <summary>
        /// The margin around the window to allow for drop down shadow
        /// </summary>
        private int _outerMarginSize = 10;
        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _windowRadius = 10;
        #endregion

        #region Public properties
        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;


        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            }
            set
            {
                _outerMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            }
            set
            {
                _windowRadius = value;
            }
        }
        #endregion

        #region Constructor
        public WindowViewModel(Window window)
        {
            _window = window;

            //Listen out for the window resizing
            _window.StateChanged += (sender, e) =>
            {

            };
        }
        #endregion
    }
}
