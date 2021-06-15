using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerDomain
{
    public class RSAEncrypter : IEncryptionServiceProvider, IEncryptionParameters, IDisposable
    {
        private const int KEY_SIZE = 2048;

        public RSACryptoServiceProvider Provider { get; private set; }

        public RSAEncrypter()
        {
            Provider = new RSACryptoServiceProvider(KEY_SIZE);
        }

        public byte[] Decrypt(byte[] bytesToDecrypt, bool useOAEPPadding)
        {
            return Provider.Decrypt(bytesToDecrypt, useOAEPPadding);
        }

        public byte[] Encrypt(byte[] bytesToEncrypt, bool useOAEPPadding)
        {
            return Provider.Encrypt(bytesToEncrypt, useOAEPPadding);
        }

        public RSAParameters ExportRSAParameters(bool includePrivateParameters)
        {
            return Provider.ExportParameters(includePrivateParameters);
        }

        public void FromXMLString(string xmlString)
        {
            Provider.FromXmlString(xmlString);
        }

        public bool PersistKeyInCsp(bool persist)
        {
            return Provider.PersistKeyInCsp = persist;
        }

        public void Dispose()
        {
            Provider.Dispose();
        }
    }
}
