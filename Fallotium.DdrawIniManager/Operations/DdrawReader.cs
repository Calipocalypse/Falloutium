using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.DdrawIniManager.Operations
{
    internal static class DdrawReader
    {
        internal static IEnumerable<DdrawEntry> GetDdrawEntriesFromFile(string path)
        {
            var iniFileText = GetFileText(path);
            var ddrawEntriesList = GetDdrawEntriesFromText(iniFileText);
            return ddrawEntriesList;
        }

        private static IEnumerable<DdrawEntry> GetDdrawEntriesFromText(string[] iniFileText)
        {
            var name = String.Empty;
            var value = String.Empty;
            var description = String.Empty;
            var category = String.Empty;
            var isCommented = false;

            var entries = new List<DdrawEntry>();

            foreach (var line in iniFileText)
            {
                if (line.Length == 0) continue;
                if (line[0] == ';')
                {
                    if (line.Contains('='))
                    {
                        var newLine = line.Replace(";", "");
                        (name, value) = GetSetting(newLine);
                        var entry = new DdrawEntry(name, category, value, description, true, false);
                        entries.Add(entry);
                        name = String.Empty;
                        value = String.Empty;
                        description = String.Empty;
                    }
                    else
                    {
                        var newLine = line.Substring(1);
                        if (description == String.Empty) description += newLine;
                        else description += '\n' + newLine;
                    }
                }
                else if (line[0] == '[')
                {
                    category = line;
                    description = String.Empty;
                }
                else if (line.Contains('='))
                {
                    (name, value) = GetSetting(line);
                    var entry = new DdrawEntry(name, category, value, description, false, false);
                    entries.Add(entry);
                    name = String.Empty;
                    value = String.Empty;
                    description = String.Empty;
                }
            }

            return entries;
        }

        private static (string name, string value) GetSetting(string line)
        {
            var name = String.Empty;
            var value = String.Empty;
            var nameValueSwitch = false;
            foreach (var character in line)
            {
                if (character == '=')
                {
                    nameValueSwitch = true;
                    continue;
                }
                if (nameValueSwitch == false)
                {
                    name += character;
                }
                else
                {
                    value += character;
                }
            }
            return (name, value);
        }

        internal static string[] GetFileText(string filePath)
        {
            return File.ReadAllLines(filePath);
        }


    }
}
