using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TermuxAPICSharp.API
{
    public class SMSEntry
    {
        [JsonProperty(PropertyName = "threadid", Required = Required.Always)]
        public int ThreadId;
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public SMSType Type;
        [JsonProperty(PropertyName = "read", Required = Required.Always)]
        public bool Read;
        [JsonProperty(PropertyName = "sender", Required = Required.Default)]
        public string SenderName;
        [JsonProperty(PropertyName = "number", Required = Required.Always)]
        public string PhoneNumber;
        [JsonProperty(PropertyName = "received", Required = Required.Always)]
        private string received_string;
        public DateTime ReceivedDate
        {
            get
            {
                string replaced = Regex.Replace(received_string, @"24:(\d\d:\d\d)$", "00:$1");
                DateTime date = DateTime.ParseExact(received_string, "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None);
                return received_string != replaced ? date.AddDays(1) : date;
            }
        }
        [JsonProperty(PropertyName = "body", Required = Required.Always)]
        public string MessageBody;
    }

    public enum SMSType
    {
        Inbox,
        Send,
        Draft,
        Outbox,
        All
    }
}
