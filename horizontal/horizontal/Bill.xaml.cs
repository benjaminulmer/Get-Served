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
        List<BillItem> orders;
        BillInfo combinedBill;
        bool isSplit;
        List<String> profiles;
        List<BillInfo> profileBills;

        public Bill()
        {
            InitializeComponent();

            profiles = new List<String>();
            profiles.Add("Mia");
            profiles.Add("Ryan");

            orders = new List<BillItem>();
            orders.Add(new BillItem("Roast Chicken", new List<String>() { "Mia" }, "$25.00"));
            orders.Add(new BillItem("Steak", new List<String>() { "Ryan" }, "$30.00"));
            orders.Add(new BillItem("Dessert", new List<String>() { "Mia", "Ryan" }, "$10.00", "No whipped cream", "$0.00"));

            combinedBill = new BillInfo();
            foreach (BillItem item in orders)
            {
                combinedBill.addItem(item);
            }
            billsPanel.Children.Add(combinedBill);

            profileBills = new List<BillInfo>();
            foreach (object name in profiles)
            {
                profileBills.Add(new BillInfo());
            }

            isSplit = false;
            splitBill();
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
                //splitBill();
                foreach (BillInfo bill in profileBills)
                {
                    billsPanel.Children.Add(bill);
                }
                billsPanel.Children.Remove(combinedBill);
            }
            isSplit = !isSplit;
        }

        private void splitBill() 
        {
            for (int i = 0; i < profiles.Count; i++)
            {
                String profile = profiles[i];

                foreach (BillItem item in combinedBill.items) {
                    if (item.users[0] == profile) {
                        profileBills[i].addItem(new BillItem(item.item, new List<String>() {}, item.price, item.mods, item.modsPrice));
                    }
                }
            }
        }

        private void combineBills()
        {
            billsPanel.Children.Clear();
            billsPanel.Children.Add(combinedBill);
        }
    }
}
