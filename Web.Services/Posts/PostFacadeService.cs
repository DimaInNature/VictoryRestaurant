namespace VictoryRestaurant.Web.Services.Posts;

public class PostFacadeService : IPostFacadeService
{
    private readonly IPostRepositoryService _repositoryService;

    public PostFacadeService(IPostRepositoryService repositoryService)
    {
        _repositoryService = repositoryService;
    }
}
