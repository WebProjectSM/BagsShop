using Entities;
using System.Text.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CategoryDL : ICategoryDL
    {
        readonly bagsContext _bagsDBContext;
        public CategoryDL(bagsContext bagsDBContext)
        {
            _bagsDBContext = bagsDBContext;
        }



        public async Task<IEnumerable<Category>> getAllCategories()
        {
            return  _bagsDBContext.Categories;
        }

        public async Task<Category> getCategoryById(int id)
        {
            Category Category = await _bagsDBContext.Categories.FindAsync(id);
            if (Category != null)

                return Category;


            else return null;
        }
        public async Task<Category> addCategory(Category CategoryToAdd)
        {

            await _bagsDBContext.Categories.AddAsync(CategoryToAdd);
            await _bagsDBContext.SaveChangesAsync();
            //Category tmpCategory= await getCategory(CategoryToAdd.Password, CategoryToAdd.Email);
            return CategoryToAdd;

        }
        public async void update(int id, Category Category)
        {
            Category CategoryToUpdate = await _bagsDBContext.Categories.FindAsync(id);
            if (CategoryToUpdate != null)
            {
                _bagsDBContext.Entry(CategoryToUpdate).CurrentValues.SetValues(Category);
                await _bagsDBContext.SaveChangesAsync();
            }

        }


    }

}