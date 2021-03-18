using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

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

        /// <summary>
        /// The size of the resize border around the 
        /// window taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

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

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar/caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLenght { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion


        #region Commands 
        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeComand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeComand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }
        /// <summary>
        /// The command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor
        public WindowViewModel(Window window)
        {
            _window = window;

            //Listen out for the window resizing
            _window.StateChanged += (sender, e) =>
            {
                //Fire event for all properties that are affected by resize
                OnpropertyChanged(nameof(ResizeBorderThickness));
                OnpropertyChanged(nameof(OuterMarginSize));
                OnpropertyChanged(nameof(OuterMarginSizeThickness));
                OnpropertyChanged(nameof(WindowRadius));
                OnpropertyChanged(nameof(WindowCornerRadius));
            };

            //Create commands
            MinimizeComand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeComand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));


        }
        #endregion

        #region Private helpers
        Point GetMousePosition() => _window.PointToScreen(Mouse.GetPosition(_window));

        #endregion
    }
}
