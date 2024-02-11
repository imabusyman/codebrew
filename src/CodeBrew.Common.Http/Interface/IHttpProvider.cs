namespace CodeBrew.Common.Http.Interface
{
    public interface IHttpProvider
    {
        #region Public Methods

        Task<TResponse> Get<TResponse>(string request) where TResponse : class;

        #endregion Public Methods
    }
}