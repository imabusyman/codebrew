using CodeBrew.Maps.Google.GeoCode;

namespace CodeBrew.Maps.Google.Interface
{
    public interface IGeoCodeBuilder : IGoogleApiBuilder<GeoCodeRequest>
    {
        #region Public Methods

        IGeoCodeBuilder WithAddress(string address);


        #endregion Public Methods
    }
}