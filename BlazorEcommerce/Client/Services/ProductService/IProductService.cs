namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        List<Product> Products { get; set; }
        Task GetProducts(string url);
        Task<ServiceResponse<Product>> GetSingleProduct(int id);
    }
}
