using System;
using System.Collections.Generic;
using TermuxAPICSharp.Dialogs.Responses;

namespace TermuxAPICSharp.Dialogs
{
    public class TermuxDatepickerDialog : TermuxDialog
    {
        public string CustomSimpleDateFormat;

        public override string BuildArguments()
        {
            List<string> args = new List<string>();
            args.Add("date");
            if (!string.IsNullOrEmpty(Title))
                args.Add($"-t \"{Title}\"");
            if (!string.IsNullOrEmpty(CustomSimpleDateFormat))
                args.Add($"-d \"{CustomSimpleDateFormat}\"");

            return string.Join(" ", args);
        }

        public override DialogResponse DeserializeResponse(string response)
        {
            //TODO: add response
            return null;
        }

        public TermuxDatepickerDialog(string customSimpleDateFormat = null, string title = null)
        {
            CustomSimpleDateFormat = customSimpleDateFormat;
            Title = title;
        }
    }
}
