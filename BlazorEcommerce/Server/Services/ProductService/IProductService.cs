namespace BlazorEcommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProducts();
        Task<ServiceResponse<Product>> GetSingleProduct(int id);
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string url);
        Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestion(string searchText);
        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();

    }
}
