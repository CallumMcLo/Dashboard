using System;
using System.Windows.Controls;

namespace Dashboard
{
    public partial class UserDetails : UserControl
    {
        public UserDetails()
        {
            InitializeComponent();
        }

        public void SetDayOfWeek()
        {
            DateTime originalDay = new DateTime(2016, 1, 4);
            DateTime thisDay = DateTime.Now;
            int numWeeks = ((int)(thisDay - originalDay).TotalDays) / (1000 * 60 * 60 * 24 * 7);

            DayLabel.Content = thisDay.DayOfWeek;
            WeekLabel.Content = (numWeeks == 0 || numWeeks % 2 == 0) ? "Week B" : "Week A";
        }

        public void Login(User user)
        {
            SetDayOfWeek();
            UserID.Content = user.UserID.ToString();
        }

        public void Logout()
        {
            UserID.Content = "User";
        }
    }
}
