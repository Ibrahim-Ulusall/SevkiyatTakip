using Microsoft.AspNetCore.Http;
using Sevkiyat.Takip.Core.Utilities.Results;

namespace Sevkiyat.Takip.Core.Utilities.Helpers;
public class Helper
{

    private string[] supportedImageExtensions = new string[]
    {
        ".png",".jpg",".jpeg"
    };

    private string[] supportedImageMimeTypes = new string[]
    {
        "image/png","image/jpeg"
    };
    public async Task<IDataResult<string>> UploadImage(IFormFile file, string path = "wwwroot/images/users")
    {
        IResult isImage = IsImage(file);

        if (!isImage.Success)
            return new ErrorDataResult<string>(message: isImage.Message);

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string newPath = Path.Combine(path, file.FileName);

        if (File.Exists(newPath))
            newPath = Path.Combine(path, $"{Path.GetFileName(file.FileName)}_{DateTime.Now:dd_MM_yyyy}{Path.GetExtension(file.FileName)}");

        using (var stream = new FileStream(newPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return new SuccessDataResult<string>
        {
            Data = newPath
        };

    }

    public IResult IsImage(IFormFile file)
    {
        string filename = file.FileName;
        string extension = Path.GetExtension(filename);

        int maxSupportedFileLength = 5 * 1024 * 1024;

        if (!supportedImageExtensions.Contains(extension))
            return new ErrorResult(message: "File not supported");

        if (file.Length > maxSupportedFileLength)
            return new ErrorResult(message: "File size must be max 5 MB");

        if (filename.StartsWith("."))
            return new ErrorResult(message: "File not supported");

        if (!supportedImageMimeTypes.Contains(file.ContentType))
            return new ErrorResult(message: "File content type not supported");

        return new SuccessResult();
    }

}
