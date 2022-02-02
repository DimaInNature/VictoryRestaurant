using VictoryRestaurant.Web.Enums;

namespace VictoryRestaurant.Web.Domain;

public class Post
{
    public string Title { get; set; }
    public string HeadingImagePath { get; set; }
    public PostCategories Category { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string Text { get; set; }
    public DateOnly PublishedDate { get; set; }
}
