namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class TableMediatRProfile
{
    public static void AddTableMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get TableEntity by Id

        services.AddScoped<IRequest<TableEntity?>, GetTableByIdQuery>();
        services.AddScoped<IRequestHandler<GetTableByIdQuery, TableEntity?>, GetTableByIdQueryHandler>();

        // Get List<TableEntity>

        services.AddScoped<IRequest<List<TableEntity>?>, GetTableListQuery>();
        services.AddScoped<IRequestHandler<GetTableListQuery, List<TableEntity>?>, GetTableListQueryHandler>();

        // Get List<TableEntity> by Number

        services.AddScoped<IRequest<List<TableEntity>?>, GetTableListByNumberQuery>();
        services.AddScoped<IRequestHandler<GetTableListByNumberQuery, List<TableEntity>?>, GetTableListByNumberQueryHandler>();

        // Get List<TableEntity> by Status (IsBooking)

        services.AddScoped<IRequest<List<TableEntity>?>, GetTableListByStatusQuery>();
        services.AddScoped<IRequestHandler<GetTableListByStatusQuery, List<TableEntity>?>, GetTableListByStatusQueryHandler>();

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