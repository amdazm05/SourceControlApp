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
        public string SweepType;

        //Sweep related variables 
        public double   DwellTime;
        public double   RfStart;
        public double   RfStop;
        public double   RfStep;
        public double   PowerStart;
        public double   PowerStop;
        public double   PowerStep;
        public bool     isTriggered;
        public RFSourceSweepTypes()
        {
            SweepType = null;
        }
    
    }
}
