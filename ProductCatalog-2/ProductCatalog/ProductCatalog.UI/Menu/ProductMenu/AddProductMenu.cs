using ProductCatalog.Data.DB;
using ProductCatalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.UI.Menu.ProductMenu
{
    internal class AddProductMenu
    {
        internal static void ShowAddProductMenu()
        {
            Console.Clear();
            Console.WriteLine($"\n\tMain Menu -> Product Menu -> Add Product\n");
            
            Categories categories = new Categories();

            if (categories.GetCategories().Count < 1) {
                Console.WriteLine("Add some categories first!!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nEnter Details of Product:\n");
            Console.WriteLine($"ID : {Product.autoIncreamentor + 1}");

            Console.WriteLine("Enter the Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the Manufacturer:");
            string manufacturer = Console.ReadLine();

            Console.WriteLine("Enter the Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the Selling Price:");
            string x = Console.ReadLine();
            int sellingPrice;
            if (!Int32.TryParse(x, out sellingPrice))
            {
                Console.WriteLine("Price must be a number!!");
                Console.Write("\nPress any key to continue..");
                Console.ReadKey();
                return;
            }
            if (sellingPrice < 0)
            {
                Console.WriteLine("Price must be greater than 0!!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter the ShortCode:");
            string shortCode = Console.ReadLine();
            if (name.Length <= 0 || manufacturer.Length <= 0 || shortCode.Length <= 0 || description.Length <= 0)
            {
                Console.WriteLine("All fields are mandatory!!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            if (shortCode.Length > 4)
            {
                Console.WriteLine("ShortCode length must be 0 to 4!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
            if (ProductMainMenu.ProductDB.GetShortCodes().Contains(shortCode))
            {
                Console.WriteLine("ShortCode Must be unique!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("Choose a Category(By ID):");
            categories.GetCategories().ForEach(x =>
            {
                Console.WriteLine($"\t{x.ID}. {x.Name}");
            });
            string y = Console.ReadLine();
            int categoryID;
            if (!Int32.TryParse(y, out categoryID))
            {
                Console.WriteLine("ID must be a number!!");
                Console.Write("\nPress any key to continue..");
                Console.ReadKey();
                return;
            }

            string categoryName = "";
            try
            {
                categoryName = categories.SearchCategory(x => x.ID == categoryID).First().Name;
                Console.WriteLine(categoryName);
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine("Category Not Found");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
            

            Product newProduct = new Product()
            {
                Name = name,
                Manufacturer = manufacturer,
                ShortCode = shortCode,
                Description = description,
                SellingPrice = sellingPrice,
                Category = categoryName
            };

            ProductMainMenu.ProductDB.AddProduct(newProduct);
        }
    }
}