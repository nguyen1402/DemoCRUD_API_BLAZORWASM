using Entities.Models;
using System.Text;
using System.Text.Json;

namespace BlazorProduct.Client.HttpResponsitori
{
    public class ProductHttpResponsitori : IProductHttpResponsitori
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public ProductHttpResponsitori(HttpClient httpClient)
        {
            _client = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<int> CreateProduct(Product product)
        {
            var content = JsonSerializer.Serialize(product);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("products", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                return 0;
            }
            return 1;
        }

        public async Task<int> DeletePr(int id)
        {
            var url = Path.Combine("Products", id.ToString());
            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
            return 1;
        }

        public async Task<List<Product>> GetAll()
        {
            var url = Path.Combine("Products/getall");
            var postResult = await _client.GetAsync(url);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }

            var products = JsonSerializer.Deserialize<List<Product>>(postContent, _options);
            return products;
        }

        public async Task<Product> GetbyID(int id)
        {
            var url = Path.Combine("Products", id.ToString());
            var getResult = await _client.GetAsync(url);
            var getContent = await getResult.Content.ReadAsStringAsync();
            if (!getResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(getContent);
            }
            var produt = JsonSerializer.Deserialize<Product>(getContent, _options);
            return produt;
        }

        public async Task<int> UpdatePr(Product pr)
        {
            var content = JsonSerializer.Serialize(pr);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("Products", pr.Id.ToString());

            var postResult = await _client.PutAsync(url, bodyContent);
            //var postContent = await postResult.Content.ReadAsStringAsync();
            if (postResult.IsSuccessStatusCode)
            {
                return 1;
            }
            return 0;
        }
    }
}
