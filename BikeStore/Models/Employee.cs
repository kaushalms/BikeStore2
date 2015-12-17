using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class Employee
    {
        /*public Employee()
        {
            StoreDetails = new List<Store>();
        }*/
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string EmpPassword { get; set; }
        public DateTime EmployeeDOB { get; set; }

        public string SSN { get; set; }

        public int InvSold { get; set; }
        public int EmployeeTypeId { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }


    }
}