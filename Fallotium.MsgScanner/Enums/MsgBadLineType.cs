using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.MsgScanner.Enums
{
    internal enum MsgBadLineType : byte
    {
        Exceeds1024 = 0,
        WordCount53 = 1,
        LineBreakNoTrailSpaceAsLastCharAllowed = 2,
        IndexNotUnique = 3,
        BracketsSyntaxError = 4
    }
}
