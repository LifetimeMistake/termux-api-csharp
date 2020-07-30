using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.Dialogs.Responses
{
    public class DialogCheckboxResponse : DialogResponse
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string SelectedValuesString;
        [JsonProperty(PropertyName = "values", Required = Required.Always)]
        public IndexedValue[] SelectedValues;
    }
}
