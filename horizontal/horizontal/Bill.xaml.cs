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
        List<BillItem> billOrders;
        BillInfo combinedBill;
        bool isSplit;
        List<BillInfo> profileBills;

        public Bill()
        {
            InitializeComponent();

            billOrders = new List<BillItem>();

            combinedBill = new BillInfo("combined");

            billsPanel.Children.Add(combinedBill);

            profileBills = new List<BillInfo>();
            foreach (String name in Global.names)
            {
                profileBills.Add(new BillInfo(name));
            }

            isSplit = false;
            splitBill();
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
            for (int i = 0; i < Global.names.Count; i++)
            {
                String profile = Global.names[i];

                foreach (BillItem item in combinedBill.items) {
                    if ((item.order.users.Count == 1) && (item.order.users[0] == profile)) {
                        profileBills[i].addItem(item.order);
                    }
                    else if (item.order.users[0] == profile)
                    {
                        splitWithMultiple(item.order);
                    }
                    profileBills[i].setPrice();
                    profileBills[i].setName(Global.names[i]);
                }
            }
        }

        private void splitWithMultiple(OrderInformation item)
        {
            int numPeople = item.users.Count;
            String fractionString = "1/" + numPeople + " ";
            item.item = fractionString + item.item;

            for (int i = 0; i < item.modsPrice.Count; i++ )
            {
                item.modsPrice[i] = (item.modsPrice[i] / numPeople);
            }
            

            foreach (BillInfo bill in profileBills)
            {
                if (item.users.Contains(bill.user))
                {
                    item.users = new List<String>() { };
                    bill.addItem(item);
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
            combinedBill.addItem(item);
            combinedBill.setPrice();

            foreach (BillInfo bill in profileBills)
            {
                if ((item.users.Count == 1) && (bill.user == item.users[0]))
                {
                    item.users = new List<String>() { };
                    bill.addItem(item);
                    bill.setPrice();
                }
                else
                {
                    splitWithMultiple(item);
                }
            }
        }
    }
}
