using ExtensionMethods;
using System.Windows;
using System.Windows.Controls;

namespace Dashboard
{
    public partial class NoticesControl : UserControl
    {
        public NoticesControl()
        {
            InitializeComponent();
            BrowserPanel.Visibility = Visibility.Collapsed;
        }

        public void Login(User user)
        {
            var client = new CookieAwareWebClient(); //WebClient allowing cookies to be stored in it.
            client.BaseAddress = Main.BaseLink;

            var loginData = new System.Collections.Specialized.NameValueCollection      //Post request information
            {
                { "username", user.UserID.ToString() },
                { "password", user.GetPassword().ToPlainString() }
            };

            client.UploadValues("index.php/login", "POST", loginData);              //Login to website

            string htmlSource = client.DownloadString("index.php/notices");
            ShowNotices(htmlSource); //Display HTML from Kamar

            client.Dispose();
            loginData = null; //Purge WebClient and LoginData as to allow them to be overwritten in memory, minimizing allowance for them to be read.
        }

        private void ShowNotices(string html)
        {
            BrowserPanel.NavigateToString(html);        //Load HTML into browser from string.
        }

        public void Logout()
        {
            BrowserPanel.Navigate(Main.LogoutLink);         //Logout of browser
        }

        private void BrowserPanel_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            BrowserPanel.Visibility = Visibility.Visible;
        }
    }
}
