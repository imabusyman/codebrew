using CodeBrew.Maps.Google.GeoCode;
using CodeBrew.Maps.Google.Models;

namespace CodeBrew.Maps.Google.Interface
{
    public interface IGeoCodeAddressBuilder : IGoogleApiBuilder<GeoCodeAddressRequest>
    {
        #region Public Methods

        IGeoCodeAddressBuilder WithAddress(GoogleAddress address);

        #endregion Public Methods
    }
}