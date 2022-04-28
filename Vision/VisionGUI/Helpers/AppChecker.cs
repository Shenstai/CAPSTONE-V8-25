using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Core;

namespace VisionGUI.Helpers
{
    public static class AppChecker
    {
        public static void WriteLine (object logObj, bool logToFile = true)
        {
            string path = $"{AppPath.InternalLogsFolder}{DateTime.Now:MM-dd-yy HH:tt}.log";

            try
            {
                string[] lines = new string[] { $"[{DateTime.UtcNow}]\t{logObj}" };

                Debug.WriteLine(lines[0]);

                if (logToFile)
                {
                    File.AppendAllLines(path, lines);
                }
            } catch (DirectoryNotFoundException)
            { 
            
                Directory.CreateDirectory(AppPath.InternalLogsFolder);
            
            } catch { }
         
        }
    }
}
