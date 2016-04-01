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
            profiles.Add("Leo");

            orders = new List<BillItem>();
            orders.Add(new BillItem("Roast Chicken", new List<String>() { "Mia", "Leo" }, 25.00F, "Subsititute sweet potato fries", 3.00F));
            orders.Add(new BillItem("Steak", new List<String>() { "Ryan" }, 30.00F));
            orders.Add(new BillItem("Dessert", new List<String>() { "Mia", "Ryan" }, 10.00F, "No whipped cream", 0.00F));

            combinedBill = new BillInfo("combined");
            foreach (BillItem item in orders)
            {
                combinedBill.addItem(item);
            }
            combinedBill.setPrice();
            billsPanel.Children.Add(combinedBill);

            profileBills = new List<BillInfo>();
            foreach (String name in profiles)
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
            for (int i = 0; i < profiles.Count; i++)
            {
                String profile = profiles[i];

                foreach (BillItem item in combinedBill.items) {
                    if ((item.users.Count == 1) && (item.users[0] == profile)) {
                        profileBills[i].addItem(new BillItem(item.item, new List<String>() {}, item.price, item.mods, item.modsPrice));
                    }
                    else if (item.users[0] == profile)
                    {
                        splitWithMultiple(item);
                    }
                    profileBills[i].setPrice();
                    profileBills[i].setName(profiles[i]);
                }
            }
        }

        private void splitWithMultiple(BillItem item)
        {
            int numPeople = item.users.Count;
            String fractionString = "1/" + numPeople + " ";
            String nameString = fractionString + item.item;

            foreach (BillInfo bill in profileBills)
            {
                if (item.users.Contains(bill.user))
                {
                    bill.addItem(new BillItem(nameString, new List<String>() { }, (item.price / numPeople), item.mods, (item.modsPrice / numPeople)));
                }
            }
        }

        private void combineBills()
        {
            billsPanel.Children.Clear();
            billsPanel.Children.Add(combinedBill);
        }

        private void addItem(BillItem item)
        {
            orders.Add(item);
            combinedBill.addItem(item);
            combinedBill.setPrice();

            foreach (BillInfo bill in profileBills)
            {
                if ((item.users.Count == 1) && (bill.user == item.users[0]))
                {
                    bill.addItem(new BillItem(item.item, new List<String>() {}, item.price, item.mods, item.modsPrice));
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
