namespace Victory.Presentation.Web.Configurations;

public static class CompanyInfoConfiguration
{
    public static string Name { get; private set; } = string.Empty;

    public static string Phone { get; private set; } = string.Empty;

    public static string Address { get; private set; } = string.Empty;

    public static string City { get; private set; } = string.Empty;

    public static string DeliveryIndex { get; private set; } = string.Empty;

    public static void SetCompanyConfiguration(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        Name = builder.Configuration[key: "Company:Name"];
        Phone = builder.Configuration[key: "Company:Phone"];
        Address = builder.Configuration[key: "Company:Address"];
        City = builder.Configuration[key: "Company:City"];
        DeliveryIndex = builder.Configuration[key: "Company:DeliveryIndex"];
    }
}