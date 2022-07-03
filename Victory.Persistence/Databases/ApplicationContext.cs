namespace Victory.Persistence.Databases;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<FoodEntity> Foods => Set<FoodEntity>();
    public DbSet<FoodTypeEntity> FoodTypes => Set<FoodTypeEntity>();
    public DbSet<BookingEntity> Bookings => Set<BookingEntity>();
    public DbSet<TableEntity> Tables => Set<TableEntity>();
    public DbSet<ContactMessageEntity> ContactMessages => Set<ContactMessageEntity>();
    public DbSet<MailSubscriberEntity> MailSubscribers => Set<MailSubscriberEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<UserRoleEntity> UserRoles => Set<UserRoleEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodEntity>().HasIndex(indexExpression: food => food.Id).IsUnique();
        modelBuilder.Entity<FoodEntity>().HasData(data: GetFoods());

        modelBuilder.Entity<FoodTypeEntity>().HasIndex(indexExpression: foodType => foodType.Id).IsUnique();
        modelBuilder.Entity<FoodTypeEntity>().HasData(data: GetFoodTypes());

        modelBuilder.Entity<BookingEntity>().HasIndex(indexExpression: booking => booking.Id).IsUnique();
        modelBuilder.Entity<BookingEntity>().HasData(data: GetBookings());

        modelBuilder.Entity<TableEntity>().HasIndex(indexExpression: table => table.Id).IsUnique();
        modelBuilder.Entity<TableEntity>().HasData(data: GetTables());

        modelBuilder.Entity<ContactMessageEntity>().HasIndex(indexExpression: contactMessage => contactMessage.Id).IsUnique();
        modelBuilder.Entity<ContactMessageEntity>().HasData(data: GetContactMessages());

        modelBuilder.Entity<MailSubscriberEntity>().HasIndex(indexExpression: mailSubscriber => mailSubscriber.Id).IsUnique();
        modelBuilder.Entity<MailSubscriberEntity>().HasData(data: GetMailSubscribers());

        modelBuilder.Entity<UserEntity>().HasIndex(indexExpression: user => user.Id).IsUnique();
        modelBuilder.Entity<UserEntity>().HasData(data: GetUsers());

        modelBuilder.Entity<UserRoleEntity>().HasIndex(indexExpression: userRole => userRole.Id).IsUnique();
        modelBuilder.Entity<UserRoleEntity>().HasData(data: GetUserRoles());

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
                FoodTypeId = 2,
                ImagePath = "https://localhost:7059/img/foods/breakfast_item.jpg"
            },
            new()
            {
                Id = 2,
                CreatedDate = DateTime.Now,
                Name = "Drink Vinegar Prism",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 7.25,
                FoodTypeId = 2,
                ImagePath = "https://localhost:7059/img/foods/lunch_item.jpg"
            },
            new()
            {
                Id = 3,
                CreatedDate = DateTime.Now,
                Name = "Taiyaki Gastro Tousled",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 11.50,
                FoodTypeId = 2,
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
                FoodTypeId = 3,
                ImagePath = "https://localhost:7059/img/foods/lunch_item.jpg"
            },
            new()
            {
                Id = 5,
                CreatedDate = DateTime.Now,
                Name = "Wayfare Lomo Core",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 11.75,
                FoodTypeId = 3,
                ImagePath = "https://localhost:7059/img/foods/breakfast_item.jpg"
            },
            new()
            {
                Id = 6,
                CreatedDate = DateTime.Now,
                Name = "Taiyaki Gastro Tousled",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 16.50,
                FoodTypeId = 3,
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
                FoodTypeId = 4,
                ImagePath = "https://localhost:7059/img/foods/dinner_item.jpg"
            },
            new()
            {
                Id = 8,
                CreatedDate = DateTime.Now,
                Name = "Ditch Corn Art",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 12.50,
                FoodTypeId = 4,
                ImagePath = "https://localhost:7059/img/foods/dinner_item.jpg"
            },
            new()
            {
                Id = 9,
                CreatedDate = DateTime.Now,
                Name = "Kale Chips Art Party",
                Description = "Dreamcatcher squid ennui cliche chicharros\n nes echo small batch jean shorts hexagon\n street art knausgaard wolf...",
                CostInUSD = 16.00,
                FoodTypeId = 4,
                ImagePath = "https://localhost:7059/img/foods/breakfast_item.jpg"
            }

            #endregion
        };
    }

    private List<FoodTypeEntity> GetFoodTypes() =>
        new()
        {
            new()
            {
                Id = 1,
                Name = "Unknown"
            },
            new()
            {
                Id = 2,
                Name = "Breakfast"
            },
            new()
            {
                Id=3,
                Name = "Lunch"
            },
            new()
            {
                Id = 4,
                Name = "Dinner"
            }
        };

    private List<BookingEntity> GetBookings() => new();

    private List<TableEntity> GetTables() => new()
    {
        new()
        {
            Id = 1,
            Number = 1,
            Status = "Free",
            BookingId = null
        },
         new()
        {
            Id = 2,
            Number = 2,
            Status = "Free",
            BookingId = null
        }
    };

    private List<ContactMessageEntity> GetContactMessages() => new();

    private List<MailSubscriberEntity> GetMailSubscribers() => new();

    private List<UserEntity> GetUsers() => new()
    {
        new()
        {
            Id = 1,
            Login = "Admin",
            Password = "Root",
            UserRoleId = 2
        },
        new()
        {
            Id = 2,
            Login = "Employee",
            Password = "Root",
            UserRoleId = 3
        },
        new()
        {
            Id = 3,
            Login = "User",
            Password = "Root",
            UserRoleId = 3
        }
    };

    private List<UserRoleEntity> GetUserRoles() => new()
    {
        new()
        {
            Id = 1,
            Name = "Unknown"
        },
        new()
        {
            Id = 2,
            Name = "Admin"
        },
        new()
        {
            Id = 3,
            Name = "Employee"
        }
    };
}