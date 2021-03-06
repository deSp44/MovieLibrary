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

        public int AddCategory(NewCategoryModel category)
        {
            var categoryModel = _mapper.Map<Category>(category);
            return _categoryRepository.AddCategory(categoryModel);
        }

        public void UpdateCategory(UpdateCategoryModel category)
        {
            var categoryModel = _mapper.Map<Category>(category);
            _categoryRepository.UpdateCategory(categoryModel);
        }

        public bool DeleteCategoryById(int categoryId)
        {
            return _categoryRepository.DeleteCategoryById(categoryId);
        }
    }
}
