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
            AppConfig.Init();

           

            if (AppConfig.appconfig.Splash)
            {
                timer = new Timer(4000);
            }
            else
            {
                timer = new Timer(1);
            }
            
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

                if (offSplashCheckBox.IsChecked == true)
                {
                    AppConfig.appconfig.Splash = false;
                    AppConfig.Update();
                }

                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }));
            
        }
    }

    public partial class AppConfig
    {
        public static AppConfig appconfig;
        public bool Splash { get; set; }
        public bool Favorite { get; set; }
        public bool Name { get; set; }
        public bool Asc { get; set; }

        public static void GetConfig()
        {
            var reader = new StreamReader(MainWindow.WorkingDerectory + "data/config.txt");

            

            var line = reader.ReadLine(); // read splash
            line = reader.ReadLine(); // on/off
            appconfig.Splash = line.Equals("on");
            line = reader.ReadLine(); // read favorite
            line = reader.ReadLine(); // on/off
            appconfig.Favorite = line.Equals("on");
            line = reader.ReadLine(); // read sort
            line = reader.ReadLine(); // name/day
            appconfig.Name = line.Equals("name");
            line = reader.ReadLine(); // asc/dec
            appconfig.Asc = line.Equals("asc");

            reader.Close();

        }
        public static void Init ()
        {
            if (appconfig == null) appconfig = new AppConfig();
            GetConfig();
        }

        public static void Update()
        {
            var writer = new StreamWriter(MainWindow.WorkingDerectory + "data/config.txt");

            writer.WriteLine("splash");
            if (appconfig.Splash) writer.WriteLine("on");
            else writer.WriteLine("off");

            writer.WriteLine("favorite");
            if (appconfig.Favorite) writer.WriteLine("on");
            else writer.WriteLine("off");

            writer.WriteLine("sort");
            if (appconfig.Name) writer.WriteLine("name");
            else writer.WriteLine("day");
            if (appconfig.Asc) writer.WriteLine("asc");
            else writer.WriteLine("dec");

            writer.Close();

        }

    }
}
