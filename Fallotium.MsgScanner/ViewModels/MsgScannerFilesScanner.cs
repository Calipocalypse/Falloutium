using Fallotium.MsgScanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Fallotium.MsgScanner.ViewModels
{
    internal class MsgScannerFilesScanner : IDisposable
    {

        public ObservableCollection<BadLine> GetBadLines(string msgTopDirectory)
        {
            /* 1. Get all files or folders to scan */
            var listOfFilesPath = GetAllFilesPath(msgTopDirectory); //Todo
            /* 2. Foreach line in file check for bad line and add to List */
            var listOfBadLines = new ObservableCollection<BadLine>();
            foreach (string filePath in listOfFilesPath)
            {
                List<BadLine> badLines = ScanForBadLines(filePath);
                if (badLines.Count > 0) badLines.ForEach(x => listOfBadLines.Add(x));
            }
            /* 3. Return list */
            return listOfBadLines;
        }

        private List<BadLine> ScanForBadLines(string filePath)
        {
            var localFileBadLines = new List<BadLine>();

            //using (var reader = new StreamReader(filePath))
            //{
            //    int lineNumber = 1;
            //    foreach (string line in filePath)
            //    {
            //        if(IsLineNotValid(line)) localFileBadLines.Add(new BadLine { LineNumber = lineNumber, })
            //        lineNumber++;
            //    }
            //}

            return localFileBadLines;
        }

        private bool IsLineNotValid(char line)
        {
            throw new NotImplementedException();
        }

        private List<string> GetAllFilesPath(string msgTopDirectory)
        {
            return new List<string>();
        }

        public void Dispose() { }
    }
}
