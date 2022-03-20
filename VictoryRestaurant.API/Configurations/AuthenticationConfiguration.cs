namespace VictoryRestaurant.API.Configurations;

public static class AuthenticationConfiguration
{
    public static void AddAuthenticationConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddSingleton<ITokenService, TokenService>();

        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        key: Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
    }

    public static void UseAuthenticationConfiguration(this IApplicationBuilder app)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        app.UseAuthentication();
        app.UseAuthorization();
    }
}