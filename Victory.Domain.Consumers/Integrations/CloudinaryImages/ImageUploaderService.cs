namespace Victory.Domain.Consumers.Integrations.CloudinaryImages;

public class ImageUploaderService
{
    private readonly IMediator _mediator;

    public ImageUploaderService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<string?> Upload(CloudinaryImage image, Account account, string subFolder, string name) =>
         await _mediator.Send(request: new UploadImageCommand(image, account, subFolder, name));
}