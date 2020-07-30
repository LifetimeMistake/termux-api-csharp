using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TermuxAPICSharp.Dialogs.Responses;

namespace TermuxAPICSharp.Dialogs
{
    public class TermuxTimeDialog : TermuxDialog
    {
        public override string BuildArguments()
        {
            List<string> args = new List<string>();
            args.Add("time");
            if (!string.IsNullOrEmpty(Title))
                args.Add($"-t \"{Title}\"");

            return string.Join(" ", args);
        }

        public override DialogResponse DeserializeResponse(string response)
        {
            return JsonConvert.DeserializeObject<DialogTimeResponse>(response);
        }

        public TermuxTimeDialog(string title = null)
        {
            Title = title;
        }
    }
}
