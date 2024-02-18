// Ignore Spelling: Api

using CodeBrew.Common.Extensions;

namespace CodeBrew.Maps.Google.Common
{
    public abstract class GoogleApiRequest : IGoogleApiRequest
    {
        #region Private Fields

        private Uri? _baseUrl;

        #endregion Private Fields

        #region Public Properties

        public string? ApiKey { get; set; }

        public Uri? BaseUrl
        {
            get
            {
                if (_baseUrl == null)
                {
                    _baseUrl = new Uri(GetDefaultUrl());
                }

                return _baseUrl;
            }
            set => _baseUrl = value;
        }

        public OutputFormat? OutputFormat { get; set; }

        #endregion Public Properties

        #region Public Methods

        public string ToMd5()
        {
            return ToString().ToMd5();
        }

        public override string ToString()
        {
            if (BaseUrl == null)
            {
                return string.Empty;
            }
            var uriBuilder = new UriBuilder(BaseUrl);
            if (OutputFormat != null)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                uriBuilder.Path = $"{uriBuilder.Path.TrimEnd('/')}/{OutputFormat?.ToString().ToLowerInvariant() ?? string.Empty}";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            return $"{uriBuilder.Uri}?{ToStringInner()}&key={ApiKey}";
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract string GetDefaultUrl();

        protected abstract string ToStringInner();

        #endregion Protected Methods
    }
}