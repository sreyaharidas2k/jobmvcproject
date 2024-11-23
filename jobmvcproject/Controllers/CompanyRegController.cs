using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobmvcproject.Models;
namespace jobmvcproject.Controllers
{
    public class CompanyRegController : Controller
    {
        jobmvc_projectEntities dbobj = new jobmvc_projectEntities();
        // GET: CompanyReg
        public ActionResult Company_Pageload()
        {
            return View();
        }
        public ActionResult Company_Click(CompanyInsert comclsobj)
        {
            if (ModelState.IsValid)
            {
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
                dbobj.sp_companyreg(regid, comclsobj.cname, comclsobj.cadd, comclsobj.cemail, comclsobj.cphn, comclsobj.state, comclsobj.dis);
                dbobj.sp_logininsert(regid, comclsobj.uname, comclsobj.pwd, "Admin");
                comclsobj.adminmsg = "Inserted Successfully";
                return View("Company_Pageload", comclsobj);
            }
            return View("Company_Pageload", comclsobj);
        }
    }
}