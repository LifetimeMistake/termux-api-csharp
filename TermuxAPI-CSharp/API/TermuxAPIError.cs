using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class TermuxAPIError
    {
        [JsonProperty(PropertyName = "error", Required = Required.Always)]
        public string Message;
    }
}
