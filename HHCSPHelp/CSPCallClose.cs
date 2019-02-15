using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using AdminToolsModel.CSPCall;

namespace HHCSPHelp
{
    internal class CSPCallClose
    {
        public CSPCallClose(CSPCallInfo info)
        {
            _calllist = info.AddList;
            _assignto = info.CallSet.Assignto;
        }

        #region 變量 Link
        private const string _bodyClose = "formpage=1&sle_seqno=1&sle_indicator=I&sle_indicator_follow=I&sle_solution=&sle_assignremark=&pagename=&sle_status=C&sle_docsts=N";

        private const string _userAgent = @"Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 10.0; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729)";
        private const string _httpAccept = @"image/gif, image/jpeg, image/pjpeg, application/x-ms-application, application/xaml+xml, application/x-ms-xbap, */*";
        private const string _host = "hiphingweb03.hiphing.com.hk";
        private string _closeCallLink1 = @"http://hiphingweb03.hiphing.com.hk/hhcsp/servlet/com.hiphing.csp.servlets.cspm0006.ServiceSave";
        #endregion

        #region 屬性
        private List<CSPCallDetails> _calllist;
        private string _assignto;
        #endregion

        #region Public Cloes Call
        public void CloseCall(string cspCookie)
        {
            try
            {             
                string postdata;
                foreach (var c in _calllist)
                {
                    postdata = "&sle_requestno=" + c.RequestNO
                             + "&sle_requestdate=" + c.RequestDate
                             + "&sle_scheduledate=" + c.RequestDate
                             + "&sle_scheduletime=" + c.ScheduleTime
                             + "&sle_servedate=" + c.RequestDate
                             + "&sle_servetime1=" + c.ServeTime1
                             + "&sle_servetime2=" + c.ServeTime2
                             + "&sle_description=" + c.ServiceDescription
                             + "&sle_staff=" + _assignto;
                    postdata = _bodyClose + postdata;
                    Close1(cspCookie, postdata);
                    PostLogOutput(c);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void PostLogOutput(CSPCallDetails c)
        {
            string put = $"Close:\t{c.RequestNO}\t{HttpUtility.UrlDecode(c.RequestDate)}\t{HttpUtility.UrlDecode(c.ServiceDescription)}" +
                         $"\t{HttpUtility.UrlDecode(c.ServeTime1)}\t{HttpUtility.UrlDecode(c.ServeTime2)}";
            CSPLogger.Log(put);
        }
        #endregion


        // Fiddler 抓包用
        private string _proxyIP = null; // "127.0.0.1:8888";
        #region Close call
        //private List<JobRequest> FilterJobRequestList(List<JobRequest> joblist)
        //{
        //    List<JobRequest> newlist = new List<JobRequest>();
        //    try
        //    {
        //        for (int i = 0; i < joblist.Count; i++)
        //        {
        //            if (!string.IsNullOrWhiteSpace(joblist[i].RequestNO))
        //            {                        
        //                newlist.Add(joblist[i]);
        //            }
        //        }
        //        return newlist;
        //    }
        //    catch (Exception) { throw; }
        //}

        private void Close1(string cspCookie, string data)
        {
            HttpHelper http = new HttpHelper();

            HttpItem item = new HttpItem()
            {
                URL = _closeCallLink1,
                Method = "post",
                KeepAlive = true,
                ContentType = "application/x-www-form-urlencoded",
                Referer = "http://hiphingweb03.hiphing.com.hk/hhcsp/CSPM0006c.jsp",
                Allowautoredirect = false,
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Host = _host,
                Cookie = cspCookie,
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            item.Header.Add("Pragma: no-cache");
            item.Postdata = data;
            try
            {
                http.GetHtml(item);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
