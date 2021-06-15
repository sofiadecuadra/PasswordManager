using System;
using System.Text;
using System.Security.Cryptography;

namespace DataManagerDomain
{
    public class Encrypter
    {
        public static Tuple<string, string> GenerateKeys()
        {
            IEncryptionParameters cryptoServiceProvider = Provider();
            var privateKey = cryptoServiceProvider.ExportRSAParameters(true);
            var publicKey = cryptoServiceProvider.ExportRSAParameters(false);
            return new Tuple<string, string>(GetKeyString(privateKey), GetKeyString(publicKey));
        }

        private static RSAEncrypter Provider()
        {
            return new RSAEncrypter();
        }

        public static string GetKeyString(RSAParameters publicKey)
        {
            var stringWriter = new System.IO.StringWriter();
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(stringWriter, publicKey);
            return stringWriter.ToString();
        }

        public static string Encrypt(string textToEncrypt, string publicKey)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);
            using (var rsa = Provider())
            {
                try
                {
                    rsa.FromXMLString(publicKey.ToString());
                    var encryptedData = rsa.Encrypt(bytesToEncrypt, true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp(false);
                }
            }
        }

        public static string Decrypt(string textToDecrypt, string privateKey)
        {
            using (var rsa = Provider())
            {
                try
                {
                    // server decrypting data with private key                    
                    rsa.FromXMLString(privateKey);

                    var resultBytes = Convert.FromBase64String(textToDecrypt);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp(false);
                }
            }
        }
    }
}
