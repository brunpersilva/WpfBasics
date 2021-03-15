using System.Windows.Input;
using System;

namespace Fasetto_Word
{
    /// <summary>
    /// A basic command that runs an action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private members
        /// <summary>
        /// The action to run
        /// </summary>
        private readonly Action _action;
        #endregion

        #region Public eventes

        /// <summary>
        /// The event that is fired when <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            _action = action;
        }
        #endregion

        #region Command Methods

        /// <summary>
        /// A relay command can always be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute the commands action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action();
        }
        #endregion
    }
}
