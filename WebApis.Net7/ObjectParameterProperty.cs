namespace WebApis.Net7;

public class ObjectParameterProperty
{
    public bool IsRequired { get; set; } = false;

    public bool HasDefaultValue { get; set; } = false;

    public string PropertyName { get; set; } = string.Empty;

    public Constraint[]? Constraints { get; set; }

    public object? DefaultValue { get; set; }
}
