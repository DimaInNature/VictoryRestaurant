namespace Victory.Domain.Features.Consumers.Integrations.CloudinaryImages;

public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, string?>
{
    public async Task<string?> Handle(UploadImageCommand request, CancellationToken token)
    {
        if (request.Image?.ImagePath is null
            | request.Account is null
            | request.SubFolder is null
            | request.Name is null)
            return null;

        Cloudinary cloudinary = new(request.Account);
        cloudinary.Api.Secure = true;

        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(request.Image?.ImagePath),
            PublicId = $"uploads/{request.SubFolder}/{request.Name}",
            Overwrite = true
        };

        return cloudinary.Upload(uploadParams).Url.ToString();
    }
}