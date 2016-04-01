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
        //List<BillItem> orders;
        BillInfo combinedBill;
        bool isSplit;
        //List<String> profiles;
        List<BillInfo> profileBills;

        public Bill()
        {
            InitializeComponent();

            combinedBill = new BillInfo("combined");
            profileBills = new List<BillInfo>();
            isSplit = false;
        }

        public void addUsers()
        {
            for (int i = 0; i < Global.names.Count; i++ )
            {
                profileBills.Add(new BillInfo(Global.names[i]));
                profileBills[i].setName(Global.names[i]);
            }
            billsPanel.Children.Add(combinedBill);
        }

        private void requestBill_Click(object sender, RoutedEventArgs e)
        {
            splitButton.IsEnabled = false;
            requestBill.IsEnabled = false;
            requestBill.Content = "Bill(s) Request Sent!";

            foreach (BillInfo bill in profileBills)
            {
                bill.requestButton.IsEnabled = false;
                bill.requestButton.Content = "Bill Request Sent!";
            }
            combinedBill.requestButton.IsEnabled = false;
            combinedBill.requestButton.Content = "Bill Request Sent!";
        }

        private void splitButton_Click(object sender, RoutedEventArgs e)
        {
            if (isSplit)
            {
                splitButton.Content = "Split the Bill";
                requestBill.Content = "Request Bill";
                combineBills();
            }
            else
            {
                splitButton.Content = "Combine Bills";
                requestBill.Content = "Request All Bills";
                foreach (BillInfo bill in profileBills)
                {
                    billsPanel.Children.Add(bill);
                }
                billsPanel.Children.Remove(combinedBill);
            }
            isSplit = !isSplit;
        }

        private void splitWithMultiple(BillItem item)
        {
            int numPeople = item.order.users.Count;
            String fractionString = "1/" + numPeople + " ";
            String nameString = fractionString + item.order.item;
            item.order.item = nameString;

            OrderInformation splitItem = new OrderInformation();
            splitItem.item = nameString;
            splitItem.users = new List<String>() { };
            splitItem.price = (item.order.price / numPeople);
            splitItem.mods = item.order.mods;
            splitItem.modsPrice = item.order.modsPrice; 

            for (int i = 0; i < item.order.modsPrice.Count; i++)
            {
                splitItem.modsPrice[i] = (splitItem.modsPrice[i] / numPeople);
            }

            foreach (BillInfo bill in profileBills)
            {
                if (item.order.users.Contains(bill.user))
                {
                    bill.addItem(new BillItem(splitItem));
                    bill.setPrice();
                }
            }
        }

        private void combineBills()
        {
            billsPanel.Children.Clear();
            billsPanel.Children.Add(combinedBill);
        }

        public void addItem(OrderInformation item)
        {

            combinedBill.addItem(new BillItem(item));
            combinedBill.setPrice();

            if (item.users.Count == 1) { 
                foreach (BillInfo bill in profileBills)
                {
                    if (bill.user == item.users[0])
                    {
                        bill.addItem(new BillItem(item));
                        bill.setPrice();
                    }
                }
            }
            else
            {
                splitWithMultiple(new BillItem(item));
            }
        }
    }
}
