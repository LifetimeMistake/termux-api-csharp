using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class CallLog
    {
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string CallerName;
        [JsonProperty(PropertyName = "phone_number", Required = Required.Always)]
        public string PhoneNumber;
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public CallType CallType;
        [JsonProperty(PropertyName = "date", Required = Required.Always)]
        private readonly string date_string;
        [JsonProperty(PropertyName = "duration", Required = Required.Always)]
        private readonly string duration_string;
        public TimeSpan Duration
        {
            get
            {
                return TimeSpan.ParseExact(duration_string, @"mm\:ss",
                    CultureInfo.InvariantCulture, TimeSpanStyles.None);
            }
        }
        public DateTime Date
        {
            get
            {
                string replaced = Regex.Replace(date_string, @"24:(\d\d:\d\d)$", "00:$1");
                DateTime date = DateTime.ParseExact(date_string, "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None);
                return date_string != replaced ? date.AddDays(1) : date;
            }
        }

        public string Date_string => date_string;
    }

    public enum CallType
    {
        Incoming,
        Outgoing,
        Missed,
        Rejected
    }
}
