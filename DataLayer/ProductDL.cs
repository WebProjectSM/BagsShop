using Entities;
using System.Text.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ProductDL : IProductDL
    {
        readonly bagsContext _bagsDBContext;
        public ProductDL(bagsContext bagsDBContext)
        {
            _bagsDBContext = bagsDBContext;
        }


        public async Task<IEnumerable<Product>> getAllProducts()
        {
            return _bagsDBContext.Products;
        }

        public async Task<List<Product>> getProducts(int position,int skip,string? desc,int? minPrice, int? maxPrice, int?[] categories)
        {
            var query = _bagsDBContext.Products.Where(product =>
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categories.Length == 0) ? (true) : (categories.Contains(product.CategoryId))))
               .OrderBy(Product => Product.Price).Include(product=> product.Category);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;

        }


        public async Task<Product> getProductById(int id)
        {
            Product Product = await _bagsDBContext.Products.FindAsync(id);
            if (Product != null)

                return Product;


            else return null;
        }
        public async Task<Product> addProduct(Product ProductToAdd)
        {

            await _bagsDBContext.Products.AddAsync(ProductToAdd);
            await _bagsDBContext.SaveChangesAsync();
           
            return ProductToAdd;

        }
        public async void update(int id, Product Product)
        {
            Product ProductToUpdate = await _bagsDBContext.Products.FindAsync(id);
            if (ProductToUpdate != null)
            {
                _bagsDBContext.Entry(ProductToUpdate).CurrentValues.SetValues(Product);
                await _bagsDBContext.SaveChangesAsync();
            }

        }


    }

}