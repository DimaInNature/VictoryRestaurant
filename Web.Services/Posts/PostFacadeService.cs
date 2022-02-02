namespace VictoryRestaurant.Web.Services.Posts;

public class PostFacadeService : IPostFacadeService
{
    private readonly IPostRepositoryService _repositoryService;

    public PostFacadeService(IPostRepositoryService repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void AddPost(Post post)
    {
        _repositoryService.AddPost(post);
    }

    public void ChangePost(Post post)
    {
        _repositoryService.UpdatePost(post);
    }

    public void DeletePost(Post post)
    {
        _repositoryService.DeletePost(post);
    }

    public IEnumerable<Post> GetAllPosts() =>
        _repositoryService.GetAll() ?? new List<Post>();

    public IEnumerable<Post> GetAllPosts(Func<Post, bool> predicate) =>
        _repositoryService.GetAll()
        .AsParallel()
        .Where(predicate)
        .ToList() ?? new List<Post>();

    public Post GetFirstPost() =>
    _repositoryService.GetAll()
        .FirstOrDefault() ?? new Post();

    public Post GetFirstPost(Func<Post, bool> predicate) =>
        _repositoryService.GetAll()
        .AsParallel()
        .Where(predicate)
        .FirstOrDefault() ?? new Post();
}
