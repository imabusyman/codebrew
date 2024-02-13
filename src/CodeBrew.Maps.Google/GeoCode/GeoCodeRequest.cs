using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CodeBrew.Maps.Google.Common;

namespace CodeBrew.Maps.Google.GeoCode
{
    public class GeoCodeRequest : GoogleApiRequest
    {
        #region Private Fields

        private const string DEFAULT_GOOGLE_API_URL = "https://maps.googleapis.com/maps/api/geocode";

        #endregion Private Fields

        #region Public Constructors

        public GeoCodeRequest() : base()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public string? Address { get; set; }

        #endregion Public Properties

        #region Protected Methods

        protected override string GetDefaultUrl()
        {
            return DEFAULT_GOOGLE_API_URL;
        }

        protected override string ToStringInner()
        {
            if (!string.IsNullOrEmpty(Address))
            {
                string encodeUrlString = HttpUtility.UrlPathEncode(Address);
                return $"address={encodeUrlString}";
            }
            return string.Empty;
        }

        #endregion Protected Methods
    }
}