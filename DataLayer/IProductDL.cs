using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProductDL
    {
        Task<Product> addProduct(Product ProductToAdd);
     
        Task<Product> getProductById(int id);
        void update(int id, Product Product);
         Task<IEnumerable<Product>> getAllProducts();
        Task<List<Product>> getProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categories);

    }
}