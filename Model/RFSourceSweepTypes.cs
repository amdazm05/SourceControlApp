using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RFSourceControllerApp.Model
{
    class RFSourceSweepTypes
    {
        //Type of sweep
        public string SweepType
        {
            get;
            set;
        }
        //Sweep related variables 
        public double   DwellTime
        {
            get;
            set;
        }
        public double   RfStart
        { 
            get; 
            set; 
        }
        public double   RfStop
        { 
            get; 
            set; 
        }
        public double   RfStep
        { 
            get; 
            set; 
        }
        public double   PowerStart
        { 
            get; 
            set; 
        }
        public double   PowerStop
        { 
            get; 
            set; 
        }
        public double   PowerStep
        { 
            get; 
            set; 
        }
        public bool StartSweep
        { 
            get; 
            set; 
        }

        public double   StepSize
        {
            get;
            set;
        }

        public bool CyclicMode
        {
            get;
            set;
        }

        public double WaitTime
        {
            get;
            set;
        }


        public RFSourceSweepTypes()
        {
            SweepType = null;
        }
    
    }
}
