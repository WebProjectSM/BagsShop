using DataLayer;
using Entities;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Zxcvbn;

namespace BusinessLayer
{
    public class CategoryBL : ICategoryBL
    {

        readonly ICategoryDL _dl;
        public CategoryBL(ICategoryDL Categorydl)
        {
            _dl = Categorydl;
        }
        
        public async Task<Category> getCategoryById(int id)
        {
            Category Category = await _dl.getCategoryById(id);
            if (Category != null)
                return Category;
            return null;
        }
        public async Task<Category> addCategory(Category usr)
        {
            Category Category = await _dl.addCategory(usr);
            if (Category != null)
            {
                return Category;
            }
            return null;
        }

        public async void update(int id, Category Category)
        {
            _dl.update(id, Category);
        }
        public async Task<IEnumerable<Category>> getAllCategories()
        {
            return await _dl.getAllCategories();
        }

      
    }
}