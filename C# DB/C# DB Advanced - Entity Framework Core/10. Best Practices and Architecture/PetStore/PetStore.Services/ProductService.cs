using System;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.Services.Interfaces;

namespace PetStore.Services
{
    public class ProductService : IProductService
    {
        //They will be loaded somehow
        //I don't care how they are going to be loaded, I just use them!
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            try
            {
                Product product = this.mapper.Map<Product>(model);

                this.dbContext.Products.Add(product);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }
        }

        public ICollection<ListAllProductsServiceModel> GetAll()
        {
            var products = this.dbContext
                .Products
                .ProjectTo<ListAllProductsServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return products;
        }

        public ICollection<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type)
        {
            ProductType productType;

            bool hasParsed = Enum.TryParse<ProductType>(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            var productsServiceModels = this.dbContext
                .Products
                .Where(p => p.ProductType == productType)
                .ProjectTo<ListAllProductsByProductTypeServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return productsServiceModels;
        }

        public ICollection<ListAllProductsByNameServiceModel> SearchByName(string searchStr, bool caseSensitive)
        {
            ICollection<ListAllProductsByNameServiceModel> products;

            if (caseSensitive)
            {
                products = this.dbContext
                    .Products
                    .Where(p => p.Name.Contains(searchStr))
                    .ProjectTo
                        <ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                    .ToList();
            }
            else
            {
                products = this.dbContext
                    .Products
                    .Where(p => p.Name.ToLower().Contains(searchStr.ToLower()))
                    .ProjectTo
                        <ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                    .ToList();
            }

            return products;
        }

        public bool RemoveById(string id)
        {
            Product productToRemove = this.dbContext
                .Products
                .Find(id);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }

        public bool RemoveByName(string name)
        {
            Product productToRemove = this.dbContext
                .Products
                .FirstOrDefault(p => p.Name == name);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool removed = rowsAffected == 1;

            return removed;
        }

        public void EditProduct(string id, EditProductInputServiceModel model)
        {
            try
            {
                Product product =
                    this.mapper.Map<Product>(model);

                Product productToUpdate = this.dbContext
                    .Products
                    .Find(id);

                if (productToUpdate == null)
                {
                    throw new ArgumentException(ExceptionMessages.ProductNotFound);
                }

                productToUpdate.Name = product.Name;
                productToUpdate.ProductType =   product.ProductType;
                productToUpdate.Price = product.Price;

                this.dbContext.SaveChanges();
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }
        }
    }
}
