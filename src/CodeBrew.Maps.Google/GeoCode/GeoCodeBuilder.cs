using System.Net.Sockets;
using CodeBrew.Maps.Google.Common;
using CodeBrew.Maps.Google.Interface;

namespace CodeBrew.Maps.Google.GeoCode
{
    public class GeoCodeBuilder : GoogleApiBuilder<GeoCodeRequest>, IGeoCodeBuilder
    {
        #region Public Constructors

        public GeoCodeBuilder() : base()
        {
        }

        public override GeoCodeRequest CreateRequest()
        {
            GeoCodeRequest request = new GeoCodeRequest
            {
                Address = Address,
                ApiKey = ApiKey,
                OutputFormat = OutputFormat
            };
            return request;
        }

        #endregion Public Constructors

        #region Public Methods

        public IGeoCodeBuilder WithAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentException($"'{nameof(address)}' cannot be null or empty.", nameof(address));
            Address = address;
            return this;
        }
        protected string? Address { get; private set; }

        #endregion Public Methods
    }
}