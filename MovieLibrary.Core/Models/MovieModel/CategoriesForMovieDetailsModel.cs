using AutoMapper;
using MovieLibrary.Core.Mapping;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models.MovieModel
{
    public class CategoriesForMovieDetailsModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoriesForMovieDetailsModel>();
        }
    }
}
