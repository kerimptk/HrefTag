namespace BaseCore.Utilities.Hashing
{
    public interface IEncryption
    {
        public void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
