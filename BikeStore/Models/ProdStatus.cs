using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class ProdStatus
    {
        public int ProdStatusId { get; set; }
        public string ProdStatusName { get; set; }
        public List<Inventory> Inventories { get; set; }


    }
}