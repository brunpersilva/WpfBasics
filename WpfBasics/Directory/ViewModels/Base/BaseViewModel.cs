using System.ComponentModel;

namespace WpfBasics
{
    /// <summary>
    /// Base Viewmodel that fires property changed as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};
    }
}