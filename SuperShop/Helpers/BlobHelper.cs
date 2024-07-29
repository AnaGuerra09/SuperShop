using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SuperShop.Helpers
{
    public class BlobHelper : IBlobHelper
    {
        private readonly CloudBlobClient _blobCliente;
        public BlobHelper(IConfiguration configuration)
        {
            string keys = configuration["Blob:ConnectionString"];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(keys);
            _blobCliente = storageAccount.CreateCloudBlobClient();
        }

        public async Task<Guid> UploadBlobAsync(IFormFile file, string conteinerName)
        {
            Stream stream = file.OpenReadStream();
            return await UploadStreamAsync(stream, conteinerName);  
        }

        public async Task<Guid> UploadBlobAsync(byte[] file, string conteinerName)
        {
            MemoryStream stream = new MemoryStream(file);
            return await UploadStreamAsync(stream, conteinerName);
        }

        public async Task<Guid> UploadBlobAsync(string image, string conteinerName)
        {
            Stream stream = File.OpenRead(image);
            return await UploadStreamAsync(stream, conteinerName);
        }

        private async Task<Guid> UploadStreamAsync(Stream stream, string conteinerName)
        {
            Guid name = Guid.NewGuid();
            CloudBlobContainer container = _blobCliente.GetContainerReference(conteinerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference($"{name}");
            await blockBlob.UploadFromStreamAsync(stream);
            return name;
        }
    }
}
