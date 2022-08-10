using BlazorProduct.Client.HttpResponsitori;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorProduct.Client.Components.ProductTable
{
    public partial class ProductTable
    {
        [Parameter]
        public List<Product> Products { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private void RedirectToUpdate(int id)
        {

            var url = Path.Combine("/updateproduct/", id.ToString());
            NavigationManager.NavigateTo(url);
        }

        private void RedirectToDelete(int id)
        {
            var url = Path.Combine("/deleteProduc/", id.ToString());
            NavigationManager.NavigateTo(url);
        }
    }
}
