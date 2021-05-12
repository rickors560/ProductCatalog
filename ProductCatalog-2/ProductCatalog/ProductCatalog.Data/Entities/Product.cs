using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Data.Entities
{
    public class Product
    {
        public static int autoIncreamentor = 0;
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public int SellingPrice { get; set; }
        public string Category { get; set; }
        public Product()
        {
            autoIncreamentor++;
            this.ID = autoIncreamentor;
        }
        public override string ToString()
        {
            return String.Format("\t{0,3} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15} {6}", this.ID, this.Name, this.Manufacturer, this.ShortCode, this.Category, "$ " + this.SellingPrice,  this.Description);
        }
    }
}