using CodeBrew.Maps.Google.Common;
using CodeBrew.Maps.Google.Interface;
using CodeBrew.Maps.Google.Models;

namespace CodeBrew.Maps.Google.GeoCode
{
    public class GeoCodeAddressBuilder : GoogleApiBuilder<GeoCodeAddressRequest>, IGeoCodeBuilder
    {
        #region Protected Properties

        protected GoogleAddress? GoogleAddress { get; private set; }

        #endregion Protected Properties

        #region Public Methods

        public override GeoCodeAddressRequest CreateRequest()
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

        public IGeoCodeBuilder WithAddress(GoogleAddress googleAddress)
        {
            GoogleAddress = googleAddress ?? throw new ArgumentException(nameof(googleAddress));
            return this;
        }

        #endregion Public Methods
    }
}