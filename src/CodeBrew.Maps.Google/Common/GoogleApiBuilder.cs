// Ignore Spelling: Api

using CodeBrew.Maps.Google.Interface;

namespace CodeBrew.Maps.Google.Common
{
    public abstract class GoogleApiBuilder<TRequest> : IGoogleApiBuilder<TRequest> where TRequest : GoogleApiRequest, new()
    {
        #region Private Fields

        private string _apiKey = string.Empty;

        private OutputFormat _outputFormat;

        #endregion Private Fields

        #region Protected Constructors

        protected GoogleApiBuilder()
        {
            _outputFormat = new JsonFormat();
        }

        #endregion Protected Constructors

        #region Public Methods

        public abstract TRequest CreateRequest();

        public Uri? CreateUrl()
        {
            var request = CreateRequest();
            if (request is null)
            {
                return null;
            }
            return new Uri(request.ToString());
        }

        public IGoogleApiBuilder WithApiKey(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            return this;
        }

        public IGoogleApiBuilder WithOutputFormat(OutputFormat outputFormat)
        {
            _outputFormat = outputFormat ?? throw new ArgumentNullException(nameof(outputFormat));
            return this;
        }

        #endregion Public Methods
    }
}