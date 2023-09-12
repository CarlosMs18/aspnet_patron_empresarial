using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Services.WebApi.Modules.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>  //esta interfaz nos permirtir descubrir todas las
                                                            //versionesdel api que maneja nuestra aplicacion
    {
        public readonly IApiVersionDescriptionProvider provider; 

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach(var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }



        public static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "Carlos Technology ASP.NET Core Web Api",
                Description = "A Simple example ASP.NET CORE",
                TermsOfService = new Uri("https://pacagroup.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Carlos Melgarejo",
                    Email = "carlos.melgarejo.solorzano@gmail.com",
                    Url = new Uri("https://pacagroup.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Use and Lincx",
                    Url = new Uri("https://pacagroup.com/license")
                }
            };

            //si hemos puesto en deprecatado para poder hacerlo visible en swagger
            if (description.IsDeprecated)
            {
                info.Description += "Esta version de la api ha quedado obsoleta";
            }
            return info;
        }

       
    }
}
