using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HHCSPHelp
{
    internal class CSPCallLogin
    {
        #region 變量
        /// <summary>
        /// 構造函數 CSPLogin
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <exception cref="CSP LoginID or password is null"></exception>
        public CSPCallLogin(string userid, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userid) || string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("CSP UserId or password is null");
                }
            }
            catch (Exception) { throw; }

            UserId = userid;
            UserPwd = password;
        }

        private string UserId { get; set; }
        private string UserPwd { get; set; }
        private string _cspCookie;
        #endregion


        #region Login Link const
        private const string _loginLink1 = @"http://hiphingweb03.hiphing.com.hk/hhcore/servlet/hiphing.login.LoginController";
        private const string _loginLink2 = @"http://hiphingweb03.hiphing.com.hk/hhcore/sysm0002.jsp";
        private const string _loginLink3 = @"http://hiphingweb03.hiphing.com.hk/hhcore/sysm0003.jsp";
        private const string _loginLink4 = @"http://hiphingweb03.hiphing.com.hk/hhcore/sysm0004.jsp";
        private const string _cspLink1 = @"http://hiphingweb03.hiphing.com.hk/hhcore/servlet/hiphing.login.LoginController?p_action=2&p_dest=hhcsp/servlet/hiphing.login.LoginController";
        private const string _cspLink3 = @"http://hiphingweb03.hiphing.com.hk/hhcsp/indexTop.jsp";
        private const string _cspLink4 = @"http://hiphingweb03.hiphing.com.hk/hhcsp/indexBottom.html";
        private const string _cspLink5 = @"http://hiphingweb03.hiphing.com.hk/hhcsp/indexBottom.jsp?action=none";

        private const string _userAgent = @"Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 10.0; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729)";
        private const string _httpAccept = @"image/gif, image/jpeg, image/pjpeg, application/x-ms-application, application/xaml+xml, application/x-ms-xbap, */*";
        private const string _host = "hiphingweb03.hiphing.com.hk";
        #endregion

        // Fiddler 抓包用
        private string _proxyIP = null; //"127.0.0.1:8888";


        #region Login hhcore
        private HttpResult Login1()
        {
            HttpHelper http = new HttpHelper();

            HttpItem item = new HttpItem()
            {
                URL = _loginLink1,
                Method = "post",
                KeepAlive = true,
                ContentType = "application/x-www-form-urlencoded",
                Referer = "http://hiphingweb03.hiphing.com.hk/hhcore/index_body.html",
                Allowautoredirect = false,
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Host = _host,
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            item.Header.Add("Pragma: no-cache");
            item.Postdata = "p_usrid=" + UserId + "&p_pwd=" + UserPwd + "&Submit=Submit";
            try
            {
                return http.GetHtml(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HttpResult Login2(string cookie)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = _loginLink2,
                Method = "get",
                Allowautoredirect = false,
                KeepAlive = true,
                Referer = "http://hiphingweb03.hiphing.com.hk/hhcore/index_body.html",
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Cookie = cookie,
                Host = _host,
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            item.Header.Add("Pragma: no-cache");
            try
            {
                return http.GetHtml(item);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private HttpResult Login3(string cookie)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = _loginLink3,
                Method = "get",
                Allowautoredirect = false,
                KeepAlive = true,
                Referer = _loginLink2,
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Cookie = cookie,
                Host = _host,
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            //item.Header.Add("Pragma: no-cache");
            try
            {
                return http.GetHtml(item);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private HttpResult Login4(string cookie)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = _loginLink4,
                Method = "get",
                Allowautoredirect = false,
                KeepAlive = true,
                Referer = _loginLink3,
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Cookie = cookie,
                Host = _host,
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            //item.Header.Add("Pragma: no-cache");
            try
            {
                return http.GetHtml(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Login hhcsp
        private HttpResult LoginCSP1(string cookie)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = _cspLink1,
                Method = "get",
                Allowautoredirect = false,
                KeepAlive = true,
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Cookie = cookie,
                Host = _host,
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            try
            {
                return http.GetHtml(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HttpResult LoginCSP2(string location, string cookie)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = location,
                Method = "get",
                Allowautoredirect = false,
                KeepAlive = true,
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Cookie = cookie,
                Host = _host,
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            //item.Header.Add("Pragma: no-cache");
            try
            {
                return http.GetHtml(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HttpResult LoginCSP3(string cspCookie)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = _cspLink3,
                Method = "get",
                Allowautoredirect = false,
                KeepAlive = true,
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Cookie = cspCookie,
                Host = _host,
                Referer = "http://hiphingweb03.hiphing.com.hk/hhcsp/index.html",
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            //item.Header.Add("Pragma: no-cache");
            try
            {
                return http.GetHtml(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HttpResult LoginCSP4(string cspCookie)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = _cspLink4,
                Method = "get",
                Allowautoredirect = false,
                KeepAlive = true,
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Cookie = cspCookie,
                Host = _host,
                Referer = "http://hiphingweb03.hiphing.com.hk/hhcsp/index.html",
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            //item.Header.Add("Pragma: no-cache");
            try
            {
                return http.GetHtml(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HttpResult LoginCSP5(string cspCookie)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = _cspLink5,
                Method = "get",
                Allowautoredirect = false,
                KeepAlive = true,
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Cookie = cspCookie,
                Host = _host,
                Referer = "http://hiphingweb03.hiphing.com.hk/hhcsp/indexBottom.html",
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            //item.Header.Add("Pragma: no-cache");
            try
            {
                return http.GetHtml(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HttpResult LoginCSP6(string cspCookie)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://hiphingweb03.hiphing.com.hk/hhcsp/CSPM0001a.jsp",
                Method = "get",
                Allowautoredirect = false,
                KeepAlive = true,
                Accept = _httpAccept,
                UserAgent = _userAgent,
                Cookie = cspCookie,
                Host = _host,
                Referer = "http://hiphingweb03.hiphing.com.hk/hhcsp/CSPM0001.html",
                ProxyIp = _proxyIP
            };
            item.Header.Add("Accept-Language: zh-HK");
            item.Header.Add("Accept-Encoding: gzip, deflate");
            //item.Header.Add("Pragma: no-cache");
            try
            {
                return http.GetHtml(item);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Public Login ,return CSP Cookie
        /// <summary>
        /// Return CSP Cookie
        /// </summary>
        /// <returns>CSP Cookie</returns>
        public string Login()
        {
            HttpResult result;
            try
            {
                result = Login1();
                if (result.RedirectUrl.ToLower() != _loginLink2.ToLower())
                {
                    throw new Exception("Login UserId or Password is invalid.");
                }
                string cookie = result.Cookie.Split(';')[0];
                Login2(cookie);
                Login3(cookie);
                Login4(cookie);

                result = LoginCSP1(cookie);
                result = LoginCSP2(result.RedirectUrl, cookie);
                _cspCookie = result.Cookie.Split(';')[0];
                if (string.IsNullOrEmpty(_cspCookie)) throw new Exception("CSP Cookie is null");

                LoginCSP3(_cspCookie);
                LoginCSP4(_cspCookie);
                LoginCSP5(_cspCookie);
                LoginCSP6(_cspCookie);
                return _cspCookie;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
