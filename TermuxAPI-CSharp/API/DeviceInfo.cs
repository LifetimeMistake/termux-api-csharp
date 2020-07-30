using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class DeviceInfo
    {
        [JsonProperty("data_enabled", Required = Required.Always)]
        public string DataEnabled;

        [JsonProperty("data_activity", Required = Required.Always)]
        public string DataActivity;

        [JsonProperty("data_state", Required = Required.Always)]
        public string DataState;

        [JsonProperty("device_id", Required = Required.Always)]
        public string DeviceId;

        [JsonProperty("device_software_version", Required = Required.Always)]
        public string DeviceSoftwareVersion;

        [JsonProperty("phone_count", Required = Required.Always)]
        public int PhoneCount;

        [JsonProperty("phone_type", Required = Required.Always)]
        public string PhoneType;

        [JsonProperty("network_operator", Required = Required.Always)]
        public string NetworkOperator;

        [JsonProperty("network_operator_name", Required = Required.Always)]
        public string NetworkOperatorName;

        [JsonProperty("network_country_iso", Required = Required.Always)]
        public string NetworkCountryIso;

        [JsonProperty("network_type", Required = Required.Always)]
        public string NetworkType;

        [JsonProperty("network_roaming", Required = Required.Always)]
        public bool NetworkRoaming;

        [JsonProperty("sim_country_iso", Required = Required.Always)]
        public string SimCountryIso;

        [JsonProperty("sim_operator", Required = Required.Always)]
        public string SimOperator;

        [JsonProperty("sim_operator_name", Required = Required.Always)]
        public string SimOperatorName;

        [JsonProperty("sim_serial_number", Required = Required.Always)]
        public string SimSerialNumber;

        [JsonProperty("sim_subscriber_id", Required = Required.Always)]
        public string SimSubscriberId;

        [JsonProperty("sim_state", Required = Required.Always)]
        public string SimState;
    }
}
