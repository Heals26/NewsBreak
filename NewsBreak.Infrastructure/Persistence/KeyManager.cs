using Microsoft.Extensions.Configuration;
using NewsBreak.Infrastructure.Services;

namespace NewsBreak.Infrastructure.Persistence
{

    public class KeyManager : IKeyManager
    {

        #region Fields

        private readonly IConfiguration m_Configuration;

        #endregion Fields

        #region Constructors

        public KeyManager(IConfiguration configuration)
            => this.m_Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        #endregion Constructors

        #region Methods

        public string GetSecret(string secret)
            => this.m_Configuration[secret];

        #endregion Methods

    }

}
