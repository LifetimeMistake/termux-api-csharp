using System;
using Newtonsoft.Json;

namespace TermuxAPICSharp
{
    public class IndexedValue
    {
        [JsonProperty(PropertyName = "index", Required = Required.Always)]
        public int Index;
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text;

        public IndexedValue()
        {
        }

        public IndexedValue(int index, string text)
        {
            Index = index;
            Text = text;
        }
    }
}
