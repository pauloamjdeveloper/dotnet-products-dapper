using Products.Dapper.WebAPI.Models;
using System.Data.SqlClient;
using Products.Dapper.WebAPI.Data;
using Dapper;
using Products.Dapper.WebAPI.Exceptions;

namespace Products.Dapper.WebAPI.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionDataBase _dataBase;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(IConnectionDataBase dataBase, ILogger<ProductRepository> logger)
        {
            _dataBase = dataBase;
            _logger = logger;
        }

        private string _errorMessage = "";

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_dataBase.GetDbConnection().ConnectionString)) 
                {
                    await connection.OpenAsync();

                    var query = "SELECT * FROM TB_Products";
                    
                    var products = await connection.QueryAsync<Product>(query);

                    return products.AsList();
                }
            }
            catch (SqlException exception)
            {
                _errorMessage = $"Error getting all products: {exception.Message}";
                _logger.LogError(exception, _errorMessage);
                throw new Exception(_errorMessage);
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_dataBase.GetDbConnection().ConnectionString))
                {
                    await connection.OpenAsync();

                    var query = "SELECT * FROM TB_Products WHERE Id = @Id";

                    var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });

                    if (product == null)
                    {
                        throw new ProductNotFoundException($"Product with ID {id} not found.");
                    }

                    return product;
                }
            }
            catch (SqlException exception)
            {
                _errorMessage = $"Error getting product by id: {exception.Message}";
                _logger.LogError(exception, _errorMessage);
                throw new Exception(_errorMessage);
            }
        }

        public async Task<Product> CreateAsync(Product product)
        {
            try
            {
                using (var connection = new SqlConnection(_dataBase.GetDbConnection().ConnectionString))
                {
                    await connection.OpenAsync();

                    var query = "INSERT INTO TB_Products (Name, Description, Price, Quantity) VALUES (@Name, @Description, @Price, @Quantity)";

                    await connection.ExecuteAsync(query, product);

                    return product;
                }
            }
            catch (SqlException exception)
            {
                _errorMessage = $"Error creating product: {exception.Message}";
                _logger.LogError(exception, _errorMessage);
                throw new Exception(_errorMessage);
            }
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            try
            {
                using (var connection = new SqlConnection(_dataBase.GetDbConnection().ConnectionString))
                {
                    await connection.OpenAsync();

                    var query = "UPDATE TB_Products SET Name = @Name, Description = @Description, Price = @Price, Quantity = @Quantity WHERE Id = @Id";

                    await connection.ExecuteAsync(query, product);

                    return product;
                }
            }
            catch (SqlException exception)
            {
                _errorMessage = $"Error updating product: {exception.Message}";
                _logger.LogError(exception, _errorMessage);
                throw new Exception(_errorMessage);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_dataBase.GetDbConnection().ConnectionString))
                {
                    await connection.OpenAsync();

                    var query = "DELETE FROM TB_Products WHERE Id = @Id";

                    await connection.ExecuteAsync(query, new { Id = id });
                }
            }
            catch (SqlException exception)
            {
                _errorMessage = $"Error deleting product: {exception.Message}";
                _logger.LogError(exception, _errorMessage);
                throw new Exception(_errorMessage);
            }
        }
    }
}
