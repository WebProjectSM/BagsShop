using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IProductBL
    {
        Task<Product> addProduct(Product usr);
       
        
        Task<Product> getProductById(int id);
        void update(int id, Product Product);
        Task<IEnumerable<Product>> getAllProducts();
        Task<List<Product>> getProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categories);



    }
}