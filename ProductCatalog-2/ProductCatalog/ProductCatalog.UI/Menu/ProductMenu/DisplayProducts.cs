using ProductCatalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.UI.Menu.ProductMenu
{
    internal class DisplayProducts
    {
        internal static void ShowDisplayProducts()
        {
            Console.WriteLine("\nProducts:\n");
            Console.WriteLine(String.Format("\t{0,3} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15} {6}", "ID", "Name", "Manufacturer", "ShortCode", "Category", "SellingPrice", "Description\n"));
            if (ProductMainMenu.ProductDB.GetProducts() == null)
            {
                Console.WriteLine("");
            }
            else
            {
                (ProductMainMenu.ProductDB.GetProducts()).ForEach(product =>
                {
                    Console.WriteLine(product);
                });
            }
        }
    }
}