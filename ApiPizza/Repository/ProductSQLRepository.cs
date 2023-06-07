using ApiPizza.DbContexts;
using ApiPizza.Exceptions;
using ApiPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPizza.Repository
{
    public class ProductSQLRepository : IProductRepository
    {
        AppDbContext dbContext;

        public ProductSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Product> CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int PizzaID)
        {
            Product product = await dbContext.Products.FirstOrDefaultAsync(p => p.PizzaID == PizzaID);
            if(product == null)
            {
                return false;
            }
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Product> GetProductById(int PizzaID)
        {
            Product product = await dbContext.Products.FirstOrDefaultAsync(p => p.PizzaID == PizzaID);
            if (product == null)
            {
                throw new NotFoundException("Producto de codigo: " + PizzaID + ", no se pudo encontrar");
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            List<Product> products = await dbContext.Products.ToListAsync();
            if(products == null)
            {
                throw new Exception();
            }
            else if (products.Count == 0)
            {
                throw new NotFoundException("El listado de productos esta vacío");
            }
                return products;
        }

        public async Task<IEnumerable<Product>> GetProducts(int page, int size)
        {
            var result = await dbContext.Products
                .Skip(page * size)
                .Take(size)
                .ToListAsync();
            if(result == null)
            {
                throw new Exception();
            }else if(result.Count == 0)
            {
                throw new NotFoundException("El listado de productos esta vacío");
            }
            return result;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
    }
}
