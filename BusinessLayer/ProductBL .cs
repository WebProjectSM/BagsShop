using DataLayer;
using Entities;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Zxcvbn;

namespace BusinessLayer
{
    public class ProductBL : IProductBL
    {
        
        readonly IProductDL _dl;
        public ProductBL(IProductDL Productdl)
        {
            _dl = Productdl;
        }
        public async Task<IEnumerable<Product>> getAllProducts()
        {
            return await _dl.getAllProducts();
        }
        public async Task<Product> getProductById(int id)
        {
            Product Product = await _dl.getProductById(id);
            if (Product != null)
                return Product;
            return null;
        }
        public async Task<Product> addProduct(Product usr)
        {
            Product Product = await _dl.addProduct(usr);
            if (Product != null)
            {
                return Product;
            }
            return null;
        }

        public async void update(int id, Product Product)
        {
            _dl.update(id, Product);
        }
       
        public async Task<List<Product>> getProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categories)
        {
            List<Product> products = await _dl.getProducts(position, skip, desc, minPrice, maxPrice, categories);
            return products;
        }

    }
}