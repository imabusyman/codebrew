using CodeBrew.Maps.Google.Common;

namespace CodeBrew.Maps.Google.Models;

public class GoogleOptions
{
    #region Public Constructors

    public GoogleOptions()
    {
    }

    public GoogleOptions(string apiKey)
    {
        ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
    }

    public GoogleOptions(OutputFormat outputFormat)
    {
        OutputFormat = outputFormat ?? throw new ArgumentNullException(nameof(outputFormat));
    }

    public GoogleOptions(Uri baseUri)
    {
        BaseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));
    }

    public GoogleOptions(string apiKey, OutputFormat outputFormat, Uri baseUri)
    {
        ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        OutputFormat = outputFormat ?? throw new ArgumentNullException(nameof(outputFormat));
        BaseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));
    }

    #endregion Public Constructors

    #region Public Properties

    public string? ApiKey { get; set; }
    public OutputFormat? OutputFormat { get; set; }

    public Uri? BaseUri { get; set; }

    #endregion Public Properties
}