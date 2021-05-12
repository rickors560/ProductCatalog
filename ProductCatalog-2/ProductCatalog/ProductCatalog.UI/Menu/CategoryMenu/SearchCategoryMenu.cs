using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.UI.Menu.CategoryMenu
{
    internal class SearchCategoryMenu
    {
        internal static void ShowSearchCategoryMenu()
        {
            Console.Clear();
            Console.WriteLine($"\n\tMain Menu -> Category Menu -> Search Category\n");
            Console.WriteLine("a. Search by ID");
            Console.WriteLine("b. Search by Name");
            Console.WriteLine("c. Search by ShortCode");
            Console.WriteLine("d. Back\n");
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    Console.WriteLine("Enter ID:");
                    int id = Int32.Parse(Console.ReadLine());
                    try
                    {
                        var foundById = CategoryMainMenu.CategoryDB.SearchCategory(category => category.ID == id).First();
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
                    var foundByName = CategoryMainMenu.CategoryDB.SearchCategory(category => category.Name.ToLower() == name);
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
                        var foundByShortCode = CategoryMainMenu.CategoryDB.SearchCategory(category => category.ShortCode == shortcode).First();
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