namespace Web.Presentation.Configurations;

public static class AuthenticationConfiguration
{
    public static void AddAuthenticationConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "Victory",
                    ValidateAudience = true,
                    ValidAudience = "Victory",
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.ASCII.GetBytes("VictoryKey-11111111111111111111111111")),
                    ValidateIssuerSigningKey = true,
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