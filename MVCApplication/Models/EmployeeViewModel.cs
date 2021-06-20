using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Models
{
    public class EmployeeViewModel
    {
        public int empId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Nullable<int> departmentId { get; set; }

        //public virtual Department Department { get; set; }
    }
}