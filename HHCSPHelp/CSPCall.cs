using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AdminToolsModel.CSPCall;

namespace HHCSPHelp
{
    public class CSPCall
    {
        public static CSPCallStatus RunStatus { get; set; }

        public void Run(CSPCallInfo info)
        {
            try
            {
                CSPCallLogin login = new CSPCallLogin(info.CallSet.LoginName, info.CallSet.Password);
                string cookie = login.Login();

                CSPCallPost post = new CSPCallPost(info);

                DelLogFile();

                post.AddCalls(cookie);
                info.CloseList = post.CloseCallList;
                CSPLogger.Log("\r\n= = = = = = = = = = = = =\r\n");


                CSPCallClose callclose = new CSPCallClose(info);

                callclose.CloseCall(cookie);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DelLogFile()
        {
            try
            {
                if (File.Exists(CSPLogger.LogPath))
                {
                    File.Delete(CSPLogger.LogPath);
                }
                if (File.Exists(CSPLogger.ErrorPath))
                {
                    File.Delete(CSPLogger.ErrorPath);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
