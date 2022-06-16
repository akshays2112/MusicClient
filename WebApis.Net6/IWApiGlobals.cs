namespace WebApis.Net6
{
    public interface IWApiGlobals
    {
        Task<T?> CallWebApiEndpoint<T>(WebApiEndpoint<T> webApiEndPoint, string? accessToken = null);
    }
}