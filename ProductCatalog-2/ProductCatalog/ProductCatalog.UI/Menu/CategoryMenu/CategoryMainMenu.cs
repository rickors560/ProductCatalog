using ProductCatalog.Data.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.UI.Menu.CategoryMenu
{
    public class CategoryMainMenu
    {
        public static Categories CategoryDB;
        public CategoryMainMenu()
        {
            CategoryDB = new Categories();
        }
        internal void ShowMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"\n\tMain Menu -> Category Menu\n");
                Console.WriteLine("a. Add a Category");
                Console.WriteLine("b. List all Categories");
                Console.WriteLine("c. Delete a Category");
                Console.WriteLine("d. Search a Category");
                Console.WriteLine("e. Back\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        AddCategoryMenu.ShowAddCategoryMenu();
                        break;
                    case "b":
                        DisplayCategories.ShowDisplayCategories();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "c":
                        DeleteCategoryMenu.ShowDeleteCategoryMenu();
                        break;
                    case "d":
                        SearchCategoryMenu.ShowSearchCategoryMenu();
                        break;
                    case "e":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option!!");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}