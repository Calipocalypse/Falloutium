using System.Collections.Generic;

namespace Fallotium.DdrawIniManager
{
    public class IniEntry
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int LineNumber { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsFavouriteSetting { get; set; }
        public List<string> SuggestedValues { get; set; } //ListView Binding

        public IniEntry(string name, string category, string value, string description, int lineNumber, bool isCommented, bool isFavouriteSeting, List<string> suggestedValues)
        {
            Name = name;
            Description = description;
            LineNumber = lineNumber;
            Category = category;
            Value = value;
            IsEnabled = !isCommented;
            IsFavouriteSetting = isFavouriteSeting;
            SuggestedValues = suggestedValues;
        }
    }
}
