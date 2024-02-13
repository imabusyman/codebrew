// Ignore Spelling: Api

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBrew.Common.Extensions;
using static System.Net.WebRequestMethods;

namespace CodeBrew.Maps.Google.Common
{
    public abstract class GoogleApiRequest : IGoogleApiRequest
    {
        #region Protected Constructors

        protected GoogleApiRequest()
        {
            BaseUrl = new Uri(GetDefaultUrl());
        }

        #endregion Protected Constructors

        #region Public Properties

        public string? ApiKey { get; set; }

        public Uri? BaseUrl { get; set; }

        public OutputFormat? OutputFormat { get; set; }

        #endregion Public Properties

        #region Public Methods

        public string ToMd5() => ToString()?.ToMD5() ?? string.Empty;

        public override string ToString()
        {
            if (BaseUrl == null)
            {
                return string.Empty;
            }
            UriBuilder uriBuilder = new UriBuilder(BaseUrl);
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