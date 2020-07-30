using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermuxAPICSharp.API
{
    public class CellTowerInfo
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type;
        [JsonProperty(PropertyName = "registered", Required = Required.Always)]
        public bool Registered;
        [JsonProperty(PropertyName = "asu", Required = Required.Always)]
        public int ArbitraryStrength;
        [JsonProperty(PropertyName = "dbm", Required = Required.Always)]
        public int SignalDbm;
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        public int QualityLevel;
        [JsonProperty(PropertyName = "pci", Required = Required.Always)]
        public int PhysicalCellID;
        [JsonProperty(PropertyName = "ci", Required = Required.Default)]
        public int CellIdentity;
        [JsonProperty(PropertyName = "tac", Required = Required.Default)]
        public int TrackingAreaCode;
        [JsonProperty(PropertyName = "mcc", Required = Required.Default)]
        public int MobileCountryCode;
        [JsonProperty(PropertyName = "mnc", Required = Required.Default)]
        public int MobileNetworkCode;
    }
}
