namespace VictoryRestaurant.API.Apis;

public class MailSubscriberApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet(pattern: "/MailSubscribers", handler: GetAll)
            .Produces<List<MailSubscriberEntity>>(StatusCodes.Status200OK)
            .WithName("GetAllMailSubscribers")
            .WithTags("Getters");

        app.MapGet(pattern: "/MailSubscribers/{id}", handler: GetById)
            .Produces<MailSubscriberEntity>(StatusCodes.Status200OK)
            .WithName("GetMailSubscriber")
            .WithTags("Getters");

        app.MapPost(pattern: "/MailSubscribers", handler: Create)
            .Accepts<MailSubscriberEntity>("application/json")
            .Produces<MailSubscriberEntity>(StatusCodes.Status201Created)
            .WithName("CreateMailSubscriber")
            .WithTags("Creators");

        app.MapPut(pattern: "/MailSubscribers", handler: Put)
            .Accepts<MailSubscriberEntity>("application/json")
            .WithName("UpdateMailSubscriber")
            .WithTags("Updaters");

        app.MapDelete(pattern: "/MailSubscribers/{id}", handler: Delete)
            .WithName("DeleteMailSubscriber")
            .WithTags("Deleters");
    }

    [AllowAnonymous]
    private async Task<IResult> GetAll(IMailSubscriberFacadeService repository)
        => Results.Ok(await repository.GetMailSubscriberListAsync());

    [AllowAnonymous]
    private async Task<IResult> GetById(int id, IMailSubscriberFacadeService repository)
        => await repository.GetMailSubscriberAsync(mailSubscriberId: id) is MailSubscriberEntity mailSubscriber
        ? Results.Ok(mailSubscriber)
        : Results.NotFound();

    [AllowAnonymous]
    private async Task<IResult> Create([FromBody] MailSubscriberEntity mailSubscriber,
        IMailSubscriberFacadeService repository)
    {
        await repository.CreateAsync(mailSubscriber);

        return Results.Created($"/MailSubscribers/{mailSubscriber.Id}", mailSubscriber);
    }

    [AllowAnonymous]
    private async Task<IResult> Put([FromBody] MailSubscriberEntity mailSubscriber,
        IMailSubscriberFacadeService repository)
    {
        await repository.UpdateAsync(mailSubscriber);

        return Results.NoContent();
    }

    [AllowAnonymous]
    private async Task<IResult> Delete(int id,
        IMailSubscriberFacadeService repository)
    {
        await repository.DeleteAsync(id);

        return Results.NoContent();
    }
}