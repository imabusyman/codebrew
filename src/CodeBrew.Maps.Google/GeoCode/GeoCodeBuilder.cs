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

        #endregion Public Methods
    }
}