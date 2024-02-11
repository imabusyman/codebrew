using CodeBrew.Maps.Google.Common;
using CodeBrew.Maps.Google.Interface;

namespace CodeBrew.Maps.Google.GeoCode
{
    public class GeoCodeBuilder : GoogleApiBuilder, IGeoCodeBuilder
    {
        #region Public Constructors

        public GeoCodeBuilder() : base()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public IGeoCodeBuilder WithAddress(string address)
        {
            throw new NotImplementedException();
        }

        public IGoogleApiBuilder WithApiKey(string apiKey)
        {
            throw new NotImplementedException();
        }

        public IGoogleApiBuilder WithOutputFormat(OutputFormat output)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}