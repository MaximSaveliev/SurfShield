using SurfShield.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ProtectionView.xaml
    /// </summary>
    public partial class ProtectionView : UserControl
    {
        public ProtectionView()
        {
            InitializeComponent();
        }

        private void serversListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ServerModel selectedServer = (ServerModel)serverListView.SelectedItem;
            if (selectedServer != null)
            {
                MessageBox.Show("Selected Server: " + selectedServer.Country);
            }
            return;
        }
    }
}
