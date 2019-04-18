using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SleepTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Init();
        }

        public void Init()
        {
            IntoSleep_tbx.Text = "5";
            AsleepTime_tbx.Text = "00:00";
            AwakeTime_tbx.Text = "06:00";
        }

        private void AwakeTime_btn_Click(object sender, RoutedEventArgs e)
        {
            DateTime asleepTime = DateTime.ParseExact(AsleepTime_tbx.Text, "HH:mm", null);
            DateTime awakeTime = asleepTime.AddMinutes(194 + Convert.ToInt32(IntoSleep_tbx.Text));
            DateTime t1 = awakeTime, t2 = awakeTime;

            Notification1.Text = "\nYou can wake up at:";
            for (int i = 1; i < 5; i++) // 3 -> 6
            {                
                Notification1.Text += "\n   " + t1.AddMinutes(90 * i).TimeOfDay;
            }

            Notification2.Text = "\nYou should wake up at:"
                + "\n   " + t2.AddMinutes(90 * 2).TimeOfDay
                + "\n   " + t2.AddMinutes(90 * 3).TimeOfDay;
        }

        private void AsleepTime_btn_Click(object sender, RoutedEventArgs e)
        {
            DateTime awakeTime = DateTime.ParseExact(AwakeTime_tbx.Text, "HH:mm", null);
            DateTime asleepTime = awakeTime.AddMinutes(-194 - Convert.ToInt32(IntoSleep_tbx.Text));
            DateTime t1 = asleepTime, t2 = asleepTime;

            Notification1.Text = "\nYou can go to bed at:";
            for (int i = 1; i < 5; i++)
            {
                Notification1.Text += "\n   " + t1.AddMinutes(-90 * i).TimeOfDay;
            }

            Notification2.Text = "\nYou should go to bed at:"
                + "\n   " + t2.AddMinutes(-90 * 2).TimeOfDay
                + "\n   " + t2.AddMinutes(-90 * 3).TimeOfDay;
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mBR = MessageBox.Show("Do you really want to exit?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (mBR == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
