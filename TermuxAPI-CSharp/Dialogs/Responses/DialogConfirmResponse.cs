using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.Dialogs.Responses
{
    public class DialogConfirmResponse : DialogResponse
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string ChoiceString;
        public DialogConfirmChoice Choice
        {
            get
            {
                return (ChoiceString == "yes") ? DialogConfirmChoice.Yes : DialogConfirmChoice.No;
            }
        }
    }

    public enum DialogConfirmChoice
    {
        Yes,
        No
    }
}
