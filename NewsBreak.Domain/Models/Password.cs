using Microsoft.AspNet.Identity;

namespace NewsBreak.Persistence.Models
{

    public class Password
    {

        #region Fields

        private string m_Password;

        #endregion Fields

        #region Constructors
        
        public Password(string password)
        {
            var _PasswordHasher = new PasswordHasher();
            this.m_Password = _PasswordHasher.HashPassword($"{password}freedom");
        }

        #endregion Constructors

        #region Methods

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

        #endregion Methods

    }

}
