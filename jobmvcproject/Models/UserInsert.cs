using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobmvcproject.Models
{
    public class UserInsert
    {
        [Required(ErrorMessage = "Enter the Name")]
        public string name { set; get; }
        [Range(10, 60, ErrorMessage = "Enter the Age")]
        public int uage { set; get; }
        [Required(ErrorMessage = "Enter the  Address")]
        public string uadd { set; get; }

        [Required(ErrorMessage = "Enter the  Phone Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Valid Phone Number")]
        public string uphn { set; get; }

        [EmailAddress(ErrorMessage = "Enter the  Email")]
        public string uemail { set; get; }
        [Required(ErrorMessage = "Enter the Field")]
        public int expyr { set; get; }
        [Required(ErrorMessage = "Enter the Field")]
        public string skills { set; get; }
       
        public string resume { set; get; }
       
        public DateTime dob { set; get; }
        [Required(ErrorMessage = "Enter the Field")]
        public string uname { set; get; }
        public string pwd { set; get; }
        [Compare("pwd", ErrorMessage = "Password Mismatch")]
        public string cpwd { set; get; }
        public string usermsg { set; get; }
    }
}