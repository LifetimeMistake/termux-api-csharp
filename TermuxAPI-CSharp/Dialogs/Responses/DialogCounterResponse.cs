using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.Dialogs.Responses
{
    public class DialogCounterResponse : DialogResponse
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string SelectedNumberString;
        public int SelectedNumber
        {
            get
            {
                return int.Parse(SelectedNumberString);
            }
        }
    }
}
