namespace VictoryRestaurant.Web.Services.Abstract.Posts;

public interface IPostRepositoryService
{
    void AddPost(Post postItem);
    void UpdatePost(Post postItem);
    void DeletePost(Post postItem);
    Post GetPostById(int id);
    IEnumerable<Post> GetAll();
}