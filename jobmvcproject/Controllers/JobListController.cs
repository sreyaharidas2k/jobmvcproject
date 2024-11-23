using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobmvcproject.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace jobmvcproject.Controllers
{
    public class JobListController : Controller
    {
        jobmvc_projectEntities dbobj = new jobmvc_projectEntities();
        // GET: UserHome
        public ActionResult JobList_Pageload()
        {
          
            return View(GetJobData());
        }

        private JobSearch GetJobData()
        {
            var joblists = new JobSearch();
            List<string> lst = new List<string>();
            var job = dbobj.Job_tb.ToList();
            foreach(var e in job)
            {
                var jobcls = new Jsearch();
                jobcls.Job_Id = e.Job_Id;
                Session["jid"] = jobcls.Job_Id;
                jobcls.Company_Id = e.Company_Id;
                jobcls.Job_Title = e.Job_Title;
                jobcls.Job_Desc = e.Job_Desc;
                jobcls.Exp_In_Yrs_Needed = e.Exp_In_Yrs_Needed;
                jobcls.Skills_Needed = e.Skills_Needed;
                jobcls.Job_Location = e.Job_Location;
                jobcls.Job_Salary = e.Job_Salary;
                jobcls.Job_Type = e.Job_Type;
                jobcls.Last_Date = e.Last_Date;
                jobcls.Job_Status = e.Job_Status;

                joblists.SelectJob.Add(jobcls);
                var s = jobcls.Skills_Needed;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
            }
            return joblists;
        }

        public ActionResult JobList_Click(JobSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Exp_In_Yrs_Needed.ToString()))
            {
                qry += " and Exp_In_Yrs_Needed like '%" + clsobj.insertse.Exp_In_Yrs_Needed + "%'";
            }
                
            if(!string.IsNullOrWhiteSpace(clsobj.insertse.Skills_Needed))
            {
                qry += " and Skills_Needed like '%" + clsobj.insertse.Skills_Needed + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Location))
            {
                qry += " and Job_Location like '%" + clsobj.insertse.Job_Location + "%'";
            }
            return View("JobList_Pageload",getdata1(clsobj,qry));
        }
        public JobSearch getdata1(JobSearch clsobj,string qry)
        {
            using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["TestCon"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while(dr.Read())
                {
                    var jobcls = new Jsearch();
                    jobcls.Job_Id = Convert.ToInt32(dr["Job_Id"].ToString());
                    Session["jid"] = jobcls.Job_Id;
                    jobcls.Company_Id = Convert.ToInt32(dr["Company_Id"].ToString());
                    jobcls.Job_Title = dr["Job_Title"].ToString();
                    jobcls.Job_Desc = dr["Job_Desc"].ToString();
                    jobcls.Exp_In_Yrs_Needed = Convert.ToInt32(dr["Exp_In_Yrs_Needed"].ToString());
                    jobcls.Skills_Needed = dr["Skills_Needed"].ToString();
                    jobcls.Job_Location = dr["Job_Location"].ToString();
                    jobcls.Job_Salary = dr["Job_Salary"].ToString();
                    jobcls.Job_Type = dr["Job_Type"].ToString();
                    jobcls.Last_Date = Convert.ToDateTime(dr["Last_Date"].ToString());
                    jobcls.Job_Status = dr["Job_Status"].ToString();

                    joblist.SelectJob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }
    }
}