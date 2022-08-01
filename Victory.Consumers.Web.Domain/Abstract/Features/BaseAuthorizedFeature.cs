namespace Victory.Consumers.Web.Domain.Abstract.Features;

public abstract record class BaseAuthorizedFeature
{
    public string? Token { get; set; } = null;
}