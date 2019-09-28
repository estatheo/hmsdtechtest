using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using hmsd.encryption.Models;
using hmsd.gateway.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace hmsd.gateway.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        private string _encryptionKey; 

        public EncryptionService(IConfiguration _configuration)
        {
            httpClient = new HttpClient();
            configuration = _configuration;
        }
        public async Task<DecryptMessageModel> EncryptAsync(EncryptMessageModel message)
        {
            var httpResponse =  await httpClient.PostAsync($"{configuration["encryptionUrl"]}/api/encrypt",
                new StringContent(JsonConvert.SerializeObject(message)));

            var response = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DecryptMessageModel>(response);
        }

        public async Task<EncryptMessageModel> DecryptAsync(DecryptMessageModel message)
        {
            var httpResponse = await httpClient.PostAsync($"{configuration["encryptionUrl"]}/api/decrypt",
                new StringContent(JsonConvert.SerializeObject(message)));

            var response = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EncryptMessageModel>(response);
        }

        public async Task UpdateKeyAsync()
        {
            await httpClient.PutAsync($"{configuration["encryptionUrl"]}/api/key", null);
        }
    }
}
