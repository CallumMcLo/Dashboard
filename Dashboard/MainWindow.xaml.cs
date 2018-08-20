using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Dashboard
{
    public partial class Main : Window
    {
        private static Dictionary<string, UserControl> UserControls = new Dictionary<string, UserControl>();
        public static string BaseDirectory { get; private set; } = AppDomain.CurrentDomain.BaseDirectory;
        public static string NoticesLink = @"https://kamar-portal.burnside.school.nz/index.php/notices";

        public Main()
        {
            InitializeComponent();

            UserControls["LoginControl"] = _LoginControl;
            UserControls["NavigationControl"] = _NavigationControl;
            UserControls["UserDetailsControl"] = _UserDetailsControl;
            UserControls["NoticesControl"] = _NoticesControl;
            UserControls["TimetableControl"] = _TimetableControl;

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
                return UserControls[key];
            else
                throw new Exception("Specified key was not found in dictionary. UserControl not adding or key invalid");
        }

        public static void ShowLoggedInWindows(User user)
        {
            SetControlVisibility(GetControl("NavigationControl"), true);
            SetControlVisibility(GetControl("UserDetailsControl"), true);
            SetControlVisibility(GetControl("NoticesControl"), true);
            SetControlVisibility(GetControl("TimetableControl"), true);

#if !DEBUG
            NoticesControl.noticesControl.LoggedIn();
            UserDetails.userDetails.Login(user);
#endif
        }

        public static void Logout()
        {
            HideAll();
        }
    }
}
