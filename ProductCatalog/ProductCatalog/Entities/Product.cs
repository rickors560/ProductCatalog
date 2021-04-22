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
            this.Categories = new HashSet<Category>();
        }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ShortCode { get; set; }
        public HashSet<Category> Categories { get; set; }
        public string Description { get; set; }
        public int SellingPrice { get; set; }
        public void AddCategories() {
            bool exit = false;
            Console.WriteLine("---------------------");
            Catalog.Categories.DisplayCategories();
            Console.WriteLine($"---------------------\n\ta. Add a Category to Product {this.Name}");
            Console.WriteLine("\tb. Done\n");
            while (!exit) {
                Console.Write("Enter a Choice:");
                switch (Console.ReadLine().ToLower()) {
                    case "a":
                        Console.Write("\n\tChoose a Category by ID:");
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
                        Console.Write("\nPress any key to continue..");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public override string ToString()
        {
            string productCategories = "";
            foreach(Category category in this.Categories)
            {
                productCategories += category.Name + ", ";
            }
            return $"\nID: {this.ID}\nName: {this.Name}" +
                $"\nManufacturer: {this.Manufacturer}\nShortCode: {this.ShortCode}" +
                $"\nCategories: {productCategories.Substring(0,productCategories.Length-2)}" +
                $"\nSellingPrice: $ {this.SellingPrice}";
        }
    }
}
