// Ignore Spelling: Api validator

using CodeBrew.Maps.Google.Interface;
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
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        protected abstract TRequest CreateRequestInner();

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
    }

    public abstract class GoogleApiBuilder(ILogger logger) : IGoogleApiBuilder
    {
        #region Protected Properties

        protected string? ApiKey { get; private set; }
        protected ILogger Logger { get; } = logger ?? throw new ArgumentNullException(nameof(logger));
        protected OutputFormat? OutputFormat { get; private set; } = new JsonFormat();

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