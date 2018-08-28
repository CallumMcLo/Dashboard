using ExtensionMethods;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for TimetableControl.xaml
    /// </summary>
    public partial class TimetableControl : UserControl
    {
        public TimetableControl()
        {
            InitializeComponent();
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

            string htmlSource = client.DownloadString("index.php/attendance");

            client.Dispose();
            loginData = null; //Purge WebClient and LoginData as to not store them in memory, allowing them to be read.

            ShowTimetable(htmlSource);              //Display HTML from Kamar
        }

        private void ShowTimetable(string html)
        {
            BrowserPanel.NavigateToString(html);        //Load HTML into browser from string.
        }

        public void Logout()
        {
            BrowserPanel.Navigate(Main.LogoutLink);         //Logout of browser
        }

        private void BrowserPanel_Navigated(object sender, NavigationEventArgs e) //When Browser finishes navigating this event fires
        {
            BrowserPanel.Visibility = Visibility.Visible; 
        }
    }
}
