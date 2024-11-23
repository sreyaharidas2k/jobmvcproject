﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobmvcproject.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Enter the Username")]
        public string uname { set; get; }
        [Required(ErrorMessage = "Enter the Password")]
        public string pwd { set; get; }
        public string logmsg { set; get; }
        public string ltype { set; get; }
    }
}