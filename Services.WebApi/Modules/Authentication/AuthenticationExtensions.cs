using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.WebApi.Helpers;
using System.Text;

namespace Services.WebApi.Modules.Authentication
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration) {
            //AUTHENTICACION , TOKEN , JWT
            var appSettingsSection = configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);//automaticamente ahre el ampeo de los valores APPsETTING CON NUESTRA CLASE
                                                                
                                                                
            var appSettings = appSettingsSection.Get<AppSettings>();//configure jwt , creando una instancia de appsettings para tener Acceso a los valores del secret ,issuer ,audience



            //mediante crear una instanciadel appsettings podemos acceder ahora a estos valores
            var key = Encoding.UTF8.GetBytes(appSettings.Secret);
            var Issuer = appSettings.Issuer;
            var Audience = appSettings.Audience;




            //COnfigturando autenticcion bearer
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opciones => opciones.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero

            });
            return services;
        }
    }
}
