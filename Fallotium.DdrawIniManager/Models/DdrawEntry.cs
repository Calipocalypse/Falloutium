using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.DdrawIniManager
{
    public class DdrawEntry
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsFavouriteSetting { get; set; }

        public DdrawEntry(string name, string category, string value, string description, bool isCommented, bool isFavouriteSeting)
        {
            Name = name;
            Description = description;
            Category = category;
            Value = value;
            IsEnabled = !isCommented;
            IsFavouriteSetting = isFavouriteSeting;
        }
    }
}
