using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TermuxAPICSharp.Dialogs.Responses;

namespace TermuxAPICSharp.Dialogs
{
    public class TermuxRadioDialog : TermuxDialog
    {
        public string[] Values;

        public override string BuildArguments()
        {
            List<string> args = new List<string>();
            args.Add("radio");
            if (!string.IsNullOrEmpty(Title))
                args.Add($"-t \"{Title}\"");
            args.Add($"-v \"{string.Join(",", Values)}\"");

            return string.Join(" ", args);
        }

        public override DialogResponse DeserializeResponse(string response)
        {
            return JsonConvert.DeserializeObject<DialogRadioResponse>(response);
        }

        public TermuxRadioDialog(string[] values, string title = null)
        {
            Title = title;
            Values = values;
        }
    }
}
