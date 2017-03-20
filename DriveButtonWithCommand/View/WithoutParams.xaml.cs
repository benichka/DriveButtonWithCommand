using DriveButtonWithCommand.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace DriveButtonWithCommand.View
{
    /// <summary>
    /// Secondary page: a button that is enabled only if a checkbox is checked. This is done
    /// without a command parameter
    /// </summary>
    public sealed partial class WithoutParams : Page
    {
        /// <summary>ViewModel attached to the page</summary>
        public WithoutParamsViewModel DoesntWorkViewModel { get; set; } = new WithoutParamsViewModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public WithoutParams()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Navigate to page 2
        /// </summary>
        /// <param name="sender">The button that called the method</param>
        /// <param name="e"></param>
        private void GoToPage1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
