using FileProcess;
using ProductCatalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Data.DB
{
    public class Products
    {
        private List<Product> ProductList { get; set; }
        private HashSet<string> ProductShortCodes { get; set; }

        public Products()
        {
            ProductList = new List<Product>();
            ProductShortCodes = new HashSet<string>();
            this.GetFromCSV();
        }

        public List<Product> GetProducts() {
            return ProductList;
        }

        public HashSet<string> GetShortCodes() {
            return ProductShortCodes;
        }

        private void GetFromCSV() {
            CSVProcessor processor = new CSVProcessor(Paths.ProductPath);
            var data = processor.GetAllRecords();
            if (data.Count == 0)    // if Empty File  // Add Header
            {
                processor.AppendRecord(new string[] { "ID","Name", "Manufacturer", "ShortCode", "Category", "Description", "SellingPrice" });
                return;
            }
            data = data.Skip(1).ToList(); // Skiping Header
            if (data.Count == 0) {
                return;
            }
            data.ForEach((
                x =>
                {
                    var product = new Product()
                    {
                        ID = Int32.Parse(x[0]),
                        Name = x[1],
                        Manufacturer = x[2],
                        ShortCode = x[3],
                        Category = x[4],
                        Description = x[5],
                        SellingPrice = Int32.Parse(x[6])
                    };
                    Product.autoIncreamentor = product.ID;

                    this.ProductList.Add(product);
                    ProductShortCodes.Add(product.ShortCode);
                })
            );
        }

        public void AddProduct(Product product) {
            if (ProductShortCodes.Contains(product.ShortCode))
            {
                return;
            }
            CSVProcessor processor = new CSVProcessor(Paths.ProductPath);
            processor.AppendRecord(new string[] {
                product.ID.ToString(),
                product.Name,
                product.Manufacturer,
                product.ShortCode,
                product.Category,
                product.Description,
                product.SellingPrice.ToString()
            });
            ProductList.Add(product);
            ProductShortCodes.Add(product.ShortCode);
        }

        public List<Product> SearchProduct(Predicate<Product> predicate) {
            return ProductList.FindAll(predicate);
        }

        public void DeleteProduct(Product product) {
            ProductList.Remove(product);
            var data = new List<string[]>() { new string[] { "ID", "Name", "Manufacturer", "ShortCode", "Category", "Description", "SellingPrice" } };

            ProductList.ForEach(x =>
            {
                data.Add(new string[] {
                    x.ID.ToString(),
                    x.Name,
                    x.Manufacturer,
                    x.ShortCode,
                    x.Category,
                    x.Description,
                    x.SellingPrice.ToString()});
            });

            CSVProcessor processor = new CSVProcessor(Paths.ProductPath);
            processor.OverWriteRecords(data);
        }
    }
}