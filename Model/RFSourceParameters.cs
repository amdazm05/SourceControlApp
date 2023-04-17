using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFSourceControllerApp.Model
{

    class RFSourceParameters
    {

        public double Rf 
        { 
            get; 
            set;
        }
        public double Pri 
        { 
            get; 
            set; 
        }
        public double Pw 
        { 
            get; 
            set; 
        }
        public double Power 
        { 
            get; 
            set; 
        }
        public bool isCW 
        {
            get; 
            set; 
        }

        public RFSourceParameters()
        {

        }
    }
}
