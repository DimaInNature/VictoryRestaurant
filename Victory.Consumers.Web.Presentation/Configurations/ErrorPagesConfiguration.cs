namespace Victory.Consumers.Web.Presentation.Configurations;

public static class ErrorPagesConfiguration
{
    public static void UseErrorPages(this IApplicationBuilder app)
    {
        app.UseNotFoundErrorPage();

        app.UseInternalServerErrorPage();
    }

    public static void UseNotFoundErrorPage(this IApplicationBuilder app) =>
        app.Use(async (ctx, next) =>
        {
            await next();

            if (ctx.Response.StatusCode is 404 && ctx.Response.HasStarted is false)
            {
                string? originalPath = ctx.Request.Path.Value;

                ctx.Items["originalPath"] = originalPath;

                ctx.Request.Path = "/error/404";

                await next();
            }
        });

    public static void UseInternalServerErrorPage(this IApplicationBuilder app) =>
       app.Use(async (ctx, next) =>
       {
           await next();

           if (ctx.Response.StatusCode is 500 && ctx.Response.HasStarted is false)
           {
               string? originalPath = ctx.Request.Path.Value;

               ctx.Items["originalPath"] = originalPath;

               ctx.Request.Path = "/error/500";

               await next();
           }
       });
}