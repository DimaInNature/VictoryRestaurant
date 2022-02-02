namespace VictoryRestaurant.Web.Services.Abstract.Posts;

public interface IPostFacadeService
{
    void AddPost(Post food);
    void ChangePost(Post food);
    void DeletePost(Post food);
    IEnumerable<Post> GetAllPosts();
    IEnumerable<Post> GetAllPosts(Func<Post, bool> predicate);
    Post GetFirstPost();
    Post GetFirstPost(Func<Post, bool> predicate);
}
