using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmsd.encryption.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt(string text);

        string Decrypt(string text);

        void UpdateKey(string key);
    }
}
