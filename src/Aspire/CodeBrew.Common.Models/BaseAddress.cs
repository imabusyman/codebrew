using CodeBrew.Common.Models.Interface;

namespace CodeBrew.Common.Models;

public abstract class BaseAddress : IBaseAddress
{
    protected BaseAddress()
    {

    }
    protected BaseAddress(string formattedAddress)
    {
        FormattedAddress = formattedAddress;
    }

    public virtual string? FormattedAddress { get; }
}