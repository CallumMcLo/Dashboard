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
    public partial class UserDetails : UserControl
    {
        public static UserDetails userDetails;
        public UserDetails()
        {
            InitializeComponent();
            userDetails = this;
        }

        public void SetDayOfWeek()
        {
            DateTime originalDay = new DateTime(2016, 1, 4);
            DateTime thisDay = DateTime.Now;
            int numWeeks = (int)((thisDay - originalDay).TotalDays / (1000 * 60 * 60 * 24 * 7));

            DayLabel.Content = thisDay.DayOfWeek;
            WeekLabel.Content = (numWeeks == 0 || numWeeks % 2 == 0) ? "Week B" : "Week A";
        }

        public void Login(User user)
        {
            SetDayOfWeek();
            UserID.Content = user.UserID.ToString();
        }
    }
}
