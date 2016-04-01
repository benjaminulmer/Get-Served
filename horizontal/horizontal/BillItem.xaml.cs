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

        public BillItem(OrderInformation newOrder)
        {
            InitializeComponent();

            order = newOrder;

            String userLabelString;
            if (order.users.Count == 0) { userLabelString = ""; }
            else { userLabelString = "For: "; }
            
            for (int i = 0; i < order.users.Count; i++)
            {
                userLabelString = userLabelString + order.users[i];
                if (i < order.users.Count - 1) { 
                    userLabelString = userLabelString + ", ";
                }
            }

            String modText = "";
            float modPriceTotal = 0.0F;

            for (int i = 0; i < newOrder.mods.Count; i++ )
            {
                modText = modText + newOrder.mods[i];
                if (i < newOrder.mods.Count - 1) { modText = modText + ", ";  }

                modPriceTotal = modPriceTotal + newOrder.modsPrice[i];
            }

                itemLabel.Content = order.item;
            priceLabel.Content = "$" + order.price.ToString("0.00");
            userLabel.Content = userLabelString;
            modsLabel.Text = modText;
            modsPriceLabel.Content = "$" + modPriceTotal.ToString("0.00");
        }
    }
}
