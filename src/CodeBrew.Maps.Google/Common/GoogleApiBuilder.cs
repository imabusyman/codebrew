// Ignore Spelling: Api

using System.ComponentModel.DataAnnotations;
using CodeBrew.Maps.Google.Interface;

namespace CodeBrew.Maps.Google.Common
{
    public abstract class GoogleApiBuilder<TRequest> : GoogleApiBuilder, IGoogleApiBuilder<TRequest> where TRequest : class, IGoogleApiRequest
    {
        #region Private Fields

        #endregion Private Fields

        #region Protected Constructors

        protected GoogleApiBuilder() : base()
        {
        }

        #endregion Protected Constructors

        #region Public Methods

        public abstract TRequest CreateRequest();

        public override Uri? CreateUri()
        {
            TRequest? request = CreateRequest();
            if (request is null)
            {
                return null;
            }
            string url = request?.ToString() ?? string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                return new Uri(url);
            }
            return null;
        }

        public override string? CreateUrl()
        {
            TRequest? request = CreateRequest();
            if (request is null)
            {
                return null;
            }
            return request.ToString();
        }

        #endregion Public Methods
    }

    public abstract class GoogleApiBuilder : IGoogleApiBuilder
    {
        #region Protected Constructors

        protected GoogleApiBuilder()
        {
            OutputFormat = new JsonFormat();
        }

        #endregion Protected Constructors

        #region Protected Properties

        protected string? ApiKey { get; private set; }
        protected OutputFormat? OutputFormat { get; private set; }

        #endregion Protected Properties

        #region Public Methods

        public abstract Uri? CreateUri();

        public abstract string? CreateUrl();

        public IGoogleApiBuilder WithApiKey(string apiKey)
        {
            ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            return this;
        }

        public IGoogleApiBuilder WithOutputFormat(OutputFormat outputFormat)
        {
            OutputFormat = outputFormat ?? throw new ArgumentNullException(nameof(outputFormat));
            return this;
        }

        #endregion Public Methods
    }
}