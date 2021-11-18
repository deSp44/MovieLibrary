using AutoMapper;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Models.CategoryModel;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Interfaces;

namespace MovieLibrary.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public CategoryDetailsModel GetCategory(int categoryId)
        {
            var category = _categoryRepository.GetCategoryById(categoryId);
            var categoryModel = _mapper.Map<CategoryDetailsModel>(category);

            return categoryModel;
        }

        public int AddCategory(Category category)
        {
            return _categoryRepository.AddCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }

        public bool DeleteCategoryById(int categoryId)
        {
            return _categoryRepository.DeleteCategoryById(categoryId);
        }
    }
}
