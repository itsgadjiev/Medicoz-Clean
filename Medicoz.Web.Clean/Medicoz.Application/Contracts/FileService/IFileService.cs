using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Contracts.FileService
{
    public interface IFileService
    {
        string Upload(IFormFile file, string path);
        void RemoveFile(IFormFile file, string path, string fileName);
        void RemoveFile(string path, string fileName);
    }
}
