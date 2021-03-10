using System.ComponentModel;
using PropertyChanged;

namespace Fasetto_Word
{
    /// <summary>
    /// Base Viewmodel that fires property changed as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a event
        /// </summary>
        /// <param name="name"></param>
        public void OnpropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}