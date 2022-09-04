using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using SpotifyGlobals = WebApis.Net7.Spotify.WApiSpotifyGlobals;

namespace WebApis.Net7;

public class WebApiEndpoint<T>
{
    public HttpMethod? HttpMethod { get; set; }

    public string? EndPointUrl { get; set; } = string.Empty;

    public EndPointUrlPlaceholder[]? EndPointUrlPlaceholders { get; set; } = Array.Empty<EndPointUrlPlaceholder>();

    public SimpleParameter[]? QuerySimpleParameters { get; set; } = Array.Empty<SimpleParameter>();

    public ObjectParameterProperty[]? QueryObjParameterProperties { get; set; }

    public object? QueryObjInstance { get; set; }

    public string? PrecalculatedQueryString { get; set; } = string.Empty;

    public object? BodyObject { get; set; }

    public T? Response { get; set; }

    public string? GetQueryString()
    {
        if (!string.IsNullOrWhiteSpace(PrecalculatedQueryString))
        {
            return PrecalculatedQueryString;
        }
        StringBuilder queryString = new($"{SpotifyGlobals.ApiUrl}");
        StringBuilder queryString2 = new();
        string? endpointUrl = EndPointUrl;
        if (EndPointUrlPlaceholders is not null && EndPointUrlPlaceholders.Length > 0)
        {
            for (int i = 0; i < EndPointUrlPlaceholders.Length; i++)
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
        if (QuerySimpleParameters is not null && QuerySimpleParameters?.Length > 0)
        {
            for (int j = 0; j < QuerySimpleParameters?.Length; j++)
            {
                object? value = null;
                if (QuerySimpleParameters[j].SimpleValue is not null)
                {
                    value = QuerySimpleParameters[j].SimpleValue;
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
                    queryString2.Append($"{QuerySimpleParameters[j].Name}={GetQueryStringValue(value)}&");
                }
            }
        }
        if (QueryObjInstance is not null && QueryObjParameterProperties is not null &&
            QueryObjParameterProperties.Length > 0)
        {
            Type? type = QueryObjInstance.GetType();
            if (type is not null)
            {
                for (int a = 0; a < QueryObjParameterProperties.Length; a++)
                {
                    if (QueryObjParameterProperties[a] is not null &&
                    !string.IsNullOrWhiteSpace(QueryObjParameterProperties[a].PropertyName))
                    {
                        PropertyInfo? objPropertyInfo = type.GetProperty(
                            QueryObjParameterProperties[a].PropertyName);
                        if (objPropertyInfo is not null)
                        {
                            object? value = objPropertyInfo?.GetValue(QueryObjInstance);
                            if (value is not null)
                            {
                                queryString2.Append(
                                    $"{QueryObjParameterProperties[a].PropertyName}={GetQueryStringValue(value)}&");
                            }
                        }
                    }
                }
            }
        }
        if(queryString2.Length > 0)
        {
            queryString.Append('?').Append(queryString2);
        }
        string retStr = queryString.ToString();
        return (retStr[^1] == '&' ? retStr[..^1] : retStr);
    }

    public string? GetQueryStringValue(object? value)
    {
        return value switch
        {
            string s => WebUtility.UrlEncode(s),
            bool or short or int or long or float or double or decimal => WebUtility.UrlEncode(value.ToString()),
            DateTime dt => WebUtility.UrlEncode(dt.ToString("s", CultureInfo.InvariantCulture)),
            Array array => JoinAndEncodeArray(array),
            _ => string.Empty,
        };
    }

    public string? JoinAndEncodeArray(Array arr)
    {
        List<string> strings = new();
        foreach(var item in arr)
        {
            if (item is not null)
            {
                strings.Add(WebUtility.UrlEncode(item.ToString() ?? string.Empty));
            }
        }
        return string.Join(',', strings);
    }

    public string? GetBodyJsonString()
    {
        if (BodyObject is null) return null;
        return JsonSerializer.Serialize(BodyObject);
    }
}
