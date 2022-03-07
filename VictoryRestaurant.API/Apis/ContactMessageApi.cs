namespace VictoryRestaurant.API.Apis;

public class ContactMessageApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet(pattern: "/ContactMessages", handler: GetAll)
            .Produces<List<ContactMessageEntity>>(StatusCodes.Status200OK)
            .WithName("GetAllContactMessages")
            .WithTags("Getters");

        app.MapGet(pattern: "/ContactMessages/{id}", handler: GetById)
            .Produces<ContactMessageEntity>(StatusCodes.Status200OK)
            .WithName("GetContactMessage")
            .WithTags("Getters");

        app.MapPost(pattern: "/ContactMessages", handler: Create)
            .Accepts<ContactMessageEntity>("application/json")
            .Produces<ContactMessageEntity>(StatusCodes.Status201Created)
            .WithName("CreateContactMessage")
            .WithTags("Creators");

        app.MapPut(pattern: "/ContactMessages", handler: Put)
            .Accepts<ContactMessageEntity>("application/json")
            .WithName("UpdateContactMessage")
            .WithTags("Updaters");

        app.MapDelete(pattern: "/ContactMessages/{id}", handler: Delete)
            .WithName("DeleteContactMessage")
            .WithTags("Deleters");
    }

    private async Task<IResult> GetAll(IContactMessageRepositoryService repository)
        => Results.Ok(await repository.GetContactMessagesAsync());

    private async Task<IResult> GetById(int id, IContactMessageRepositoryService repository)
        => await repository.GetContactMessageAsync(contactMessageId: id) is ContactMessageEntity contactMessage
        ? Results.Ok(contactMessage)
        : Results.NotFound();

    private async Task<IResult> Create([FromBody] ContactMessageEntity contactMessage,
        IContactMessageRepositoryService repository)
    {
        await repository.InsertContactMessageAsync(contactMessage);
        await repository.SaveAsync();
        return Results.Created($"/ContactMessages/{contactMessage.Id}", contactMessage);
    }

    private async Task<IResult> Put([FromBody] ContactMessageEntity contactMessage,
        IContactMessageRepositoryService repository)
    {
        await repository.UpdateContactMessageAsync(contactMessage);
        await repository.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(int id, IContactMessageRepositoryService repository)
    {
        await repository.DeleteContactMessageAsync(id);
        await repository.SaveAsync();
        return Results.NoContent();
    }
}
