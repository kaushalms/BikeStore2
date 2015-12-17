using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public int OrderId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Pickup Date is required")]
        public DateTime PickUpDate { get; set; }
        public string EmailId { get; set; }
        public int OrderStatusId { get; set; }

        public int PayModeId { get; set; }
        
        public decimal Total { get; set; }
        public decimal Bonus { get; set; }
        public int EmployeeId { get; set; }
        public int OrderStageId { get; set; }
        public virtual PayMode PayMode { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public virtual OrderStatus OrderStatus{get; set;}
        public virtual OrderStage OrderStage { get; set; }
        


    }
}