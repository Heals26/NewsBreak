namespace NewsBreak.Domain.Entities
{

    public class ClientApplication
    {

        #region Constructors

        public ClientApplication()
        {
            this.ClientApplicationScopes = new HashSet<ClientApplicationScope>();
        }

        #endregion Constructors

        #region Properties

        public long ClientApplicationID { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }

        public ICollection<ClientApplicationScope> ClientApplicationScopes { get; set; }

        #endregion Properties

    }

}
