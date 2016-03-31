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
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : UserControl
    {
        BillInfo combinedBill;
        bool isSplit;
        List<String> profiles;

        public Bill()
        {
            InitializeComponent();
            combinedBill = new BillInfo();
            combinedBill.addItem(new BillItem("Roast Chicken", "Mia", "$25.00"));
            combinedBill.addItem(new BillItem("Steak", "Ryan", "$30.00"));
            combinedBill.addItem(new BillItem("Dessert", "Mia", "$10.00", "No whipped cream", "$0.00"));
            billsPanel.Children.Add(combinedBill);

            profiles = new List<String>();
            profiles.Add("Mia");
            profiles.Add("Ryan");

            isSplit = false;
        }

        private void requestBill_Click(object sender, RoutedEventArgs e)
        {
            requestBill.IsEnabled = false;
            requestBill.Content = "Bill on its way!";
        }

        private void splitButton_Click(object sender, RoutedEventArgs e)
        {
            if (isSplit)
            {
                splitButton.Content = "Split the Bill";
                combineBills();
            }
            else
            {
                splitButton.Content = "Combine Bills";
                splitBill();
            }
            isSplit = !isSplit;
        }

        private void splitBill() 
        {
            for (int i = 0; i < profiles.Count; i++)
            {
                String current = profiles[i];
                BillInfo currentBill = new BillInfo();

                for (int j = 0; j < combinedBill.items.Count; j++) {
                    if (combinedBill.items[j].user == current) {
                        BillItem swapItem = combinedBill.items[j];
                        combinedBill.removeItem(swapItem);
                        currentBill.addItem(swapItem);
                    }
                }
                billsPanel.Children.Add(currentBill);
            }
            billsPanel.Children.Remove(combinedBill);
        }

        private void combineBills() 
        {

        }

    }
}
