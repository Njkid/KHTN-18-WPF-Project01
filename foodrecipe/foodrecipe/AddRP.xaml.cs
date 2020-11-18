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
using System.Diagnostics;
using System.ComponentModel;

namespace foodrecipe
{
    /// <summary>
    /// Interaction logic for AddRP.xaml
    /// </summary>
    public partial class AddRP : Fluent.RibbonWindow
    {
        public Recipe CurrentRecipe { get; set; }        
        public int currentStep { get; set; }
        public int maxStep { get; set; }
        public AddRP()
        {
            InitializeComponent();
            
              
            CurrentRecipe = new Recipe();
            Title = "Tạo mới công thức";

            CurrentRecipe.steps.Add(new Step());

            CurrentRecipe.steps[0].NameStep = "Giới thiệu";
            CurrentRecipe.steps[0].Text = "Giới thiệu món ăn của bạn";

            currentStep = 0;
            maxStep = 1;

            stepsListView.ItemsSource = CurrentRecipe.steps;
            stepsListView.SelectedIndex = currentStep;
          
        }

        private void currentStepUpload_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = stepsListView.SelectedIndex;

            Debug.WriteLine("(index) " + index + "(CurrentRecipe.steps.Count - 1)" + (CurrentRecipe.steps.Count - 1));

            if (index == CurrentRecipe.steps.Count - 1)
            {
                CurrentRecipe.steps.Add(new Step());
                stepsListView.ItemsSource = CurrentRecipe.steps;
                stepsListView.Items.Refresh();
                maxStep = CurrentRecipe.steps.Count - 1;
                stepsListView.SelectedIndex = index;
                
            }
            
            StepText.Text = CurrentRecipe.steps[index].Text;
            stepCurrentText.Text = "" + (stepsListView.SelectedIndex + 1) + "/" + (maxStep + 1);    

            if (index > 0)
            {
                PreImgButton.Source = new BitmapImage(new Uri(MainWindow.WorkingDerectory + "imgs/null.jpg"));
            }

            if (index < maxStep)
            {
                NextImgButton.Source = new BitmapImage(new Uri(MainWindow.WorkingDerectory + "imgs/null.jpg"));
            }
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
    }
}
