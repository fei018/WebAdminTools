using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HHCSPHelp
{
    public class CSPLogger
    {
        public static readonly string LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"log_cspcall.txt");
        public static readonly string ErrorPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_cspcall.txt");

        internal static void Log(string log)
        {
            log += Environment.NewLine;
            try
            {
                File.AppendAllText(LogPath, log);
            }
            catch (Exception)
            {
            }
        }

        internal static void Error(string error)
        {
            error += "\r\n\r\n";
            try
            {
                File.AppendAllText(ErrorPath, error);
            }
            catch (Exception)
            {
            }
        }
    }
}
