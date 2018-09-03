using ExtensionMethods;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) //Event fires when this control is loaded
        {
            UserIDEntry.Focus(); //Make it so user can type into user ID box immediately and not have to click on it.
        }

        private void SignIn_Click(object sender, RoutedEventArgs e) //Do login validation here
        {
#if !DEBUG //Allows skipping logging in if in DEBUG mode.
            if (!IsValid(UserIDEntry.Text, PasswordEntry.Password)) //Check if username/password passes requirements
            {
                ClearPassword();
                ShowLoginError();
                return;
            }

            if (!(int.TryParse(UserIDEntry.Text, out int userID)))
                return;

            User user = new User(userID, PasswordEntry.Password.ToSecureString()); //Make new User object
            Main.ShowLoggedInWindows(user); //Login with user object
#else
            Main.ShowLoggedInWindows(null);
#endif
            ClearInput(); //Clear entered username/password from window

#if !DEBUG
            EraseUser(user); //Erase user from memory
#endif
        }

        private bool IsValid(string username, string password) 
        {
            if (!int.TryParse(UserIDEntry.Text, out int userID) || UserIDEntry.Text.Length != 5) //UserID cannot be less than or greater than 5 chars
                return false;

            if (PasswordEntry.Password.Length != 8)     //User passwords can only be 8 chars
                return false;

            return true;
        }

        public void ShowLoginError()
        {
            MessageBox.Show("Invalid Username or Password");
        }

        public void ClearInput()
        {
            UserIDEntry.Text = "";
            ClearPassword();
        }

        private void ClearPassword()
        {
            PasswordEntry.Password = ""; //Clear from entry box
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e) //Keydown event fires whenever a key is pushed.
        {
            if (e.Key == Key.Enter)         //Allow user to hit enter to login
            {
                SignIn_Click(this, null);
            }
        }

        private void EraseUser(User user)
        {
            user = null;  //Allow Garbage Collector to overwrite user in memory
        }
    }
}
