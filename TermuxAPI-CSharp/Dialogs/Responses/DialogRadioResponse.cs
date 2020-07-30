using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.Dialogs.Responses
{
    public class DialogRadioResponse : DialogResponse
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        private readonly string selectedValueText;
        [JsonProperty(PropertyName = "index", Required = Required.Always)]
        private readonly int selectedValueIndex;
        public IndexedValue SelectedValue
        {
            get
            {
                return new IndexedValue(selectedValueIndex, selectedValueText);
            }
        }
    }
}
