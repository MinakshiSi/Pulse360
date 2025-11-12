using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace CreditService.Infrastructure.Storage
{
    using Microsoft.Extensions.Configuration;

    public class BlobStorageProvider
    {
        private readonly BlobContainerClient _container;

        public BlobStorageProvider(IConfiguration config)
        {
            var client = new BlobServiceClient(config["BlobStorage:ConnectionString"]);
            _container = client.GetBlobContainerClient(config["BlobStorage:ContainerName"]);
        }

        public async Task UploadAsync(string blobName, Stream content)
        {
            await _container.UploadBlobAsync(blobName, content);
        }
    }

}
