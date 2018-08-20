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
    /// Interaction logic for TimetableControl.xaml
    /// </summary>
    public partial class TimetableControl : UserControl
    {
        public static TimetableControl timetableControl;
        public TimetableControl()
        {
            InitializeComponent();
            timetableControl = this;
        }

        private void KamarLogin(User user)
        {

        }

        public void ShowTimetable(User user)
        {

        }
    }
}
