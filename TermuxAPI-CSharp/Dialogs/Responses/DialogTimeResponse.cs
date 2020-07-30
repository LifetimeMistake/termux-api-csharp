using System;
using System.Globalization;
using Newtonsoft.Json;

namespace TermuxAPICSharp.Dialogs.Responses
{
    public class DialogTimeResponse : DialogResponse
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string TimeString;
        public DateTime Time
        {
            get
            {
                return DateTime.ParseExact(TimeString, @"mm\:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
        }
    }
}
