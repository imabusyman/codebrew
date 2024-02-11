namespace CodeBrew.Maps.Google.Interface
{
    public interface IGeoCodeBuilder : IGoogleApiBuilder
    {
        #region Public Methods

        IGeoCodeBuilder WithAddress(string address);


        #endregion Public Methods
    }
}