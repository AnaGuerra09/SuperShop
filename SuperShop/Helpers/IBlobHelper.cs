using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SuperShop.Helpers
{
    public interface IBlobHelper
    {
        Task<Guid> UploadBlobAsync(IFormFile file, string conteinerName);

        Task<Guid> UploadBlobAsync(byte[] file, string conteinerName);

        Task<Guid> UploadBlobAsync(string image, string conteinerName);

    }
}
