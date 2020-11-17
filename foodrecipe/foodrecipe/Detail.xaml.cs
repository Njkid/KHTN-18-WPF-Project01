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

namespace foodrecipe
{
    /// <summary>
    /// Interaction logic for Detail.xaml
    /// </summary>
    public partial class Detail : Fluent.RibbonWindow
    {
        Recipe CurrentRecipe { get; set; }
        public Detail()
        {
            InitializeComponent();
        }

        public Detail(Recipe recipe)
        {
            InitializeComponent();
            CurrentRecipe = recipe;
            Title = CurrentRecipe.RecipeName;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}
