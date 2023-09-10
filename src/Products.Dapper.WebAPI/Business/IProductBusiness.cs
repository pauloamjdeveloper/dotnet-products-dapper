using Products.Dapper.WebAPI.Models;

namespace Products.Dapper.WebAPI.Business
{
    public interface IProductBusiness
    {
        Task<List<Product>> GetAllProductsAsync(); 
        
        Task<Product> GetProductByIdAsync(int id);

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product);
        
        Task DeleteProductAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
