using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class WifiConnectionInfo
    {
        [JsonProperty("bssid", Required = Required.Always)]
        public string BSSID;

        [JsonProperty("frequency_mhz", Required = Required.Always)]
        public int FrequencyMhz;

        [JsonProperty("ip", Required = Required.Always)]
        public string IPAddress;

        [JsonProperty("link_speed_mbps", Required = Required.Always)]
        public int LinkSpeedMbps;

        [JsonProperty("mac_address", Required = Required.Always)]
        public string MacAddress;

        [JsonProperty("network_id", Required = Required.Always)]
        public int NetworkId;

        [JsonProperty("rssi", Required = Required.Always)]
        public int RSSI;

        [JsonProperty("ssid", Required = Required.Always)]
        public string SSID;

        [JsonProperty("ssid_hidden", Required = Required.Always)]
        public bool SSIDHidden;

        [JsonProperty("supplicant_state", Required = Required.Always)]
        public string SupplicantState;
    }
}
