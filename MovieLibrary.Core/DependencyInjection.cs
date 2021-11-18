using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Services;

namespace MovieLibrary.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
