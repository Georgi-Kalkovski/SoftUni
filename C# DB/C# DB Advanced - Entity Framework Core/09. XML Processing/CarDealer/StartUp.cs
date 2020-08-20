using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using CarDealer.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            // string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            // Console.WriteLine(ImportSuppliers(db, suppliersXml));

            // Problem 10 - Import Parts
            // string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            // Console.WriteLine(ImportParts(db, partsXml));

            // Problem 11 - Import Cars
            // string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            // Console.WriteLine(ImportCars(db, carsXml));

            // Problem 12 - Import Customers
            // string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            // Console.WriteLine(ImportCustomers(db, customersXml));

            // Problem 13 - Import Sales
            // string salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            // Console.WriteLine(ImportSales(db, salesXml));

            // Problem 14 - Export Cars With Distance
            // Console.WriteLine(GetCarsWithDistance(db));

            // Problem 15 - Export Cars From Make BMW
            // Console.WriteLine(GetCarsFromMakeBmw(db));

            // Problem 16 - Export Local Suppliers
            // Console.WriteLine(GetLocalSuppliers(db));

            // Problem 17 - Export Cars With Their List Of Parts
            // Console.WriteLine(GetCarsWithTheirListOfParts(db));

            // Problem 18 - Export Total Sales By Customer
            // Console.WriteLine(GetTotalSalesByCustomer(db));

            // Problem 19 - Export Sales With Applied Discount
            // Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        // Problem 00 - Import Data
        public static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            System.Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            System.Console.WriteLine("Database was successfully created!");
        }

        // Problem 09 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Suppliers";

            var suppliersResult = XmlConverter.Deserializer<SupplierDto>(inputXml, rootElement);

            var suppliers = suppliersResult
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        // Problem 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Parts";

            var partsResult = XmlConverter.Deserializer<PartsDto>(inputXml, rootElement);

            var suppCount = context.Suppliers.Count();

            var parts = partsResult
                .Where( s=> s.SupplierId > 0 && s.SupplierId <= suppCount)
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        // Problem 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Cars";

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            var partsCount = context.Parts.Count();
            var carsResult = XmlConverter.Deserializer<CarsDto>(inputXml, rootElement);

            foreach (var car in carsResult)
            {
                var newCar = new Car { Make = car.Make, Model = car.Model, TravelledDistance = car.TraveledDistance };

                cars.Add(newCar);
                foreach (var partId in car.CarParts.Select(x => new { partId = x.PartId }).Distinct())
                {
                    var newCarPart = new PartCar
                    {
                        PartId = partId.partId,
                        Car = newCar
                    };
                    carParts.Add(newCarPart);
                }
            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // Problem 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Customers";

            var customersResult = XmlConverter.Deserializer<CustomersDto>(inputXml, rootElement);

            var customers = customersResult
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungerDriver
                })
                .ToList();

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        // Problem 13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Sales";

            var salesResult = XmlConverter.Deserializer<SalesDto>(inputXml, rootElement);

            var sales = salesResult
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .Select(s => new Sale
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        // Problem 14 - Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string rootElement = "cars";

            var carsWithDistance = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new CarsWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    Distance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            var xmlOutput = XmlConverter.Serialize(carsWithDistance, rootElement);

            return xmlOutput;
        }

        // Problem 15 - Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string rootElement = "cars";

            var carsFromMakeBmw = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarsFromMakeBmwDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    Distance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.Distance)
                .ToList();

            var xmlOutput = XmlConverter.Serialize(carsFromMakeBmw, rootElement);

            return xmlOutput;
        }

        // Problem 16 - Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string rootElement = "suppliers";

            var localSuppliers = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new LocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Count = s.Parts.Count
                })
                .ToList();

            var xmlOutput = XmlConverter.Serialize(localSuppliers, rootElement);

            return xmlOutput;
        }

        // Problem 17 - Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string rootElement = "cars";

            var carsWithTheirListOfParts = context
                .Cars
                .Select(c => new CarsWithTheirListOfPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    Distance = c.TravelledDistance,
                    Parts = c.PartCars
                     .Select(pc => new SinglePart
                     {
                         Name = pc.Part.Name,
                         Price = pc.Part.Price
                     })
                     .OrderByDescending(pc => pc.Price)
                     .ToList()
                })
                .OrderByDescending(c => c.Distance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            var xmlOutput = XmlConverter.Serialize(carsWithTheirListOfParts, rootElement);

            return xmlOutput;
        }

        // Problem 18 - Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string rootElement = "customers";

            var totalSalesByCustomer = context
                .Sales
                .Where(s => s.Car.Sales.Any())
                .Select(s => new TotalSalesByCustomerDto
                {
                    Name = s.Customer.Name,
                    Count = s.Customer.Sales.Count,
                    TotalPrice = s.Car.PartCars.Sum(p => p.Part.Price)
                })
                .OrderByDescending(s => s.TotalPrice)
                .ToList();

            var xmlOutput = XmlConverter.Serialize(totalSalesByCustomer, rootElement);

            return xmlOutput;
        }

        // Problem 19 - Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string rootElement = "sales";

            var salesWithAppliedDiscount = context
                .Sales
                .Select(s => new SalesWithAppliedDiscountsDto
                {
                   SingleCar = new SingleCar
                   { 
                   Make = s.Car.Make,
                   Model = s.Car.Model,
                   Distance = s.Car.TravelledDistance
                   },
                   Discount = s.Discount,
                   Name = s.Customer.Name,
                   Price = s.Car.PartCars.Sum(p=>p.Part.Price),
                   PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price) - s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100.0M
                })
                .ToList();

            var xmlOutput = XmlConverter.Serialize(salesWithAppliedDiscount, rootElement);

            return xmlOutput;
        }
    }
}