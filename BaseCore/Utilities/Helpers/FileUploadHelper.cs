using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BaseCore.Utilities.Helpers
{
    public class FileUploadHelper
    {
        public static async Task<string> Image(IFormFile image, string path, string imageFileName = null)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
            var myUniqueFileName = imageFileName ?? Convert.ToString(Guid.NewGuid());
            var fileExtension = Path.GetExtension(fileName);
            var newFileName = imageFileName != null ? myUniqueFileName : myUniqueFileName + fileExtension;

            if (File.Exists(path + imageFileName))
                File.Delete(path + imageFileName);

            path += imageFileName ?? "/" + newFileName;
            await using var fs = File.Create(path);

            await image.CopyToAsync(fs);
            fs.Flush();
            return newFileName;
        }
    }
}
