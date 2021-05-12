using FileProcess;
using ProductCatalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Data.DB
{
    public class Categories
    {
        private List<Category> CategoryList { get; set; }
        private HashSet<string> CategoryShortCodes { get; set; }
        public Categories()
        {
            this.CategoryList = new List<Category>();
            this.CategoryShortCodes = new HashSet<string>();
            this.GetFromCSV();
        }

        public List<Category> GetCategories()
        {
            return CategoryList;
        }

        public HashSet<string> GetShortCodes()
        {
            return CategoryShortCodes;
        }

        private void GetFromCSV()
        {
            CSVProcessor processor = new CSVProcessor(Paths.CategoryPath);
            var data = processor.GetAllRecords();
            if (data.Count == 0)    // if Empty File  // Add Header
            {
                processor.AppendRecord(new string[] { "ID", "Name", "ShortCode", "Description" });
                return;
            }
            data = data.Skip(1).ToList(); // Skiping Header
            if (data.Count == 0)
            {
                return;
            }
            data.ForEach((
                x =>
                {
                    var category = new Category()
                    {
                        ID = Int32.Parse(x[0]),
                        Name = x[1],
                        ShortCode = x[2],
                        Description = x[3],
                    };
                    Category.autoIncreamentor = category.ID;

                    this.CategoryList.Add(category);
                    CategoryShortCodes.Add(category.ShortCode);
                })
            );
        }

        public void AddCategory(Category category)
        {
            if (CategoryShortCodes.Contains(category.ShortCode))
            {
                return;
            }
            CSVProcessor processor = new CSVProcessor(Paths.CategoryPath);
            processor.AppendRecord(new string[] {
                category.ID.ToString(),
                category.Name,
                category.ShortCode,
                category.Description
            });
            CategoryList.Add(category);
            CategoryShortCodes.Add(category.ShortCode);
        }

        public List<Category> SearchCategory(Predicate<Category> predicate)
        {
            return CategoryList.FindAll(predicate);
        }

        public void DeleteCategory(Category category) {
            CategoryList.Remove(category);
            var data = new List<string[]>() { new string[] { "ID", "Name", "ShortCode", "Description" } };

            CategoryList.ForEach(x =>
            {
                data.Add(new string[] {
                    x.ID.ToString(),
                    x.Name,
                    x.ShortCode,
                    x.Description });
            });

            CSVProcessor processor = new CSVProcessor(Paths.CategoryPath);
            processor.OverWriteRecords(data);
        }
    }
}