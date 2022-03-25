namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        List<Product> Products { get; set; }
        string Message { get; set; }
        Task GetProducts(string url);
        Task<ServiceResponse<Product>> GetSingleProduct(int id);
        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
