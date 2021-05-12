using ProductCatalog.UI.Menu.CategoryMenu;
using ProductCatalog.UI.Menu.ProductMenu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProductCatalog.UI.Menu
{
    public class MainMenu
    {
        public static void ShowMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"\n\tMain Menu\n");
                Console.WriteLine("a. Category");
                Console.WriteLine("b. Product");
                Console.WriteLine("c. Exit\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        Console.Clear();
                        CategoryMainMenu categoryMainMenu = new CategoryMainMenu();
                        categoryMainMenu.ShowMainMenu();
                        break;
                    case "b":
                        Console.Clear();
                        ProductMainMenu productMainMenu = new ProductMainMenu();
                        productMainMenu.ShowMainMenu();
                        break;
                    case "c":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        Thread.Sleep(500);
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