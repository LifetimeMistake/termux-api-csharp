using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class AudioCapabilitiesInfo
    {
        [JsonProperty(PropertyName = "PROPERTY_OUTPUT_SAMPLE_RATE", Required = Required.Always)]
        public string OutputSampleRate;
        [JsonProperty(PropertyName = "PROPERTY_OUTPUT_FRAMES_PER_BUFFERs", Required = Required.Always)]
        public string OutputFramesPerBuffer;
        [JsonProperty(PropertyName = "AUDIOTRACK_SAMPLE_RATE", Required = Required.Always)]
        public int AudioTrackSampleRate;
        [JsonProperty(PropertyName = "AUDIOTRACK_BUFFER_SIZE_IN_FRAMES", Required = Required.Always)]
        public int AudioTrackBufferSizeFrames;
        [JsonProperty(PropertyName = "AUDIOTRACK_SAMPLE_RATE_LOW_LATENCY", Required = Required.Always)]
        public int AudioTrackSampleRateLowLatency;
        [JsonProperty(PropertyName = "AUDIOTRACK_BUFFER_SIZE_IN_FRAMES_LOW_LATENCY", Required = Required.Always)]
        public int AudioTrackBufferSizeFramesLowLatency;
        [JsonProperty(PropertyName = "BLUETOOTH_A2DP_IS_ON", Required = Required.Always)]
        public bool BluetoothA2DPOn;
        [JsonProperty(PropertyName = "WIREDHEADSET_IS_CONNECTED", Required = Required.Always)]
        public bool WiredHeadsetConnected;

        public AudioCapabilitiesInfo()
        {
        }
    }
}
