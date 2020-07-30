using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.Dialogs.Responses
{
    public abstract class DialogResponse
    {
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        private readonly int code;
        public DialogResponseCode Code
        {
            get
            {
                if (code == 0) return DialogResponseCode.Success;
                return (DialogResponseCode)code;
                //TODO: add a bounds check before the cast
            }
        }
    }

    public enum DialogResponseCode
    {
        Success = -1,
        Canceled = -2,
        Neutral = -3
    }
}
