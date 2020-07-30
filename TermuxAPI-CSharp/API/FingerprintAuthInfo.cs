using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class FingerprintAuthInfo
    {
        [JsonProperty(PropertyName = "errors", Required = Required.Always)]
        public string[] Errors;
        [JsonProperty(PropertyName = "failed_attempts", Required = Required.Always)]
        public int FailedAttemptCount;
        [JsonProperty(PropertyName = "auth_result", Required = Required.Always)]
        private string auth_result;
        public FingerprintAuthResult AuthResult
        {
            get
            {
                switch(auth_result)
                {
                    case "AUTH_RESULT_SUCCESS":
                        return FingerprintAuthResult.Success;
                    case "AUTH_RESULT_FAILURE":
                        return FingerprintAuthResult.Failure;
                    default:
                        return FingerprintAuthResult.Unknown;
                }
            }
        }

    }

    public enum FingerprintAuthResult
    {
        Success,
        Failure,
        Unknown
    }
}
