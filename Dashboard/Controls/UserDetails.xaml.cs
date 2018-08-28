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
            int numWeeks = ((int)(thisDay - originalDay).TotalDays) / (1000 * 60 * 60 * 24 * 7); //Get number of weeks between original day and current day

            DayLabel.Content = thisDay.DayOfWeek; //Say what day of the week it is
            WeekLabel.Content = (numWeeks == 0 || numWeeks % 2 == 0) ? "Week B" : "Week A"; //If even week, it's week B, if odd week it's week A
        }

        public void Login(User user)
        {
            SetDayOfWeek();
            UserID.Content = user.UserID.ToString(); //Set username to users id
        }

        public void Logout()
        {
            UserID.Content = "User"; //When logged out, don't display users id anymore.
        }
    }
}
