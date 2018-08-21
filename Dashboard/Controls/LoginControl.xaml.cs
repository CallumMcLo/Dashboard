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
            if (!isValid(UserIDEntry.Text, PasswordEntry.Password))
            {
                MessageBox.Show("Invalid Username or Password");
                ClearPassword();
                return;
            }

            if (!(int.TryParse(UserIDEntry.Text, out int userID)))
                return;

            User user = new User(userID, PasswordEntry.Password);
            Main.ShowLoggedInWindows(user);
#else
            Main.ShowLoggedInWindows(null);
#endif
            ClearInput();
            Main.SetControlVisibility(this, false);
        }

        private bool isValid(string username, string password)
        {
            if (!int.TryParse(UserIDEntry.Text, out int userID) || UserIDEntry.Text.Length != 5) //UserID cannot be 
                return false;

            if (PasswordEntry.Password.Length != 8)
                return false;

            return true;
        }

        public void ClearInput()
        {
            UserIDEntry.Text = "";
            ClearPassword();
        }

        private void ClearPassword()
        {
            PasswordEntry.Password = "";
        }
    }
}
