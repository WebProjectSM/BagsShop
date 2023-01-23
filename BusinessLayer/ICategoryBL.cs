using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICategoryBL
    {
        
        Task<Category> addCategory(Category usr);
        Task<Category> getCategoryById(int id);
        void update(int id, Category Category);
         Task<IEnumerable<Category>> getAllCategories();
    }
}