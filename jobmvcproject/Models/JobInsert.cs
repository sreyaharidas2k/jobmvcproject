using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobmvcproject.Models
{
    public class JobInsert
    {
        
       // public int cid { set; get; }
        [Required(ErrorMessage ="Enter The Field")]
        public string title { set; get; }
        [Required(ErrorMessage = "Enter The Field")]
        public string desc { set; get; }
        [Required(ErrorMessage = "Enter The Field")]
        public int exp { set; get; }
        [Required(ErrorMessage = "Enter The Field")]
        public string skill { set; get; }
        [Required(ErrorMessage = "Enter The Field")]
        public string loc { set; get; }
        [Required(ErrorMessage = "Enter The Field")]
        public string salary { set; get; }
        [Required(ErrorMessage = "Enter The Field")]
        public string type { set; get; }
       
        public DateTime lastdate { set; get; }
       
        public string msg { set; get; }

        public int cid { set; get; }
        public string cname { set; get; }

    }

    public class company_class
    {
        public int cid { set; get; }
        public string cname { set; get; }
    }
}