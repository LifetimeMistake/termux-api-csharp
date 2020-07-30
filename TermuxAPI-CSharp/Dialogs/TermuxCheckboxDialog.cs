using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TermuxAPICSharp.Dialogs.Responses;

namespace TermuxAPICSharp.Dialogs
{
    public class TermuxCheckboxDialog : TermuxDialog
    {
        public string[] Values;

        public override string BuildArguments()
        {
            List<string> args = new List<string>();
            args.Add("checkbox");
            if (!string.IsNullOrEmpty(Title))
                args.Add($"-t \"{Title}\"");
            args.Add($"-v \"{string.Join(",", Values)}\"");

            return string.Join(" ", args);
        }

        public override DialogResponse DeserializeResponse(string response)
        {
            return JsonConvert.DeserializeObject<DialogCheckboxResponse>(response);
        }

        public TermuxCheckboxDialog(string[] values, string title = null)
        {
            Title = title;
            Values = values;
        }
    }
}
