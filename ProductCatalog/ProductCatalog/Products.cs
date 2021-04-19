using ProductCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog
{
    public class Products
    {
        public List<Product> ProductList { get; set; }
        public HashSet<string> ProductShortCodes { get; set; }
        public Products()
        {
            this.ProductList = new List<Product>();
            this.ProductShortCodes = new HashSet<string>();
        }
        public void ShowProductCatalog()
        {
            bool exit = false;
            while (!exit) {
                Console.WriteLine("\n\t\t-------------------Product Catalog-------------------\n");
                Console.WriteLine("\na. Add a Product");
                Console.WriteLine("b. List all Products");
                Console.WriteLine("c. Delete a Product");
                Console.WriteLine("d. Search a Product");
                Console.WriteLine("e. Back\n");
                switch (Console.ReadLine().ToLower()) {
                    case "a":
                        this.AddProduct();
                        break;
                    case "b":
                        this.DisplayProducts();
                        Console.ReadKey();
                        break;
                    case "c":
                        this.DeleteProduct();
                        break;
                    case "d":
                        this.SearchProduct();
                        break;
                    case "e":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option!!");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
        public void AddProduct() {
            Console.WriteLine("\nEnter Details of Product:\n");
            Console.WriteLine($"ID : {Product.autoIncreamentor + 1}");
            Console.WriteLine("Enter the Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Manufacturer:");
            string manufacturer = Console.ReadLine();
            Console.WriteLine("Enter the ShortCode:");
            string shortCode = Console.ReadLine();
            Console.WriteLine("Enter the Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the Selling Price:");
            string x = Console.ReadLine();
            int sellingPrice; Int32.TryParse(x, out sellingPrice);
            if (name.Length <= 0 || manufacturer.Length <= 0 || shortCode.Length <= 0 || description.Length <= 0 || sellingPrice <= 0) {
                Console.WriteLine("\nAll fields are mandatory!!");
                Console.ReadKey();
                return;
            }
            if (shortCode.Length > 4) {
                Console.WriteLine("\nShortCode length must be 0 to 4!");
                Console.ReadKey();
                return;
            }
            if (this.ProductShortCodes.Contains(shortCode)) {
                Console.WriteLine("\nShortCode Must be unique!");
                Console.ReadKey();
                return;
            }
            Product newProduct = new Product();
            newProduct.AddCategories();
            newProduct.Name = name;
            newProduct.Manufacturer = manufacturer;
            newProduct.ShortCode = shortCode;
            newProduct.Description = description;
            newProduct.SellingPrice = sellingPrice;
            this.ProductShortCodes.Add(shortCode);
            this.ProductList.Add(newProduct);
        }
        public void DisplayProducts()
        {
            Console.WriteLine("\nProducts:\n");
            this.ProductList.ForEach(product =>
            {
                Console.WriteLine(product);
            });
        }
        public void DeleteProduct() {
            Console.WriteLine("\na. Delete by ID");
            Console.WriteLine("\na. Delete by ShortCode");
            Console.WriteLine("\nc. Back");
            switch (Console.ReadLine().ToLower()) {
                case "a":
                    Console.WriteLine("Enter ID:");
                    int id = Int32.Parse(Console.ReadLine());
                    try
                    {
                        var x = this.ProductList.Single(p => p.ID == id);
                        this.ProductList.Remove(x);
                    }
                    catch (System.InvalidOperationException) {
                        Console.WriteLine("Not Found");
                    }
                    break;
                case "b":
                    Console.WriteLine("Enter ShortCode:");
                    string shortcode = Console.ReadLine();
                    try
                    {
                        var x = this.ProductList.Single(p => p.ShortCode == shortcode);
                        this.ProductList.Remove(x);
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                    }
                    break;
                case "c":
                    break;
                default:
                    Console.WriteLine("Invalid option!!");
                    Console.ReadKey();
                    break;
            }
        }
        public void SearchProduct() {
            Console.WriteLine("\na. Search by ID");
            Console.WriteLine("b. Search by Name");
            Console.WriteLine("c. Search by ShortCode");
            Console.WriteLine("d. Search by SellingPrice Greater than");
            Console.WriteLine("e. Search by SellingPrice Less than");
            Console.WriteLine("f. Search by SellingPrice Equal to");
            Console.WriteLine("g. Back\n");
            switch (Console.ReadLine().ToLower()) {
                case "a":
                    Console.WriteLine("Enter ID:");
                    int id = Int32.Parse(Console.ReadLine());
                    try
                    {
                        var foundById = this.ProductList.Single(product => product.ID == id);
                        Console.WriteLine("Results:\n\n");
                        Console.WriteLine(foundById);
                        Console.ReadKey();
                    }
                    catch (System.InvalidOperationException) {
                        Console.WriteLine("Not Found");
                        Console.ReadKey();
                    }
                    break;
                case "b":
                    Console.WriteLine("Enter Name:");
                    string name = Console.ReadLine().ToLower();
                    var foundByName = this.ProductList.Where(product => product.Name.ToLower() == name).ToList();
                    if (foundByName.Count > 0)
                    {
                        Console.WriteLine("Results:\n\n");
                        foundByName.ForEach(i => Console.WriteLine(i));
                        Console.ReadKey();
                    }
                    else {
                        Console.WriteLine("Not Found");
                        Console.ReadKey();
                    }
                    break;
                case "c":
                    Console.WriteLine("Enter ShortCode:");
                    string shortcode = Console.ReadLine();
                    try
                    {
                        var foundByShortCode = this.ProductList.Single(product => product.ShortCode == shortcode);
                        Console.WriteLine("Results:\n\n");
                        Console.WriteLine(foundByShortCode);
                        Console.ReadKey();
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                        Console.ReadKey();
                    }
                    break;
                case "d":
                    Console.WriteLine("Enter SellingPrice Greater than:");
                    int sp = Int32.Parse(Console.ReadLine());
                    var foundByPrice = this.ProductList.Where(product => product.SellingPrice >= sp).ToList();
                    if (foundByPrice.Count > 0)
                    {
                        Console.WriteLine("Results:\n\n");
                        foundByPrice.ForEach(i => Console.WriteLine(i));
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                        Console.ReadKey();
                    }
                    break;
                case "e":
                    Console.WriteLine("Enter SellingPrice Less than:");
                    sp = Int32.Parse(Console.ReadLine());
                    foundByPrice = this.ProductList.Where(product => product.SellingPrice <= sp).ToList();
                    if (foundByPrice.Count > 0)
                    {
                        Console.WriteLine("Results:\n\n");
                        foundByPrice.ForEach(i => Console.WriteLine(i));
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                        Console.ReadKey();
                    }
                    break;
                case "f":
                    Console.WriteLine("Enter SellingPrice Equal to:");
                    sp = Int32.Parse(Console.ReadLine());
                    foundByPrice = this.ProductList.Where(product => product.SellingPrice == sp).ToList();
                    if (foundByPrice.Count > 0)
                    {
                        Console.WriteLine("Results:\n\n");
                        foundByPrice.ForEach(i => Console.WriteLine(i));
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                        Console.ReadKey();
                    }
                    break;
                case "g":
                    break;
                default:
                    Console.WriteLine("Invalid option!!");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
