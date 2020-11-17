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
using System.IO;
using System.Diagnostics;

namespace foodrecipe
{
    /// <summary>
    /// Interaction logic for Detail.xaml
    /// </summary>
    public partial class Detail : Fluent.RibbonWindow
    {
        Recipe CurrentRecipe { get; set; }
        public int currentStep { get; set; }
        public int maxStep {get;set;}

        public Detail()
        {
            InitializeComponent();
        }

        public Detail(Recipe recipe)
        {
            InitializeComponent();
            CurrentRecipe = recipe;
            Title = CurrentRecipe.RecipeName;
            currentStepImage.Source = new BitmapImage(new Uri(MainWindow.WorkingDerectory + CurrentRecipe.RecipeImagePath));
            stepsListView.ItemsSource = recipe.steps;
            currentStep = 0;
            maxStep = recipe.steps.Count - 1;
 
            stepsListView.SelectedIndex = currentStep;

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void preStepButton_Click(object sender, RoutedEventArgs e)
        {
            currentStep = stepsListView.SelectedIndex;
            if (currentStep > 0) currentStep--;
            stepsListView.SelectedIndex = currentStep;
            stepsListView.ScrollIntoView(stepsListView.Items[currentStep]);
            stepCurrentText.Text = "" + (currentStep + 1) + "/" + (maxStep + 1);

        }

        private void nextStepButton_Click(object sender, RoutedEventArgs e)
        {
            currentStep = stepsListView.SelectedIndex;
            if (currentStep < maxStep) currentStep++;
            stepsListView.SelectedIndex = currentStep;
            stepsListView.ScrollIntoView(stepsListView.Items[currentStep]);
            stepCurrentText.Text = "" + (currentStep + 1) + "/" + (maxStep + 1);
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
                       
        }

        private void DataTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = stepsListView.SelectedIndex;
            currentStepImage.Source = new BitmapImage(new Uri(MainWindow.WorkingDerectory + CurrentRecipe.steps[index].Img));
            StepText.Text = CurrentRecipe.steps[index].Text;
            stepCurrentText.Text = "" + (stepsListView.SelectedIndex + 1) + "/" + (maxStep + 1);
            Debug.WriteLine(stepCurrentText.Text);

            if (index > 0)
            {
                PreImgButton.Source = new BitmapImage(new Uri(MainWindow.WorkingDerectory + CurrentRecipe.steps[index - 1].Img));
            }

            if (index < maxStep )
            {
                NextImgButton.Source = new BitmapImage(new Uri(MainWindow.WorkingDerectory + CurrentRecipe.steps[index + 1].Img));
            }
        }
    }

    
}
