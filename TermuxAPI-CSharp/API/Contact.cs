using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class Contact
    {
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name;
        [JsonProperty(PropertyName = "number", Required = Required.Always)]
        public string PhoneNumber;
    }
}
