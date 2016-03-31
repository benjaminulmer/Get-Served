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
        public String price;
        public String mods;
        public String modsPrice;

        public BillItem(String item, List<String> users, String price)
        {
            InitializeComponent();
            this.item = item;
            this.users = users;
            this.price = price;
            this.mods = "";
            this.modsPrice = "";

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
            priceLabel.Content = price;
            userLabel.Content = userLabelString;
            modsLabel.Text = "";
            modsPriceLabel.Content = "";
        }

        public BillItem(String item, List<String> users, String price, String mods, String modsPrice)
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
            priceLabel.Content = price;
            userLabel.Content = userLabelString;
            modsLabel.Text = mods;
            modsPriceLabel.Content = modsPrice;
        }
    }
}
