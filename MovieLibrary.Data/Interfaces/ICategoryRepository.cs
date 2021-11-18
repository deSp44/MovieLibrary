using MovieLibrary.Data.Entities;

namespace MovieLibrary.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int id);
        int AddCategory(Category category);
        void UpdateCategory(Category category);
        bool DeleteCategoryById(int categoryId);
    }
}
