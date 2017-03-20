using System;
using System.Windows.Input;

namespace DriveButtonWithCommand.Command
{
    /// <summary>
    /// Command class used for a button that sends a parameter to
    /// drives it
    /// </summary>
    public class MyCommand : ICommand
    {
        /// <summary>Action to execute in case the command is executable</summary>
        private Action methodToExecute = null;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="methodToExecute">Method to execute in case the command is executable</param>
        public MyCommand(Action methodToExecute)
        {
            this.methodToExecute = methodToExecute;
        }

        /// <summary>
        /// Determine whether the command is executable or not
        /// </summary>
        /// <param name="parameter">optional parameters</param>
        /// <returns>True if the method can be executed, false otherwise</returns>
        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return true;
            }
            else
            {
                return (bool)parameter;
            }
        }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="parameter">optional parameters</param>
        public void Execute(object parameter)
        {
            this.methodToExecute();
        }


        /// <summary>Event handler</summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Raise the event indicating that something changed and we need
        /// to check if the command is now executable or not
        /// </summary>
        void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
