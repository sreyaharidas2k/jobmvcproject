using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobmvcproject.Models
{
    public class CompanyInsert
    {

        [Required(ErrorMessage = "Enter the Company Name")]
        public string cname { set; get; }
        [Required(ErrorMessage = "Enter the Company Address")]
        public string cadd { set; get; }
        [EmailAddress(ErrorMessage = "Enter the Company Email")]
        public string cemail { set; get; }
        [Required(ErrorMessage = "Enter the Company Phone Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Valid Phone Number")]
        public string cphn { set; get; }
        [Required(ErrorMessage = "Enter the Field")]
        public string state { set; get; }
        [Required(ErrorMessage = "Enter the Field")]
        public string dis { set; get; }
        [Required(ErrorMessage = "Enter the Field")]
        public string uname { set; get; }
        public string pwd { set; get; }
        [Compare("pwd", ErrorMessage = "Password Mismatch")]
        public string cpwd { set; get; }
        public string adminmsg { set; get; }
    }
}