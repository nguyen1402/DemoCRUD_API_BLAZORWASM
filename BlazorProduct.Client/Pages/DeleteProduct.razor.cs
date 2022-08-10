using BlazorProduct.Client.HttpResponsitori;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorProduct.Client.Pages
{
    partial class DeleteProduct
    {
        private Product _pr;
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        IProductHttpResponsitori _ipr { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _pr = await _ipr.GetbyID(Convert.ToInt32(Id));
        }

        private async Task Delete()
        {
            await _ipr.DeletePr(_pr.Id);
            Navigation.NavigateTo("/products");
        }
    }
}
