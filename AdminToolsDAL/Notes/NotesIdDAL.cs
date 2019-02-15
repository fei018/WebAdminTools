using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using AdminToolsModel.Notes;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AdminToolsDAL.Notes
{
    public class NotesIdDAL
    {
        private readonly static object _Locker = new object();
 
        private static string _DirPath;
        private static DateTime _DirLastWriteTime;
        private static List<NotesId> _NotesList;

        #region +GetIdFileList()
        /// <summary>
        /// Set _Noteslist && _DirLastWriteTime
        /// </summary>
        /// <exception cref="throw"></exception>
        private void SetNotesListAndOtherStatic()
        {
            DirectoryInfo dirInfo;
            try
            {
                lock (_Locker)
                {
                    _DirPath = System.Configuration.ConfigurationManager.AppSettings["NotesIdPath"];
                    dirInfo = new DirectoryInfo(_DirPath);
                    dirInfo.Refresh();
                    _DirLastWriteTime = dirInfo.LastWriteTime;
                }
                var files = dirInfo.GetFiles("*.id", SearchOption.AllDirectories);
                if (files.Count() != 0)
                {
                    int strIndex = _DirPath.Length;
                    List<NotesId> list = new List<NotesId>();
                    int i = 1;
                    foreach (var f in files)
                    {
                        //var g = Regex.Match(f.DirectoryName, @"^\\\\192\.168\.10\.90(.*)$").Groups; c:\notesid\
                        NotesId id = new NotesId();
                        id.FileId = i.ToString();
                        ++i;
                        id.FilePath = f.FullName;
                        id.FileName = f.Name;
                        id.FileDir = f.DirectoryName.Substring(strIndex);
                        list.Add(id);
                    }
                    lock (_Locker)
                    {
                        _NotesList = list;
                    }
                }
                else
                {
                    throw new Exception("Can't find any Id Files.");
                }
            }
            catch (Exception)
            {
                _NotesList = null;
                throw;
            }
        }

        private void UpdateNotesList()
        {
            try
            {
                if (_NotesList == null)
                {
                    SetNotesListAndOtherStatic();
                    return;
                }

                //對比Dir 最後寫入時間, 如果不一樣則更新 _NotesList 和 _DirLastWriteTime
                var dir = new DirectoryInfo(_DirPath);
                dir.Refresh();
                if (dir.LastWriteTime.CompareTo(_DirLastWriteTime) != 0)
                {
                    SetNotesListAndOtherStatic();
                    return;
                }
            }
            catch (Exception)
            {
                _NotesList = null;
            }
        }

        public List<NotesId> GetIdFileList()
        {
            UpdateNotesList();
            return _NotesList;
        }
        #endregion


        #region +SendEmailAfterDownload()
        private void SendEmail(string smtpServer, string fromAddress, string toAddress, string subject, string body)
        {
            try
            {
                //确定smtp服务器地址 实例化一个Smtp客户端
                using (SmtpClient smtpclient = new SmtpClient())
                {
                    smtpclient.Host = smtpServer;
                    //smtpclient.Port = 25;
                    smtpclient.Timeout = 10000; //ms(10s)
                    smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //是否使用默认凭据，若为false，则使用自定义的证书，就是下面的networkCredential实例对象
                    smtpclient.UseDefaultCredentials = false;

                    //构造一个Email的Message对象 内容信息
                    using (MailMessage mailMessage = new MailMessage(fromAddress, toAddress))
                    {
                        mailMessage.Subject = subject;
                        mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                        mailMessage.Body = body;
                        mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                        smtpclient.UseDefaultCredentials = false;

                        //指定邮箱账号和密码
                        //NetworkCredential networkCredential = new NetworkCredential(sendEmail, sendpwd);
                        //smtpclient.Credentials = networkCredential;

                        //发送邮件
                        smtpclient.Send(mailMessage);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public void SendEmailAfterDownload(string subject, string body)
        {
            try
            {
                string smtp = ConfigurationManager.AppSettings["SmtpServer"];
                string from = ConfigurationManager.AppSettings["FromEmailAddress"];
                string to = ConfigurationManager.AppSettings["ToEmailAddress"];
                Task task = new Task(() => { SendEmail(smtp, from, to, subject, body); });
                task.Start();
            }
            catch (Exception)
            {
                return;
            }
        } 
        #endregion
    }
}