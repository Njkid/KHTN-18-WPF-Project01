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
using System.IO;
using Microsoft.Win32;


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
            CurrentRecipe = new Recipe();
            InitializeComponent();
            
              
            
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
            OpenFileDialog openFileDialogCSV = new OpenFileDialog();

            openFileDialogCSV.ShowDialog();
            openFileDialogCSV.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialogCSV.FilterIndex = 1;
            openFileDialogCSV.RestoreDirectory = true;

            var fileName = openFileDialogCSV.FileName;
            int index = stepsListView.SelectedIndex;

            System.IO.File.Copy(fileName,MainWindow.WorkingDerectory + "imgs/rp" + RecipeDAO.numInitRP + "img" + index + ".jpg", true);

            CurrentRecipe.steps[index].Img = "imgs/rp" + RecipeDAO.numInitRP + "img" + index + ".jpg";

            if (index == 0)
            {
                CurrentRecipe.RecipeImagePath = CurrentRecipe.steps[index].Img;
            }

            stepsListView.Items.Refresh();
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
            Debug.WriteLine(CurrentRecipe.steps[index].Text);
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
                
        
        
        private void StepText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int index = stepsListView.SelectedIndex; 
            if (index >= 0)
            {
                CurrentRecipe.steps[index].Text = StepText.Text;
                stepsListView.Items.Refresh();
            }
            
        }

        private void rpNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CurrentRecipe.RecipeName = rpNameTextBox.Text;           
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeDAO.Update(CurrentRecipe);
            MessageBox.Show("Thêm thành công!");
        }

        private void StepText_KeyUp(object sender, KeyEventArgs e)
        {            
            if (e.Key == Key.Enter)
            {
                //newline
            }            
        }
    }
}
