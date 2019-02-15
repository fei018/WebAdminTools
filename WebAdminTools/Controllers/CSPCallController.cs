using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdminTools.Filters;
using PagedList.Mvc;
using PagedList;
using AdminToolsDAL.CSPCall;
using AdminToolsModel.CSPCall;
using AdminToolsViewModel.CSPCall;

namespace WebAdminTools.Controllers
{
    [Filter_LoginAuthorize]
    [Filter_ActionExecuted]
    public class CSPCallController : Controller
    {
        private CSPCallDAL _dal = new CSPCallDAL();

        // GET: CSPCall
        public ActionResult Index()
        {
            return View();
        }

        #region +CallList()
        public ActionResult CallList(int? page)
        {
            
            var table = _dal.GetTableList();
            int pagenum = page ?? 1;
            int pagesize = 10;
            int totalcount = table.Count;
            var calls = (from c in table orderby c.Id ascending select c).Skip((pagenum - 1) * pagesize).Take(pagesize);

            var vm = new PagedList.StaticPagedList<CSPCallDetails>(calls, pagenum, pagesize, totalcount) as IPagedList<CSPCallDetails>;
            return View(vm);
        }
        #endregion

        #region +Create()
        // GET: CSPCall/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CSPCall/Create
        /// <summary>
        /// 添加 call details 到數據庫
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(CSPCallDetails call)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dal.AddOrUpdateCall(call);
                }
                else
                {
                    return View();
                }

                return RedirectToAction("CallList");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region +Edit()
        // GET: CSPCall/Edit/5
        public ActionResult Edit(int id)
        {
            CSPCallDetails c = _dal.GetTableList().Find(f => f.Id == id);
            return View(c);
        }

        // POST: CSPCall/Edit/5
        [HttpPost]
        public ActionResult Edit(CSPCallDetails call)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dal.AddOrUpdateCall(call);
                }
                else
                {
                    return View(call);
                }

                return RedirectToAction("CallList");
            }
            catch
            {
                return View(call);
            }
        }

        #endregion

        #region +Delete()
        //public ActionResult Delete(int id)
        //{
        //    CSPCallDetails c = _db.CSPCallList.Find(id);
        //    CSPCallViewModel vm = new CSPCallViewModel();
        //    vm.SetAllProperty(c);
        //    return View(vm);
        //}

        // POST: CSPCall/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    _dal.DeleteCall(id);
                }
                //return RedirectToAction("CallList");
                return new EmptyResult();
            }
            catch
            {
                return new EmptyResult();
            }
        }
        #endregion

        #region +CallProcess()
        public ActionResult CallProcess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CallProcess(CSPCallSet set)
        {
            if (ModelState.IsValid)
            {
                CSPCallDAL call = new CSPCallDAL();
                //call.Run(set);
            }
            else
            {
                return PartialView("CallProcess_ajax");
            }
            return RedirectToAction("CallList");
        }
        #endregion
    }
}
