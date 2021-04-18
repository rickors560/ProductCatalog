using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductCatalog.Entities
{
    public class Category
    {
        public static int autoIncreamentor = 0;
        public int ID { get; }
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
            return $"\nID: {this.ID}\nName: {this.Name}\nShortCode: {this.ShortCode}";
        }
    }
}
