using AutoMapper;
using Transversal.Mapper;
using Transversal.Common;
using Transversal.Logging;
using Infraestructure.Data;
using Infraestructure.Interface;
using Infraestructure.Repository;
using Domain.Interface;
using Domain.Core;
using Application.Interface;
using Application.Main;
using Services.WebApi.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.WebApi.Modules.Swagger;
using Services.WebApi.Modules.Authentication;
using Services.WebApi.Modules.Mapper;
using Services.WebApi.Modules.Feature;
using Services.WebApi.Modules.Injection;
using Services.WebApi.Modules.Validator;
using Services.WebApi.Modules.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Services.WebApi
{
    public class Startup
    {
        readonly string myPolicy = "policyApiEcommerce";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;  
        }

        public IConfiguration Configuration { get; }

        public IApiVersionDescriptionProvider provider { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            //Añdiendo servicios

            //Refactorizando la configuracion de automapper
            services.AddMapper();

            //Añadiendo Cors
            //Refactorizando Cors
            services.AddFeature(this.Configuration);



            //Refactorizando inyeccion de dependencias de autoMapper
            services.AddInjection(this.Configuration);

            services.AddControllers();
            services.AddEndpointsApiExplorer();


            //Refactorizando
            services.AddAuthentication(this.Configuration);


            //Para el versionamiento
            services.AddVersioning();


            //Refactorizando swagger mediante metodo de extensuion
            services.AddSwagger();


            //Refactorizando Fluent Validation
            services.AddValidator();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            //agregando un nuevo parametro apra el versionamiento, esta interfaz nso
            //permite descubrir todas las version de api que tengamos en nuestra app
        {

            
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });

                // app.UseSwaggerUI();
            }

         
            app.UseRouting();

            app.UseCors(myPolicy);

        

            app.UseAuthorization();

            //app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
