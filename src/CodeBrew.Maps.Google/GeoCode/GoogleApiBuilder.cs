using CodeBrew.Maps.Google.Interface;

namespace CodeBrew.Maps.Google.GeoCode
{
    public abstract class GoogleApiBuilder : IGoogleApiBuilder
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