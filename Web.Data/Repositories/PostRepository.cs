namespace VictoryRestaurant.Web.Data.Repositories;

public class PostRepository : IPostRepository
{
    private List<PostEntity> _posts = new()
    {
        new()
        {
            Title = "Nullam ornare purus massa",
            Description = @"Vivamus venenatis mi enim, ut gravida sem viverra sit amet. Nam ullamcorper dui nec risus malesuada fringilla.
                Aliquam erat volutpat. Aliquam a varius odio. Quisque iaculis massa vel nunc porta vehicula. Nulla consectetur iaculis
                elit. Vivamus euismod lorem rutrum iaculis commodo. Cras congue nisi non varius tincidunt.",
            Category = PostCategories.Branding,
            Author = "Admin",
            HeadingImagePath = "~img/blog_item_01.jpg",
            Text = "",
            PublishedDate = new DateOnly(year: 2020, month: 10, day: 26)
        },
        new()
        {
            Title = "Class aptent taciti sociosqu",
            Description = @"Praesent id pellentesque est. Etiam vestibulum eros quis vulputate convallis. Praesent quam diam, placerat a ipsum
                sed, facilisis dignissim lorem. Vivamus a elit vitae mauris fringilla scelerisque sit amet eget mauris.
                Suspendisse vulputate congue eleifend.",
            Category = PostCategories.Branding,
            Author = "Admin",
            HeadingImagePath = "~img/blog_item_02.jpg",
            Text = "",
            PublishedDate = new DateOnly(year: 2020, month: 10, day: 21)
        },
        new()
        {
            Title = "Cras congue nisi non varius tincidunt",
            Description = @"Mauris mollis urna sit amet eros pretium, a tincidunt tellus eleifend. Sed dictum sit amet sapien ut scelerisque. Duis
                vulputate elit vehicula nisl maximus eleifend. Suspendisse potenti. Aenean ut dui fermentum, pharetra quam vitae,
                placerat dolor. Curabitur at dolor sed felis lacinia ultricies sit amet vel sem.",
            Category = PostCategories.Desserts,
            Author = "Chef",
            HeadingImagePath = "~img/blog_item_03.jpg",
            Text = "",
            PublishedDate = new DateOnly(year: 2020, month: 10, day: 11)
        },
        new()
        {
            Title = "Vivamus euismod lorem",
            Description = @"Pellentesque nec orci in erat venenatis viverra. Vivamus in lorem et leo feugiat ullamcorper. Donec volutpat fermentum
                erat non aliquet. Cras fermentum, risus a blandit sodales, erat turpis eleifend lacus, venenatis mollis leo lorem vel eros.
                Quisque et sem tempus, feugiat urna iaculis, tempor metus.",
            Category = PostCategories.Food,
            Author = "Chef",
            HeadingImagePath = "~img/blog_item_04.jpg",
            Text = "",
            PublishedDate = new DateOnly(year: 2020, month: 10, day: 3)
        },
    };

    private readonly ApplicationContext _context;

    public PostRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task AddPostAsync(PostEntity postEntity)
    {
        await _context.Posts.AddAsync(postEntity);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<PostEntity> GetAll() => _posts;

    public async Task DeletePost(PostEntity postItem)
    {
        _context.Posts.Attach(postItem);
        _context.Posts.Remove(postItem);
        await _context.SaveChangesAsync();
    }

    //public async Task<FoodEntity> GetFoodByIdAsync(int id) =>
    //    await _context.Foods.FirstOrDefaultAsync(x => x.Id == id);

    public PostEntity GetPostById(int id) =>
       _posts.FirstOrDefault(x => x.Id == id);

    public async Task UpdatePost(PostEntity postItem) =>
        await Task.Run(() =>
        {
            _context.Posts.Update(
                new()
                {
                    Title = postItem.Title,
                    Description = postItem.Description,
                    Category = postItem.Category,
                    Author = postItem.Author,
                    HeadingImagePath = postItem.HeadingImagePath,
                    Text = postItem.Text,
                    PublishedDate = postItem.PublishedDate,
                    CreatedDate = postItem.CreatedDate,
                    Id = postItem.Id
                });
            return _context.SaveChanges();
        });
}
