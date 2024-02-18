using CodeBrew.Maps.Google.Common;
using CodeBrew.Maps.Google.Interface;
using CodeBrew.Maps.Google.Models;
using Microsoft.Extensions.Logging;

namespace CodeBrew.Maps.Google.GeoCode
{
    public class GeoCodeAddressBuilder(ILogger<GeoCodeAddressBuilder> logger)
        : GoogleApiBuilder<GeoCodeAddressRequest>(logger), IGeoCodeAddressBuilder
    {
        #region Protected Properties

        protected GoogleAddress? GoogleAddress { get; private set; }

        #endregion Protected Properties

        #region Public Methods

        public override GeoCodeAddressRequest CreateRequestInner()
        {
            if (GoogleAddress is null)
                throw new ArgumentException(nameof(GoogleAddress));
            var request = new GeoCodeAddressRequest
            {
                GoogleAddress = GoogleAddress,
                ApiKey = ApiKey,
                OutputFormat = OutputFormat
            };
            return request;
        }

        public IGeoCodeAddressBuilder WithAddress(GoogleAddress googleAddress)
        {
            GoogleAddress = googleAddress ?? throw new ArgumentException(nameof(googleAddress));
            return this;
        }

        #endregion Public Methods
    }
}