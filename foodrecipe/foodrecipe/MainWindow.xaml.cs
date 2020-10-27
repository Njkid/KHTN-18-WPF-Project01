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
            List<Food> foods = new List<Food>();
            foods.Add(new Food { FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò kho"});
            foods.Add(new Food { FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò né" });
            foods.Add(new Food { FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò né" });
            foods.Add(new Food { FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò kho" });
            foods.Add(new Food { FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò né" });
            foods.Add(new Food { FoodImagePath = "./imgs/suon-xao-chua-ngot.jpg", FoodName = "Bò né" });
            foodsListView.ItemsSource = foods;

        }

        
    }

    public class Food
    {
        public string FoodImagePath { get; set; }
        public string FoodName { get; set; }
    }
}
