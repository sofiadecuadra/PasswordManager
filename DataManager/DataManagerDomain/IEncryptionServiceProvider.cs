using System;


namespace DataManagerDomain
{
    public interface IEncryptionServiceProvider
    {
        byte[] Encrypt(byte[] bytesToEncrypt, bool useOAEPPadding);
        byte[] Decrypt(byte[] bytesToDecrypt, bool useOAEPPadding);
        void FromXMLString(string xmlString);
        bool PersistKeyInCsp(bool persist);
    }
}
