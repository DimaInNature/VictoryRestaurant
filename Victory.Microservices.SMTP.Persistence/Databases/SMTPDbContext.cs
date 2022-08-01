namespace Victory.Microservices.SMTP.Persistence.Databases;

public sealed class SMTPDbContext : DbContext
{
    public DbSet<MailSubscriberEntity> MailSubscribers => Set<MailSubscriberEntity>();

    public SMTPDbContext(DbContextOptions<SMTPDbContext> options)
       : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MailSubscriberEntity>()
            .HasIndex(indexExpression: mailSubscriber => mailSubscriber.Id)
            .IsUnique();

        modelBuilder.Entity<MailSubscriberEntity>()
            .HasData(data: GetMailSubscribers());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        base.OnConfiguring(optionsBuilder);

    private List<MailSubscriberEntity> GetMailSubscribers() => new();
}