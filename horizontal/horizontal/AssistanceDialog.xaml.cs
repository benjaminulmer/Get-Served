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
    /// Interaction logic for AssistanceDialog.xaml
    /// </summary>
    public partial class AssistanceDialog : UserControl
    {
        Assistance parent;

        public AssistanceDialog(Assistance parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            resetParentButtonColors();
            cancelButton.Visibility = System.Windows.Visibility.Hidden;
            confirmButton.Visibility = System.Windows.Visibility.Hidden;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            resetParentButtonColors();
            cancelButton.Visibility = System.Windows.Visibility.Hidden;
            confirmButton.Visibility = System.Windows.Visibility.Hidden;

            parent.refillButton.IsEnabled = false;
            parent.serverButton.IsEnabled = false;
            parent.managerButton.IsEnabled = false;
            parent.customButton.IsEnabled = false;
            topLabel.Content = "Assistance is on its way!";
        }

        private void resetParentButtonColors()
        {
            parent.refillButton.Background = Brushes.White;
            parent.serverButton.Background = Brushes.White;
            parent.managerButton.Background = Brushes.White;
            parent.customButton.Background = Brushes.White;
        }
    }
}
