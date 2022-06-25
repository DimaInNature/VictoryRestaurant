namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class TableMediatRProfile
{
    public static void AddTableMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get Table by Id

        services.AddScoped<IRequest<Table?>, GetTableByIdQuery>();
        services.AddScoped<IRequestHandler<GetTableByIdQuery, Table?>, GetTableByIdQueryHandler>();

        // Get List<Table>

        services.AddScoped<IRequest<List<Table>?>, GetTableListQuery>();
        services.AddScoped<IRequestHandler<GetTableListQuery, List<Table>?>, GetTableListQueryHandler>();

        // Get List<Table> by Number

        services.AddScoped<IRequest<List<Table>?>, GetTableListByNumberQuery>();
        services.AddScoped<IRequestHandler<GetTableListByNumberQuery, List<Table>?>, GetTableListByNumberQueryHandler>();

        // Get List<Table> by Status (IsBooking)

        services.AddScoped<IRequest<List<Table>?>, GetTableListByStatusQuery>();
        services.AddScoped<IRequestHandler<GetTableListByStatusQuery, List<Table>?>, GetTableListByStatusQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateTableCommand>();
        services.AddScoped<IRequestHandler<CreateTableCommand, Unit>, CreateTableCommandHandler>();

        // Update by Id

        services.AddScoped<IRequest, UpdateTableCommand>();
        services.AddScoped<IRequestHandler<UpdateTableCommand, Unit>, UpdateTableCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteTableCommand>();
        services.AddScoped<IRequestHandler<DeleteTableCommand, Unit>, DeleteTableCommandHandler>();

        #endregion
    }
}