
using Microsoft.AspNetCore.Http;

namespace CMgt.shared.Helpers;

public static class SaveImage
{
    public static string SaveFile(string webRootPath, string subDirectory, IFormFile file)
    {
        const int megabyte = 1024 * 1024;

        if (!file.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Invalid MIME content type.");
        }

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        string[] allowedExtensions = { ".gif", ".jpg", ".jpeg", ".png", ".svg", ".webp" };
        if (!allowedExtensions.Contains(extension))
        {
            throw new InvalidOperationException("Invalid file extension.");
        }

        if (file.Length > (10 * megabyte))
        {
            throw new InvalidOperationException("Error: Maximum file size is 10MB.");
        }

        var fileName = Guid.NewGuid() + extension;

        // Combine paths and ensure the directory exists
        var targetFolder = Path.Combine(webRootPath, subDirectory);
        if (!Directory.Exists(targetFolder))
        {
            Directory.CreateDirectory(targetFolder);
        }

        var filePath = Path.Combine(targetFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        var returnFilePath = Path.Combine(subDirectory, fileName).Replace('\\', '/');
        return returnFilePath;
    }
}
