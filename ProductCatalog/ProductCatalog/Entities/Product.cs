using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Entities
{
    public class Product
    {
        public static int autoIncreamentor = 0;
        public int ID { get;}
        public Product()
        {
            autoIncreamentor++;
            ID = autoIncreamentor;
            this.Categories = new List<Category>();
        }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ShortCode { get; set; }
        public List<Category> Categories { get; set; }
        public string Description { get; set; }
        public int SellingPrice { get; set; }
        public void AddCategories() {
            bool exit = false;
            while (!exit) {
                Console.WriteLine("---------------------" +
                    "\n\ta. Add a Category to Product");
                Console.WriteLine("\tb. Exit\n");
                switch (Console.ReadLine().ToLower()) {
                    case "a":
                        Console.WriteLine("Choose a Category by ID");
                        Catalog.Categories.DisplayCategories();
                        int id; Int32.TryParse(Console.ReadLine(), out id);
                        try
                        {
                            Category selectedCategory = Catalog.Categories.CategoryList.Single(category => category.ID == id);
                            this.Categories.Add(selectedCategory);
                        }
                        catch (System.InvalidOperationException)
                        {
                            Console.WriteLine("Not found");
                        }
                        break;
                    case "b":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\tInvalid option");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public override string ToString()
        {
            string productCategories = "";
            this.Categories.ForEach(c =>
            {
                productCategories += c.Name + ", ";
            });
            return $"\nID: {this.ID}\nName: {this.Name}" +
                $"\nManufacturer: {this.Manufacturer}\nShortCode: {this.ShortCode}" +
                $"\nCategories: {productCategories}" +
                $"\nSellingPrice: $ {this.SellingPrice}";
        }
    }
}
