// Ignore Spelling: Validator

using CodeBrew.Maps.Google.Common.Validators;
using CodeBrew.Maps.Google.GeoCode;
using CodeBrew.Maps.Google.Interface;

namespace CodeBrew.Maps.Google.Validators;

public class GoogleAddressRequestValidator : GoogleApiRequestValidator<GeoCodeAddressRequest>
{
    #region Protected Constructors

    protected GoogleAddressRequestValidator()
    {
    }

    #endregion Protected Constructors
}

public interface IGoogleAddressRequestValidator : IGoogleApiRequestValidator<GeoCodeAddressRequest>
{
}