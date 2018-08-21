using System.Net;
using System.Windows;
using System.Windows.Controls;
using HtmlAgilityPack;
using mshtml;

namespace Dashboard
{
    public partial class NoticesControl : UserControl
    {
        public NoticesControl()
        {
            InitializeComponent();
            //BrowserPanel.Visibility = Visibility.Collapsed;
        }

        public void LoggedIn()
        {
            GetNotices();
        }

        private void GetNotices()
        {
            BrowserPanel.Navigate(Main.NoticesLink);
        }

        private void BrowserPanel_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //dynamic document = BrowserPanel.Document;
            //string notices = document.documentElement.InnerHtml;
            //BrowserPanel.NavigateToString(notices);
            //HTMLDocument document = BrowserPanel.Document as mshtml.HTMLDocument;
            //document.getElementById("//div[@class='container']").outerHTML = "";
            //document.body.innerHTML = document.getElementById("wrapper").outerHTML;
            //BrowserPanel.Visibility = Visibility.Visible;
            BrowserPanel.Focus();
        }
    }
}
