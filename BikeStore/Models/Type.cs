using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class Type
    {
        public int TypeId { get; set; }        
        public string TypeName { get; set; }
        public string TypeDesc { get; set; }
        public virtual List<Inventory> Inventories { get; set; }
    }
}