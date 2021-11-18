using MovieLibrary.Core.Models.CategoryModel;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Interfaces
{
    public interface ICategoryService
    {
        CategoryDetailsModel GetCategory(int id);
        int AddCategory(NewCategoryModel category);
        void UpdateCategory(UpdateCategoryModel category);
        bool DeleteCategoryById(int categoryId);
    }
}
