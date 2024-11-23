using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobmvcproject.Models;
namespace jobmvcproject.Controllers
{
    public class LoginController : Controller
    {
        jobmvc_projectEntities dbobj = new jobmvc_projectEntities();
        // GET: Login
        public ActionResult Login_Loadpage()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Login_Click(Login lgclsobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_logincountid(lgclsobj.uname, lgclsobj.pwd, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_LoginRegId(lgclsobj.uname, lgclsobj.pwd).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = dbobj.sp_logintype(lgclsobj.uname, lgclsobj.pwd).FirstOrDefault();
                    if (lt == "User")
                    {
                        //return RedirectToAction("JobList_Pageload","JobList");
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "Admin")
                    {
                        return RedirectToAction("AdminHome");
                    }
                }
            }
            else
            {
                ModelState.Clear();
                lgclsobj.logmsg = "Invalid login";
                return View("Login_Loadpage", lgclsobj);
            }
            return View("Login_Loadpage", lgclsobj);
        }
    }
}