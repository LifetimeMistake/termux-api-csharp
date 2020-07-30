using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class TTSEngine
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name;

        [JsonProperty("label", Required = Required.Always)]
        public string Label;

        [JsonProperty("default", Required = Required.Always)]
        public bool Default;
    }
}
