using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Compny_Task.Models
{
    public class Employee_model
    {
        public int ID { get; set; }
        public string EmpNO { get; set; }
        public string EmpName { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNo { get; set; }
        public string Salary { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Email { get; set; }
        public string Emp_Photo { get; set; }
        public string PhotoPath { get; set; }
        public string Qualification { get; set; }

        public HttpPostedFileBase Imagefile { get; set; }



    }
}