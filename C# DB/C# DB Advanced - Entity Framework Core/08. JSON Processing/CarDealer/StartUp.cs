using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            // Problem 00 - Import Data
            // ResetDatabase(db);

            // Problem 09 - Import Suppliers
            // var inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
            // Console.WriteLine(ImportSuppliers(db, inputJson));

            // Problem 10 - Import Parts
            // var inputJson = File.ReadAllText("../../../Datasets/parts.json");
            // Console.WriteLine(ImportParts(db, inputJson));

            // Problem 11 - Import Cars
            // var inputJson = File.ReadAllText("../../../Datasets/cars.json");
            // Console.WriteLine(ImportCars(db, inputJson));

            // Problem 12 - Import Customers
            // var inputJson = File.ReadAllText("../../../Datasets/customers.json");
            // Console.WriteLine(ImportCustomers(db, inputJson));

            // Problem 13 - Import Sales
            // var inputJson = File.ReadAllText("../../../Datasets/sales.json");
            // Console.WriteLine(ImportSales(db, inputJson));

            // Problem 14 - Export Ordered Customers
            // Console.WriteLine(GetOrderedCustomers(db));

            // Problem 15 - Export Cars from Make Toyota
            // Console.WriteLine(GetCarsFromMakeToyota(db));

            // Problem 16 - Export Local Suppliers
            // Console.WriteLine(GetLocalSuppliers(db));

            // Problem 17 - Export Cars With Their List Of Parts
            // Console.WriteLine(GetCarsWithTheirListOfParts(db));

            // Problem 18 - Export Total Sales By Customer
            // Console.WriteLine(GetTotalSalesByCustomer(db));

            // Problem 19 - Export Sales With Applied Discount
            //Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }
        // Problem 00 - Import Data
        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        // Problem 09 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        // Problem 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var count = context.Suppliers.Count();
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson).Where(s => s.SupplierId <= count);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        // Problem 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDTO = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDTO in carsDTO)
            {
                var newCar = new Car()
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TravelledDistance
                };

                cars.Add(newCar);

                foreach (var partId in carDTO.PartsId.Distinct())
                {
                    var newPartCar = new PartCar
                    {
                        PartId = partId,
                        Car = newCar
                    };

                    carParts.Add(newPartCar);
                }
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        // Problem 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        // Problem 13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        // Problem 14 - Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context
                    .Customers
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver)
                    .Select(c => new
                    {
                        c.Name,
                        BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                        c.IsYoungDriver
                    })
                    .ToList();

            var jsonOutput = JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);

            return jsonOutput;
        }

        // Problem 15 - Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromMakeToyota = context
                    .Cars
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .Where(c => c.Make == "Toyota")
                    .Select(c => new
                    {
                        c.Id,
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    })
                    .ToList();

            var jsonOutput = JsonConvert.SerializeObject(carsFromMakeToyota, Formatting.Indented);

            return jsonOutput;
        }

        // Problem 16 - Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

            return jsonOutput;
        }

        // Problem 17 - Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithTheirListOfParts = context
                    .Cars
                    .Select(c => new
                    {
                        car = new
                        {
                            c.Make,
                            c.Model,
                            c.TravelledDistance
                        },
                        parts = c
                        .PartCars
                        .Select(p => new
                        {
                            p.Part.Name,
                            Price = p.Part.Price.ToString("F")
                        })
                        .ToList()
                    })
                    .ToList();

            var jsonOutput = JsonConvert.SerializeObject(carsWithTheirListOfParts, Formatting.Indented);

            return jsonOutput;
        }

        // Problem 18 - Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSalesByCustomer = context
                    .Customers
                    .Where(c => c.Sales.Count > 0)
                    .Select(c => new
                    {
                        fullName = c.Name,
                        boughtCars = c.Sales.Count(),
                        spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                    })
                    .OrderByDescending(c => c.spentMoney)
                    .ThenByDescending(c => c.boughtCars)
                    .ToList();

            var jsonOutput = JsonConvert.SerializeObject(totalSalesByCustomer, Formatting.Indented);

            return jsonOutput;
        }

        // Problem 19 - Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithAppliedDiscount = context
                    .Sales
                    .Take(10)
                    .Select(s => new
                    {
                        car = new
                        {
                            s.Car.Make,
                            s.Car.Model,
                            s.Car.TravelledDistance
                        },
                        customerName = s.Customer.Name,
                        Discount = s.Discount.ToString("F2"),
                        price = s.Car.PartCars.Sum(p => p.Part.Price).ToString("F"),
                        priceWithDiscount = (s.Car.PartCars.Sum(p => p.Part.Price) * (1M - s.Discount / 100M)).ToString("F")
                    })
                    .ToList();

            var jsonOutput = JsonConvert.SerializeObject(salesWithAppliedDiscount, Formatting.Indented);

            return jsonOutput;
        }
    }
}