using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RFSourceControllerApp.Model.Data
{
   
    class RfSourceJsonSchema
    {
        public struct SourceParameters
        {
            [JsonProperty("SourceIndex")]
            int SourceIndex { get; set; }
            [JsonProperty("sourceName")]
            public string sourceName { get; set; }
            [JsonProperty("Rf")]
            public double Rf { get; set; }
            [JsonProperty("Pri")]
            public double Pri { get; set; }
            [JsonProperty("Pw")]
            public double Pw { get; set; }
            [JsonProperty("Power")]
            public double Power { get; set; }
            [JsonProperty("isCW")]
            public double isCW { get; set; }
            [JsonProperty("isOn")]
            public double isOn { get; set; }
            [JsonProperty("SweepType")]
            public double SweepType { get; set; }
            [JsonProperty("DwellTime")]
            public double DwellTime { get; set; }
            [JsonProperty("RfStart")]
            public double RfStart { get; set; }
            [JsonProperty("RfStop")]
            public double RfStop { get; set; }
            [JsonProperty("RfStep")]
            public double RfStep { get; set; }
            [JsonProperty("PowerStart")]
            public double PowerStart { get; set; }
            [JsonProperty("PowerStop")]
            public double PowerStop { get; set; }
            [JsonProperty("PowerStep")]
            public double PowerStep { get; set; }
        }
        [JsonProperty("SourceParameters")]
        public List<SourceParameters> SourceParams { get; set; }
        public RfSourceJsonSchema()
        {
            SourceParams = new List<SourceParameters>(3);
            //SourceParameters param1 = new SourceParameters();
            //SourceParams.Add(param1);
            //SourceParams.Add(param1);
            //SourceParams.Add(param1);
        }

        public string JsonSerialise()
        {
            string message = JsonConvert.SerializeObject(this);
            return message;
        }
    }
}
