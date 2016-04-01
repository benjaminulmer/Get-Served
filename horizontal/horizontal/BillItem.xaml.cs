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
        public OrderInformation order;

        //public BillItem(String item, List<String> users, float price, String mods, float modsPrice)
        public BillItem(OrderInformation newOrder)
        {
            InitializeComponent();
            this.order = newOrder;

            String userLabelString;
            if (order.users.Count == 0) { userLabelString = ""; }
            else { userLabelString = "For: "; }

            for (int i = 0; i < order.users.Count; i++)
            {
                userLabelString = userLabelString + order.users[i];
                if (i < order.users.Count - 1)
                {
                    userLabelString = userLabelString + ", ";
                }
            }

            String modText = "";
            float modPrice = 0.0F;

            for (int i = 0; i < order.mods.Count; i++ )
            {
                modText = modText + order.mods[i];
                if (i < order.mods.Count - 1) { modText = modText + ", "; }

                modPrice = modPrice + order.modsPrice[i];
            }

            itemLabel.Content = order.item;
            priceLabel.Content = "$" + order.price.ToString("0.00");
            userLabel.Content = userLabelString;
            modsLabel.Text = modText;
            modsPriceLabel.Content = "$" + modPrice.ToString("0.00");
        }
    }
}
