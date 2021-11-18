using MovieLibrary.Core.Models.CategoryModel;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Interfaces
{
    public interface ICategoryService
    {
        CategoryDetailsModel GetCategory(int id);
        int AddCategory(Category category);
        void UpdateCategory(Category category);
        bool DeleteCategoryById(int categoryId);
    }
}
