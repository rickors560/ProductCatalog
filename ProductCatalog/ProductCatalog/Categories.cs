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
                Console.WriteLine("\n\t\t-------------------Category Catelog-------------------\n");
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
                Console.ReadKey();
                return;
            }
            if (shortCode.Length > 4)
            {
                Console.WriteLine("\nShortCode length must be 0 to 4!");
                Console.ReadKey();
                return;
            }
            if (this.CategoryShortCodes.Contains(shortCode))
            {
                Console.WriteLine("\nShortCode Must be unique!");
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
            Console.WriteLine("Categories:\n");
            this.CategoryList.ForEach(category =>
            {
                Console.WriteLine(category);
            });
        }
        public void DeleteCategory() {
            Console.WriteLine("\na. Delete by ID");
            Console.WriteLine("\na. Delete by ShortCode");
            Console.WriteLine("\nc. Back");
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    Console.WriteLine("Enter ID:");
                    int id = Int32.Parse(Console.ReadLine());
                    try
                    {
                        var x = this.CategoryList.Single(c => c.ID == id);
                        this.CategoryList.Remove(x);
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                    }
                    break;
                case "b":
                    Console.WriteLine("Enter ShortCode:");
                    string shortcode = Console.ReadLine();
                    try
                    {
                        var x = this.CategoryList.Single(c => c.ShortCode == shortcode);
                        this.CategoryList.Remove(x);
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
                        Console.ReadKey();
                    }
                    catch (System.InvalidOperationException)
                    {
                        Console.WriteLine("Not Found");
                        Console.ReadKey();
                    }
                    break;
                case "b":
                    Console.WriteLine("Enter Name:");
                    string name = Console.ReadLine().ToLower();
                    var foundByName = this.CategoryList.Where(category => category.Name.ToLower() == name).ToList();
                    if (foundByName.Count > 0)
                    {
                        Console.WriteLine("Results:\n\n");
                        foundByName.ForEach(i => Console.WriteLine(i));
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                        Console.ReadKey();
                    }
                    break;
                case "c":
                    Console.WriteLine("Enter ShortCode:");
                    string shortcode = Console.ReadLine();
                    try
                    {
                        var foundByShortCode = this.CategoryList.Single(category => category.ShortCode == shortcode);
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
                    break;
                default:
                    Console.WriteLine("Invalid option!!");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
