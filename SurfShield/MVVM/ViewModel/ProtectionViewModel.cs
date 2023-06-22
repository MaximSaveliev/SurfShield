using SurfShield.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SurfShield.MVVM.ViewModel
{
    internal class ProtectionViewModel : ObservableObject
    {
        public ObservableCollection<ServerModel> Servers { get; set; }
        
        private ServerModel _selectedServer;

        public ServerModel SelectedServer
        {
            get { return _selectedServer; }
            set { _selectedServer = value; }
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
            set 
            { 
                _isConnected = value;
                OnPropertyChanged(nameof(ConnectionButton));
            }
        }



        public RelayCommand ConnectCommand { get; set; }
        public ProtectionViewModel()
        {
            ConnectionButton = "Connect";
            Servers = new ObservableCollection<ServerModel>();
            //for (int i = 0; i < 10; i++)
            //{
                Servers.Add(new ServerModel
                {
                    Country = "USA1",
                    Flag = "https://img.icons8.com/color/256/usa.png"
                });
                Servers.Add(new ServerModel
                {
                    Country = "USA2",
                    Flag = "https://img.icons8.com/color/256/usa.png"
                });
                Servers.Add(new ServerModel
                {
                    Country = "Canada1",
                    Flag = "https://img.icons8.com/color/256/canada.png"
                });
                Servers.Add(new ServerModel
                {
                    Country = "Canada2",
                    Flag = "https://img.icons8.com/color/256/canada.png"
                });
                Servers.Add(new ServerModel
                {
                    Country = "France1",
                    Flag = "https://img.icons8.com/color/256/france.png"
                });
                Servers.Add(new ServerModel
                {
                    Country = "France2",
                    Flag = "https://img.icons8.com/color/256/france.png"
                });
                Servers.Add(new ServerModel
                {
                    Country = "Switzerland",
                    Flag = "https://img.icons8.com/color/256/switzerland.png"
                });
                Servers.Add(new ServerModel
                {
                    Country = "Netherlands",
                    Flag = "https://img.icons8.com/color/256/netherlands.png"
                });
                Servers.Add(new ServerModel
                {
                    Country = "Singapore",
                    Flag = "https://img.icons8.com/color/256/singapore.png"
                });
                Servers.Add(new ServerModel
                {
                    Country = "Czechia",
                    Flag = "https://img.icons8.com/color/256/czech-republic.png"
                });
            //Servers = new ObservableCollection<ServerModel>( Servers.OrderByDescending(x => x.Country));
            //}


            ConnectCommand = new RelayCommand(o => 
            {
                Task.Run(() => 
                {
                    if (ConnectionStatus == "Connected!")
                    {
                        var disconnect = new Process();
                        disconnect.StartInfo.FileName = "cmd.exe";
                        disconnect.StartInfo.Arguments = @"/c rasdial /d";
                        disconnect.StartInfo.UseShellExecute = false;
                        disconnect.StartInfo.CreateNoWindow = true;
                        disconnect.Start();
                        disconnect.WaitForExit();
                        if(disconnect.ExitCode == 0)
                            disconnect.Kill();
                        ConnectionStatus = string.Empty;
                        ConnectionButton = "Connect";
                        return;
                    }
                    ConnectionStatus = "Connecting...";
                    var process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                    if (SelectedServer?.Country == Servers[0].Country)
                    {
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer vpnbook 3ev7r8m /phonebook:./VPN/VPN.pbk");
                    }
                    else if(SelectedServer?.Country == Servers[1].Country)
                    {
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer2 vpnbook 3ev7r8m /phonebook:./VPN/VPN2.pbk");
                    }
                    else if (SelectedServer?.Country == Servers[2].Country)
                    {
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer3 vpnbook 3ev7r8m /phonebook:./VPN/VPN3.pbk");
                    }
                    else if (SelectedServer?.Country == Servers[3].Country)
                    {
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer4 vpnbook 3ev7r8m /phonebook:./VPN/VPN4.pbk");
                    }
                    else if (SelectedServer?.Country == Servers[4].Country)
                    {
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer5 vpnbook 3ev7r8m /phonebook:./VPN/VPN5.pbk");
                    }
                    else if (SelectedServer?.Country == Servers[5].Country)
                    {
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer6 vpnbook 3ev7r8m /phonebook:./VPN/VPN6.pbk");
                    }
                    else if (SelectedServer?.Country == Servers[6].Country)
                    {
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer7 freevpn724 u5tf696 /phonebook:./VPN/VPN7.pbk");
                    }
                    else if (SelectedServer?.Country == Servers[7].Country)
                    {
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer8 freevpn724 u5tf696 /phonebook:./VPN/VPN8.pbk");
                    }
                    else if (SelectedServer?.Country == Servers[8].Country)
                    {
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer9 freevpn724 u5tf696 /phonebook:./VPN/VPN9.pbk");
                    }
                    else if (SelectedServer?.Country == Servers[9].Country)
                    {
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer10 freevpn724 u5tf696 /phonebook:./VPN/VPN10.pbk");
                    }

                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();
                    ConnectionButton = "Disconnect";
                    process.WaitForExit();

                    

                    switch (process.ExitCode)
                    {
                        case 0:
                            Debug.WriteLine(("Success!"));
                            ConnectionStatus = "Connected!";
                            break;
                        case 691:
                            Debug.WriteLine("Wrong credentials!");
                            ConnectionStatus = "Wrong credentials!";
                            break;
                        default:
                            Debug.WriteLine($"Error: {process.ExitCode}");
                            break;
                    }
                });
            });
        }
        private void ServerBuilder()
        {
            var address = "us1.vpnbook.com";
            var FolderPath = $"{Directory.GetCurrentDirectory()}/VPN";
            var PbkPath = $"{FolderPath}/VPN.pbk";

            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            if (File.Exists(PbkPath))
            {
                MessageBox.Show("Connection already exists!");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("[MyServer]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine($"PhoneNumber={address}");
            File.WriteAllText(PbkPath, sb.ToString());
        }
    }
}
