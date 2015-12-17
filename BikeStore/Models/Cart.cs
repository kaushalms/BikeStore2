using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int InventoryId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}