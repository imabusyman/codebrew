namespace CodeBrew.Common.Extensions
{
    public static class StringExtensions
    {
        #region Public Methods

        public static string ToMd5(this string input)
        {
            // Use input string to calculate MD5 hash
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes); // .NET 5 +
        }

        #endregion Public Methods
    }
}