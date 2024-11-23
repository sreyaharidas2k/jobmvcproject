using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobmvcproject.Models;
namespace jobmvcproject.Controllers
{
    public class UserRegController : Controller
    {
        jobmvc_projectEntities dbobj = new jobmvc_projectEntities();
        // GET: UserReg
        public ActionResult User_Pageload()
        {
            return View();
        }
        public ActionResult User_Click(UserInsert usrclsobj,HttpPostedFileBase file)
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
                    usrclsobj.resume = fullpath;
                }
                var getmaxid = dbobj.sp_maxidlogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_userreg(regid,usrclsobj.name, usrclsobj.uage, usrclsobj.uadd, usrclsobj.uphn, usrclsobj.uemail, usrclsobj.expyr, usrclsobj.skills, usrclsobj.resume, usrclsobj.dob, "Active");
                dbobj.sp_logininsert(regid, usrclsobj.uname, usrclsobj.pwd, "User");
                usrclsobj.usermsg = "Inserted Successfully";
                return View("User_Pageload", usrclsobj);
            }
            return View("User_Pageload", usrclsobj);
        }
    }
}