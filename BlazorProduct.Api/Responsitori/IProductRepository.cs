using Entities.Models;
using Entities.ViewModels;

namespace BlazorProduct.Api.Responsitori;

public interface IProductRepository
{
    Task CreatProduct(Product product);
    Task UpdateProduct(ProductUpdate product,Product productdb);
    Task<Product> GetProduct(int id);
    Task DeleteProduct(Product productdb);
    Task<List<Product>> GetAll();
}
