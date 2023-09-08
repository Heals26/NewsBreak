namespace NewsBreak.Infrastructure.HttpClients
{

    public class LifxHttpClient
    {

        #region Fields



        #endregion Fields

        #region Constructors

        public LifxHttpClient() { }

        public LifxHttpClient(HttpClient httpClient)
        {
            this.HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        #endregion Constructors

        #region Properties

        public HttpClient HttpClient { get; set; }

        #endregion Properties

        #region Methods

        public virtual async Task<HttpResponseMessage>

        #endregion Methods

    }

}
