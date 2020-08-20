using Microsoft.EntityFrameworkCore.Update;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XMLHelper;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            // Problem 00 - Import Data
            // ResetDatabase(db);

            // Problem 01 - Import Users
            // string inputXml = File.ReadAllText("../../../Datasets/users.xml");
            // Console.WriteLine(ImportUsers(db, inputXml));

            // Problem 02 - Import Products
            // string inputXml = File.ReadAllText("../../../Datasets/products.xml");
            // Console.WriteLine(ImportProducts(db, inputXml));

            // Problem 03 - Import Categories
            // string inputXml = File.ReadAllText("../../../Datasets/categories.xml");
            // Console.WriteLine(ImportCategories(db, inputXml));

            // Problem 04 - Import Categories and Products
            // string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            // Console.WriteLine(ImportCategoryProducts(db, inputXml));

            // Problem 05 - Export Products In Range
            // Console.WriteLine(GetProductsInRange(db));
            // var prodcutsInRange = GetProductsInRange(db);
            // File.WriteAllText("../../../results/productsInRange.xml", prodcutsInRange);

            // Problem 06 - Export Sold Products
            // Console.WriteLine(GetSoldProducts(db));

            // Problem 07 - Export Categories By Products Count
            // Console.WriteLine(GetCategoriesByProductsCount(db));

            // Problem 08 - Export Users and Products
            // Console.WriteLine(GetUsersWithProducts(db));
        }

        // Problem 00 - Import Data
        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        // Problem 01 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";

            var usersResult = XmlConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            var users = usersResult
               .Select(u => new
               {
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   Age = u.Age
               })
               .ToList();

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        // Problem 02 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";

            var productsResult = XmlConverter.Deserializer<ImportProductDto>(inputXml, rootElement);

            var products = productsResult
               .Select(p => new Product
               {
                   Name = p.Name,
                   Price = p.Price,
                   SellerId = p.SellerId,
                   BuyerId = p.BuyerId
               })
               .ToList();

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        // Problem 03 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";
            var categoriesResult = XmlConverter.Deserializer<ImportCategoryDto>(inputXml, rootElement);

            var categories = categoriesResult
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // Problem 04 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "CategoryProducts";

            var categoryProductsResult = XmlConverter.Deserializer<ImportCategoryProductDto>(inputXml, rootElement);

            var categoryProducts = categoryProductsResult
                .Where(i => context.Categories.Any(s => s.Id == i.CategoryId) &&
                context.Products.Any(s => s.Id == i.ProductId))
                .Select(cp => new CategoryProduct
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                })
                .ToList();

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // Problem 05 - Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";

            var productsInRange = context
                        .Products
                        .Where(p => p.Price >= 500 && p.Price <= 1000)
                        .Select(p => new ExportProductInfoDto
                        {
                            Name = p.Name,
                            Price = p.Price,
                            Buyer = $"{ p.Buyer.FirstName} {p.Buyer.LastName}"
                        })
                        .OrderBy(x => x.Price)
                        .Take(10)
                        .ToList();

            var xmlOutput = XmlConverter.Serialize(productsInRange, rootElement);

            return xmlOutput;
        }

        // Problem 06 - Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var soldProducts = context
                .Users
                .Where(u => u.ProductsSold.Count >= 1)
                .Select(u => new ExportUserProductInfoDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new UserProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
               .ToArray()
                })
                .OrderBy(u=>u.LastName)
                .ThenBy(u=>u.FirstName)
                .Take(5)
                .ToList();

            var xmlOutput = XmlConverter.Serialize(soldProducts, rootElement);

            return xmlOutput;
        }

        // Problem 07 - Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categoriesByProductsCount = context
                .Categories
                .Select(c => new ExportCategoriesByProductsCountDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            var xmlOutput = XmlConverter.Serialize(categoriesByProductsCount, rootElement);

            return xmlOutput;
        }

        // Problem 08 - Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var targetUsers = context.Users
                .ToArray()
                .Where(x => x.ProductsSold.Any())
                .Select(x => new UserInfo
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductCount
                    {
                        Count = x.ProductsSold.Count,
                        Products = x.ProductsSold.Select(p => new SoldProduct
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToList()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .Take(10)
                .ToList();

            var finalObj = new ExportUserCountDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = targetUsers
            };

            const string rootName = "Users";
            var resultXml = XmlConverter.Serialize(finalObj, rootName);
            return resultXml;
        }
    }
}