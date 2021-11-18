using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MovieLibrary.Core.Mapping;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models.CategoryModel
{
    public class UpdateCategoryModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCategoryModel, Category>().ReverseMap();
        }
    }
}
