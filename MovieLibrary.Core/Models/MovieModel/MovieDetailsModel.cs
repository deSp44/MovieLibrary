using System.Collections.Generic;
using AutoMapper;
using MovieLibrary.Core.Mapping;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models.MovieModel
{
    public class MovieDetailsModel : IMapFrom<Movie>
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal ImdbRating { get; set; }

        public ICollection<CategoriesForMovieDetailsModel> Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Movie, MovieDetailsModel>()
                .ForMember(dest => dest.Categories, m => m.MapFrom(src => src.MovieCategories));
            profile.CreateMap<MovieCategory, CategoriesForMovieDetailsModel>()
                .ForMember(dest => dest.Id,
                    m => m.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.Category.Name));
        }
    }
}
