using ProductCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog
{
    public class Catalog
    {
        public static Categories Categories { get; set; }
        public Products Products { get; set; }
        public Catalog()
        {
            Catalog.Categories = new Categories();
            this.Products = new Products();
        }
        public void ShowCatalog() {
            bool exit = false;
            while (!exit) {
                Console.WriteLine("\n\t\t-------------------Welcome-------------------\n");
                Console.WriteLine("\na. Category");
                Console.WriteLine("b. Product");
                Console.WriteLine("c. Exit\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        Console.Clear();
                        Catalog.Categories.ShowCategoryCatalog();
                        break;
                    case "b":
                        Console.Clear();
                        this.Products.ShowProductCatalog();
                        break;
                    case "c":
                        exit = true;
                        Console.WriteLine("\nExiting\n");
                        break;
                    default:
                        Console.WriteLine("\nInvalid option!!\n");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
        public void ShowCatagoryCatalog() {
            
            bool exit = false;
            while (!exit) {
                Console.WriteLine("\na. Enter a Category");
                Console.WriteLine("b. List all Categories");
                Console.WriteLine("c. Delete a Category");
                Console.WriteLine("d. Search a Category");
                Console.WriteLine("e. Back to MainMenu\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        
                        break;
                    case "b":
                        Console.WriteLine("category b");
                        break;
                    case "c":
                        Console.WriteLine("category c");
                        break;
                    case "d":
                        Console.WriteLine("category d");
                        break;
                    case "e":
                        Console.WriteLine("category e");
                        break;
                    default:
                        Console.WriteLine("\nInvalid option\n");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
