using System.Collections.Generic;
using AutoMapper;
using MovieLibrary.Core.Mapping;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models.CategoryModel
{
    public class CategoryDetailsModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MoviesForCategoryDetailsModel> Movies { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDetailsModel>()
                .ForMember(dest => dest.Movies, m => m.MapFrom(src => src.MovieCategories));
            profile.CreateMap<MovieCategory, MoviesForCategoryDetailsModel>()
                .ForMember(dest => dest.Id,
                    m => m.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.Title, m => m.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Description, m => m.MapFrom(src => src.Movie.Description))
                .ForMember(dest => dest.Year, m => m.MapFrom(src => src.Movie.Year))
                .ForMember(dest => dest.ImdbRating, m => m.MapFrom(src => src.Movie.ImdbRating))

                ;
        }
    }
}
