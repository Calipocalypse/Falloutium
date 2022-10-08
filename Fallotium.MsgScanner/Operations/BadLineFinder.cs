using Fallotium.MsgScanner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Fallotium.MsgScanner.Operations
{
    internal class BadLineFinder
    {
        internal List<BadLine> BadLines { get; set; }
        internal BadLineFinder(string filePath)
        {
            FindAndAddBadLines(filePath);
        }

        public void Test(string filePath)
        {
            using (File.Open(filePath, FileMode.Open))
            {
                var content = File.ReadAllLines(filePath);
                int i = 0;
            }
        }

        private void FindAndAddBadLines(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                var line = String.Empty;
                sr.ReadToEnd().Count();
                for (int lineNum = 1; sr.ReadLine != null; lineNum++)
                {
                    //(bool isLineCorrect, int? badPosition) = GetLineCorrectnessData(line);
                    //if (!isLineCorrect)
                    //{
                    //    var badLine = new BadLine(lineNum, filePath, line, (int)badPosition);
                    //    BadLines.Add(badLine);
                    //}
                }
            }
        }
        //private (bool lineCorrectness, int? position) GetLineCorrectnessData(string line)
        //{
        //    if (IsCommentLine(line)) ;
        //    if (line.Count() <= 1024) ; //ale do czesci tekstowej
        //    if (AreWordsShorterThan(54, line)) ;
        //    if (IsSyntaxCorrect(line)) ;
        //}

        private bool IsSyntaxCorrect(string line)
        {
            throw new NotImplementedException();
        }

        private bool AreWordsShorterThan(int v, string line)
        {
            throw new NotImplementedException();
        }

        private bool IsCommentLine(string line)
        {
            throw new NotImplementedException();
        }
    }
}
