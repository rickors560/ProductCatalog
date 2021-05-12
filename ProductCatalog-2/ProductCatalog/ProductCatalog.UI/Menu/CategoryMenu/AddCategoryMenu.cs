using ProductCatalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.UI.Menu.CategoryMenu
{
    internal class AddCategoryMenu
    {
        internal static void ShowAddCategoryMenu()
        {
            Console.Clear();
            Console.WriteLine($"\n\tMain Menu -> Category Menu -> Add Category\n");
            Console.WriteLine("\nEnter Details of Category:\n");
            Console.WriteLine($"ID : {Category.autoIncreamentor + 1}");

            Console.WriteLine("Enter the Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the ShortCode:");
            string shortCode = Console.ReadLine();

            if (name.Length <= 0 || shortCode.Length <= 0 || description.Length <= 0)
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
            if (CategoryMainMenu.CategoryDB.GetShortCodes().Contains(shortCode))
            {
                Console.WriteLine("ShortCode Must be unique!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
            Category newCategory = new Category()
            {
                Name = name,
                ShortCode = shortCode,
                Description = description
            };

            CategoryMainMenu.CategoryDB.AddCategory(newCategory);
        }
    }
}