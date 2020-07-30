using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TermuxAPICSharp.Dialogs.Responses;

namespace TermuxAPICSharp.Dialogs
{
    public class TermuxSpeechDialog : TermuxDialog
    {
        public string Hint;
        public override string BuildArguments()
        {
            List<string> args = new List<string>();
            args.Add("speech");
            if (!string.IsNullOrEmpty(Title))
                args.Add($"-t \"{Title}\"");
            if (!string.IsNullOrEmpty(Hint))
                args.Add($"-i \"{Hint}\"");

            return string.Join(" ", args);
        }

        public override DialogResponse DeserializeResponse(string response)
        {
            return JsonConvert.DeserializeObject<DialogSpeechResponse>(response);
        }

        public TermuxSpeechDialog(string title = null, string hint = null)
        {
            Title = title;
            Hint = hint;
        }
    }
}
