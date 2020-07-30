using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp
{
    public class InfraredFrequency
    {
        [JsonProperty(PropertyName = "min", Required = Required.Always)]
        public int Min;
        [JsonProperty(PropertyName = "max", Required = Required.Always)]
        public int Max;
    }
}
