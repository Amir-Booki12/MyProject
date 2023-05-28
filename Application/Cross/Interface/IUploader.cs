using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Cross.Interface
{
    public interface IUploader
    {
        Task<string> UploadGeneralsFile(IFormFile file, string userId = null);
        Task<string> UploadUserPrimaryInfoDocumnetsFile(IFormFile file, string userId = null);
        Task<string> UploadFile(IFormFile file, string path, string exteraPath, string userId = null);
        Task<string> UploadProductionProductFile(IFormFile file);
    }
}