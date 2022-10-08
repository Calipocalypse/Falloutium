using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.MsgScanner.Models
{
    internal class BadLine
    {
        internal int LineNumber { get; set; }
        internal string FilePath { get; set; }
        //internal string FileName => FilePath.Substring()
        internal string LineContent { get; set; }
        internal int BadPositionInLineNumber { get; set; }

        public BadLine(int lineNumber, string filePath, string lineContent, int badPositionInLineNumber)
        {
            LineNumber = lineNumber;
            FilePath = filePath;
            LineContent = lineContent;
            BadPositionInLineNumber = badPositionInLineNumber;
        }
    }
}
