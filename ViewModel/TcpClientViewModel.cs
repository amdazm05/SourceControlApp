using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RFSourceControllerApp.Model;
using RFSourceControllerApp.Model.Util;
using RFSourceControllerApp.Model.Data;

namespace RFSourceControllerApp.ViewModel
{

    class TcpClientViewModel : ViewModelBase
    {
        //This is the TCP client Model
        private TcpClient _tcpClient;
        //Shows the connected status
        private bool _isConnected;
        //stores the Ip
        private string _ipAddress;
        //Port Number
        private int? _port;
        /// <summary>
        /// Connect disconnect Command along with the relevant connects
        /// </summary>
        private async void Connect()
        {
            if (!ValidateConnect())
                return;

            try
            {
                await _tcpClient.ConnectAsync(IpAddress, Port.Value);
            }
            catch (Exception ex)
            {
                DialogUtils.ShowErrorDialog(ex.Message);
            }
        }
        private void Disconnect()
        {
            _tcpClient.Disconnect();
        }

        private bool ValidateConnect()
        {
            string error = null;
            if (HasError(nameof(IpAddress)))
                error = GetError(nameof(IpAddress));
            else if (HasError(nameof(Port)))
                error = GetError(nameof(Port));

            if (error != null)
            {
                DialogUtils.ShowErrorDialog(error);
                return false;
            }

            return true;
        }

        public async void OnSend(byte[] data)
        {
            try
            {
                Transmission msg = new Transmission(data, Transmission.EType.Sent);
                TransmissionResult res = await _tcpClient.SendAsync(msg);
                if (res != null)
                {
                    msg.Origin = res.From;
                    msg.Destination = res.To;
                }
            }
            catch (Exception ex)
            {
                DialogUtils.ShowErrorDialog(ex.Message);
            }
        }


        public void Dispose()
        {
            _tcpClient?.Dispose();
        }


        /// <summary>
        /// View related firled
        /// </summary>
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }


        public string IpAddress
        {
            get { return _ipAddress; }
            set
            {
                if (_ipAddress != value)
                {
                    _ipAddress = value;

                    if (String.IsNullOrWhiteSpace(_ipAddress))
                    {
                        AddError(nameof(IpAddress), "IP address cannot be empty.");
                    }
                    else
                    {
                        RemoveError(nameof(IpAddress));
                    }

                    OnPropertyChanged(nameof(IpAddress));
                }
            }
        }


        public int? Port
        {
            get { return _port; }
            set
            {
                if (_port != value)
                {
                    _port = value;

                    if (!NetworkUtils.IsValidPort(_port.HasValue ? _port.Value : -1, false))
                    {
                        AddError(nameof(Port), "Port must be between 1 and 65535.");
                    }
                    else
                    {
                        RemoveError(nameof(Port));
                    }
                }

                OnPropertyChanged(nameof(Port));
            }
        }

        public ICommand ConnectDisconnectCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (IsConnected)
                    {
                        Disconnect();
                    }
                    else
                    {
                        Connect();
                    }
                }
                );
            }
        }

        public TcpClientViewModel()
        {
            _tcpClient = new TcpClient();
            _tcpClient.StatusChanged +=
                (sender, arg) =>
                {
                    IsConnected = arg.Status == TcpClientStatusEventArgs.EConnectStatus.Connected;

                    if (IsConnected)
                    {
                        //History.Header = "Connected to: < " + arg.RemoteEndPoint.ToString() + " >";
                    }
                    else
                    {
                        //History.Header = "Conversation";
                    }

                };
        }
    }
}


