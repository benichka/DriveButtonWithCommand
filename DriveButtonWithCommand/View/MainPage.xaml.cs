using DriveButtonWithCommand.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DriveButtonWithCommand.View
{
    /// <summary>
    /// Main page: a button that is enabled only if a checkbox is checked. This is done
    /// using a command parameter in the XAML page.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>ViewModel attached to the page</summary>
        public MainPageViewModel ViewModel { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainPage()
        {
            ViewModel = new MainPageViewModel();

            this.InitializeComponent();
        }

        /// <summary>
        /// Navigate to page 2
        /// </summary>
        /// <param name="sender">The button that called the method</param>
        /// <param name="e"></param>
        private void GoToPage2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WithoutParams));
        }
    }
}
