using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Data.Entities
{
    public class Category
    {
        public static int autoIncreamentor = 0;
        public int ID { get; set; }
        public Category()
        {
            autoIncreamentor++;
            ID = autoIncreamentor;
        }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return String.Format("\t{0,3} {1,-15} {2,-15} {3}", this.ID, this.Name, this.ShortCode, this.Description);
        }
    }
}