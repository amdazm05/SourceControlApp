using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using RFSourceControllerApp.Model;

namespace RFSourceControllerApp.ViewModel
{
    class RFSourceControlViewModel : ViewModelBase
    {
        private RFSourceSweepTypes _RFSourceSweeptype;
        private RFSourceParameters _RFSourceParameters;

        //Intially these views are hidden
        private string _isVisibilePowerSweep = "Hidden";
        private string _isVisibileFreqSweep = "Hidden";
        public string isVisibilePowerSweep
        {
            get
            {
                return _isVisibilePowerSweep;
            }
            set
            {
                _isVisibilePowerSweep = value;
                OnPropertyChanged(nameof(isVisibilePowerSweep));
            }
        }

        public string isVisibileFreqSweep
        {
            get
            {
                return _isVisibileFreqSweep;
            }
            set
            {
                _isVisibileFreqSweep = value;
                OnPropertyChanged(nameof(isVisibileFreqSweep));
            }
        }

        //Sweep modes
        public string SweepType
        {
            get
            {
                return _RFSourceSweeptype.SweepType;
            }
            set
            {
                _RFSourceSweeptype.SweepType = value;
                if(_RFSourceSweeptype.SweepType.Contains("FreqSweep"))
                    isVisibileFreqSweep = "Visible";
                if (_RFSourceSweeptype.SweepType.Contains("PowerSweep"))
                    isVisibilePowerSweep = "Visible";
                
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

        private ICommand _ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return _ButtonCommand;
            }
            set
            {
                _ButtonCommand = value;
            }
        }

        public void HideViews(object obj)
        {
            isVisibilePowerSweep = "Hidden";
            isVisibileFreqSweep = "Hidden";
        }

        public RFSourceControlViewModel(RFSourceSweepTypes RFSourceSweeptype, RFSourceParameters SourceParams)
        {
            _RFSourceSweeptype = RFSourceSweeptype;
            _RFSourceParameters = SourceParams;
            ButtonCommand = new RelayCommand(new Action<object>(HideViews));
        }
    }
}
