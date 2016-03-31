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
        String item;
        public String user;
        String price;
        String mods;
        String modsPrice;

        public BillItem(String item, String user, String price)
        {
            InitializeComponent();
            this.item = item;
            this.user = user;
            this.price = price;
            this.mods = "";
            this.modsPrice = "";

            itemLabel.Content = item;
            priceLabel.Content = price;
            userLabel.Content = user;
            modsLabel.Text = "";
            modsPriceLabel.Content = "";
        }

        public BillItem(String item, String user, String price, String mods, String modsPrice)
        {
            InitializeComponent();
            this.item = item;
            this.user = user;
            this.price = price;
            this.mods = mods;
            this.modsPrice = modsPrice;

            itemLabel.Content = item;
            priceLabel.Content = price;
            userLabel.Content = user;
            modsLabel.Text = mods;
            modsPriceLabel.Content = modsPrice;
        }
    }
}
