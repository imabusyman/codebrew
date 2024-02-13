// Ignore Spelling: Api

namespace CodeBrew.Maps.Google.Common
{
    public interface IGoogleApiRequest
    {
        #region Public Properties

        string? ApiKey { get; }
        OutputFormat? OutputFormat { get; }

        #endregion Public Properties

        #region Public Methods

        string ToMd5();

        #endregion Public Methods
    }
}