namespace VictoryRestaurant.Web.Mappers;

public static class PostMapper
{
    public static PostEntity ToEntity(this Post postItem) =>
        postItem is not null ? new()
        {
            Title = postItem.Title,
            Description = postItem.Description,
            PublishedDate = postItem.PublishedDate,
            Text = postItem.Text,
            Category = postItem.Category,
            HeadingImagePath = postItem.HeadingImagePath,
            Author = postItem.Author
        }
        : throw new ArgumentNullException($"{nameof(PostMapper)},{nameof(postItem)}");

    public static Post ToDomain(this PostEntity postModel) =>
       postModel is not null ? new()
       {
           Title = postModel.Title,
           Description = postModel.Description,
           PublishedDate = postModel.PublishedDate,
           Text = postModel.Text,
           Category = postModel.Category,
           HeadingImagePath = postModel.HeadingImagePath,
           Author = postModel.Author
       }
       : throw new ArgumentNullException($"{nameof(PostMapper)},{nameof(postModel)}");
}
