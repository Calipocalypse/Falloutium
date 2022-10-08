using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.MsgScanner.ExtensionMethods
{
    internal static class CharsExtension
    {
        public static char OppositeChar(this char character)
        {
            if (character == '{') return '}';
            else if (character == '}') return '{';
            else throw new NotImplementedException();
        }
    }
}
