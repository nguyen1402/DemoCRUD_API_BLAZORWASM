using Entities.Models;
using Entities.ViewModels;

namespace BlazorProduct.Client.HttpResponsitori
{
    public interface IProductHttpResponsitori
    {
        Task<List<Product>> GetAll();
        Task<Product> GetbyID(int id);
        Task<int> CreateProduct(Product product);
        Task<int> UpdatePr(Product pr);
        Task<int> DeletePr(int id);
    }
}
