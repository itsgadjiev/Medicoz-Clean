using Microsoft.AspNetCore.Http;

namespace Medicoz.Application.Common.Validations
{
    public class IsValidImage
    {
        public static async Task<bool> Handle(IFormFile file)
        {
            if (file != null)
            {
                if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
                {
                    return false;
                }
                if (file.Length > 4097152)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
