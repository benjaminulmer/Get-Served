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

        public BillInfo()
        {
            InitializeComponent();

            items = new List<BillItem>();

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
    }

}
