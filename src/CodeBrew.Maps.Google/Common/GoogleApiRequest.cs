using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBrew.Maps.Google.Common
{
    public abstract class GoogleApiRequest : IGoogleApiRequest
    {
        protected GoogleApiRequest(string apiKey, OutputFormat outputFormat)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException($"'{nameof(apiKey)}' cannot be null or empty.", nameof(apiKey));
            ApiKey = apiKey;
            OutputFormat = outputFormat ?? throw new ArgumentNullException(nameof(outputFormat));
        }
        public string ApiKey { get; }
        public OutputFormat OutputFormat { get; }

        protected abstract string ToStringInner();

        public override string ToString()
        {
            return ToStringInner();
        }
        public string ToMd5() => ToString().ToMD5();
    }
}
