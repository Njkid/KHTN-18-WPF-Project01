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

        public static PageManager pageManager;
        public static List<Recipe> foods;
        public static List<Recipe> subListRecipes;

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

            if (AppConfig.appconfig.Favorite) favoriteFilter.IsChecked = true;
            if (AppConfig.appconfig.Name)
            {
                if (AppConfig.appconfig.Asc) filterComboBox.SelectedIndex = 0;
                else filterComboBox.SelectedIndex = 1;
            }
            else
            {
                if (AppConfig.appconfig.Asc) filterComboBox.SelectedIndex = 2;
                else filterComboBox.SelectedIndex = 3;
            }


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
                Debug.WriteLine(btn.Tag.ToString());
                RecipeDAO.Update((Recipe)(subListRecipes.Where(
                    item => item.RecipeFile.Equals(btn.Tag.ToString())).ToList())[0]
                    );       
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
                AppConfig.appconfig.Name = true;
                AppConfig.appconfig.Asc = true;
                AppConfig.Update();
            }

            private void sortZANameSelection_Selected(object sender, RoutedEventArgs e)
            {
                pageManager.ListRecipe.Sort(sortZARecipeByName);
                if (foodsListView != null)
                    foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
                AppConfig.appconfig.Name = true;
                AppConfig.appconfig.Asc = false;
                AppConfig.Update();
            }
   
            private void sortAZDateSelection_Selected(object sender, RoutedEventArgs e)
            {
                pageManager.ListRecipe.Sort(sortAZRecipeByDate);
                if (foodsListView != null)
                    foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
                AppConfig.appconfig.Name = false;
                AppConfig.appconfig.Asc = true;
                AppConfig.Update();
            }

            private void sortZADateSelection_Selected(object sender, RoutedEventArgs e)
            {
                pageManager.ListRecipe.Sort(sortZARecipeByDate);
                if (foodsListView != null)
                    foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
                AppConfig.appconfig.Name = false;
                AppConfig.appconfig.Asc = false;
                AppConfig.Update();
            }

            private void favoriteFilter_Checked(object sender, RoutedEventArgs e)
            {
                pageManager.UpdateListRecipe(subListRecipes.Where(item => item.Liked == true).ToList());
                numPageTextBlock.Text = (pageManager.CurrentPage).ToString() + "/" + pageManager.MaxPage;
                foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
                AppConfig.appconfig.Favorite = true;
                AppConfig.Update();
            }

            private void favoriteFilter_Unchecked(object sender, RoutedEventArgs e)
            {
                pageManager.UpdateListRecipe(subListRecipes);
                numPageTextBlock.Text = (pageManager.CurrentPage).ToString() + "/" + pageManager.MaxPage;
                foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
                AppConfig.appconfig.Favorite = false;
                AppConfig.Update();

            }

        #endregion

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                int index = foodsListView.SelectedIndex;
                Window detail = new Detail(pageManager.ListRecipe[index + (pageManager.CurrentPage-1) * PageManager.NumPerPage]);
                detail.Show();
            }
        }

        private void BackstageTabItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void createRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var createRP = new AddRP();
            createRP.ShowDialog();
            foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            foodsListView.Items.Refresh();
        }

        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string key = searchTextBox.Text.ToLower();

                pageManager.UpdateListRecipe(subListRecipes.Where(item => item.RecipeName.ToLower().IndexOf(key) >= 0).ToList());
                numPageTextBlock.Text = (pageManager.CurrentPage).ToString() + "/" + pageManager.MaxPage;
                foodsListView.ItemsSource = pageManager.GetDataCurrentPage();
            }
        }
    }

    public class PageManager
    {
        public const int NumPerPage = 6;

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
        public string RecipeFile { get; set; }
        public string RecipeImagePath { get; set; }
        public string RecipeName { get; set; }
        public bool Liked { get; set; }
        public string Date { get; set; }
        public List<Step> steps { get; set; }

        public Recipe()
        {
            steps = new List<Step>();
            Date = "";
            Liked = false;
            RecipeImagePath = "imgs/null.jpg";
            RecipeFile = "new";
            RecipeName = "";
        }

    }

    public class Step
    {
        public string NameStep { get; set; }
        public string Text { get; set; }
        public string Img { get; set; }

        public Step()
        {
            Img = "imgs/null.jpg";
            Text = "Điền thông tin mỗi bước";
            NameStep = "Điền tên bước";
        }
    }

    public class RecipeDAO
    {
        public static int numInitRP;

        public static List<string> idfileRP = new List<string>();

        public static void Update(Recipe value)
        {
            DateTime dateTime = DateTime.Now;
            Debug.WriteLine(dateTime.ToString("dd/MM/yyyy"));

            // if new, change path and update list in data.txt
            if (value.RecipeFile.Equals("new"))
            {
                value.RecipeFile = "rp" + numInitRP + ".rp";
                idfileRP.Add(value.RecipeFile);                

                numInitRP++;

                var updateDatafile = new StreamWriter(MainWindow.WorkingDerectory + "data/data.txt");

                updateDatafile.WriteLine(numInitRP);

                foreach (var line in idfileRP)
                {
                    updateDatafile.WriteLine(line);
                }

                updateDatafile.Close();
            }

            // write down data
            var writer = new StreamWriter(MainWindow.WorkingDerectory + "data/" + value.RecipeFile);

            writer.WriteLine(value.RecipeName);

            writer.WriteLine(dateTime.ToString("dd/MM/yyyy"));

            Debug.WriteLine("Changed " + value.RecipeFile + " " + value.Liked);
            if (value.Liked) writer.WriteLine("<liked>");
            else writer.WriteLine("<!liked>");

            foreach (var step in value.steps)
            {
                if (!step.NameStep.Equals("Điền tên bước"))
                {
                    writer.WriteLine("<img>");
                    writer.WriteLine(step.Img);
                    writer.WriteLine("<step>");
                    writer.WriteLine(step.NameStep);
                    writer.WriteLine(step.Text);
                    writer.WriteLine("</step>");
                }
                else
                {
                    break;
                }
            }
            
            writer.Close();

            

            MainWindow.foods = GetAll();
            MainWindow.subListRecipes = new List<Recipe>(MainWindow.foods);
            MainWindow.pageManager.UpdateListRecipe(MainWindow.subListRecipes);             
        }

        public static List<Recipe> GetAll()
        {
            List<Recipe> result = new List<Recipe>();
            var dataReader = new StreamReader(MainWindow.WorkingDerectory + "data/data.txt");
            var strnumInit = dataReader.ReadLine();
            idfileRP.Clear();

            numInitRP = Int32.Parse(strnumInit);

            while (!dataReader.EndOfStream)
            {
                var fileRP = dataReader.ReadLine();
                idfileRP.Add(fileRP);
                var rpReader = new StreamReader(MainWindow.WorkingDerectory + "data/" + fileRP);                 

                var newRP = new Recipe();
                newRP.RecipeFile = fileRP;
                newRP.RecipeName = rpReader.ReadLine();
                newRP.Date = rpReader.ReadLine();
                var lineLike = rpReader.ReadLine(); // is liked?
                newRP.Liked = (lineLike.Equals("<liked>")) ? true : false;


                while (!rpReader.EndOfStream)
                {
                    var newStep = new Step();
                    var line = rpReader.ReadLine(); // read <img>
                    newStep.Img = rpReader.ReadLine(); // read link img
                    if (newStep.Img.Equals("-")) // if there are no img
                    {
                        newStep.Img = newRP.steps[newRP.steps.Count - 1].Img;
                        if (newStep.Img.Equals("-")) {
                            newStep.Img = "imgs/null.jpg";
                        }
                    }
                    line = rpReader.ReadLine(); // read <step>
                    newStep.NameStep = rpReader.ReadLine(); // read name Step

                    line = rpReader.ReadLine();
                    newStep.Text = "";

                    while (!line.Equals("</step>"))
                    {
                        
                        newStep.Text += "\n";
                        newStep.Text += line;
                        line = rpReader.ReadLine();
                    }

                    newRP.steps.Add(newStep);
                    
                }

                newRP.RecipeImagePath = newRP.steps[0].Img;

                rpReader.Close();

                result.Add(newRP);

            }

            dataReader.Close();
          
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
