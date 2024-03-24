// Ignore Spelling: Api validator

using CodeBrew.Maps.Google.Interface;
using CodeBrew.Maps.Google.Models;
using FluentValidation;

namespace CodeBrew.Maps.Google.Common
{
    public abstract class GoogleApiBuilder<TRequest>
        : GoogleApiBuilder, IGoogleApiBuilder<TRequest>
        where TRequest : class, IGoogleApiRequest
    {
        #region Protected Properties

        protected IValidator<TRequest>? Validator { get; set; }

        #endregion Protected Properties

        #region Public Methods

        public virtual TRequest CreateRequest()
        {
            var request = CreateRequestInner();
            if (Validator == null)
                return request;
            Validator.ValidateAndThrow(request);
            return request;
        }

        public override Uri? CreateUri()
        {
            var request = CreateRequest();
            var url = request.ToString() ?? string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                return new Uri(url);
            }
            return null;
        }

        public override string? CreateUrl()
        {
            var request = CreateRequest();
            return request.ToString();
        }

        public void WithValidation(IValidator<TRequest> validator)
        {
            Validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract TRequest CreateRequestInner();

        #endregion Protected Methods
    }

    public abstract class GoogleApiBuilder : IGoogleApiBuilder
    {
        #region Protected Properties

        protected GoogleOptions? Options { get; private set; } = new();

        #endregion Protected Properties

        #region Public Methods

        public abstract Uri? CreateUri();

        public abstract string? CreateUrl();

        public IGoogleApiBuilder WithApiKey(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                return this;
            if (Options != null)
                Options.ApiKey = apiKey;
            return this;
        }

        public IGoogleApiBuilder WithBaseUrl(string url)
        {
            return WithBaseUrl(new Uri(url));
        }

        public IGoogleApiBuilder WithBaseUrl(Uri? uri)
        {
            if (uri is null)
                return this;
            if (Options != null)
                Options.BaseUri = uri;
            return this;
        }

        public IGoogleApiBuilder WithOptions(GoogleOptions? googleOptions)
        {
            if (googleOptions is null) return this;
            Options = googleOptions;
            return this;
        }

        public IGoogleApiBuilder WithOutputFormat(OutputFormat? outputFormat)
        {
            if (outputFormat != null)
            {
                if (Options != null)
                    Options.OutputFormat = outputFormat;
            }
            return this;
        }

        #endregion Public Methods
    }
}