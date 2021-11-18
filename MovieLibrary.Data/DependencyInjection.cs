using Microsoft.Extensions.DependencyInjection;
using MovieLibrary.Data.Interfaces;
using MovieLibrary.Data.Repositories;

namespace MovieLibrary.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
