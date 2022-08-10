using BlazorProduct.Client.HttpResponsitori;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorProduct.Client.Pages
{
    public partial class Products
    {
        public List<Product> ProductList { get; set; } = new List<Product>();
        [Inject]
        public IProductHttpResponsitori _iProductRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task GetProducts()
        {
          var c =  await _iProductRepo.GetAll();
           ProductList = c;
        }
    }
}
