using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.UI.Menu.CategoryMenu
{
    internal class DisplayCategories
    {
        internal static void ShowDisplayCategories()
        {
            Console.WriteLine("\nCategories:\n");
            Console.WriteLine(String.Format("\t{0,3} {1,-15} {2,-15} {3}", "ID", "Name", "ShortCode", "Description\n"));
            if (CategoryMainMenu.CategoryDB.GetCategories() == null)
            {
                Console.WriteLine("");
            }
            else
            {
                (CategoryMainMenu.CategoryDB.GetCategories()).ForEach(product =>
                {
                    Console.WriteLine(product);
                });
            }
        }
    }
}