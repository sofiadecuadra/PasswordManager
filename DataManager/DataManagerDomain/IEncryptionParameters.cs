using System;
using System.Security.Cryptography;

namespace DataManagerDomain
{
    public interface IEncryptionParameters
    {
        RSAParameters ExportRSAParameters(bool includePrivateParameters);
    }
}
