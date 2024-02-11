using CodeBrew.Maps.Google.GeoCode;

namespace CodeBrew.Maps.Google.Interface
{
    public interface IGoogleApiBuilder : Igoo
    {
        #region Public Methods

        IGoogleApiBuilder WithApiKey(string apiKey);

        IGoogleApiBuilder WithOutputFormat(OutputFormat output);

        #endregion Public Methods
    }
}