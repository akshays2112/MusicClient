namespace WebApis.Net7;

public class EndPointUrlPlaceholder
{
    public string? Placeholder { get; set; } = string.Empty;

    public object? SimpleValue { get; set; }

    public string? PropertyName { get; set; }

    public object? ObjInstance { get; set; }

    public Constraint[]? Constraints { get; set; }
}
