using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.UI.Menu.CategoryMenu
{
    internal class DeleteCategoryMenu
    {
        internal static void ShowDeleteCategoryMenu()
        {
            Console.Clear();
            Console.WriteLine($"\n\tMain Menu -> Category Menu -> Delete Category\n");
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
                        var x = CategoryMainMenu.CategoryDB.GetCategories().Single(p => p.ID == id);
                        CategoryMainMenu.CategoryDB.DeleteCategory(x);
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
                        var x = CategoryMainMenu.CategoryDB.GetCategories().Single(p => p.ShortCode == shortcode);
                        CategoryMainMenu.CategoryDB.DeleteCategory(x);
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