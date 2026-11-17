
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

class Program
{
    static async Task Main()
    {
        string tenantId = "registredapplicationtenantid";
        string clientId = "registredapplicationclientid";
        string clientSecret = "yourclientsecret";
        string storageAccountName = "storageaccountname";
        string containerName = "storageaccountcontainername";



        // Application Object credentials
        var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

        // Connect to Azure Blob Storage
        var blobServiceClient = new BlobServiceClient(
            new Uri($"https://{storageAccountName}.blob.core.windows.net"),
            credential);

        // Get container
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);




        Console.WriteLine("Listing blobs...\n");

        // List blobs
        await foreach (BlobItem blob in containerClient.GetBlobsAsync())
        {
            Console.WriteLine($"Blob Name: {blob.Name}");
            Console.WriteLine($"Size: {blob.Properties.ContentLength} bytes");
            Console.WriteLine("----------------------------------");
        }

        Console.WriteLine("\nCompleted.");
    }
}
