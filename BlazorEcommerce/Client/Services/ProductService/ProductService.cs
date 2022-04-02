using BlazorEcommerce.Shared.DTO;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public event Action ProductsChanged;
        public List<Product> Products { get; set; } = new();
        public List<Product> AdminProducts { get; set; } = new();
        public string Message { get; set; } = "Loading products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; }

        public async Task GetProducts(string url)
        {
            var result = url == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product/featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/Category/{url}");
            if (result != null && result.Data != null)
                Products = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0)
                Message = "No products found";

            ProductsChanged.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetSingleProduct(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{id}");
            return result;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            LastSearchText = searchText;
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResultDTO>>($"api/Product/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Products.Count == 0) Message = "No products found.";
            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Product/search-suggestions/{searchText}");
            return result.Data;
        }

        public async Task GetAdminProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/admin");
            AdminProducts = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (AdminProducts.Count == 0)
                Message = "No products found.";
        }
    }
}
