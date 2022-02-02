namespace VictoryRestaurant.Web.Data.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<FoodEntity> Foods => Set<FoodEntity>();
    public DbSet<PostEntity> Posts => Set<PostEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodEntity>().HasIndex(food => food.Id).IsUnique();
        modelBuilder.Entity<FoodEntity>().HasData(GetFoods());
        modelBuilder.Entity<PostEntity>().HasIndex(post => post.Id).IsUnique();

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
                Name = "Kale Chips Art Party",
                Description = @"Dreamcatcher squid ennui cliche chicharros
                    nes echo small batch jean shorts hexagon
                    street art knausgaard wolf...",
                CostInUSD = 4.50,
                Type = FoodType.Breakfast,
                ImagePath = "~/img/breakfast_item.jpg"
            },
            new()
            {
                Id = 2,
                Name = "Drink Vinegar Prism",
                Description = @"Dreamcatcher squid ennui cliche chicharros
                    nes echo small batch jean shorts hexagon
                    street art knausgaard wolf...",
                CostInUSD = 7.25,
                Type = FoodType.Breakfast,
                ImagePath = "~/img/lunch_item.jpg"
            },
            new()
            {
                Id = 3,
                Name = "Taiyaki Gastro Tousled",
                Description = @"Dreamcatcher squid ennui cliche chicharros
                    nes echo small batch jean shorts hexagon
                    street art knausgaard wolf...",
                CostInUSD = 11.50,
                Type = FoodType.Breakfast,
                ImagePath = "~/img/dinner_item.jpg"
            },

            #endregion

            #region Lunch

            new()
            {
                Id = 4,
                Name = "Mumble Ditch Corn",
                Description = @"Dreamcatcher squid ennui cliche chicharros
                    nes echo small batch jean shorts hexagon
                    street art knausgaard wolf...",
                CostInUSD = 6.50,
                Type = FoodType.Lunch,
                ImagePath = "~/img/lunch_item.jpg"
            },
            new()
            {
                Id = 5,
                Name = "Wayfare Lomo Core",
                Description = @"Dreamcatcher squid ennui cliche chicharros
                    nes echo small batch jean shorts hexagon
                    street art knausgaard wolf...",
                CostInUSD = 11.75,
                Type = FoodType.Lunch,
                ImagePath = "~/img/breakfast_item.jpg"
            },
            new()
            {
                Id = 6,
                Name = "Taiyaki Gastro Tousled",
                Description = @"Dreamcatcher squid ennui cliche chicharros
                    nes echo small batch jean shorts hexagon
                    street art knausgaard wolf...",
                CostInUSD = 16.50,
                Type = FoodType.Lunch,
                ImagePath = "~/img/breakfast_item.jpg"
            },

            #endregion

            #region Dinner

            new()
            {
                Id = 7,
                Name = "Meal Apples Almonds",
                Description = @"Dreamcatcher squid ennui cliche chicharros
                    nes echo small batch jean shorts hexagon
                    street art knausgaard wolf...",
                CostInUSD = 8.25,
                Type = FoodType.Dinner,
                ImagePath = "~/img/dinner_item.jpg"
            },
            new()
            {
                Id = 8,
                Name = "Ditch Corn Art",
                Description = @"Dreamcatcher squid ennui cliche chicharros
                    nes echo small batch jean shorts hexagon
                    street art knausgaard wolf...",
                CostInUSD = 12.50,
                Type = FoodType.Dinner,
                ImagePath = "~/img/dinner_item.jpg"
            },
            new()
            {
                Id = 9,
                Name = "Kale Chips Art Party",
                Description = @"Dreamcatcher squid ennui cliche chicharros
                    nes echo small batch jean shorts hexagon
                    street art knausgaard wolf...",
                CostInUSD = 16.00,
                Type = FoodType.Dinner,
                ImagePath = "~/img/breakfast_item.jpg"
            },

            #endregion
        };
    }
}