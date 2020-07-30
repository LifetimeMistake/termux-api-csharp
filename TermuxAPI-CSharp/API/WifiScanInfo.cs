using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class WifiScanInfo
    {
        [JsonProperty("bssid", Required = Required.Always)]
        public string BSSID;

        [JsonProperty("frequency_mhz", Required = Required.Always)]
        public int FrequencyMhz;

        [JsonProperty("rssi", Required = Required.Always)]
        public int RSSI;

        [JsonProperty("ssid", Required = Required.Always)]
        public string SSID;

        [JsonProperty("timestamp", Required = Required.Always)]
        public int Timestamp;

        [JsonProperty("channel_bandwidth_mhz", Required = Required.Always)]
        public string ChannelBandwidthMhz;

        [JsonProperty("center_frequency_mhz")]
        public int? CenterFrequencyMhz;
    }
}
