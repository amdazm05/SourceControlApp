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
        public ViewModelBase CurrentViewModel { get; }
        public RFSourceSweepTypes SweepModes;
        public RFSourceParameters SourceParams;
        public MainViewModel()
        {
            SweepModes = new RFSourceSweepTypes();
            SourceParams = new RFSourceParameters();
            CurrentViewModel = new RFSourceControlViewModel(SweepModes, SourceParams);
        }
    }
}
