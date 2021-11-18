using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MovieLibrary.Core.Mapping;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models.MovieModel
{
    public class UpdateMovieModel : IMapFrom<Movie>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal ImdbRating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMovieModel, Movie>().ReverseMap();
        }
    }
}
