// Ignore Spelling: Validator

namespace CodeBrew.Common.Models.Interface;

public interface IAddressValidator<in TAddress> : ICommonValidator<TAddress> where TAddress : Address, new();