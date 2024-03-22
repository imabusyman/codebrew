using System.Web;
using CodeBrew.Common.Models.Interface;
using CodeBrew.Maps.Google.Common;
using CodeBrew.Maps.Google.Models;

namespace CodeBrew.Maps.Google.GeoCode
{
    public class GeoCodeAddressRequest : GoogleApiRequest
    {
        #region Private Fields

        private const string DEFAULT_GOOGLE_API_URL = "https://maps.googleapis.com/maps/api/geocode";

        #endregion Private Fields

        #region Public Constructors

        public GeoCodeAddressRequest()
        {
            
        }

        public GeoCodeAddressRequest(GoogleAddress googleAddress)
        {
            GoogleAddress = googleAddress ?? throw new ArgumentNullException(nameof(googleAddress));
        }

        #endregion Public Constructors

        #region Public Properties

        public IBaseAddress? GoogleAddress { get; set; }

        #endregion Public Properties

        #region Protected Methods

        protected override string GetDefaultUrl()
        {
            return DEFAULT_GOOGLE_API_URL;
        }

        protected override string FormattedUrlInner()
        {
            if (!string.IsNullOrEmpty(GoogleAddress?.FormattedAddress))
            {
                var encodeUrlString = HttpUtility.UrlPathEncode(GoogleAddress.FormattedAddress);
                return $"address={encodeUrlString}";
            }
            return string.Empty;
        }

        #endregion Protected Methods
    }
}