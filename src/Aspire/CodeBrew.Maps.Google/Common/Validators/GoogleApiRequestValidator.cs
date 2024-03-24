// Ignore Spelling: Validator Api

using CodeBrew.Maps.Google.Interface;
using FluentValidation;

namespace CodeBrew.Maps.Google.Common.Validators;

public abstract class GoogleApiRequestValidator<TRequest> : AbstractValidator<TRequest>, IGoogleApiRequestValidator<TRequest>
    where TRequest : class, IGoogleApiRequest
{
    #region Public Methods

    public virtual void CreateRule()
    {
        RuleFor(a => a.ApiKey)
            .NotNull()
            .WithMessage("Api Key is required")
            .NotEmpty()
            .WithMessage("Api Key can't be empty");
        RuleFor(a => a.BaseUrl)
            .NotNull()
            .WithMessage("BaseUrl is required")
            .NotEmpty()
            .WithMessage("BaseUrl can't be empty");
        RuleFor(a => a.OutputFormat)
            .NotNull()
            .WithMessage("Output Format is required");
        RuleFor(a => a.OutputFormat!.Format)
            .NotNull()
            .WithMessage("Output Format is required");
    }

    #endregion Public Methods
}