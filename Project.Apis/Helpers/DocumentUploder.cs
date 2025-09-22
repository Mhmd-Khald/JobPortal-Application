using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Project.Apis.Helpers
{
    //public static class DocumentUploder
    //{

    //    public static string UploadFile(IFormFile file, string folderName)
    //    //{
        //    if (file == null || string.IsNullOrEmpty(file.FileName))
        //    {
        //        throw new ArgumentException("Invalid file parameter.");
        //    }

        //    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Helpers\\files", folderName);
        //    //2 Get File Name
        //    string fileName = $"{Guid.NewGuid()}{file.FileName}";
        //    //3 get File Path
        //    string filePath = Path.Combine(folderPath, fileName);
        //    //4 Save File As Streams
        //    using var fs = new FileStream(filePath, FileMode.Create);

        //    file.CopyTo(fs);
        //    return fileName;




            

public static class DocumentUploader
    {
        public static async Task<string> Upload(IFormFile file, HttpRequest request)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(request.HttpContext.Request.PathBase, "images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var imageUrl = $"{request.Scheme}://{request.Host}/images/{fileName}";
            return imageUrl;
        }
    }


}
  


