using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ICategoryDL
    {
        Task<Category> addCategory(Category CategoryToAdd);
        Task<Category> getCategoryById(int id);
        void update(int id, Category Category);

        Task<IEnumerable<Category>> getAllCategories();
    }
}