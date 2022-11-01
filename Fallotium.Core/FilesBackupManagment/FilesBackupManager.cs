using Fallotium.Core.FilesBackupManagment.Enum;
using Fallotium.Core.SettingsManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.Core.FilesBackupManagment
{
    public static class FilesBackupManager
    {
        public static void CreateBackup(string filePath, FilesBackupTypes type)
        {
            var currentDateTime = DateTime.Now.ToString(" [MM-dd-yyyy hh;mm;ss;fff]");
            var fileName = Path.GetFileNameWithoutExtension(filePath) + currentDateTime + ".ini";
            var destinationPath = Settings.settingsXmlDirectory + '\\' + type.ToString() + '\\';
            var destinationFile = destinationPath + fileName;
            if (!Directory.Exists(destinationPath)) Directory.CreateDirectory(destinationPath);
            File.Copy(filePath, destinationFile);
        }
    }
}
