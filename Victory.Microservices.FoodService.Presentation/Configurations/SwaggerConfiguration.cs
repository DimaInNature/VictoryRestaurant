namespace Victory.Microservices.FoodService.Presentation.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(name: "v1", info: new OpenApiInfo
            {
                Version = "Demo v1",
                Title = "SMTP API",
                Description = "FoodService API for Victory Restaurant",
                Contact = new OpenApiContact
                {
                    Name = "DimaInNature",
                    Email = "dimainnature@yandex.ru",
                    Url = new Uri(uriString: "https://github.com/DimaInNature")
                }

            });

            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(path1: AppContext.BaseDirectory, path2: xmlFile);
            c.IncludeXmlComments(filePath: xmlPath);
        });
    }

    public static void UseSwaggerSetup(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Victory FoodService API V1");
            c.RoutePrefix = string.Empty;
        });
    }
}