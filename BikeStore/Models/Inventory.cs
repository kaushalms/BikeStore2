using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class Inventory
    {
     
        public int InventoryId { get; set; }
        public int Frameid { get; set; }
        public int TypeId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }

        public string Desc { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StoreId { get; set; }
        public int ProdStatusId { get; set; }

        
        public virtual Frame Frame { get; set; }
        public virtual Type Type { get; set; }
        public virtual Store Store { get; set; }
        public virtual ProdStatus ProdStatus { get; set; }

    }
}