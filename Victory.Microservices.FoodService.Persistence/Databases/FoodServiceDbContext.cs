namespace Victory.Microservices.FoodService.Persistence.Databases;

public sealed class FoodServiceDbContext : DbContext
{
    public DbSet<FoodEntity> Foods => Set<FoodEntity>();

    public DbSet<FoodTypeEntity> FoodTypes => Set<FoodTypeEntity>();

    public FoodServiceDbContext(DbContextOptions<FoodServiceDbContext> options)
       : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodEntity>()
            .HasIndex(indexExpression: food => food.Id)
            .IsUnique();

        modelBuilder.Entity<FoodEntity>()
            .HasData(data: GetFoods());

        modelBuilder.Entity<FoodTypeEntity>()
           .HasIndex(indexExpression: food => food.Id)
           .IsUnique();

        modelBuilder.Entity<FoodTypeEntity>()
            .HasData(data: GetFoodTypes());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        base.OnConfiguring(optionsBuilder);

    private List<FoodEntity> GetFoods() => new();

    private List<FoodTypeEntity> GetFoodTypes() => new();
}