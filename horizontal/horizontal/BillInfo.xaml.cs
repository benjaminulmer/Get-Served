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
    /// Interaction logic for BillInfo.xaml
    /// </summary>
    public partial class BillInfo : UserControl
    {
        public List<BillItem> items;
        public String user;

        public BillInfo(String userName)
        {
            InitializeComponent();

            items = new List<BillItem>();
            user = userName;

        }

        public void addItem(BillItem item)
        {
            billPanel.Children.Add(item);
            this.items.Add(item);
        }

        public void removeItem(BillItem item)
        {
            billPanel.Children.Remove(item);
        }

        public void setName(String name)
        {
            billTitle.Content = name + "'s Bill:";
            this.user = name;
        }

        public void setPrice()
        {
            float total = 0.0F;

            foreach (BillItem item in items)
            {
                total = total + item.order.price;
                for (int i = 0; i < item.order.modsPrice.Count; i++)
                {
                    total = total + item.order.modsPrice[i];
                }
            }

            String totalString = "$" + total.ToString("0.00");
            requestButton.Content = "Request this Bill (" + totalString + ")";
        }

        private void requestButton_Click(object sender, RoutedEventArgs e)
        {
            requestButton.IsEnabled = false;
            requestButton.Content = "Bill Request Sent!";
        }
    }

}
