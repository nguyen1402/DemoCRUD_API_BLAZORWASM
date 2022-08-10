using BlazorProduct.Client.HttpResponsitori;
using Microsoft.AspNetCore.Components;
using BlazorProduct.Client.Shared;
using Entities.Models;

namespace BlazorProduct.Client.Pages
{
    public partial class CeateProduct
    {
        private Product _product = new Product();
        [Inject]
        public NavigationManager Navigation { get; set; }
        public bool ShowAuthError { get; set; }
        [Parameter]
        public string Error { get; set; }
        [Inject]
        public IProductHttpResponsitori ProductRepo { get; set; }

        private async Task Create()
        {
            ShowAuthError = false;
            var c =  await ProductRepo.CreateProduct(_product);
            if (c == 0)
            {
                Error = "Thất bại !";
                ShowAuthError = true;
            }
            else
            {
                Navigation.NavigateTo("/products");
            }
        } 
    }
}
