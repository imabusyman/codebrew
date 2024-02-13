﻿// Ignore Spelling: Api

using CodeBrew.Maps.Google.Common;

namespace CodeBrew.Maps.Google.Interface
{
    public interface IGoogleApiBuilder<TRequest> : IGoogleApiBuilder where TRequest : class, IGoogleApiRequest
    {
        #region Public Methods

        public TRequest? CreateRequest();

        #endregion Public Methods
    }

    public interface IGoogleApiBuilder
    {
        #region Public Methods

        Uri? CreateUri();

        string? CreateUrl();

        IGoogleApiBuilder WithApiKey(string apiKey);

        IGoogleApiBuilder WithOutputFormat(OutputFormat output);

        #endregion Public Methods
    }
}