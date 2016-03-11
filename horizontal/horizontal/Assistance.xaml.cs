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

namespace horizontal
{
    /// <summary>
    /// Interaction logic for Assistance.xaml
    /// </summary>
    public partial class Assistance : UserControl
    {
        AssistanceDialog assistanceDialog;

        public Assistance()
        {
            assistanceDialog = new AssistanceDialog(this);
            InitializeComponent();
            confirmStackPanel.Children.Add(assistanceDialog);
        }

        private void refillButton_Click(object sender, RoutedEventArgs e)
        {
            refillButton.Background = Brushes.LightGray;
            serverButton.Background = Brushes.White;
            managerButton.Background = Brushes.White;
            customButton.Background = Brushes.White;

            //assistanceDialog.topLabel.Content = "Testing";
            assistanceDialog.cancelButton.Visibility = System.Windows.Visibility.Visible;
            assistanceDialog.confirmButton.Visibility = System.Windows.Visibility.Visible;
            assistanceDialog.customRequest.Visibility = System.Windows.Visibility.Hidden;
        }

        private void serverButton_Click(object sender, RoutedEventArgs e)
        {
            refillButton.Background = Brushes.White;
            serverButton.Background = Brushes.LightGray;
            managerButton.Background = Brushes.White;
            customButton.Background = Brushes.White;

            //assistanceDialog.topLabel.Content = "Testing";
            assistanceDialog.cancelButton.Visibility = System.Windows.Visibility.Visible;
            assistanceDialog.confirmButton.Visibility = System.Windows.Visibility.Visible;
            assistanceDialog.customRequest.Visibility = System.Windows.Visibility.Hidden;
        }

        private void managerButton_Click(object sender, RoutedEventArgs e)
        {
            refillButton.Background = Brushes.White;
            serverButton.Background = Brushes.White;
            managerButton.Background = Brushes.LightGray;
            customButton.Background = Brushes.White;

            //assistanceDialog.topLabel.Content = "Testing";
            assistanceDialog.cancelButton.Visibility = System.Windows.Visibility.Visible;
            assistanceDialog.confirmButton.Visibility = System.Windows.Visibility.Visible;
            assistanceDialog.customRequest.Visibility = System.Windows.Visibility.Hidden;
        }

        private void customButton_Click(object sender, RoutedEventArgs e)
        {
            refillButton.Background = Brushes.White;
            serverButton.Background = Brushes.White;
            managerButton.Background = Brushes.White;
            customButton.Background = Brushes.LightGray;

            //assistanceDialog.topLabel.Content = "Testing";
            assistanceDialog.cancelButton.Visibility = System.Windows.Visibility.Visible;
            assistanceDialog.confirmButton.Visibility = System.Windows.Visibility.Visible;
            assistanceDialog.customRequest.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
