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
using System.IO;
using System.Diagnostics;

namespace foodrecipe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static string WorkingDerectory { set; get; }

        public PageManager pageManager;

        public MainWindow()
        {
            InitializeComponent();

            

            WorkingDerectory = System.IO.Directory.GetCurrentDirectory().Replace('\\','/') + "/";
            Debug.WriteLine(WorkingDerectory);

            SortFoodtByName sortFoodByName = new SortFoodtByName();


            previousPageButton.Content = "<";
            nextPageButton.Content = ">";
                       
            
            List<Food> foods = FoodDAO.GetAll();
            //Comparer and sort
            foods.Sort(sortFoodByName);

            pageManager = new PageManager(foods);


            foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            numPageTextBlock.Text = (pageManager.CurrentPage).ToString() + "/" + pageManager.MaxPage;


            DateTime dateTime = DateTime.Now;
            Debug.WriteLine(dateTime.ToString("dd/MM/yyyy"));


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

        private void previousPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageManager.CurrentPage > 1)
            {
                numPageTextBlock.Text = (--pageManager.CurrentPage).ToString() + "/" + pageManager.MaxPage;
                foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            }

        }

        private void nextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageManager.CurrentPage < pageManager.MaxPage )
            {
                numPageTextBlock.Text =(++pageManager.CurrentPage).ToString() + "/" + pageManager.MaxPage;
                foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            }

        }
    }

    public class PageManager
    {
        const int NumPerPage = 6;

        public PageManager()
        {
            MaxPage = 1;
            CurrentPage = 1;
        }

        public PageManager(List<Food> list)
        {
            CurrentPage = 1;
            ListFood = list;
            MaxPage = list.Count / NumPerPage + (list.Count % NumPerPage == 0 ? 0 : 1);

        }

        public List<Food> ListFood { get; set; }
        public int MaxPage { get; set; }
        public int CurrentPage { get; set; }

        public List<Food> GetDataCurrentPage()
        {
            var temp = ListFood.Skip((CurrentPage - 1) * NumPerPage).Take(NumPerPage).Cast<Food>();
            List<Food> currentItems = new List<Food>(temp);
            return currentItems;
        }

        public void UpdateMaxPage()
        {
            MaxPage = ListFood.Count / NumPerPage + (ListFood.Count % NumPerPage == 0 ? 0 : 1);
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

    public sealed class DirectoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return MainWindow.WorkingDerectory + (string)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((string)value).Substring(MainWindow.WorkingDerectory.Length, ((string)value).Length - MainWindow.WorkingDerectory.Length) ;
        }
    }

    public class Food
    {
        public int FoodID { get; set; }
        public string FoodImagePath { get; set; }
        public string FoodName { get; set; }
        public bool Liked { get; set; }
        public string Date { get; set; }

    }

    public class FoodDAO
    {
        public static List<Food> GetAll()
        {
            List<Food> result = new List<Food>();

            result.Add(new Food { FoodID = 0, Date = "01/11/2020", FoodImagePath = "imgs/suon-xao-chua-ngot.jpg", FoodName = "zBò kho", Liked=false  });
            result.Add(new Food { FoodID = 1, Date = "01/11/2020", FoodImagePath = "imgs/suon-xao-chua-ngot.jpg", FoodName = "gBò né", Liked = true  });
            result.Add(new Food { FoodID = 2, Date = "01/11/2020", FoodImagePath = "imgs/suon-xao-chua-ngot.jpg", FoodName = "cBò né", Liked = false });
            result.Add(new Food { FoodID = 3, Date = "01/11/2020", FoodImagePath = "imgs/suon-xao-chua-ngot.jpg", FoodName = "dBò kho", Liked = true });
            result.Add(new Food { FoodID = 4, Date = "01/11/2020", FoodImagePath = "imgs/suon-xao-chua-ngot.jpg", FoodName = "hBò né", Liked = false });
            result.Add(new Food { FoodID = 5, Date = "01/11/2020", FoodImagePath = "imgs/suon-xao-chua-ngot.jpg", FoodName = "nnBò né", Liked = false });
            result.Add(new Food { FoodID = 6, Date = "01/11/2020", FoodImagePath = "imgs/suon-xao-chua-ngot.jpg", FoodName = "dfBò kho", Liked = true });
            result.Add(new Food { FoodID = 7, Date = "01/11/2020", FoodImagePath = "imgs/suon-xao-chua-ngot.jpg", FoodName = "zxBò né", Liked = false });
            result.Add(new Food { FoodID = 8, Date = "01/11/2020", FoodImagePath = "imgs/suon-xao-chua-ngot.jpg", FoodName = "fxBò né", Liked = false });

            return result;
        }

    }

    public class SortFoodtByName :IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            return String.Compare(x.FoodName, y.FoodName);
        }
    }
}
