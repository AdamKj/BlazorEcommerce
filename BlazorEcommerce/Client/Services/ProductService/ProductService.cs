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
        public async Task GetProducts(string url)
        {
            var result = url == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("/api/Product") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"/api/Product/Category/{url}");
            if (result != null && result.Data != null)
                Products = result.Data;

            ProductsChanged.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetSingleProduct(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"/api/Product/{id}");
            return result;
        }
    }
}
