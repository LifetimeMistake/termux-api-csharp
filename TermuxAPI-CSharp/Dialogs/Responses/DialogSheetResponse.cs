using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.Dialogs.Responses
{
    public class DialogSheetResponse : DialogResponse
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        private string selectedValueText;
        [JsonProperty(PropertyName = "index", Required = Required.Always)]
        private int selectedValueIndex;
        public IndexedValue SelectedValue
        {
            get
            {
                return new IndexedValue(selectedValueIndex, selectedValueText);
            }
        }
    }
}
