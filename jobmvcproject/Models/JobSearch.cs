using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobmvcproject.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            SelectJob = new List<Jsearch>();
            insertse = new Jsearch();
        }
        public Jsearch insertse { set; get; }
        public List<Jsearch> SelectJob { set; get; }
    }
    public class Jsearch
    {
        public int Job_Id { get; set; }
        public int Company_Id { get; set; }
        public string Job_Title { get; set; }
        public string Job_Desc { get; set; }
        public int? Exp_In_Yrs_Needed { get; set; }
        public string Skills_Needed { get; set; }
        public string Job_Location { get; set; }
        public string Job_Salary { get; set; }
        public string Job_Type { get; set; }
        public System.DateTime Last_Date { get; set; }
        public string Job_Status { get; set; }
        public string jobmsg { set; get; }
    }
}