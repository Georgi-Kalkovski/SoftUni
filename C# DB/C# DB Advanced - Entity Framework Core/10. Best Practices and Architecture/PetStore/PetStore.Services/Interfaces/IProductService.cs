using System.Collections.Generic;

using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;

namespace PetStore.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(AddProductInputServiceModel model);

        ICollection<ListAllProductsServiceModel> GetAll();

        ICollection<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type);

        ICollection<ListAllProductsByNameServiceModel> SearchByName(string searchStr, bool caseSensitive);

        bool RemoveById(string id);

        bool RemoveByName(string name);

        void EditProduct(string id, EditProductInputServiceModel model);
    }
}
