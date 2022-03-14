namespace VictoryRestaurant.API;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<FoodEntity> Foods => Set<FoodEntity>();
    public DbSet<BookingEntity> Bookings => Set<BookingEntity>();
    public DbSet<ContactMessageEntity> ContactMessages => Set<ContactMessageEntity>();
    public DbSet<MailSubscriberEntity> MailSubscribers => Set<MailSubscriberEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodEntity>().HasIndex(food => food.Id).IsUnique();
        modelBuilder.Entity<FoodEntity>().HasData(GetFoods());

        modelBuilder.Entity<BookingEntity>().HasIndex(booking => booking.Id).IsUnique();
        modelBuilder.Entity<BookingEntity>().HasData(GetBookings());

        modelBuilder.Entity<ContactMessageEntity>().HasIndex(contactMessage => contactMessage.Id).IsUnique();
        modelBuilder.Entity<ContactMessageEntity>().HasData(GetContactMessages());

        modelBuilder.Entity<MailSubscriberEntity>().HasIndex(mailSubscriber => mailSubscriber.Id).IsUnique();
        modelBuilder.Entity<MailSubscriberEntity>().HasData(GetMailSubscribers());

        modelBuilder.Entity<UserEntity>().HasIndex(user => user.Id).IsUnique();
        modelBuilder.Entity<UserEntity>().HasData(GetUsers());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    private List<FoodEntity> GetFoods()
    {
        return new()
        {

            #region Breakfast
            new()
            {
                Id = 1,
                CreatedDate = DateTime.Now,
                Name = "Kale Chips Art Party",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 4.50,
                Type = FoodType.Breakfast,
                ImagePath = "https://localhost:7059/img/foods/breakfast_item.jpg"
            },
            new()
            {
                Id = 2,
                CreatedDate = DateTime.Now,
                Name = "Drink Vinegar Prism",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 7.25,
                Type = FoodType.Breakfast,
                ImagePath = "https://localhost:7059/img/foods/lunch_item.jpg"
            },
            new()
            {
                Id = 3,
                CreatedDate = DateTime.Now,
                Name = "Taiyaki Gastro Tousled",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 11.50,
                Type = FoodType.Breakfast,
                ImagePath = "https://localhost:7059/img/foods/dinner_item.jpg"
            },

            #endregion

            #region Lunch

            new()
            {
                Id = 4,
                CreatedDate = DateTime.Now,
                Name = "Mumble Ditch Corn",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 6.50,
                Type = FoodType.Lunch,
                ImagePath = "https://localhost:7059/img/foods/lunch_item.jpg"
            },
            new()
            {
                Id = 5,
                CreatedDate = DateTime.Now,
                Name = "Wayfare Lomo Core",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 11.75,
                Type = FoodType.Lunch,
                ImagePath = "https://localhost:7059/img/foods/breakfast_item.jpg"
            },
            new()
            {
                Id = 6,
                CreatedDate = DateTime.Now,
                Name = "Taiyaki Gastro Tousled",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 16.50,
                Type = FoodType.Lunch,
                ImagePath = "https://localhost:7059/img/foods/breakfast_item.jpg"
            },

            #endregion

            #region Dinner

            new()
            {
                Id = 7,
                CreatedDate = DateTime.Now,
                Name = "Meal Apples Almonds",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 8.25,
                Type = FoodType.Dinner,
                ImagePath = "https://localhost:7059/img/foods/dinner_item.jpg"
            },
            new()
            {
                Id = 8,
                CreatedDate = DateTime.Now,
                Name = "Ditch Corn Art",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 12.50,
                Type = FoodType.Dinner,
                ImagePath = "https://localhost:7059/img/foods/dinner_item.jpg"
            },
            new()
            {
                Id = 9,
                CreatedDate = DateTime.Now,
                Name = "Kale Chips Art Party",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 16.00,
                Type = FoodType.Dinner,
                ImagePath = "https://localhost:7059/img/foods/breakfast_item.jpg"
            }

            #endregion
        };
    }

    private List<BookingEntity> GetBookings() => new();

    private List<ContactMessageEntity> GetContactMessages() => new();

    private List<MailSubscriberEntity> GetMailSubscribers() => new();

    private List<UserEntity> GetUsers() => new()
    {
        new()
        {
            Id = 1,
            Login = "Admin",
            Password = "Root"
        }
    };
}