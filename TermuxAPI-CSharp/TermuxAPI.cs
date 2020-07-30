using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TermuxAPICSharp.API;
using TermuxAPICSharp.Dialogs;
using TermuxAPICSharp.Dialogs.Responses;

namespace TermuxAPICSharp
{
    public static class TermuxAPI
    {
        /// <summary>
        /// The root of the simulated termux filesystem.
        /// </summary>
        public static string TermuxRoot = "/data/data/com.termux/files";
        /// <summary>
        /// Gets the audio capabilities.
        /// </summary>
        /// <returns>The audio capabilities info.</returns>
        public static AudioCapabilitiesInfo GetAudioInfo()
        {
            if (TermuxBridge.TryExecuteObject("termux-audio-info", null,
                out AudioCapabilitiesInfo audioCapabilities))
            {
                return audioCapabilities;
            }

            return null;
        }

        /// <summary>
        /// Gets the battery status.
        /// </summary>
        /// <returns>The battery info.</returns>
        public static BatteryInfo GetBatteryStatus()
        {
            if (TermuxBridge.TryExecuteObject("termux-battery-status", null,
                out BatteryInfo batteryInfo))
            {
                return batteryInfo;
            }

            return null;
        }

        /// <summary>
        /// Sets the display brightness.
        /// </summary>
        /// <returns><c>true</c>, if display brightness was set, <c>false</c> otherwise.</returns>
        /// <param name="brightness">Brightness value. 0-255 range, pass -1 to turn on auto brightness.</param>
        public static bool SetDisplayBrightness(int brightness)
        {
            string arg;
            if (brightness == -1)
                arg = "auto";
            else
            {
                if (brightness < 0 || brightness > 255)
                    throw new ArgumentOutOfRangeException(nameof(brightness));
                arg = brightness.ToString();
            }

            if(TermuxBridge.TryExecute($"termux-brightness", arg, out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the call log.
        /// </summary>
        /// <returns>The call log.</returns>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit.</param>
        public static CallLog[] GetCallLog(int offset = 0, int limit = 10)
        {
            if(TermuxBridge.TryExecuteObject($"termux-call-log", $"-o {offset} -l {limit}",
                out CallLog[] call_log))
            {
                return call_log;
            }

            return null;
        }

        /// <summary>
        /// Gets the camera info.
        /// </summary>
        /// <returns>The camera info.</returns>
        public static CameraInfo[] GetCameraInfo()
        {
            if(TermuxBridge.TryExecuteObject("termux-camera-info", null, 
                out CameraInfo[] cameraInfo))
            {
                return cameraInfo;
            }

            return null;
        }

        public static bool TakePhoto(string path, int cameraId = 0)
        {
            if(string.IsNullOrEmpty(path))
            {
                return false;
            }

            if (TermuxBridge.TryExecute($"termux-camera-photo", $"-c {cameraId} {path}", 
                out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static string GetClipboardContent()
        {
            if(TermuxBridge.TryExecute("termux-clipboard-get", null, out string content))
            {
                return content;
            }

            return null;
        }

        public static bool SetClipboardContent(string text)
        {
            if(TermuxBridge.TryExecute($"termux-clipboard-set", text, out string output))
            {
                if(output.Length == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static Contact[] GetContactList()
        {
            if(TermuxBridge.TryExecuteObject("termux-contact-list", null, out Contact[] contactList))
            {
                return contactList;
            }

            return null;
        }

        public static DialogResponse ShowDialog(TermuxDialog dialog)
        {
            Console.WriteLine(dialog.BuildArguments());
            if(TermuxBridge.TryExecute($"termux-dialog", dialog.BuildArguments(),
                out string response))
            {
                try
                {
                    return dialog.DeserializeResponse(response);
                }
                catch(Exception)
                {
                    return null;
                }
            }

            return null;
        }

        public static bool DownloadURLResource(string URL, string NotificationTitle = null, string NotificationDesc = null)
        {
            if(string.IsNullOrEmpty(URL))
            {
                return false;
            }

            List<string> args = new List<string>();
            if(!string.IsNullOrEmpty(NotificationTitle))
                args.Add($"-t \"{NotificationTitle}\"");
            if (!string.IsNullOrEmpty(NotificationDesc))
                args.Add($"-d \"{NotificationDesc}\"");
            args.Add($"\"{URL}\"");

            if (TermuxBridge.TryExecute($"termux-download", string.Join(" ", args),
                out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static FingerprintAuthInfo AuthenticateFingerprint()
        {
           if(TermuxBridge.TryExecuteObject("termux-fingerprint", null,
               out FingerprintAuthInfo fingerprintAuthInfo))
            {
                return fingerprintAuthInfo;
            }

            return null;
        }

        public static InfraredFrequency[] GetAvailableInfraredFrequencies()
        {
            if(TermuxBridge.TryExecuteObject("termux-infrared-frequencies", null,
                out InfraredFrequency[] infraredFrequencies))
            {
                return infraredFrequencies;
            }

            return null;
        }

        public static bool InfraredTransmit(int frequency, int[] pattern)
        {
            if(TermuxBridge.TryExecute("termux-infrared-transmit", 
            $"-f {frequency} {string.Join(",", pattern)}", out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        //TODO: implement TermuxJobScheduler

        public static LocationInfo GetLocation(LocationProvider provider = LocationProvider.GPS,
         LocationRequestType request = LocationRequestType.Once)
        {
            List<string> args = new List<string>();
            args.Add($"-p {provider.ToString().ToLower()}");
            args.Add($"-r {request.ToString().ToLower()}");

            if (TermuxBridge.TryExecuteObject("termux-location", string.Join(" ", args),
                out LocationInfo locationInfo))
            {
                return locationInfo;
            }

            return null;
        }

        public static bool MediaPlayerPlayFile(string filePath)
        {
            if(string.IsNullOrEmpty(filePath))
            {
                return false;
            }
            if (TermuxBridge.TryExecute("termux-media-player", 
                $"play \"{filePath}\"", out string output))
            {
                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch
                {
                    if (output.StartsWith("Error", StringComparison.CurrentCulture))
                        return false;
                }

                return true;
            }

            return false;
        }

        public static bool MediaPlayerSendCmd(MediaPlayerCommand command)
        {
            string cmd_str = "";
            switch (command)
            {
                case MediaPlayerCommand.Resume:
                    cmd_str = "play";
                    break;
                case MediaPlayerCommand.Pause:
                    cmd_str = "pause";
                    break;
                case MediaPlayerCommand.Stop:
                    cmd_str = "stop";
                    break;
            }

            if (TermuxBridge.TryExecute($"termux-media-player", cmd_str,
                out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static string MediaPlayerGetInfo()
        {
            if (TermuxBridge.TryExecute("termux-media-player", null,
                out string info))
            {
                return info;
            }

            return null;
        }

        public static string MediaScan(string[] files, bool recursive = false, bool verbose = false)
        {
            List<string> args = new List<string>();
            if (recursive)
                args.Add("-r");
            if (verbose)
                args.Add("v");
            foreach (string file in files)
                args.Add($"\"{file}\"");

            if (TermuxBridge.TryExecute("termux-media-scan", string.Join(" ", args),
                out string output))
            {
                return output;
            }

            return null;
        }

        // TODO: implement a wrapper for termux-notification (time intensive!)

        // TODO: implement a wrapper for termux-record-microphone (easy enough but im hella tired rn)

        public static bool ShareFile(ShareAction action = ShareAction.View, string contentType = null, bool useDefaultReceiver = false, string title = null)
        {
            List<string> args = new List<string>();
            args.Add($"-a {action.ToString().ToLower()}");
            if (!string.IsNullOrEmpty(contentType))
                args.Add($"-c {contentType}");
            if (useDefaultReceiver)
                args.Add("-d");
            if (!string.IsNullOrEmpty(title))
                args.Add($"-t \"{title}\"");

            if (TermuxBridge.TryExecute("termux-share",
            string.Join(" ", args), out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static SMSEntry[] GetSMSList(SMSType messageType, int offset = 0, int limit = 10, bool showPhoneNumbers = true, bool showDates = true)
        {
            List<string> args = new List<string>();
            args.Add($"-t {messageType.ToString().ToLower()}");
            args.Add($"-o {offset}");
            args.Add($"-l {limit}");
            if (showPhoneNumbers)
                args.Add("-n");
            if (showDates)
                args.Add("-d");

            if(TermuxBridge.TryExecuteObject("termux-sms-list", string.Join(" ", args), out SMSEntry[] smsEntries))
            {
                return smsEntries;
            }

            return null;
        }

        public static bool SendSMS(string[] phone_numbers, string body)
        {
            if(phone_numbers.Length == 0)
            {
                return false;
            }

            if(string.IsNullOrEmpty(body))
            {
                return false;
            }

            if (TermuxBridge.TryExecute("termux-send-sms",
           $"-n {string.Join(",", phone_numbers)} \"{body}\"", out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Request a file from the system and write it to the specified file.
        /// </summary>
        /// <param name="output_file">Output file path. (Make sure it's writable)</param>
        /// <returns><c>true</c>, if no error was reported, <c>false</c> otherwise.</returns>
        public static bool StorageGetFile(string output_file)
        {
            if(string.IsNullOrEmpty(output_file))
            {
                return false;
            }

            if (TermuxBridge.TryExecute("termux-storage-get",
            output_file, out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static bool MakePhoneCall(string phoneNumber)
        {
            if(string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            if (TermuxBridge.TryExecute("termux-telephony-call",
            phoneNumber, out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static CellTowerInfo[] GetCellTowerInfo()
        {
            if (TermuxBridge.TryExecuteObject("termux-telephony-cellinfo", null,
                out CellTowerInfo[] cellTowerInfo))
            {
                return cellTowerInfo;
            }

            return null;
        }

        public static DeviceInfo TelephonyGetDeviceInfo()
        {
            if (TermuxBridge.TryExecuteObject("termux-telephony-cellinfo", null,
                out DeviceInfo deviceInfo))
            {
                return deviceInfo;
            }

            return null;
        }

        public static bool ShowToast(string text, string forecolor = null, string backcolor = null, ToastPosition position = ToastPosition.Center, bool shortToast = false)
        {
            if(string.IsNullOrEmpty(text))
            {
                return false;
            }

            List<string> args = new List<string>();
            if (!string.IsNullOrEmpty(forecolor))
                args.Add($"-c \"{forecolor}\"");
            if (!string.IsNullOrEmpty(backcolor))
                args.Add($"-b \"{backcolor}\"");
            switch (position)
            {
                case ToastPosition.Top:
                    args.Add("-g top");
                    break;
                case ToastPosition.Center:
                    args.Add("-g middle");
                    break;
                case ToastPosition.Bottom:
                    args.Add("-g bottom");
                    break;
            }
            if (shortToast)
                args.Add("-s");
            args.Add(text.Replace("\"", "\\\""));

            if (TermuxBridge.TryExecute("termux-toast",
            string.Join(" ", args), out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static void EnableFlashlight(bool enabled)
        {
            string state = enabled ? "on" : "off";
            TermuxBridge.TryExecute("termux-torch", state, out string output);
        }

        public static TTSEngine[] GetTTSEngineList()
        {
            if (TermuxBridge.TryExecuteObject("termux-tts-engines", null,
                out TTSEngine[] engines))
            {
                return engines;
            }

            return null;
        }

        public static bool TTSSpeak(string text, string engine = null, string language = null
        , string languageRegion = null, string languageVariant = null, float pitch = 1.0f, float rate = 1.0f, AudioStream channel = AudioStream.Notification)
        {
            if(string.IsNullOrEmpty(text))
            {
                return false;
            }

            List<string> args = new List<string>();
            if (!string.IsNullOrEmpty(engine))
                args.Add($"-e \"{engine}\"");
            if (!string.IsNullOrEmpty(language))
                args.Add($"-l \"{language}\"");
            if (!string.IsNullOrEmpty(languageRegion))
                args.Add($"-n \"{languageRegion}\"");
            if (!string.IsNullOrEmpty(languageVariant))
                args.Add($"-v \"{languageVariant}\"");
            args.Add($"-p {pitch}");
            args.Add($"-r {rate}");
            switch (channel)
            {
                case AudioStream.Alarm:
                    args.Add("-s ALARM");
                    break;
                case AudioStream.Music:
                    args.Add("-s MUSIC");
                    break;
                case AudioStream.Notification:
                    args.Add("-s NOTIFICATION");
                    break;
                case AudioStream.Ring:
                    args.Add("-s RING");
                    break;
                case AudioStream.System:
                    args.Add("-s SYSTEM");
                    break;
                case AudioStream.Voicecall:
                    args.Add("-s VOICE_CALL");
                    break;
            }

            if (TermuxBridge.TryExecute("termux-tts-speak",
            string.Join(" ", args), out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        //TODO: implement termux-usb (very low priority)

        public static void Vibrate(bool force, int durationMs = 1000)
        {
            TermuxBridge.TryExecute("termux-vibrate", $"-d {durationMs}{(force ? " -f" : "")}", out string output);
        }

        public static VolumeInfo[] GetVolumeInfoRaw()
        {
            if (TermuxBridge.TryExecuteObject("termux-volume", null,
                out VolumeInfo[] volumeInfo))
            {
                return volumeInfo;
            }

            return null;
        }

        public static VolumeCollection GetVolumeInfo()
        {
            VolumeInfo[] info = GetVolumeInfoRaw();
            if (info == null) return null;
            return new VolumeCollection(info);
        }

        public static bool SetVolume(AudioStream stream, int volume)
        {
            string stream_name = "";
            switch (stream)
            {
                case AudioStream.Alarm:
                    stream_name = "alarm";
                    break;
                case AudioStream.Music:
                    stream_name = "music";
                    break;
                case AudioStream.Notification:
                    stream_name = "notification";
                    break;
                case AudioStream.Ring:
                    stream_name = "ring";
                    break;
                case AudioStream.System:
                    stream_name = "system";
                    break;
                case AudioStream.Voicecall:
                    stream_name = "call";
                    break;
            }

            if (TermuxBridge.TryExecute("termux-volume",
            $"{stream_name} {volume}", out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static bool SetWallpaperFromFile(string path, bool setOnLockscreen)
        {
            if(string.IsNullOrEmpty(path))
            {
                return false;
            }

            if (TermuxBridge.TryExecute("termux-wallpaper",
            $"-f \"{path}\"{(setOnLockscreen ? "-l" : "")}", out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static bool SetWallpaperFromURL(string url, bool setOnLockscreen)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }

            if (TermuxBridge.TryExecute("termux-wallpaper",
            $"-u \"{url}\"{(setOnLockscreen ? "-l" : "")}", out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static WifiConnectionInfo GetWifiConnectionInfo()
        {
            if (TermuxBridge.TryExecuteObject("termux-wifi-connectioninfo", null,
                out WifiConnectionInfo info))
            {
                return info;
            }

            return null;
        }

        public static bool EnableWiFi(bool enabled)
        {
            if (TermuxBridge.TryExecute("termux-wifi-enable",
            enabled.ToString().ToLower(), out string output))
            {
                if (output.Length == 0)
                {
                    return true;
                }

                try
                {
                    TermuxAPIError error = JsonConvert.DeserializeObject<TermuxAPIError>(output);
                    Console.WriteLine("Termux API has returned an error: " + error.Message);
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Termux API has returned an error (non-JSON format): " + output);
                    return false;
                }
            }

            return false;
        }

        public static WifiScanInfo[] GetWifiScanInfo()
        {
            if (TermuxBridge.TryExecuteObject("termux-wifi-scaninfo", null,
                out WifiScanInfo[] info))
            {
                return info;
            }

            return null;
        }
    }
}
