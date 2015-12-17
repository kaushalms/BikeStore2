using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class Store
    {
        public Store()
        {
            InventoryDetails = new List<Inventory>();
            EmployeeDetails = new List<Employee>();
        }

        
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
               

        public List<Inventory> InventoryDetails { get; set; }
        public List<Employee> EmployeeDetails { get; set; }
    }
}