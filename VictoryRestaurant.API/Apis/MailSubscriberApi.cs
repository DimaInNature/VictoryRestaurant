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

    private async Task<IResult> GetAll(IMailSubscriberRepositoryService repository)
        => Results.Ok(await repository.GetMailSubscribersAsync());

    private async Task<IResult> GetById(int id, IMailSubscriberRepositoryService repository)
        => await repository.GetMailSubscriberAsync(mailSubscriberId: id) is MailSubscriberEntity mailSubscriber
        ? Results.Ok(mailSubscriber)
        : Results.NotFound();

    private async Task<IResult> Create([FromBody] MailSubscriberEntity mailSubscriber,
        IMailSubscriberRepositoryService repository)
    {
        await repository.InsertMailSubscriberAsync(mailSubscriber);
        await repository.SaveAsync();
        return Results.Created($"/MailSubscribers/{mailSubscriber.Id}", mailSubscriber);
    }

    private async Task<IResult> Put([FromBody] MailSubscriberEntity mailSubscriber,
        IMailSubscriberRepositoryService repository)
    {
        await repository.UpdateMailSubscriberAsync(mailSubscriber);
        await repository.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(int id, IMailSubscriberRepositoryService repository)
    {
        await repository.DeleteMailSubscriberAsync(id);
        await repository.SaveAsync();
        return Results.NoContent();
    }
}