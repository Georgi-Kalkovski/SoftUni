using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

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
            // string inputJson = File.ReadAllText("../../../Datasets/users.json");
            // Console.WriteLine(ImportUsers(db, inputJson));

            // Problem 02 - Import Products
            // string inputJson = File.ReadAllText("../../../Datasets/products.json");
            // Console.WriteLine(ImportProducts(db, inputJson));

            // Problem 03 - Import Categories
            // string inputJson = File.ReadAllText("../../../Datasets/categories.json");
            // Console.WriteLine(ImportCategories(db, inputJson));

            // Problem 04 - Import Categories and Products
            // string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            // Console.WriteLine(ImportCategoryProducts(db, inputJson));

            // Problem 05 - Export Products In Range
            // Console.WriteLine(GetProductsInRange(db));

            // Problem 06 - Export Successfully Sold Products
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
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert
                .DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        // Problem 02 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert
                .DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        // Problem 03 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // Problem 04 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert
                    .DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // Problem 05 - Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                    .Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .Select(x => new
                    {
                        name = x.Name,
                        price = x.Price,
                        seller = $"{ x.Seller.FirstName} {x.Seller.LastName}"
                    })
                    .OrderBy(x => x.price)
                    .ToList();

            var jsonOutput = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return jsonOutput;
        }

        // Problem 06 - Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context
                    .Users
                    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        soldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                    })
                    .OrderBy(u => u.lastName)
                    .ThenBy(u => u.firstName)
                    .ToList();

            var jsonOutput = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

            return jsonOutput;
        }

        // Problem 07 - Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context
                    .Categories
                    .Select(c => new
                    {
                        category = c.Name,
                        productsCount = c.CategoryProducts.Count(),
                        averagePrice = c.CategoryProducts.Average(p => p.Product.Price).ToString("F"),
                        totalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("F")
                    })
                    .OrderByDescending(c => c.productsCount)
                    .ToList();

            var jsonOutput = JsonConvert.SerializeObject(categoriesByProductsCount, Formatting.Indented);

            return jsonOutput;
        }

        // Problem 08 - Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context
                    .Users
                    .AsEnumerable()
                    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                    .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.ProductsSold
                            .Count(p => p.Buyer != null),
                            products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(ps => new
                            {
                                name = ps.Name,
                                price = ps.Price
                            })
                            .ToList()
                        }
                    })
                    .ToList();

            var usersInfo = new
            {
                usersCount = usersWithProducts.Count,
                users = usersWithProducts
            };


            var jsonOutput = JsonConvert.SerializeObject(usersInfo,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                });

            return jsonOutput;
        }
    }
}