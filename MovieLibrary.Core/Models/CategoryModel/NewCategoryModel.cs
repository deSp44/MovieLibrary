using System.Text.Json.Serialization;
using AutoMapper;
using MovieLibrary.Core.Mapping;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models.CategoryModel
{
    public class NewCategoryModel : IMapFrom<Category>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCategoryModel, Category>().ReverseMap();
        }
    }
}
