using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DriveButtonWithCommand.Command;

namespace DriveButtonWithCommand.ViewModel
{
    /// <summary>
    /// ViewModel for the main page
    /// </summary>
    public class WithoutParamsViewModel : INotifyPropertyChanged
    {
        private bool? _IsChecked;
        /// <summary>Checkbox state</summary>
        public bool? IsChecked
        {
            get { return this._IsChecked; }
            set
            {
                SetProperty(ref this._IsChecked, value);
                if (this.ClickButton != null)
                {
                    this.ClickButton.RaiseCanExecuteChanged();
                }

                this.TextToDisplay = string.Empty;
            }
        }

        private string _TextToDisplay;
        /// <summary>Text to display when the checkbox change state</summary>
        public string TextToDisplay
        {
            get { return this._TextToDisplay; }
            set
            {
                SetProperty(ref this._TextToDisplay, value);
            }
        }

        /// <summary>Command attached to the button</summary>
        public MyOtherCommand ClickButton { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public WithoutParamsViewModel()
        {
            IsChecked = false;
            this.ClickButton = new MyOtherCommand(this.ChangeText, () => IsChecked.Value);
        }

        /// <summary>
        /// Method invoked when the button is clicked
        /// </summary>
        public void ChangeText()
        {
            TextToDisplay = $"The button was clicked at {DateTime.Now.ToString()}";
        }

        /// <summary>
        /// Method use to determine is the button can be clicked
        /// </summary>
        /// <returns>true if the button can be clicked, false otherwise</returns>
        private bool CanIChange()
        {
            return IsChecked.Value;
        }

        #region event handling
        /// <summary>Event handler for the ViewModel</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method used to indicated that something changed in the ViewModel
        /// </summary>
        /// <param name="propertyName">Name of the property that changed</param>
        protected void RaisedPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Customized property setter; set the property only if the value changed and
        /// raise an PropertyChanged event when it's the case
        /// </summary>
        /// <typeparam name="T">Type of the parameter that changed</typeparam>
        /// <param name="storage">Initial value of the parameter</param>
        /// <param name="value">New value for the parameter</param>
        /// <param name="propertyName">Name of the parameter that changed</param>
        /// <returns>True if the value of the parameter changed, else otherwise</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            else
            {
                storage = value;
                this.RaisedPropertyChanged(propertyName);
                return true;
            }
        }
        #endregion event handling
    }
}
