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
            [JsonProperty("SyncId")]
            public int SyncId { get; set; }
            [JsonProperty("SourceIndex")]
            public int SourceIndex { get; set; }
            [JsonProperty("sourceName")]
            public string sourceName { get; set; }
            [JsonProperty("Rf")]
            public double Rf { get;  set;}
            [JsonProperty("Pri")]
            public double Pri { get; set; }
            [JsonProperty("Pw")]
            public double Pw { get; set; }
            [JsonProperty("Power")]
            public double Power { get; set; }
            [JsonProperty("isCW")]
            public bool isCW { get; set; }
            [JsonProperty("isOn")]
            public bool isOn { get; set; }
            [JsonProperty("SweepType")]
            public string SweepType { get; set; }
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
            [JsonProperty("CyclicMode")]
            public bool CyclicMode { get; set; }
            [JsonProperty("WaitTime")]
            public double WaitTime { get; set; }
        }
        [JsonProperty("SourceCount")]
        public int sourceCount;
        [JsonProperty("SourceParameters")]
        public List<SourceParameters> SourceParams { get; set; }

        public RfSourceJsonSchema(int numberOfSources)
        {
            sourceCount = numberOfSources;
            SourceParams = new List<SourceParameters>(numberOfSources);
            for(int i=0; i<numberOfSources;i++)
            {
                SourceParameters sourceParams = new SourceParameters();
                sourceParams.SourceIndex = i;
                sourceParams.SyncId = 7;
                SourceParams.Add(sourceParams);
            }
        }

        //Helpers
        public void SetSourceParamsFromModel(int index , RFSourceParameters Params, RFSourceSweepTypes SweepParams)
        {
            SourceParameters  UpdatedParams = SourceParams[index];
            UpdatedParams.Rf = Params.Rf;
            UpdatedParams.Pri = Params.Pri;
            UpdatedParams.Pw = Params.Pw;
            UpdatedParams.Power = Params.Power;
            UpdatedParams.isCW = Params.isCW;
            UpdatedParams.isOn = Params.isCW;
            UpdatedParams.SweepType = SweepParams.SweepType;
            UpdatedParams.DwellTime = SweepParams.DwellTime;
            UpdatedParams.RfStart = SweepParams.RfStart;
            UpdatedParams.RfStop = SweepParams.RfStop;
            UpdatedParams.RfStep = SweepParams.RfStep;
            UpdatedParams.PowerStart = SweepParams.PowerStart;
            UpdatedParams.PowerStop = SweepParams.PowerStop;
            UpdatedParams.PowerStep = SweepParams.PowerStep;
            UpdatedParams.CyclicMode = SweepParams.CyclicMode;
            UpdatedParams.WaitTime = SweepParams.WaitTime;
            SourceParams[index]  = UpdatedParams;
        }
        public string JsonSerialise()
        {
            string message = JsonConvert.SerializeObject(this);
            return message;
        }
    }
}
