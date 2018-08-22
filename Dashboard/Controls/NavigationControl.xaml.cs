using System.Windows;
using System.Windows.Controls;

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for NavigationControl.xaml
    /// </summary>
    public partial class NavigationControl : UserControl
    {
        public NavigationControl()
        {
            InitializeComponent();
        }

        public void Login() //Needed so program can see that this is a control to show on login
        {

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Logout();  //Logout
        }
    }
}
