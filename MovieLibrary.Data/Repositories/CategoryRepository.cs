using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Interfaces;

namespace MovieLibrary.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MovieLibraryContext _context;

        public CategoryRepository(MovieLibraryContext context)
        {
            _context = context;
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Include(x => x.MovieCategories).ThenInclude(x => x.Movie).FirstOrDefault(x => x.Id == id);
        }

        public int AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.Id;
        }

        public void UpdateCategory(Category category)
        {
            _context.Attach(category);
            _context.Update(category);
            _context.SaveChanges();
        }

        public bool DeleteCategoryById(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category == null)
                return false;

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
}
