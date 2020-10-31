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

namespace foodrecipe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            previousPageButton.Content = "<";
            nextPageButton.Content = ">";

            List<Food> foods = FoodDAO.GetAll();

            foodsListView.ItemsSource = foods;

            
        }

        private void ButtonLike_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var bc = new BrushConverter();

            if (btn.Background.ToString().ToLower().Equals("#ff9f9f9f"))
            {
                btn.Background = (Brush)bc.ConvertFrom("#2a7aa1");
            }
            else
            {
                btn.Background = (Brush)bc.ConvertFrom("#9f9f9f");
            }
        }
    }

    public sealed class BtnColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return "#2a7aa1";
            }
            return "#9f9f9f";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString().ToLower().Equals("#2a7aa1") || value.ToString().ToLower().Equals("#ff2a7aa1"))
            {
                return true;
            }

            return false;
        }
    }

    public class Food
    {
        public int FoodID { get; set; }
        public string FoodImagePath { get; set; }
        public string FoodName { get; set; }
        public bool Liked { get; set; }
    }

    public class FoodDAO
    {
        public static List<Food> GetAll()
        {
            List<Food> result = new List<Food>();

            result.Add(new Food { FoodID = 0, FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò kho", Liked=false});
            result.Add(new Food { FoodID = 1, FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò né", Liked = true });
            result.Add(new Food { FoodID = 2, FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò né", Liked = false });
            result.Add(new Food { FoodID = 3, FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò kho", Liked = true });
            result.Add(new Food { FoodID = 4, FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò né", Liked = false });
            result.Add(new Food { FoodID = 5, FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò né", Liked = false });

            return result;
        }
    }
}
