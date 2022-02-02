namespace VictoryRestaurant.Web.Services.Posts;

public class PostRepositoryService : IPostRepositoryService
{
    private readonly IPostRepository _repository;

    public PostRepositoryService(IPostRepository repository)
    {
        _repository = repository;
    }

    public void AddPost(Post postItem)
    {
        _repository.AddPostAsync(postItem.ToEntity());
    }

    public void DeletePost(Post postItem)
    {
        _repository.DeletePost(postItem.ToEntity());
    }

    public IEnumerable<Post> GetAll()
    {
        List<Post> posts = new();

        foreach (var item in _repository.GetAll())
        {
            posts.Add(item.ToDomain());
        }

        return posts;
    }

    public Post GetPostById(int id)
    {
        return _repository.GetPostById(id).ToDomain();
    }

    public void UpdatePost(Post postItem)
    {
        _repository.UpdatePost(postItem.ToEntity());
    }
}