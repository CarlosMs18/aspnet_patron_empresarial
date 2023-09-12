using Transversal.Mapper;

namespace Services.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MapppingsProfile()));
            return services;    
        }
    }
}
