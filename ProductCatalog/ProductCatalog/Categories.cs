using ProductCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog
{
    public class Categories
    {
        public List<Category> CategoryList { get; set; }
        public HashSet<string> CategoryShortCodes { get; set; }
        public Categories()
        {
            this.CategoryList = new List<Category>() {
                new Category
                {
                    Name = "Technology",
                    ShortCode = "Tech",
                    Description = "Some Technical Products"
                },
                new Category
                { 
                    Name = "Food",
                    ShortCode = "Food",
                    Description = "Food products"
                }
            };
            this.CategoryShortCodes = new HashSet<string>();
        }
        public void ShowCategoryCatalog() {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n\t\t-------------------Category Catalog-------------------\n");
                Console.WriteLine("\na. Add a Category");
                Console.WriteLine("b. List all Categories");
                Console.WriteLine("c. Delete a Category");
                Console.WriteLine("d. Search a Category");
                Console.WriteLine("e. Back\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        this.AddCategory();
                        break;
                    case "b":
                        this.DisplayCategories();
                        Console.Write("\nPress any key to continue..");
                        Console.ReadKey();
                        break;
                    case "c":
                        this.DeleteCategory();
                        break;
                    case "d":
                        this.SearchCategory();
                        break;
                    case "e":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option!!");
                        Console.Write("\nPress any key to continue..");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
        public void AddCategory() {
            Console.WriteLine("\nEnter Details of Category:\n");
            Console.WriteLine($"Category ID : {Category.autoIncreamentor + 1}");
            Console.WriteLine("Enter the Category Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Category ShortCode:");
            string shortCode = Console.ReadLine();
            Console.WriteLine("Enter the Category Description:");
            string description = Console.ReadLine();
            if (name.Length <= 0 ||shortCode.Length <= 0 || description.Length <= 0)
            {
                Console.WriteLine("\nAll fields are mandatory!!");
                Console.Write("\nPress any key to continue..");
                Console.ReadKey();
                return;
            }
            if (shortCode.Length > 4)
            {
                Console.WriteLine("\nShortCode length must be 0 to 4!");
                Console.Write("\nPress any key to continue..");
                Console.ReadKey();
                return;
            }
            if (this.CategoryShortCodes.Contains(shortCode))
            {
                Console.WriteLine("\nShortCode Must be unique!");
                Console.Write("\nPress any key to continue..");
                Console.ReadKey();
                return;
            }
            Category newCategory = new Category();
            newCategory.Name = name;
            newCategory.ShortCode = shortCode;
            newCategory.Description = description;
            this.CategoryShortCodes.Add(shortCode);
            this.CategoryList.Add(newCategory);
        }
        public void DisplayCategories() {
            Console.WriteLine("\nCategories:");
            this.CategoryList.ForEach(category =>
            {
                Console.WriteLine(category);
            });
        }
        public void DeleteCategory() {
            Console.WriteLine("\na. Delete by ID");
            Console.WriteLine("b. Delete by ShortCode");
            Console.WriteLine("c. Back\n");
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    Console.WriteLine("Enter ID:");
                    int id = Int32.Parse(Console.ReadLine());
                    try
                    {
                        var x = this.CategoryList.Single(c => c.ID == id);
                        this.CategoryList.Remove(x);
                        Catalog.Products.ProductList.ForEach(product => 
                            {
                                if (product.Categories.Contains(x)) {
                                    product.Categories.Remove(x);
                                }
                            }
                        );
                        Console.WriteLine("Removed!!");
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.Write("\nPress any key to continue..");
                    Console.ReadKey();
                    break;
                case "b":
                    Console.WriteLine("Enter ShortCode:");
                    string shortcode = Console.ReadLine();
                    try
                    {
                        var x = this.CategoryList.Single(c => c.ShortCode == shortcode);
                        this.CategoryList.Remove(x);
                        Catalog.Products.ProductList.ForEach(product =>
                            {
                                if (product.Categories.Contains(x))
                                {
                                    product.Categories.Remove(x);
                                }
                            }
                        );
                        Console.WriteLine("Removed!!");
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.Write("\nPress any key to continue..");
                    Console.ReadKey();
                    break;
                case "c":
                    break;
                default:
                    Console.WriteLine("Invalid option!!");
                    Console.Write("\nPress any key to continue..");
                    Console.ReadKey();
                    break;
            }
        }
        public void SearchCategory() {
            Console.WriteLine("\na. Search by ID");
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
                        var foundById = this.CategoryList.Single(category => category.ID == id);
                        Console.WriteLine(foundById);
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.Write("\nPress any key to continue..");
                    Console.ReadKey();
                    break;
                case "b":
                    Console.WriteLine("Enter Name:");
                    string name = Console.ReadLine().ToLower();
                    var foundByName = this.CategoryList.Where(category => category.Name.ToLower() == name).ToList();
                    if (foundByName.Count > 0)
                    {
                        Console.WriteLine("Results:\n\n");
                        foundByName.ForEach(i => Console.WriteLine(i));
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.Write("\nPress any key to continue..");
                    Console.ReadKey();
                    break;
                case "c":
                    Console.WriteLine("Enter ShortCode:");
                    string shortcode = Console.ReadLine();
                    try
                    {
                        var foundByShortCode = this.CategoryList.Single(category => category.ShortCode == shortcode);
                        Console.WriteLine("Results:\n\n");
                        Console.WriteLine(foundByShortCode);
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                    }
                    Console.Write("\nPress any key to continue..");
                    Console.ReadKey();
                    break;
                case "d":
                    break;
                default:
                    Console.WriteLine("Invalid option!!");
                    Console.Write("\nPress any key to continue..");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
