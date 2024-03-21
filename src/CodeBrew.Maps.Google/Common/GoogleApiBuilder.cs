// Ignore Spelling: Api validator

using CodeBrew.Maps.Google.Interface;
using CodeBrew.Maps.Google.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace CodeBrew.Maps.Google.Common
{
    public abstract class GoogleApiBuilder<TRequest>(ILogger logger)
        : GoogleApiBuilder(logger), IGoogleApiBuilder<TRequest>
        where TRequest : class, IGoogleApiRequest
    {
        #region Protected Properties

        protected IValidator<TRequest>? Validator { get; private set; }

        #endregion Protected Properties

        #region Public Methods

        public virtual TRequest CreateRequest()
        {
            try
            {
                var request = CreateRequestInner();
                if (Validator == null)
                    return request;
                Validator.ValidateAndThrow(request);
                return request;
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, ex.Message);
                throw;
            }
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

    public abstract class GoogleApiBuilder(ILogger logger) : IGoogleApiBuilder
    {
        #region Protected Properties

        protected ILogger? Logger { get; } = logger ?? throw new ArgumentNullException(nameof(logger));
        protected GoogleOptions? Options { get; private set; } = new();

        #endregion Protected Properties

        #region Public Methods

        public abstract Uri? CreateUri();

        public abstract string? CreateUrl();

        public IGoogleApiBuilder WithApiKey(string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                if (Options != null) Options.ApiKey = apiKey;
            }
            return this;
        }

        public IGoogleApiBuilder WithOptions(GoogleOptions? googleOptions)
        {
            if (googleOptions != null)
            {
                Options = googleOptions;
            }

            return this;
        }

        public IGoogleApiBuilder WithOutputFormat(OutputFormat? outputFormat)
        {
            if (outputFormat != null)
            {
                if (Options != null) Options.OutputFormat = outputFormat;
            }
            return this;
        }

        #endregion Public Methods
    }
}