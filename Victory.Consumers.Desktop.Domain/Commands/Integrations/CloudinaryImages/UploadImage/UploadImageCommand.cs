namespace Victory.Consumers.Desktop.Domain.Commands.Integrations.CloudinaryImages;

public sealed record class UploadImageCommand : IRequest<string?>
{
    public CloudinaryImage? Image { get; }

    public Account? Account { get; }

    public string? SubFolder { get; }

    public string? Name { get; }

    public UploadImageCommand(CloudinaryImage imageEntity,
        Account accountEntity, string subFolder, string name) =>
        (Image, Account, SubFolder, Name) = (imageEntity, accountEntity, subFolder, name);

    public UploadImageCommand() { }
}