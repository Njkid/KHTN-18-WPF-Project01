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

    public partial class MainWindow : Fluent.RibbonWindow
    {
        public static string WorkingDerectory { set; get; }

        public PageManager pageManager;
        public List<Recipe> foods;
        public List<Recipe> subListRecipes;

        // Init sort type for list
        public SortAZRecipeByName sortAZRecipeByName = new SortAZRecipeByName();
        public SortZARecipeByName sortZARecipeByName = new SortZARecipeByName();
        public SortAZRecipeByDate sortAZRecipeByDate = new SortAZRecipeByDate();
        public SortZARecipeByDate sortZARecipeByDate = new SortZARecipeByDate();

        public MainWindow()
        {
            // Main List            
            foods = RecipeDAO.GetAll();

            // Sub List
            subListRecipes = new List<Recipe>(foods);
            subListRecipes.Sort(sortAZRecipeByName);

            // Page Manager
            pageManager = new PageManager(subListRecipes);


            InitializeComponent();
            

            WorkingDerectory = System.IO.Directory.GetCurrentDirectory().Replace('\\','/') + "/";
            Debug.WriteLine(WorkingDerectory);
                                    
            previousPageButton.Content = "<";
            nextPageButton.Content = ">";            

            foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            numPageTextBlock.Text = (pageManager.CurrentPage).ToString() + "/" + pageManager.MaxPage;


            DateTime dateTime = DateTime.Now;
            Debug.WriteLine(dateTime.ToString("dd/MM/yyyy"));

        }

        #region Button
            private void buttonLike_Click(object sender, RoutedEventArgs e)
            {
                var btn = sender as Button;
                var bc = new BrushConverter();

                // Change color when click
                if (btn.Foreground.ToString().ToLower().Equals("#ff9f9f9f"))
                {
                    btn.Foreground = (Brush)bc.ConvertFrom("#ff0000");
                }
                else
                {
                    btn.Foreground = (Brush)bc.ConvertFrom("#9f9f9f");
                }

                // debug binding data
                foreach (var item in subListRecipes)
                {
                    Debug.WriteLine(item.Liked);
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

            private void searchButton_Click(object sender, RoutedEventArgs e)
            {
                string key = searchTextBox.Text.ToLower();

                pageManager.UpdateListRecipe(subListRecipes.Where(item => item.RecipeName.ToLower().IndexOf(key) >= 0).ToList());
                numPageTextBlock.Text = (pageManager.CurrentPage).ToString() + "/" + pageManager.MaxPage;
                foodsListView.ItemsSource = pageManager.GetDataCurrentPage();

            }

        #endregion
         
        #region Sort and Filter
            private void sortAZNameSelection_Selected(object sender, RoutedEventArgs e)
            {
                pageManager.ListRecipe.Sort(sortAZRecipeByName);
                if (foodsListView != null) 
                    foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            }

            private void sortZANameSelection_Selected(object sender, RoutedEventArgs e)
            {
                pageManager.ListRecipe.Sort(sortZARecipeByName);
                if (foodsListView != null)
                    foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            }

            private void sortAZDateSelection_Selected(object sender, RoutedEventArgs e)
            {
                pageManager.ListRecipe.Sort(sortAZRecipeByDate);
                if (foodsListView != null)
                    foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            }

            private void sortZADateSelection_Selected(object sender, RoutedEventArgs e)
            {
                pageManager.ListRecipe.Sort(sortZARecipeByDate);
                if (foodsListView != null)
                    foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            }

            private void favoriteFilter_Checked(object sender, RoutedEventArgs e)
            {
                pageManager.UpdateListRecipe(subListRecipes.Where(item => item.Liked == true).ToList());
                numPageTextBlock.Text = (pageManager.CurrentPage).ToString() + "/" + pageManager.MaxPage;
                foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            }

            private void favoriteFilter_Unchecked(object sender, RoutedEventArgs e)
            {
                pageManager.UpdateListRecipe(subListRecipes);
                numPageTextBlock.Text = (pageManager.CurrentPage).ToString() + "/" + pageManager.MaxPage;
                foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            }

        #endregion

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                Window detail = new Detail();
                detail.Show();
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

        public PageManager(List<Recipe> list)
        {
            CurrentPage = 1;
            ListRecipe = list;
            MaxPage = list.Count / NumPerPage + (list.Count % NumPerPage == 0 ? 0 : 1);

        }

        public List<Recipe> ListRecipe { get; set; }
        public int MaxPage { get; set; }
        public int CurrentPage { get; set; }

        public List<Recipe> GetDataCurrentPage()
        {
            var temp = ListRecipe.Skip((CurrentPage - 1) * NumPerPage).Take(NumPerPage).Cast<Recipe>();
            List<Recipe> currentItems = new List<Recipe>(temp);
            return currentItems;
        }

        public void UpdateMaxPage()
        {
            MaxPage = ListRecipe.Count / NumPerPage + (ListRecipe.Count % NumPerPage == 0 ? 0 : 1);
        }

        public void UpdateListRecipe( List<Recipe> foods)
        {
            CurrentPage = 1;
            ListRecipe = foods;
            UpdateMaxPage();
        }
        
        
    }

    public sealed class BtnColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return "#ff0000";
            }
            return "#9f9f9f";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString().ToLower().Equals("#ff0000") || value.ToString().ToLower().Equals("#ffff0000"))
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

    public class Recipe
    {
        public int RecipeID { get; set; }
        public string RecipeImagePath { get; set; }
        public string RecipeName { get; set; }
        public bool Liked { get; set; }
        public string Date { get; set; }
        public Step[] steps { get; set; }

    }

    public class Step
    {
        public string Text { get; set; }
        public string Img { get; set; }
    }

    public class RecipeDAO
    {
        public static List<Recipe> GetAll()
        {
            List<Recipe> result = new List<Recipe>();

            // demo data
            result.Add(new Recipe { RecipeID = 0, Date = "01/11/2020", RecipeImagePath = "imgs/suon-xao-chua-ngot.jpg", RecipeName = "zBò kho", Liked=false  });
            result.Add(new Recipe { RecipeID = 1, Date = "01/11/2020", RecipeImagePath = "imgs/suon-xao-chua-ngot.jpg", RecipeName = "gBò né", Liked = true  });
            result.Add(new Recipe { RecipeID = 2, Date = "01/11/2020", RecipeImagePath = "imgs/suon-xao-chua-ngot.jpg", RecipeName = "cBò né", Liked = false });
            result.Add(new Recipe { RecipeID = 3, Date = "01/11/2020", RecipeImagePath = "imgs/suon-xao-chua-ngot.jpg", RecipeName = "dBò kho", Liked = true });
            result.Add(new Recipe { RecipeID = 4, Date = "01/11/2020", RecipeImagePath = "imgs/suon-xao-chua-ngot.jpg", RecipeName = "hBò né", Liked = false });
            result.Add(new Recipe { RecipeID = 5, Date = "01/11/2020", RecipeImagePath = "imgs/suon-xao-chua-ngot.jpg", RecipeName = "nnBò né", Liked = false });
            result.Add(new Recipe { RecipeID = 6, Date = "01/11/2020", RecipeImagePath = "imgs/suon-xao-chua-ngot.jpg", RecipeName = "dfBò kho", Liked = true });
            result.Add(new Recipe { RecipeID = 7, Date = "01/11/2020", RecipeImagePath = "imgs/suon-xao-chua-ngot.jpg", RecipeName = "zxBò né", Liked = false });
            result.Add(new Recipe { RecipeID = 8, Date = "01/11/2020", RecipeImagePath = "imgs/suon-xao-chua-ngot.jpg", RecipeName = "fxBò né", Liked = false });

            return result;
        }

    }

    #region Type Sort Class
    public class SortAZRecipeByName :IComparer<Recipe>
    {
        public int Compare(Recipe x, Recipe y)
        {
            return String.Compare(x.RecipeName, y.RecipeName);
        }
    }

    public class SortZARecipeByName : IComparer<Recipe>
    {
        public int Compare(Recipe x, Recipe y)
        {
            return -String.Compare(x.RecipeName, y.RecipeName);
        }
    }
    public class SortZARecipeByDate : IComparer<Recipe>
    {
        public int Compare(Recipe x, Recipe y)
        {
            return -String.Compare(x.Date, y.Date);
        }
    }
    public class SortAZRecipeByDate : IComparer<Recipe>
    {
        public int Compare(Recipe x, Recipe y)
        {
            return String.Compare(x.Date, y.Date);
        }
    }

    #endregion
}
