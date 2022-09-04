namespace WebApis.Net7
{
    public interface IWApiGlobals
    {
        Task<T?> CallWebApiEndpoint<T>(WebApiEndpoint<T> webApiEndPoint, string? accessToken = null);
    }
}