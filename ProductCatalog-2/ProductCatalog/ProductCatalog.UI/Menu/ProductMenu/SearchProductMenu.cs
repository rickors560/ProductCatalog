using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.UI.Menu.ProductMenu
{
    internal class SearchProductMenu
    {
        internal static void ShowSearchProductMenu()
        {
            Console.Clear();
            Console.WriteLine($"\n\tMain Menu -> Product Menu -> Search Product\n");
            Console.WriteLine("a. Search by ID");
            Console.WriteLine("b. Search by Name");
            Console.WriteLine("c. Search by ShortCode");
            Console.WriteLine("d. Search by SellingPrice Greater than");
            Console.WriteLine("e. Search by SellingPrice Less than");
            Console.WriteLine("f. Search by SellingPrice Equal to");
            Console.WriteLine("g. Back\n");
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    Console.WriteLine("Enter ID:");
                    int id = Int32.Parse(Console.ReadLine());
                    try
                    {
                        var foundById = ProductMainMenu.ProductDB.SearchProduct(product => product.ID == id).First();
                        Console.WriteLine("Results:\n\n");
                        Console.WriteLine(foundById);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    break;
                case "b":
                    Console.WriteLine("Enter Name:");
                    string name = Console.ReadLine().ToLower();
                    var foundByName = ProductMainMenu.ProductDB.SearchProduct(product => product.Name.ToLower() == name);
                    if (foundByName.Count > 0)
                    {
                        Console.WriteLine("Results:\n\n");
                        foundByName.ForEach(i => Console.WriteLine(i));
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "c":
                    Console.WriteLine("Enter ShortCode:");
                    string shortcode = Console.ReadLine();
                    try
                    {
                        var foundByShortCode = ProductMainMenu.ProductDB.SearchProduct(product => product.ShortCode == shortcode).First();
                        Console.WriteLine("Results:\n\n");
                        Console.WriteLine(foundByShortCode);
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "d":
                    Console.WriteLine("Enter SellingPrice Greater than:");
                    int sp = Int32.Parse(Console.ReadLine());
                    var foundByPrice = ProductMainMenu.ProductDB.SearchProduct(product => product.SellingPrice >= sp);
                    if (foundByPrice.Count > 0)
                    {
                        Console.WriteLine("Results:\n\n");
                        foundByPrice.ForEach(i => Console.WriteLine(i));
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "e":
                    Console.WriteLine("Enter SellingPrice Less than:");
                    sp = Int32.Parse(Console.ReadLine());
                    foundByPrice = ProductMainMenu.ProductDB.SearchProduct(product => product.SellingPrice <= sp);
                    if (foundByPrice.Count > 0)
                    {
                        Console.WriteLine("Results:\n\n");
                        foundByPrice.ForEach(i => Console.WriteLine(i));
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "f":
                    Console.WriteLine("Enter SellingPrice Equal to:");
                    sp = Int32.Parse(Console.ReadLine());
                    foundByPrice = ProductMainMenu.ProductDB.SearchProduct(product => product.SellingPrice == sp);
                    if (foundByPrice.Count > 0)
                    {
                        Console.WriteLine("Results:\n\n");
                        foundByPrice.ForEach(i => Console.WriteLine(i));
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "g":
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