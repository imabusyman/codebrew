// Ignore Spelling: Validator

using CodeBrew.Maps.Google.Common.Validators;
using CodeBrew.Maps.Google.GeoCode;
using CodeBrew.Maps.Google.Interface;

namespace CodeBrew.Maps.Google.Validators;

public class GoogleAddressRequestValidator : GoogleApiRequestValidator<GeoCodeAddressRequest> , IGoogleAddressRequestValidator
{
    #region Protected Constructors

    public GoogleAddressRequestValidator()
    {
    }

    #endregion Protected Constructors
}