using CodeBrew.Common.Models.Interface;
using CodeBrew.Maps.Google.Common;
using CodeBrew.Maps.Google.Interface;
using CodeBrew.Maps.Google.Validators;
using FluentValidation;

namespace CodeBrew.Maps.Google.GeoCode
{
    public class GeoCodeAddressBuilder
        : GoogleApiBuilder<GeoCodeAddressRequest>, IGeoCodeAddressBuilder
    {
        public GeoCodeAddressBuilder()
        {
            Validator = new GoogleAddressRequestValidator();
        }
        #region Protected Properties

        protected IBaseAddress? GoogleAddress { get; private set; }

        #endregion Protected Properties

        #region Public Methods

        protected override GeoCodeAddressRequest CreateRequestInner()
        {
            if (Options is null)
            {
                throw new ArgumentNullException(nameof(Options));
            }

            if (GoogleAddress is null)
            {
                throw new ArgumentNullException(nameof(GoogleAddress));
            }

            var request = new GeoCodeAddressRequest { GoogleAddress = GoogleAddress, OutputFormat = Options.OutputFormat, ApiKey = Options.ApiKey};
                    
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