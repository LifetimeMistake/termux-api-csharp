using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.Dialogs.Responses
{
    public class DialogTextResponse : DialogResponse
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text;
    }
}
