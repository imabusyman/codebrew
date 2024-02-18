// Ignore Spelling: Validator

using CodeBrew.Common.Models.Interface;
using FluentValidation;

namespace CodeBrew.Common.Models.Validators;

public abstract class AddressValidator<TAddress> : AbstractValidator<TAddress>, IAddressValidator<TAddress> where TAddress : Address, new()
{
    #region Protected Constructors

    protected AddressValidator()
    {
        RuleFor(a => a.Street)
            .NotNull()
            .WithMessage("Address is required")
            .NotEmpty()
            .WithMessage("Address can't be empty");
        RuleFor(a => a.City)
            .NotNull()
            .WithMessage("City is required")
            .NotEmpty()
            .WithMessage("City can't be empty");
        RuleFor(a => a.State)
            .NotNull()
            .WithMessage("State is required");
        RuleFor(a => a.State.Name)
            .NotNull()
            .WithMessage("State Name is required")
            .NotEmpty()
            .WithMessage("State Name can't be empty");
        RuleFor(a => a.State.Abbreviation)
            .NotNull()
            .WithMessage("State Abbreviation is required")
            .IsInEnum()
            .WithMessage("Invalid State Abbreviation");
    }

    #endregion Protected Constructors
}