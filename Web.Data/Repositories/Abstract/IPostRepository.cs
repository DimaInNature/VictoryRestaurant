namespace VictoryRestaurant.Web.Data.Repositories.Abstract;

public interface IPostRepository
{
    Task AddPostAsync(PostEntity postItem);
    Task UpdatePost(PostEntity postItem);
    Task DeletePost(PostEntity postItem);
    PostEntity GetPostById(int id);
    IEnumerable<PostEntity> GetAll();
}