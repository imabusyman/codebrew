using CodeBrew.Common.Models.Interface;
using CodeBrew.Maps.Google.GeoCode;
using CodeBrew.Maps.Google.Models;

namespace CodeBrew.Maps.Google.Interface
{
    public interface IGeoCodeAddressBuilder : IGoogleApiBuilder<GeoCodeAddressRequest>
    {
        #region Public Methods

        IGeoCodeAddressBuilder WithAddress(IBaseAddress address);

        #endregion Public Methods
    }
}