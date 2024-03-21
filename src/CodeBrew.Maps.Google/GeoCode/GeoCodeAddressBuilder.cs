using CodeBrew.Common.Models.Interface;
using CodeBrew.Maps.Google.Common;
using CodeBrew.Maps.Google.Interface;
using CodeBrew.Maps.Google.Validators;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace CodeBrew.Maps.Google.GeoCode
{
    public class GeoCodeAddressBuilder(ILogger<GeoCodeAddressBuilder> logger)
        : GoogleApiBuilder<GeoCodeAddressRequest>(logger), IGeoCodeAddressBuilder
    {
        #region Protected Properties

        protected IBaseAddress? GoogleAddress { get; private set; }

        #endregion Protected Properties

        #region Public Methods

        protected override GeoCodeAddressRequest CreateRequestInner()
        {
            if (GoogleAddress is null)
                throw new ArgumentNullException(nameof(GoogleAddress));
            var request = new GeoCodeAddressRequest
            {
                GoogleAddress = GoogleAddress,
                ApiKey = ApiKey,
                OutputFormat = OutputFormat
            };
            var googleAddressRequestValidator = new GoogleAddressRequestValidator();
            googleAddressRequestValidator.ValidateAndThrow(request);
            return request;
        }

        public IGeoCodeAddressBuilder WithAddress(IBaseAddress googleAddress)
        {
            GoogleAddress = googleAddress ?? throw new ArgumentNullException(nameof(googleAddress));
            return this;
        }

        #endregion Public Methods
    }
}