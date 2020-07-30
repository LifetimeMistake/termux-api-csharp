using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp.API
{
    public class CameraInfo
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public int CameraId;
        [JsonProperty(PropertyName = "facing", Required = Required.Always)]
        public string Facing;
        [JsonProperty(PropertyName = "jpeg_output_sizes", Required = Required.Always)]
        public TermuxSize[] JpegOutputSizes;
        [JsonProperty(PropertyName = "focal_lengths", Required = Required.Always)]
        public double[] FocalLengths;
        [JsonProperty(PropertyName = "auto_exposure_modes", Required = Required.Always)]
        public string[] AutoExposureModes;
        [JsonProperty(PropertyName = "physical_size", Required = Required.Always)]
        public TermuxSize PhysicalSize;
        [JsonProperty(PropertyName = "capabilities", Required = Required.Always)]
        public string[] Capabilities;
    }

    public class TermuxSize
    {
        [JsonProperty(PropertyName = "width", Required = Required.Always)]
        public double Width;
        [JsonProperty(PropertyName = "height", Required = Required.Always)]
        public double Height;
    }
}
