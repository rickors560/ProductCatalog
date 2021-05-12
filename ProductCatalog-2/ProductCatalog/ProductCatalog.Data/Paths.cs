using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductCatalog.Data
{
    public struct Paths
    {
        //C:\Assignment2 C#\ProductCatalog-2\ProductCatalog\data\Product
        public static string ProductPath { get; } = System.IO.Path.Combine((new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName),"data", "Product", "products.csv");
        //C:\Assignment2 C#\ProductCatalog - 2\ProductCatalog\data\Category
        public static string CategoryPath { get; } = System.IO.Path.Combine((new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName), "data", "Category", "categories.csv");
    }
}