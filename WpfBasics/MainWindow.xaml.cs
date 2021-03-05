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

namespace WpfBasics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The Description is: {this.DescriptionText.Text}");

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.WeldCheckBox.IsChecked = this.AssemblyCheckBox.IsChecked = this.PlasmaCheckBox.IsChecked = this.LaserCheckBox.IsChecked = this.PurchaseCheckBox.IsChecked =
                this.LatherCheckBox.IsChecked = this.DrillCheckBox.IsChecked = this.FoldCheckBox.IsChecked = this.RollCheckBox.IsChecked = this.SawCheckBox.IsChecked = false;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            LenghText.Text += ((CheckBox)sender).Content;
                
        }

        private void FinishDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NoteText == null)
            {
                return;
            }
            var combo = (ComboBox)sender;
            var value = (ComboBoxItem)combo.SelectedValue;
            NoteText.Text = (string)value.Content;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FinishDropDown_SelectionChanged(this.FinishDropDown, null);
        }

        private void SuplierText_TextChanged(object sender, TextChangedEventArgs e)
        {
            MassText.Text = SuplierText.Text;
        }
    }
}
