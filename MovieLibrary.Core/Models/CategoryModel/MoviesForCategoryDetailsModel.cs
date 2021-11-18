using AutoMapper;
using MovieLibrary.Core.Mapping;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models.CategoryModel
{
    public class MoviesForCategoryDetailsModel : IMapFrom<Movie>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal ImdbRating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Movie, MoviesForCategoryDetailsModel>();
        }
    }
}
