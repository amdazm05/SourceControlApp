using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFSourceControllerApp.Model;

namespace RFSourceControllerApp.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        //Displaying current view model
        public TcpClientViewModel ClientTCPViewModel { get;  set; }
        public RFSourceControlViewModel CurrentViewModel { get; set; }
        public RFSourceSweepTypes SweepModes;
        public RFSourceParameters SourceParams;
        public MessageSendViewModel Messenger;
        public MainViewModel()
        {
            ClientTCPViewModel = new TcpClientViewModel();
            SweepModes = new RFSourceSweepTypes();
            SourceParams = new RFSourceParameters();
            CurrentViewModel = new RFSourceControlViewModel(SweepModes, SourceParams);
            Messenger = new MessageSendViewModel(CurrentViewModel,  ClientTCPViewModel);
        }
    }
}
