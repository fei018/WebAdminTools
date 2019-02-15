using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using WebAdminTools.Filters;
using AdminToolsDAL.Notes;
using AdminToolsModel.Notes;

namespace WebAdminTools.Controllers
{
    [Filter_LoginAuthorize]
    [Filter_ActionExecuted]
    public class NotesIdController : Controller
    {
        // GET: NotesId
        public ActionResult Index()
        {
            return View();
        }

        #region +SearchId()
        [HttpPost]
        public ActionResult SearchId(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return new EmptyResult();
            }

            NotesIdDAL dal = new NotesIdDAL();
            var idList = dal.GetIdFileList();
            if (idList == null)
            {
                return new ContentResult() { Content = "There is no Id file in the Server." };
            }
            return GetSearchResult(filename, idList);
        }

        private ActionResult GetSearchResult(string q, List<NotesId> notes)
        {
            var tList = new List<NotesId>();
            foreach (var i in notes)
            {
                if (i.FileName.ToLower().IndexOf(q.ToLower()) >= 0)
                {
                    tList.Add(i);
                }
            }

            if (tList.Count != 0)
            {
                return PartialView("SearchId", tList);
            }
            return new ContentResult() { Content = "Search result: 0" };
        }
        #endregion


        #region +Download()
        public ActionResult Download(string filename)
        {
            var list = new NotesIdDAL().GetIdFileList();
            if (list == null)
            {
                return new EmptyResult();
            }
            try
            {
                NotesId nid = (from i in list where i.FileName == filename select i).First();

                byte[] data = GetFileBytes(nid.FilePath);
                SendEmailAfterDownload(nid.FileName);
                return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, nid.FileName);
            }
            catch (Exception)
            {
                return new EmptyResult();
                //throw;
            }
        }

        /// <summary>
        /// 讀取 文件流
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private byte[] GetFileBytes(string s)
        {
            try
            {
                using (System.IO.FileStream fs = System.IO.File.OpenRead(s))
                {
                    byte[] data = new byte[fs.Length];
                    int br = fs.Read(data, 0, data.Length);

                    if (br != fs.Length)
                        throw new System.IO.IOException(s);
                    return data;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SendEmailAfterDownload(string filename)
        {
            string sub = "NotesId download";
            NotesIdDAL dal = new NotesIdDAL();
            dal.SendEmailAfterDownload(sub, filename);
        }
        #endregion

    }
}