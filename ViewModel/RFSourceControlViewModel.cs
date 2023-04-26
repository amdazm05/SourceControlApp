using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using RFSourceControllerApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RFSourceControllerApp.Model.EventArg;
using RFSourceControllerApp.Model.Data;


namespace RFSourceControllerApp.ViewModel
{
    class RFSourceControlViewModel : ViewModelBase
    {
        private RFSourceSweepTypes _RFSourceSweeptype;
        private RFSourceParameters _RFSourceParameters;
        private RfSourceJsonSchema _RfSourceJsonSchema;
        private string _isVisibilePowerSweep = "Hidden";
        private string _isVisibileFreqSweep = "Hidden";
        private string _isVisibileFreqPowerSweep = "Hidden";
        private string _isRFButtonVisible = "Visible";
        private string _isSweepStartVisible = "Hidden";
        private string _SweepInfoBar = "Hidden";
        private string _RFButtonONOFFContent = "RF ON";
        private string _SweepButtonStartContent = "Start Sweep";
        private ICommand _ButtonCommand;
        private ICommand _RfButtonCommand;
        private ICommand _SweepStartCommand;
        private bool _FixedParameterEnabled = true;
        //Used for triggering Send data to an outside source
        public event Action<byte[]> SendData;

        public string RFButtonONOFFContent
        {
        
            get
            {
                return _RFButtonONOFFContent;
            }

            set
            {
                _RFButtonONOFFContent = value;
                OnPropertyChanged(nameof(RFButtonONOFFContent));
            }
        }

        public string SweepButtonStartContent
        {

            get
            {
                return _SweepButtonStartContent;
            }

            set
            {
                _SweepButtonStartContent = value;
                OnPropertyChanged(nameof(SweepButtonStartContent));
            }
        }

        public bool FixedParameterEnabled
        {
            get
            {
                return _FixedParameterEnabled;
            }

            set
            {
                _FixedParameterEnabled = value;
                OnPropertyChanged(nameof(FixedParameterEnabled));
            }
        }

        public string isSweepStartVisible
        {
            get
            {
                return _isSweepStartVisible;
            }
            set
            {
                _isSweepStartVisible = value;
                OnPropertyChanged(nameof(isSweepStartVisible));
            }
        }

        public string isRFButtonVisible
        {
            get
            {
                return _isRFButtonVisible;
            }
            set
            {
                _isRFButtonVisible = value;
                OnPropertyChanged(nameof(isRFButtonVisible));
            }
        }

        public string isVisibileFreqPowerSweep
        {
            get
            {
                return _isVisibileFreqPowerSweep;
            }
            set
            {
                _isVisibileFreqPowerSweep = value;
                OnPropertyChanged(nameof(isVisibileFreqPowerSweep));
            }
        }

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
                if (_RFSourceSweeptype.SweepType.Contains("FreqSweep"))
                {
                    isVisibileFreqSweep = "Visible";
                    isRFButtonVisible = "Hidden";
                    FixedParameterEnabled = false;
                    SweepInfoBar = "Visible";
                    isSweepStartVisible = "Visible";
                    _RFSourceSweeptype.SweepType = "FreqSweep";

                }
                if (_RFSourceSweeptype.SweepType.Contains("PowerSweep"))
                {
                    isVisibilePowerSweep = "Visible";
                    isRFButtonVisible = "Hidden";
                    FixedParameterEnabled = false;
                    SweepInfoBar = "Visible";
                    isSweepStartVisible = "Visible";
                    _RFSourceSweeptype.SweepType = "PowerSweep";
                }
                if (_RFSourceSweeptype.SweepType.Contains("Frequency-Power"))
                {
                    isVisibileFreqPowerSweep = "Visible";
                    isRFButtonVisible = "Hidden";
                    FixedParameterEnabled = false;
                    SweepInfoBar = "Visible";
                    isSweepStartVisible = "Visible";
                    _RFSourceSweeptype.SweepType = "FreqPowerSweep";
                }
                if(_RFSourceSweeptype.SweepType.Contains("Power-Frequency"))
                {
                    isVisibileFreqPowerSweep = "Visible";
                    isRFButtonVisible = "Hidden";
                    FixedParameterEnabled = false;
                    SweepInfoBar = "Visible";
                    isSweepStartVisible = "Visible";
                    _RFSourceSweeptype.SweepType = "PowerFreqSweep";
                }
                if (_RFSourceSweeptype.SweepType.Contains("Fixed"))
                {
                    isRFButtonVisible = "Visible";
                    FixedParameterEnabled = true;
                    SweepInfoBar = "Hidden";
                    isSweepStartVisible = "Hidden";
                    _RFSourceSweeptype.SweepType = "Fixed";
                }

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

        public bool isCyclicMode
        {
            get
            {
                return _RFSourceSweeptype.CyclicMode;
            }
            set
            {
                _RFSourceSweeptype.CyclicMode = Convert.ToBoolean(value);
                OnPropertyChanged(nameof(isCyclicMode));
            }
        }

        //Sweep related variables 
        public double DwellTime
        {
            get
            {
                return _RFSourceSweeptype.DwellTime;
            }
            set
            {
                _RFSourceSweeptype.DwellTime = value;
                OnPropertyChanged(nameof(DwellTime));
            }
        }
        public double RfStart
        {
            get
            {
                return _RFSourceSweeptype.RfStart;
            }
            set
            {
                _RFSourceSweeptype.RfStart = value;
                OnPropertyChanged(nameof(RfStart));
            }
        }
        public double RfStop
        {
            get
            {
                return _RFSourceSweeptype.RfStop;
            }
            set
            {
                _RFSourceSweeptype.RfStop = value;
                OnPropertyChanged(nameof(RfStop));
            }
        }
        public double RfStep
        {
            get
            {
                return _RFSourceSweeptype.RfStep;
            }
            set
            {
                _RFSourceSweeptype.RfStep = value;
                OnPropertyChanged(nameof(RfStep));
            }
        }
        public double PowerStart
        {
            get
            {
                return _RFSourceSweeptype.PowerStart;
            }
            set
            {
                _RFSourceSweeptype.PowerStart = value;
                OnPropertyChanged(nameof(PowerStart));
            }
        }
        public double PowerStop
        {
            get
            {
                return _RFSourceSweeptype.PowerStop;
            }
            set
            {
                _RFSourceSweeptype.PowerStop = value;
                OnPropertyChanged(nameof(PowerStop));
            }
        }

        public bool isRFOn
        {
            get
            {
                return _RFSourceParameters.isOn;
            }
            set
            {
                _RFSourceParameters.isOn = value;
                if (_RFSourceParameters.isOn)
                {
                    RFButtonONOFFContent = "RF ON";
                }
                else
                {
                    RFButtonONOFFContent = "RF OFF";
                }
                OnPropertyChanged(nameof(isRFOn));
            }
        }
        public string SweepInfoBar
        {
            get
            {
                return _SweepInfoBar;
            }
            set
            {
                _SweepInfoBar= value;
                OnPropertyChanged(nameof(SweepInfoBar));
            }
        }
        public double StepSize
        {
            get
            {
                return _RFSourceSweeptype.RfStep;
            }
            set
            {
                _RFSourceSweeptype.RfStep = value;
                OnPropertyChanged(nameof(StepSize));
            }
        }

        public double PowerStep
        {
            get
            {
                return _RFSourceSweeptype.PowerStep;
            }
            set
            {
                _RFSourceSweeptype.PowerStep = value;
                OnPropertyChanged(nameof(PowerStep));
            }
        }

        public double WaitTime
        {
            get
            {
                return _RFSourceSweeptype.WaitTime;
            }
            set
            {
                _RFSourceSweeptype.WaitTime = value;
                OnPropertyChanged(nameof(WaitTime));
            }
        }


        //hides the RF button and the Sweep Views
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

        public string JSONifyModel()
        { 

            _RfSourceJsonSchema.SetSourceParamsFromModel(0,_RFSourceParameters, _RFSourceSweeptype);
            return _RfSourceJsonSchema.JsonSerialise();
            
        }

        public void ParseJSONDataToSourceModel(byte[] arg)
        {
            string json = Encoding.Default.GetString(arg);
            try
            {
                JObject jsonObject = JObject.Parse(json);
                isRFOn = Convert.ToBoolean(jsonObject.SelectToken("SourceParameters")[0].SelectToken("isOn").ToString());
                isCWChecked = Convert.ToBoolean(jsonObject.SelectToken("SourceParameters")[0].SelectToken("isCW").ToString());
                PwUpdate = Convert.ToDouble(jsonObject.SelectToken("SourceParameters")[0].SelectToken("Pw").ToString());
                PriUpdate = Convert.ToDouble(jsonObject.SelectToken("SourceParameters")[0].SelectToken("Pri").ToString());
                PowerUpdate = Convert.ToDouble(jsonObject.SelectToken("SourceParameters")[0].SelectToken("Power").ToString());
                RfUpdate = Convert.ToDouble(jsonObject.SelectToken("SourceParameters")[0].SelectToken("Rf").ToString());
            }

            catch(Exception e)
            {

            }
            
        }

        public ICommand RfButtonCommand
        {
            get
            {
                return _RfButtonCommand;
            }
            set
            {
                _RfButtonCommand = value;
                
            }
        }

        public ICommand SweepStartCommand
        {
            get
            {
                return _SweepStartCommand;
            }
            set
            {
                _SweepStartCommand = value;
            }
        }

        public void HideViews(object obj)
        {
            isVisibilePowerSweep = "Hidden";
            isVisibileFreqSweep = "Hidden";
            isVisibileFreqPowerSweep = "Hidden";
        }

        public void ToggleRf(object obj)
        {
            //Toggle RF State 
            _RFSourceParameters.isOn = !_RFSourceParameters.isOn;
            byte[] bufferToTransmit = Encoding.ASCII.GetBytes(JSONifyModel());
            if(SendData !=null)
                SendData?.Invoke(bufferToTransmit);
            if (_RFSourceParameters.isOn)
            {
                RFButtonONOFFContent = "RF ON";
            }
            else
            {
                RFButtonONOFFContent = "RF OFF";
            }
        }

        public void ToggleSweepStart(object obj)
        {
            //Toggle RF State 
            _RFSourceSweeptype.StartSweep = !_RFSourceSweeptype.StartSweep;
            byte[] bufferToTransmit = Encoding.ASCII.GetBytes(JSONifyModel());
            if (SendData != null)
                SendData?.Invoke(bufferToTransmit);
            if (_RFSourceSweeptype.StartSweep)
                SweepButtonStartContent = "Stop Sweep";
            else
                SweepButtonStartContent = "Start Sweep";

        }

        public RFSourceControlViewModel(RFSourceSweepTypes RFSourceSweeptype, RFSourceParameters SourceParams)
        {

            _RFSourceSweeptype = RFSourceSweeptype;
            SweepType = "Fixed";
            _RFSourceParameters = SourceParams;
            _RfSourceJsonSchema = new RfSourceJsonSchema(1);
            ButtonCommand = new RelayCommand(new Action<object>(HideViews));
            RfButtonCommand = new RelayCommand(new Action<object>(ToggleRf));
            SweepStartCommand = new RelayCommand(new Action<object>(ToggleSweepStart));
        }
    }
}
