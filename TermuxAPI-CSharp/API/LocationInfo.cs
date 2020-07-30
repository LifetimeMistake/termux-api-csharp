using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class LocationInfo
    {
        [JsonProperty(PropertyName = "latitude", Required = Required.Always)]
        public double Latitude;
        [JsonProperty(PropertyName = "longitude", Required = Required.Always)]
        public double Longitude;
        [JsonProperty(PropertyName = "altitude", Required = Required.Always)]
        public double Altitude;
        [JsonProperty(PropertyName = "accuracy", Required = Required.Always)]
        public double AccuracyMeters;
        [JsonProperty(PropertyName = "vertical_accuracy", Required = Required.Always)]
        public double VerticalAccuracy;
        [JsonProperty(PropertyName = "bearing", Required = Required.Always)]
        public double Bearing;
        [JsonProperty(PropertyName = "speed", Required = Required.Always)]
        public double Speed;
        [JsonProperty(PropertyName = "elapsedMs", Required = Required.Always)]
        public int ElapsedMs;
        [JsonProperty(PropertyName = "provider", Required = Required.Always)]
        public LocationProvider Provider;
    }

    public enum LocationProvider
    {
        GPS,
        Network,
        Passive
    }

    public enum LocationRequestType
    {
        Once,
        Last
    }
}
