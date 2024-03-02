namespace CodeBrew.Maps.Google.Common
{
    public abstract class OutputFormat(string format)
    {
        #region Public Properties

        public string Format { get; } = format ?? throw new ArgumentNullException(nameof(format));

        public override string ToString()
        {
            return Format;
        }

        #endregion Public Properties
    }
}