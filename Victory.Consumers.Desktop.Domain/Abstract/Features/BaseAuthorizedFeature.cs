namespace Victory.Consumers.Desktop.Domain.Configurations;

public abstract record class BaseAuthorizedFeature
{
    public string? Token { get; set; } = null;
}