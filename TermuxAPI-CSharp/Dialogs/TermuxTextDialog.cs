using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TermuxAPICSharp.Dialogs.Responses;

namespace TermuxAPICSharp.Dialogs
{
    public class TermuxTextDialog : TermuxDialog
    {
        public string Hint;
        public TextDialogInputType InputType;
        public override string BuildArguments()
        {
            List<string> args = new List<string>();
            args.Add("text");
            if (!string.IsNullOrEmpty(Title))
                args.Add($"-t \"{Title}\"");
            if (!string.IsNullOrEmpty(Hint))
                args.Add($"-i \"{Hint}\"");

            switch (InputType)
            {
                case TextDialogInputType.MultiLine:
                    args.Add("-m");
                    break;
                case TextDialogInputType.MultiLinePassword:
                    args.Add("-m");
                    args.Add("-p");
                    break;
                case TextDialogInputType.Numbers:
                    args.Add("-n");
                    break;
                case TextDialogInputType.NumbersPassword:
                    args.Add("-n");
                    args.Add("-p");
                    break;
            }

            return string.Join(" ", args);
        }

        public override DialogResponse DeserializeResponse(string response)
        {
            return JsonConvert.DeserializeObject<DialogTextResponse>(response);
        }

        public TermuxTextDialog(string title = null, string hint = null, TextDialogInputType inputType = TextDialogInputType.Normal)
        {
            Title = title;
            Hint = hint;
            InputType = inputType;
        }
    }

    public enum TextDialogInputType
    {
        Normal,
        MultiLine,
        MultiLinePassword,
        Numbers,
        NumbersPassword
    }
}
