using SurfShield.MVVM.ViewModel;
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

namespace SurfShield.MVVM.View
{
    /// <summary>
    /// Interaction logic for ProxyView.xaml
    /// </summary>
    public partial class ProxyView : UserControl
    {
        public ProxyView()
        {
            InitializeComponent();
        }

        private void proxyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProxyModel SelectedProxy = (ProxyModel)proxyComboBox.SelectedItem;
            if (SelectedProxy != null)
            {
                MessageBox.Show("Selected Proxy: " + SelectedProxy.IP);
            }
            return;
        }
    }
}
