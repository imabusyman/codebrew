using CodeBrew.Maps.Google.Interface;

namespace CodeBrew.Maps.Google
{
    public abstract class GoogleProvider : IGoogleProvider
    {
        #region Protected Constructors

        protected GoogleProvider(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        #endregion Protected Constructors

        #region Protected Properties

        protected HttpClient HttpClient { get; }

        #endregion Protected Properties
    }
}