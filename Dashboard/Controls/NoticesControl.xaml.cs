using System.Windows;
using System.Windows.Controls;

namespace Dashboard
{
    public partial class NoticesControl : UserControl
    {
        private int counter = 0;

        public NoticesControl()
        {
            InitializeComponent();
            BrowserPanel.Visibility = Visibility.Collapsed;
        }

        public void Login()
        {
            GetNotices();
        }

        private void GetNotices()
        {
            BrowserPanel.Navigate(Main.NoticesLink);
        }

        private void BrowserPanel_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (!(e.Uri.ToString() == Main.NoticesLink) && counter <= Main.MAX_NETWORK_ATTEMPTS)
            {
                BrowserPanel.Navigate(Main.NoticesLink);
                counter++;
            }

            if (counter == Main.MAX_NETWORK_ATTEMPTS)
            {
                MessageBox.Show("Error retrieving notices after " + Main.MAX_NETWORK_ATTEMPTS + " attempts.");
                return;
            }

            BrowserPanel.Visibility = Visibility.Visible;
            counter = 0;
        }
    }
}
