using CodeBrew.Common.Http.Interface;

namespace CodeBrew.Common.Http
{
    public sealed class HttpProvider : IHttpProvider
    {
        #region Private Fields

        private readonly HttpClient _httpClient;

        #endregion Private Fields

        #region Public Constructors

        public HttpProvider(IHttpClientFactory httpClientFactory, string name)
        {
            if (httpClientFactory is null)
                throw new ArgumentNullException(nameof(httpClientFactory));
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            _httpClient = httpClientFactory.CreateClient(name);
        }

        public HttpProvider(IHttpClientFactory httpClientFactory)
        {
            if (httpClientFactory is null)
                throw new ArgumentNullException(nameof(httpClientFactory));
            _httpClient = httpClientFactory.CreateClient();
        }

        public HttpProvider(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        #endregion Public Constructors

        #region Public Methods

        public Task<TResponse> Get<TResponse>(string request) where TResponse : class
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}