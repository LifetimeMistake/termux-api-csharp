using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class VolumeInfo
    {
        [JsonProperty("stream", Required = Required.Always)]
        public string StreamName;

        [JsonProperty("volume", Required = Required.Always)]
        public int Volume;

        [JsonProperty("max_volume", Required = Required.Always)]
        public int MaxVolume;

        public double VolumePercentage
        {
            get
            {
                return Math.Round(((double)Volume / (double)MaxVolume) * 100, 2);
            }
        }
    }
}
