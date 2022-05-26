using System.Net;
using System.Text;
using System.Text.Json;
using System.Reflection;
using SpotifyGlobals = WebApis.Net6.Spotify.Globals;
using System.Globalization;

namespace WebApis.Net6;

public class WebApiEndpoint<T>
{
    public HttpMethod? HttpMethod { get; set; }

    public string? EndPointUrl { get; set; } = string.Empty;

    public EndPointUrlPlaceholder[]? EndPointUrlPlaceholders { get; set; } = Array.Empty<EndPointUrlPlaceholder>();

    public SimpleParameter[]? QuerySimpleParameters { get; set; } = Array.Empty<SimpleParameter>();

    public ObjectParameter? QueryObjectParameters { get; set; }

    public string? GetQueryString()
    {
        StringBuilder queryString = new($"{SpotifyGlobals.ApiUrl}");
        string? endpointUrl = EndPointUrl;
        if (EndPointUrlPlaceholders is not null && EndPointUrlPlaceholders.Length > 0)
        {
            for(int i = 0; i < EndPointUrlPlaceholders.Length; i++)
            {
                object? epValue = null;
                if (EndPointUrlPlaceholders[i].SimpleValue is not null)
                {
                    epValue = EndPointUrlPlaceholders[i].SimpleValue;
                }
                else if (EndPointUrlPlaceholders[i].ObjInstance is not null && !string.IsNullOrWhiteSpace(EndPointUrlPlaceholders[i].PropertyName))
                {
                    PropertyInfo? propertyInfo = EndPointUrlPlaceholders[i]?.ObjInstance?.GetType().GetProperty(
                        EndPointUrlPlaceholders[i].PropertyName ?? string.Empty);
                    if (propertyInfo is not null) epValue = propertyInfo?.GetValue(EndPointUrlPlaceholders[i].ObjInstance);
                }
                if (!string.IsNullOrWhiteSpace(EndPointUrlPlaceholders[i].Placeholder))
                {
                    endpointUrl = endpointUrl?.Replace(EndPointUrlPlaceholders[i].Placeholder ?? "", GetQueryStringValue(epValue));
                }
            }
        }
        queryString.Append(endpointUrl);
        if ((QuerySimpleParameters is not null && QuerySimpleParameters?.Length > 0) ||
            (QueryObjectParameter is not null && QueryParameterObjPropertyNames is not null &&
            QueryParameterObjPropertyNames.Length > 0))
        {
            queryString.Append('?');
        }
        if (QuerySimpleParameters is not null && QuerySimpleParameters?.Length > 0)
        {
            for (int j = 0; j < QuerySimpleParameters?.Length; j++)
            {
                object? value = null;
                if (QuerySimpleParameters[j].SimpleValue is not null)
                {
                    value = QuerySimpleParameters[j].SimpleValue;
                }
                else if (QuerySimpleParameters[j].ObjInstance is not null && 
                    !string.IsNullOrWhiteSpace(QuerySimpleParameters[j].PropertyName))
                {
                    PropertyInfo? propertyInfo = QuerySimpleParameters[j]?.ObjInstance?.GetType().GetProperty(
                        QuerySimpleParameters[j].PropertyName ?? string.Empty);
                    if (propertyInfo is not null) value = propertyInfo?.GetValue(QuerySimpleParameters[j].ObjInstance);
                }
                for (int c = 0; c < QuerySimpleParameters[j]?.Constraints?.Length; c++)
                {
                    if (!QuerySimpleParameters[j]?.Constraints?[c].CheckConstraint(value) ?? false)
                    {
                        throw new Exception("Query Parameter failed Constraint.");
                    }
                }
                if (value is not null)
                {
                    queryString.Append($"{QuerySimpleParameters[j].Name}={GetQueryStringValue(value)}&");
                }
            }
        }
        if (QueryObjectParameter is not null && QueryParameterObjPropertyNames is not null &&
            QueryParameterObjPropertyNames.Length > 0)
        {
            Type? type = QueryObjectParameter?.GetType();
            if(type is not null)
            {
                for (int a = 0; a < QueryParameterObjPropertyNames?.Length; a++)
                {
                    object? value = null; 
                    if (QueryParameterObjPropertyNames[a] is not null &&
                    !string.IsNullOrWhiteSpace(QueryParameterObjPropertyNames[a]))
                    {
                        PropertyInfo? objPropertyInfo = type.GetProperty(
                            QueryParameterObjPropertyNames[a] ?? string.Empty);
                        if (objPropertyInfo is not null)
                        {
                            value = objPropertyInfo?.GetValue(QueryParameterObjPropertyNames[a]);
                            if (value is not null)
                            {
                                queryString.Append(
                                    $"{QueryParameterObjPropertyNames[a]}={GetQueryStringValue(value)}&");
                            }
                        }
                    }
                }
            }
        }
        string retStr = queryString.ToString();
        return (retStr[^1] == '&' ? retStr[..^1] : retStr);
    }

    public object? BodyObject { get; set; }

    public T? Response { get; set; }

    public string? GetQueryStringValue(object? value)
    {
        return value switch
        {
            string s => WebUtility.UrlEncode(s),
            bool or short or int or long or float or double or decimal => WebUtility.UrlEncode(value.ToString()),
            string[] arr => WebUtility.UrlEncode(string.Join(',', (string[]) arr)),
            DateTime dt => WebUtility.UrlEncode(dt.ToString("s", CultureInfo.InvariantCulture)),
            _ => string.Empty,
        };
    }

    public string? GetBodyJsonString()
    { 
        if (BodyObject is null) return null;
        return JsonSerializer.Serialize(BodyObject);
    }
}
