namespace BlazorEcommerce.Client.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        event Action Onchange;
        public List<ProductType> ProductTypes { get; set; }
        Task GetProductTypes();
        Task AddProductType(ProductType productType);
        Task UpdateProductType(ProductType productType);
        ProductType CreateNewProductType();
    }
}
