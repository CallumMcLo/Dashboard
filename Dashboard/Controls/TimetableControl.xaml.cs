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

            var loginData = new System.Collections.Specialized.NameValueCollection      //Post request information, needed to login to website
            {
                { "username", user.UserID.ToString() },
                { "password", user.GetPassword().ToPlainString() }
            };

            client.UploadValues("index.php/login", "POST", loginData);              //Login to website

            string htmlSource = client.DownloadString("index.php/attendance");
            if (htmlSource.Contains("Denied")) //We can't login to KAMAR, therefore username/password must be wrong
            {
                Main.Logout(ErrorState.InvalidDetails); //Logout with invalid details error state
                return;
            }

            client.Dispose();
            loginData = null; //Purge WebClient and LoginData allowing Garbage Collector to get them out of memory.

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
