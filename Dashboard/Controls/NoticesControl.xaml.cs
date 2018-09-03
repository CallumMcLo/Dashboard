using System.Windows;
using System.Windows.Controls;

namespace Dashboard
{
    public partial class NoticesControl : UserControl
    {
        public NoticesControl()
        {
            InitializeComponent();
            BrowserPanel.Visibility = Visibility.Collapsed; //Hide window until ready to be shown
            BrowserPanel.Navigate(Main.NoticesLink); //Navigate to notices
        }

        public void Login() //Needed so .HasMethod returns true for this class having a login function
        {
            BrowserPanel.Navigate(Main.NoticesLink); //Navigate to notices
        }

        public void Logout()
        {
            BrowserPanel.Navigate(Main.LogoutLink);         //Logout of browser
        }

        private void BrowserPanel_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            BrowserPanel.Visibility = Visibility.Visible; //Show panel when loaded.
        }
    }
}
