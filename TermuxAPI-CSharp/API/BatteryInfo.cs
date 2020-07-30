using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class BatteryInfo
    {
        [JsonProperty(PropertyName = "health", Required = Required.Always)]
        public string Health;
        [JsonProperty(PropertyName = "percentage", Required = Required.Always)]
        public int Percentage;
        [JsonProperty(PropertyName = "plugged", Required = Required.Always)]
        public ChargerStatus ChargerStatus;
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public BatteryStatus BatteryStatus;
        [JsonProperty(PropertyName = "temperature", Required = Required.Always)]
        public double Temperature;
        [JsonProperty(PropertyName = "current", Required = Required.Always)]
        public int Current;
    }

    public enum ChargerStatus
    {
        Plugged,
        Unplugged
    }

    public enum BatteryStatus
    {
        Charging,
        Discharging
    }
}
