namespace Victory.Domain.Models;

public class CloudinaryImage
{
    public string? ImagePath { get; }

    public override string ToString() => ImagePath ?? string.Empty;

    public CloudinaryImage(string path) => ImagePath = path;
}