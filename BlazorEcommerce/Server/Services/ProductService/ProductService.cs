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

        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await FindProductsBySearchText(searchText)
            };

            return response;
        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products
                .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            || p.Description.ToLower().Contains(searchText.ToLower()))
                .Include(p => p.Variants)
                .ToListAsync();
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestion(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);

            List<string> result = new();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> {Data = result};
        }
    }
}
