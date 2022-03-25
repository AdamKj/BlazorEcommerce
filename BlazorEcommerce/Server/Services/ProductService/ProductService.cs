namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products.Include(p => p.Variants).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetSingleProduct(int id)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                response.Success = false;
                response.Message = "The product does not exist.";
            }

            response.Data = product;
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string url)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                    .Where(p => p.Category.Url.ToLower().Equals(url.ToLower()))
                    .Include(p => p.Variants)
                    .ToListAsync()
            };

            return response;
        }
    }
}
