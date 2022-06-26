namespace Victory.Presentation.Web.Configurations;

public static class DomainInfoConfiguration
{
    public static string Name { get; private set; } = string.Empty;

    public static string Phone { get; private set; } = string.Empty;

    public static string Address { get; private set; } = string.Empty;

    public static string City { get; private set; } = string.Empty;

    public static string DeliveryIndex { get; private set; } = string.Empty;

    public static void SetDomainConfiguration(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        Name = builder.Configuration[key: "Domain:Name"];
        Phone = builder.Configuration[key: "Domain:Phone"];
        Address = builder.Configuration[key: "Domain:Address"];
        City = builder.Configuration[key: "Domain:City"];
        DeliveryIndex = builder.Configuration[key: "Domain:DeliveryIndex"];
    }
}