namespace CodeBrew.Maps.Google.GeoCode
{
    public abstract class OutputFormat
    {
        #region Protected Constructors

        protected OutputFormat(string format)
        {
            Format = format ?? throw new ArgumentNullException(nameof(format));
        }

        #endregion Protected Constructors

        #region Public Properties

        public string Format { get; }

        #endregion Public Properties
    }
}