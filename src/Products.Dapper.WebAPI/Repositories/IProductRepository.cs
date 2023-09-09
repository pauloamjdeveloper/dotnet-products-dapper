﻿using Products.Dapper.WebAPI.Models;

namespace Products.Dapper.WebAPI.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task DeleteAsync(int id);
    }
}
