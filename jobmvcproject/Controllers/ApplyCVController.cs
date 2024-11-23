using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobmvcproject.Models;

namespace jobmvcproject.Controllers
{
    public class ApplyCVController : Controller
    {
        jobmvc_projectEntities dbobj = new jobmvc_projectEntities();
        // GET: ApplyCV
        public ActionResult ApplyCV_Load()
        {
            return View();
        }
        public ActionResult ApplyCV_Click(Apply apply,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Resume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\Resume", fname);
                    apply.resume = fullpath;
                }
                int userid = Convert.ToInt32(Session["uid"]);
                int jobid = Convert.ToInt32(Session["jid"]);
                dbobj.sp_appliinsert(userid,jobid, apply.resume, DateTime.Now, "Applied");
                return View("ApplyCV_Load", apply);
            }
            return View("ApplyCV_Load", apply);
        }
    }
}