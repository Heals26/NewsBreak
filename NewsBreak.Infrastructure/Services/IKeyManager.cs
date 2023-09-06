namespace NewsBreak.Infrastructure.Services
{

    public interface IKeyManager
    {

        #region Methods

        string GetSecret(string secret);

        #endregion Methods

    }

}
