namespace BlazorEcommerce.Client.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly HttpClient _http;

        public ProductTypeService(HttpClient http)
        {
            _http = http;
        }

        public event Action Onchange;
        public List<ProductType> ProductTypes { get; set; } = new();
        public async Task GetProductTypes()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ProductType>>>("api/ProductType");
            ProductTypes = result.Data;
        }
    }
}
