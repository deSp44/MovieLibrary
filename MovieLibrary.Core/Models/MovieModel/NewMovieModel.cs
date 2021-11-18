using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using AutoMapper;
using MovieLibrary.Core.Mapping;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models.MovieModel
{
    public class NewMovieModel : IMapFrom<Movie>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal ImdbRating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewMovieModel, Movie>().ReverseMap();
        }
    }
}
