using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Dashboard
{
    //This is the main class that will connect all the other classes together
    public enum ErrorState { OK, InvalidDetails, Unknown };

    public partial class Main : Window
    {
        private static Dictionary<string, UserControl> UserControls = new Dictionary<string, UserControl>();
        public static string BaseDirectory { get; private set; } = AppDomain.CurrentDomain.BaseDirectory; //Gets base directory that the program is in
        public static string BaseLink = @"https://kamar-portal.burnside.school.nz/";
        public static string NoticesLink = @"https://kamar-portal.burnside.school.nz/index.php/notices"; //@ means string literal, means \ or " doesn't escape the string.
        public static string LogoutLink = @"https://kamar-portal.burnside.school.nz/index.php/logout";
        public static string TimetableLink = @"https://kamar-portal.burnside.school.nz/index.php/attendance";

        private static List<UserControl> LoginControls = new List<UserControl>();
        private static List<UserControl> LogoutControls = new List<UserControl>();

        public Main()
        {
            InitializeComponent();
            
            //Inserting all the UserControls into the private dictionary on startup so they can be used.
            UserControls["LoginControl"] = _LoginControl;
            UserControls["NavigationControl"] = _NavigationControl;
            UserControls["UserDetailsControl"] = _UserDetailsControl;
            UserControls["NoticesControl"] = _NoticesControl;
            UserControls["TimetableControl"] = _TimetableControl;

            LoginControls = GetSpecificControls(UserControls.Values.ToList(), "Login"); //Get all controls that have a .Login function
            LogoutControls = GetSpecificControls(UserControls.Values.ToList(), "Logout"); //Get all controls that have a .Logout function

            HideAll();

            SetControlVisibility(GetControl("LoginControl"), true);
        }

        public static void SetControlVisibility(UserControl control, bool isVisible)
        {
            control.Visibility = (isVisible) ? Visibility.Visible : Visibility.Collapsed; //Ternary Operation, if bool is true, first case (Visibility.Visible) will occur, if false second will occur.
        }

        public static void HideAll()
        {
            foreach (UserControl control in UserControls.Values) //Get all controls in UserControls dictionary.
            {
                SetControlVisibility(control, false);
            }
        }

        public static UserControl GetControl(string key) //Get control from UserControls dictionary.
        {
            if (UserControls.ContainsKey(key))
                return UserControls[key]; //Extract Control from private Dictionary, keeps encapsulation
            else
                throw new Exception("Specified key was not found in dictionary. UserControl not adding or key invalid");
        }

        public static void ShowLoggedInWindows(User user) //These windows are the windows to show when logged in
        {
            SetControlVisibility(GetControl("LoginControl"), false); //User is logged in, don't need to show them the login window anymore

            foreach (UserControl control in LoginControls) //Set every control with a Login() method to visible
                SetControlVisibility(control, true);

#if !DEBUG  //Allows login to the program without a username/password for debug purposes.
            ((NoticesControl)GetControl("NoticesControl")).Login();
            ((UserDetails)GetControl("UserDetailsControl")).Login(user);
            ((TimetableControl)GetControl("TimetableControl")).Login(user);
#endif
        }

        public static void Logout(ErrorState errorState = ErrorState.OK) //Logout function, everything that needs to be done when logging out will be in here, errorstate defaults to OK if no params passed
        {
            ((NoticesControl)GetControl("NoticesControl")).Logout();
            ((UserDetails)GetControl("UserDetailsControl")).Logout();
            ((TimetableControl)GetControl("TimetableControl")).Logout();

            HideAll();
            SetControlVisibility(GetControl("LoginControl"), true);

            if (errorState == ErrorState.InvalidDetails) //If logout reason is due to invalid details
                ((LoginControl)GetControl("LoginControl")).ShowLoginError();
            if (errorState == ErrorState.Unknown) //If logout is due to unknown error
                MessageBox.Show("Unknown Error occured, please try again.");
        }

        private List<UserControl> GetSpecificControls(List<UserControl> controlsToCheck, string function)
        {
            List<UserControl> _controlsList = new List<UserControl>();
            foreach (UserControl control in controlsToCheck)
            {
                if (control.HasMethod(function)) //Check if control has a function name, eg Logout(), Login()
                {
                    _controlsList.Add(control); //Add it to the temporary list to be returned.
                }
            }
            return _controlsList;
        }
    }
}
