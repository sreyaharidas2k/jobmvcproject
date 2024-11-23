using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobmvcproject.Models
{
    public class Apply
    {
        public int id { set; get; }
        public int jobid { set; get; }
        public int userid { set; get; }
        public string resume { set; get; }
        public DateTime appdate { set; get; }
        public string appstatus { set; get; }
    }
}