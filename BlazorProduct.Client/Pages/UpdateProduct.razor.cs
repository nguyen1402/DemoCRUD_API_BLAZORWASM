using BlazorProduct.Client.HttpResponsitori;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorProduct.Client.Pages
{
    partial class UpdateProduct
    {
        private Product _pr;
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
         IProductHttpResponsitori _ipr { get; set; }
        public bool ShowAuthError { get; set; }
        [Parameter]
        public string Error { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _pr = await _ipr.GetbyID(Convert.ToInt32(Id));
        }
        private async Task Update()
        {
            ShowAuthError = false;
            var result = await _ipr.UpdatePr(_pr);
            if (result == 0)
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
