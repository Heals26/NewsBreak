using Microsoft.AspNet.Identity;

namespace NewsBreak.Persistence.Models
{

    public class Password
    {

        private string m_Password;

        public Password(string password)
        {
            var _PasswordHasher = new PasswordHasher();
            this.m_Password = _PasswordHasher.HashPassword($"{password}freedom");
        }

        internal string GetPasswordHash()
            => this.m_Password;

        public void RehashKey(string key)
        {
            var _PasswordHasher = new PasswordHasher();
            if (this.VerifyHash(key) != PasswordVerificationResult.Failed)
                this.m_Password = _PasswordHasher.HashPassword(key);
        }

        public PasswordVerificationResult VerifyHash(string key)
        {
            var _PasswordHasher = new PasswordHasher();
            return _PasswordHasher.VerifyHashedPassword(this.m_Password, key);
        }

    }

}
