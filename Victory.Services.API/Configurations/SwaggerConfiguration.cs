namespace Victory.Services.API.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(setupAction: c =>
        {
            c.SwaggerDoc(name: "v1", info: new OpenApiInfo
            {
                Version = "Demo v1",
                Title = "API",
                Description = "API for Victory Restaurant",
                Contact = new OpenApiContact
                {
                    Name = "DimaInNature",
                    Email = "dimainnature@yandex.ru",
                    Url = new Uri(uriString: "https://github.com/DimaInNature")
                }
            });

            c.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(securityRequirement: new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },

                    new List<string>()
                }
            });

            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            string xmlPath = Path.Combine(path1: AppContext.BaseDirectory, path2: xmlFile);

            c.IncludeXmlComments(filePath: xmlPath);
        });
    }

    public static void UseSwaggerSetup(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Victory API V1");
        });
    }
}