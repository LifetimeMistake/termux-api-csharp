using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TermuxAPICSharp.Dialogs.Responses;

namespace TermuxAPICSharp.Dialogs
{
    public class TermuxCounterDialog : TermuxDialog
    {
        public int MinValue;
        public int MaxValue;
        public int StartValue;
        private readonly bool useFields;

        public override string BuildArguments()
        {
            List<string> args = new List<string>();
            args.Add("counter");
            if (!string.IsNullOrEmpty(Title))
                args.Add($"-t \"{Title}\"");
            if(useFields)
            {
                args.Add($"-r {MinValue},{MaxValue},{StartValue}");
            }

            return string.Join(" ", args);
        }

        public override DialogResponse DeserializeResponse(string response)
        {
            return JsonConvert.DeserializeObject<DialogCounterResponse>(response);

        }

        public TermuxCounterDialog(int minValue, int maxValue, int startValue, string title = null)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            StartValue = startValue;
            useFields = true;
        }

        public TermuxCounterDialog(string title = null)
        {
            useFields = false;
        }
    }
}
