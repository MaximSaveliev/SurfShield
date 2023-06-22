using SurfShield.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Reflection;
using System.Windows;

namespace SurfShield.MVVM.ViewModel
{
    internal class ProxyViewModel : ObservableObject
    {
        public ObservableCollection<ProxyModel> Proxies { get; set; }

        private ProxyModel _selectedProxy;

        public ProxyModel SelectedProxy
        {
            get { return _selectedProxy; }
            set { _selectedProxy = value; }
        }

        private string _connectionStatus;

        public string ConnectionStatus
        {
            get { return _connectionStatus; }
            set { 
                _connectionStatus = value;
                OnPropertyChanged();
            }
        }

        private string _isConnected = "Connected";

        public string ConnectionButton
        {
            get { return _isConnected; }
            set { 
                _isConnected = value;
                OnPropertyChanged(nameof(ConnectionButton));
            }
        }


        public RelayCommand ConnectProxy { get; set; }
        RegistryKey reg_key;

        public ProxyViewModel()
        {
            ConnectionButton = "Connect";
            Proxies = new ObservableCollection<ProxyModel>();

            Proxies.Add(new ProxyModel
            {
                Country = "USA",
                IP = "20.99.187.69",
                //52.4.150.19 USA 8080 BOT
                //54.39.177.103 CA 3128
                //51.79.50.22 ?? 9300 👍
                //20.159.154.112 US 8080 BOT
                //82.165.184.53 DE 80 👍-
                //185.237.98.113 GB 8081 👍-
                //103.69.108.78 PH 8191 👍-
                //8.219.176.202 SG 8080 👍-
                //20.99.187.69 US 8443 👍-
                //43.228.85.144 TH 8080 👍-
                //20.111.54.16 FR 80 👍-
                //20.210.113.32 JP 80 👍-
                //23.254.209.174 US 8888 👍-
                Port = "8443",
                Flag = "https://img.icons8.com/color/256/usa.png"
            });

            Proxies.Add(new ProxyModel
            {
                Country = "USA",
                IP = "23.254.209.174",
                Port = "8888",
                Flag = "https://img.icons8.com/color/256/usa.png"
            });

            Proxies.Add(new ProxyModel
            {
                Country = "Great Britain",
                IP = "185.237.98.113",
                Port = "8081",
                Flag = "https://img.icons8.com/color/256/great-britain.png"
            });

            Proxies.Add(new ProxyModel
            {
                Country = "France",
                IP = "20.111.54.16",
                Port = "80",
                Flag = "https://img.icons8.com/color/256/france.png"
            });

            Proxies.Add(new ProxyModel
            {
                Country = "German",
                IP = "82.165.184.53",
                Port = "80",
                Flag = "https://img.icons8.com/color/256/germany.png"
            });

            Proxies.Add(new ProxyModel
            {
                Country = "Japan",
                IP = "20.210.113.32",
                Port = "80",
                Flag = "https://img.icons8.com/color/256/japan.png"
            });

            Proxies.Add(new ProxyModel
            {
                Country = "Singapore",
                IP = "8.219.176.202",
                Port = "8080",
                Flag = "https://img.icons8.com/color/256/singapore.png"
            });

            Proxies.Add(new ProxyModel
            {
                Country = "Philippines",
                IP = "103.69.108.78",
                Port = "8191",
                Flag = "https://img.icons8.com/color/256/philippines.png"
            });

            Proxies.Add(new ProxyModel
            {
                Country = "Thailand",
                IP = "43.228.85.144",
                Port = "8080",
                Flag = "https://img.icons8.com/color/256/thailand.png"
            });


            ConnectProxy = new RelayCommand(o =>
            {
                Task.Run(() =>
                {
                    if (ConnectionStatus == "Connected!")
                    {
                        reg_key.SetValue("ProxyEnable", 0);
                        ConnectionStatus = string.Empty;
                        ConnectionButton = "Connect";
                        return;
                    }

                    ConnectionStatus = "Connecting...";
                    string proxy = string.Empty;
                    reg_key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
                    if (SelectedProxy?.IP == Proxies[0].IP)
                    {
                        proxy = Proxies[0].IP + ":" + Proxies[0].Port;
                    }
                    else if (SelectedProxy?.IP == Proxies[1].IP)
                    {
                        proxy = Proxies[1].IP + ":" + Proxies[1].Port;
                    }
                    else if (SelectedProxy?.IP == Proxies[2].IP)
                    {
                        proxy = Proxies[2].IP + ":" + Proxies[2].Port;
                    }
                    else if (SelectedProxy?.IP == Proxies[3].IP)
                    {
                        proxy = Proxies[3].IP + ":" + Proxies[3].Port;
                    }
                    else if (SelectedProxy?.IP == Proxies[4].IP)
                    {
                        proxy = Proxies[4].IP + ":" + Proxies[4].Port;
                    }
                    else if (SelectedProxy?.IP == Proxies[5].IP)
                    {
                        proxy = Proxies[5].IP + ":" + Proxies[5].Port;
                    }
                    else if (SelectedProxy?.IP == Proxies[6].IP)
                    {
                        proxy = Proxies[6].IP + ":" + Proxies[6].Port;
                    }
                    else if (SelectedProxy?.IP == Proxies[7].IP)
                    {
                        proxy = Proxies[7].IP + ":" + Proxies[7].Port;
                    }
                    else if (SelectedProxy?.IP == Proxies[8].IP)
                    {
                        proxy = Proxies[8].IP + ":" + Proxies[8].Port;
                    }


                    reg_key.SetValue("ProxyEnable", 1);
                    reg_key.SetValue("ProxyServer", proxy);

                    ConnectionButton = "Disconnect";
                    ConnectionStatus = "Connected!";
                    //MessageBox.Show("Proxy changed to: ", proxy);
                });
            });

        }
    }
}
