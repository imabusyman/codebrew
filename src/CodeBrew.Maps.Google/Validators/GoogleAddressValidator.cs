using CodeBrew.Common.Models.Validators;
using CodeBrew.Maps.Google.Interface;
using CodeBrew.Maps.Google.Models;

namespace CodeBrew.Maps.Google.Validators;

public class GoogleAddressValidator : AddressValidator<GoogleAddress>, IGoogleAddressValidator;