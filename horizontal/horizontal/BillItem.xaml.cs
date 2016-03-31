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
    /// Interaction logic for BillItem.xaml
    /// </summary>
    public partial class BillItem : UserControl
    {
        public String item;
        public List<String> users;
        public float price;
        public String mods;
        public float modsPrice;

        public BillItem(String item, List<String> users, float price)
        {
            InitializeComponent();
            this.item = item;
            this.users = users;
            this.price = price;
            this.mods = "No modifications";
            this.modsPrice = 0.0F;

            String userLabelString;
            if (users.Count == 0) { userLabelString = ""; }
            else { userLabelString = "For: "; }
            
            for (int i = 0; i < users.Count; i++)
            {
                userLabelString = userLabelString + users[i];
                if (i < users.Count - 1) { 
                    userLabelString = userLabelString + ", ";
                }
            }

            itemLabel.Content = item;
            priceLabel.Content = "$" + price.ToString("0.00");
            userLabel.Content = userLabelString;
            modsLabel.Text = this.mods;
            modsPriceLabel.Content = "$0.00";
        }

        public BillItem(String item, List<String> users, float price, String mods, float modsPrice)
        {
            InitializeComponent();
            this.item = item;
            this.users = users;
            this.price = price;
            this.mods = mods;
            this.modsPrice = modsPrice;

            String userLabelString;
            if (users.Count == 0) { userLabelString = ""; }
            else { userLabelString = "For: "; }

            for (int i = 0; i < users.Count; i++)
            {
                userLabelString = userLabelString + users[i];
                if (i < users.Count - 1)
                {
                    userLabelString = userLabelString + ", ";
                }
            }

            itemLabel.Content = item;
            priceLabel.Content = "$" + price.ToString("0.00");
            userLabel.Content = userLabelString;
            modsLabel.Text = mods;
            modsPriceLabel.Content = "$" + modsPrice.ToString("0.00");
        }
    }
}
