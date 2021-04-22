using ProductCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("\nInvalid option!!\n");
                        Console.Write("\nPress any key to continue..");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
