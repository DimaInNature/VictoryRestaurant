namespace VictoryRestaurant.Web.Services.Posts;

public class PostRepositoryService : IPostRepositoryService
{
    private readonly IPostRepository _repository;

    public PostRepositoryService(IPostRepository repository)
    {
        _repository = repository;
    }
}