using CodeBrew.Maps.Google.GeoCode;
using CodeBrew.Maps.Google.Models;

namespace CodeBrew.Maps.Google.Interface
{
    public interface IGeoCodeBuilder : IGoogleApiBuilder<GeoCodeAddressRequest>
    {
        #region Public Methods

        IGeoCodeBuilder WithAddress(GoogleAddress address);


        #endregion Public Methods
    }
}