using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.UI.Menu.ProductMenu
{
    internal class DeleteProductMenu
    {
        internal static void ShowDeleteProductMenu()
        {
            Console.Clear();
            Console.WriteLine($"\n\tMain Menu -> Product Menu -> Delete Product\n");
            Console.WriteLine("a. Delete by ID");
            Console.WriteLine("b. Delete by ShortCode");
            Console.WriteLine("c. Back\n");
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    Console.WriteLine("Enter ID:");
                    int id = Int32.Parse(Console.ReadLine());
                    try
                    {
                        var x = ProductMainMenu.ProductDB.GetProducts().Single(p => p.ID == id);
                        ProductMainMenu.ProductDB.DeleteProduct(x);
                        Console.WriteLine("Removed!!");
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "b":
                    Console.WriteLine("Enter ShortCode:");
                    string shortcode = Console.ReadLine();
                    try
                    {
                        var x = ProductMainMenu.ProductDB.GetProducts().Single(p => p.ShortCode == shortcode);
                        ProductMainMenu.ProductDB.DeleteProduct(x);
                        Console.WriteLine("Removed!!");
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "c":
                    break;
                default:
                    Console.WriteLine("Invalid option!!");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}