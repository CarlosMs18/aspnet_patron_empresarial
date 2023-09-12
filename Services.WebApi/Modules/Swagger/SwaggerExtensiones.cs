using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Services.WebApi.Modules.Swagger
{
    public static class SwaggerExtensiones
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            //Inyeccion de dependencias por instancias de la interfaz IConfigureOptions para el
            //cersionanimeinto d ela clase ComnfigureSwaggerOptiosn
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(c =>
            {
                //C0N ESTE EMTODO ENNO HAXCE FALTA PONER EL BEARER + TOEKN SOLO EL TOKEN
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer Token **__only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http, //nos permite agregar autenticaciojn por el header
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id,securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new List<string>() { } }
                });
            });
            return services;
        }
    }
}
