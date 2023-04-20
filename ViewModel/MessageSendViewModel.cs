using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFSourceControllerApp.ViewModel;

namespace RFSourceControllerApp.ViewModel
{
    class MessageSendViewModel
    {
        private RFSourceControlViewModel _SourceControlViewModel;
        private TcpClientViewModel _NetworkClientViewModel;
        public MessageSendViewModel( RFSourceControlViewModel SourceControlViewModel, TcpClientViewModel NetworkClientViewModel)
        {
            _SourceControlViewModel = SourceControlViewModel;
            _NetworkClientViewModel = NetworkClientViewModel;
            _SourceControlViewModel.SendData += _NetworkClientViewModel.OnSend;
        }
    }
}
