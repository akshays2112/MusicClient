namespace WebApis.Net6;

public class Parameter
{
    public string? Name { get; set; } = string.Empty;

    public object? SimpleValue { get; set; }

    public string? PropertyName { get; set; }

    public object? ObjInstance { get; set; }

    public Constraint[]? Constraints { get; set; }
}
