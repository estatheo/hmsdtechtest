using System.Threading.Tasks;
using hmsd.encryption.Models;

namespace hmsd.gateway.Interfaces
{
    public interface IEncryptionService
    {
        Task<DecryptMessageModel> EncryptAsync(EncryptMessageModel message);

        Task<EncryptMessageModel> DecryptAsync(DecryptMessageModel message);

        Task UpdateKeyAsync();
    }
}
