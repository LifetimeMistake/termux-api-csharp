using System;
using TermuxAPICSharp.Dialogs.Responses;

namespace TermuxAPICSharp.Dialogs
{
    public abstract class TermuxDialog
    {
        public string Title;
        public abstract string BuildArguments();
        public abstract DialogResponse DeserializeResponse(string response);
    }
}
