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
using System.Windows.Shapes;
using System.Timers;
using System.IO;
using System.Diagnostics;

namespace foodrecipe
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        Timer timer;
        public SplashScreen()
        {
            InitializeComponent();
            timer = new Timer(1000);
            timer.Elapsed += ToMainWindows;

            string WorkingDerectory = System.IO.Directory.GetCurrentDirectory().Replace('\\', '/') + "/";

            imgSplash.ImageSource = new BitmapImage( new Uri(WorkingDerectory + "imgs/suon-xao-chua-ngot.jpg"));
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void ToMainWindows(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() => {
                timer.Stop();
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }));
            
        }
    }
}
