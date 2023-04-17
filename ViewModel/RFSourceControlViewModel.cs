using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFSourceControllerApp.Model;

namespace RFSourceControllerApp.ViewModel
{
    class RFSourceControlViewModel : ViewModelBase
    {
        //A copy of the model
        private  RFSourceSweepTypes _RFSourceSweeptype;
        private  RFSourceParameters _RFSourceParameters;
        public string SweepType
        {
            get
            {
                return _RFSourceSweeptype.SweepType;
            }
            set
            {
                _RFSourceSweeptype.SweepType = value;
                OnPropertyChanged(nameof(SweepType));
            }
        }

        public double RfUpdate
        {
            get
            {
                return _RFSourceParameters.Rf;
            }
            set
            {
                _RFSourceParameters.Rf = Convert.ToDouble(value);
                OnPropertyChanged(nameof(RfUpdate));
            }
        }

        public double PriUpdate
        {
            get
            {
                return _RFSourceParameters.Pri;
            }
            set
            {
                _RFSourceParameters.Pri = Convert.ToDouble(value);
                OnPropertyChanged(nameof(PriUpdate));
            }
        }

        public double PwUpdate
        {
            get
            {
                return _RFSourceParameters.Pw;
            }
            set
            {
                _RFSourceParameters.Pw = Convert.ToDouble(value);
                OnPropertyChanged(nameof(PwUpdate));
            }
        }

        public double PowerUpdate
        {
            get
            {
                return _RFSourceParameters.Power;
            }
            set
            {
                _RFSourceParameters.Power = Convert.ToDouble(value);
                OnPropertyChanged(nameof(PowerUpdate));
            }
        }


        public bool isCWChecked
        {
            get
            {
                return _RFSourceParameters.isCW;
            }
            set
            {
                _RFSourceParameters.isCW = Convert.ToBoolean(value);
                OnPropertyChanged(nameof(isCWChecked));
            }
        }
        


        public RFSourceControlViewModel(RFSourceSweepTypes RFSourceSweeptype, RFSourceParameters SourceParams)
        {
            _RFSourceSweeptype = RFSourceSweeptype;
            _RFSourceParameters = SourceParams;
        }
    }
}
