namespace Victory.Services.API.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
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