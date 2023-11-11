using Medicoz.Application.Contracts.FileService;
using Microsoft.AspNetCore.Http;

namespace Medicoz.Infrastructure.FileService
{
    public class FileService : IFileService
    {
        public string Upload(IFormFile file, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(path, uniqueFileName);

            using var fileStream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(fileStream);

            return uniqueFileName;
        }

        public void RemoveFile(IFormFile file, string path, string folderName, string fileName)
        {
            if (file != null)
            {
                string fullPath = Path.Combine(path, folderName, fileName);
                if (System.IO.File.Exists(fullPath)) { System.IO.File.Delete(fullPath); }
            }
        }

        public void RemoveFile(string path, string folderName, string fileName)
        {
            string fullPath = Path.Combine(path, folderName, fileName);
            if (System.IO.File.Exists(fullPath)) { System.IO.File.Delete(fullPath); }
        }
    }
}
