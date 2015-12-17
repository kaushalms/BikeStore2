using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int InventoryId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Order Order { get; set; }
        //public virtual Store Store { get; set; }
    }
}