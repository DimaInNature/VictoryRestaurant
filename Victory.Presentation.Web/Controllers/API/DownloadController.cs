namespace Victory.Presentation.Web.Controllers.API;

public class DownloadController : Controller
{
    [HttpGet("/Download")]
    public async Task<FileStreamResult> Download(string fileName)
    {
        var applicationPath = Directory.GetParent(
            path: Directory.GetCurrentDirectory()).FullName;

        var filePath = $@"{applicationPath}\Victory.Infra.Shared.Downloads\Client\{fileName}";

        var memory = new MemoryStream();

        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            await stream.CopyToAsync(memory);
        }

        memory.Position = 0;

        string fileExtension = Path.GetExtension(filePath).ToLowerInvariant();

        string fileType = GetMimeTypes()[fileExtension];

        return File(memory, fileType, Path.GetFileName(filePath));
    }

    private Dictionary<string, string> GetMimeTypes()
    {
        return new Dictionary<string, string>
        {
            {".txt", "text/plain"},
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".zip", "application/zip" },
            {".rar", "application/x-rar-compressed" }
        };
    }
}