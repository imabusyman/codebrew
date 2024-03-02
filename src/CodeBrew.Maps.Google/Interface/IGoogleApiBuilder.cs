// Ignore Spelling: Api

using CodeBrew.Maps.Google.Common;
using CodeBrew.Maps.Google.Models;
using FluentValidation;

namespace CodeBrew.Maps.Google.Interface
{
    public interface IGoogleApiBuilder<out TRequest> : IGoogleApiBuilder where TRequest : class, IGoogleApiRequest
    {
        #region Public Methods

        public TRequest? CreateRequest();
        void WithValidation(IValidator<TRequest> validator);

        #endregion Public Methods
    }

    public interface IGoogleApiBuilder
    {
        #region Public Methods

        Uri? CreateUri();

        string? CreateUrl();

        IGoogleApiBuilder WithApiKey(string apiKey);

        IGoogleApiBuilder WithOptions(GoogleOptions? googleOptions);

        IGoogleApiBuilder WithOutputFormat(OutputFormat? output);

        #endregion Public Methods
    }
}