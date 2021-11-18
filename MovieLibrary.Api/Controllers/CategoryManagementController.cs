using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Models.CategoryModel;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.WebApi.Controllers
{
    [ApiController]
    [Route("/swagger/v1/[controller]")]
    public class CategoryManagementController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryManagementController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<CategoryDetailsModel> GetCategory(int categoryId)
        {
            var category = _categoryService.GetCategory(categoryId);
            if (category == null)
                return NotFound("Invalid category ID");

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<int> AddCategory(NewCategoryModel category)
        {
            if (!ModelState.IsValid || category.Name == "")
                return BadRequest("Invalid data!");

            var categoryId = _categoryService.AddCategory(category);

            return Ok($"Category Id: {categoryId}");
        }

        [HttpPut]
        public ActionResult UpdateCategory(UpdateCategoryModel category)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data!");

            _categoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteCategory(int categoryId)
        {
            var result = _categoryService.DeleteCategoryById(categoryId);
            if (result == false)
                return NotFound();

            return Ok();
        }
    }
}
