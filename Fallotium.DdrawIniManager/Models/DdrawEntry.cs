using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.DdrawIniManager.Models
{
    internal class DdrawEntry
    {
        internal string Name { get; set; }
        internal object Value { get; set; }
        internal string Category { get; set; }
    }
}
