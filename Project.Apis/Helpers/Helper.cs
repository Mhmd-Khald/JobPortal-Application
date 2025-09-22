using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;

namespace Project.Apis.Helpers
{
    public class Helper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Helper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public  string UploadImage(IFormFile file, string scheme, HostString host)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file was uploaded.");
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Documentaion", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                 file.CopyToAsync(stream);
            }

            var imageUrl = $"{scheme}://{host}/images/{fileName}";

            return imageUrl;
        }

    }

}
