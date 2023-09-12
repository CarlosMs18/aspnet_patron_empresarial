

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Services.WebApi.Modules.Versioning
{
    public static class VersioningExtensions
    {
        //CONTROL DE VERSIONES MEDIANTE QUERYSTRINGS
        //public static IServiceCollection AddVersioning(this IServiceCollection services)
        //{
        //    services.AddApiVersioning(o =>
        //    {
        //        o.DefaultApiVersion = new ApiVersion(1, 0);
        //        o.AssumeDefaultVersionWhenUnspecified = true; //en caso no se especifique la version a la hora d ellamar  ala api, tome la version por deceto
        //        o.ReportApiVersions = true; //mostrar a los clientes las versiones disponibles
        //        o.ApiVersionReader = new QueryStringApiVersionReader("api-version"); //mediante que manera se leera
        //    });

        //    services.AddVersionedApiExplorer(options =>
        //    {
        //        options.GroupNameFormat = "'v'VVV";
        //    });

        //    return services;
        //}


        //CONTROL DE VERSIONES MEDIANTE DE HEADER
        //public static IServiceCollection AddVersioning(this IServiceCollection services)
        //{
        //    services.AddApiVersioning(o =>
        //    {
        //        o.DefaultApiVersion = new ApiVersion(1, 0);
        //        o.AssumeDefaultVersionWhenUnspecified = true; //en caso no se especifique la version a la hora d ellamar  ala api, tome la version por deceto
        //        o.ReportApiVersions = true; //mostrar a los clientes las versiones disponibles
        //        o.ApiVersionReader = new HeaderApiVersionReader("x-version"); //mediante que manera se leera
        //    });

        //    services.AddVersionedApiExplorer(options =>
        //    {
        //        options.GroupNameFormat = "'v'VVV";
        //    });

        //    return services;
        //}



        //Control DE VERSIONES MEDIANTE URL SEGMENT
         public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true; //en caso no se especifique la version a la hora d ellamar  ala api, tome la version por deceto
                o.ReportApiVersions = true; //mostrar a los clientes las versiones disponibles
                o.ApiVersionReader = new UrlSegmentApiVersionReader(); //mediante que manera se leera
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
