using ApiPizza.Models;
using System;
namespace ApiPizza.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProducts(int page, int size);
        Task<Product> GetProductById(int PizzaID);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int PizzaID);

    }
}
