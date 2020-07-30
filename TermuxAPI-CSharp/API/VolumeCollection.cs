using System;
using System.Linq;
namespace TermuxAPICSharp.API
{
    public class VolumeCollection
    {
        private readonly VolumeInfo[] rawInfo;
        //  You should always perform a null-check when getting data from these properties
        public VolumeInfo AlarmVolume { get { return GetStream("alarm"); } }
        public VolumeInfo MusicVolume { get { return GetStream("music"); } }
        public VolumeInfo NotificationVolume { get { return GetStream("notification"); } }
        public VolumeInfo RingVolume { get { return GetStream("ring"); } }
        public VolumeInfo SystemVolume { get { return GetStream("system"); } }
        public VolumeInfo CallVolume { get { return GetStream("call"); } }

        public VolumeCollection(VolumeInfo[] volumeInfo)
        {
            rawInfo = volumeInfo;
        }

        public VolumeInfo GetStream(string name)
        {
            VolumeInfo info = rawInfo.First(v => v.StreamName == name);
            return info;
        }
    }
}
