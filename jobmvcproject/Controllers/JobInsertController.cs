using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobmvcproject.Models;
namespace jobmvcproject.Controllers
{
    public class JobInsertController : Controller
    {
        jobmvc_projectEntities dbobj = new jobmvc_projectEntities();

        
        // GET: JobInsert
        public ActionResult Job_Pageload()
        {
            return View();
        }

        public ActionResult Job_Click(JobInsert jobcls,FormCollection form)
        {
            if(ModelState.IsValid)
            {
                int cid = Convert.ToInt32(Session["uid"]);
                dbobj.sp_jobinsert(cid, jobcls.title, jobcls.desc, jobcls.exp, jobcls.skill, jobcls.loc, jobcls.salary, jobcls.type, jobcls.lastdate, "Apply");
                jobcls.msg = "Inserted Successfully";
                return View("Job_Pageload", jobcls);

            }
            else
            {
                ModelState.Clear();
                return View("Job_Pageload", jobcls);
            }
           
        }
    }
}