using Microsoft.OpenApi.Models;

namespace EccomereceAPI.Configs
{
    public static class DipendencyInjection
    {
        public static void Inject(WebApplicationBuilder builder)
        {

            #region Configuration
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(
                option =>
                {
                    option.SwaggerDoc("v1", new OpenApiInfo { Title = "eccomerece Project", Version = "V1" });
                    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter a valid token",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });
                    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
                }
            );
            #endregion
            #region InjectDependency
            builder.Services.AddAuthorization();
            builder.Services.AddAuthorization();

            #endregion

        }
    }
}
