namespace WebApis.Net6;

public class SimpleParameter
{
    public string? Name { get; set; } = string.Empty;

    public object? SimpleValue { get; set; }

    public Constraint[]? Constraints { get; set; }
}
