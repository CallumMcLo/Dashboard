using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        Window mainWindow = Application.Current.MainWindow;

        public LoginControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Do login validation here
        {
#if !DEBUG
            if (!int.TryParse(UserIDEntry.Text, out int userID) || UserIDEntry.Text.Length != 5)
            {
                MessageBox.Show("Invalid UserID / Password");
                return;
            }

            if (PasswordEntry.Password.Length != 8)
            {
                MessageBox.Show("Invalid UserID / Password");
                return;
            }
            User user = new User(userID, PasswordEntry.Password);
            Main.ShowLoggedInWindows(user);
#else
            Main.ShowLoggedInWindows(null);
#endif
            Main.SetControlVisibility(this, false);
        }
    }
}
