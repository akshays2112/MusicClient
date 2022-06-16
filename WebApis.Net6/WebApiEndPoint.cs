using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using SpotifyGlobals = WebApis.Net6.Spotify.WApiSpotifyGlobals;

namespace WebApis.Net6;

public class WebApiEndpoint<T>
{
    public HttpMethod? HttpMethod { get; set; }

    public string? EndPointUrl { get; set; } = string.Empty;

    public EndPointUrlPlaceholder[]? EndPointUrlPlaceholders { get; set; } = Array.Empty<EndPointUrlPlaceholder>();

    public SimpleParameter[]? QuerySimpleParameters { get; set; } = Array.Empty<SimpleParameter>();

    public ObjectParameter? QueryObjectParameters { get; set; }

    public string? PrecalculatedQueryString { get; set; } = string.Empty;

    public string? GetQueryString()
    {
        if (!string.IsNullOrWhiteSpace(PrecalculatedQueryString))
        {
            return PrecalculatedQueryString;
        }
        StringBuilder queryString = new($"{SpotifyGlobals.ApiUrl}");
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
        if ((QuerySimpleParameters is not null && QuerySimpleParameters?.Length > 0) ||
            QueryObjectParameters is not null)
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
        if (QueryObjectParameters is not null && QueryObjectParameters.ObjectParameterProperties is not null &&
            QueryObjectParameters.ObjectParameterProperties.Length > 0)
        {
            Type? type = QueryObjectParameters?.GetType();
            if (type is not null)
            {
                for (int a = 0; a < QueryObjectParameters?.ObjectParameterProperties?.Length; a++)
                {
                    if (QueryObjectParameters.ObjectParameterProperties[a] is not null &&
                    !string.IsNullOrWhiteSpace(QueryObjectParameters.ObjectParameterProperties[a].PropertyName))
                    {
                        PropertyInfo? objPropertyInfo = type.GetProperty(
                            QueryObjectParameters.ObjectParameterProperties[a].PropertyName ?? string.Empty);
                        if (objPropertyInfo is not null)
                        {
                            object? value = objPropertyInfo?.GetValue(
                                QueryObjectParameters.ObjectParameterProperties[a].PropertyName);
                            if (value is not null)
                            {
                                queryString.Append(
                                    $"{QueryObjectParameters.ObjectParameterProperties[a].PropertyName}={GetQueryStringValue(value)}&");
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
            string[] arr => JoinAndEncodeStringArray((string[])arr),
            DateTime dt => WebUtility.UrlEncode(dt.ToString("s", CultureInfo.InvariantCulture)),
            _ => string.Empty,
        };
    }

    public string? JoinAndEncodeStringArray(string[] arr)
    {
        arr.ToList().ForEach(s => WebUtility.UrlEncode(s));
        return string.Join(',', arr);
    }

    public string? GetBodyJsonString()
    {
        if (BodyObject is null) return null;
        return JsonSerializer.Serialize(BodyObject);
    }
}
