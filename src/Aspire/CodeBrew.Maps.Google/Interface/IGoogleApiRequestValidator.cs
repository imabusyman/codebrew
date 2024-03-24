// Ignore Spelling: Validator Api

using CodeBrew.Common.Models.Interface;
using CodeBrew.Maps.Google.Common;

namespace CodeBrew.Maps.Google.Interface;

public interface IGoogleApiRequestValidator<in TRequest> : ICommonValidator<TRequest>
    where TRequest : class, IGoogleApiRequest;