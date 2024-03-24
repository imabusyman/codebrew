// Ignore Spelling: Validator

using FluentValidation;

namespace CodeBrew.Common.Models.Interface;

public interface ICommonValidator<in T> : IValidator<T>
{
    #region Public Methods

    void CreateRule();

    #endregion Public Methods
}