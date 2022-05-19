using static WebApis.Net6.Globals;

namespace WebApis.Net6;

public class Constraint
{
    public object? Value { get; set; }

    public ConstraintComparison? ConstraintComparison { get; set; }

    public string? RegEx { get; set; }

    public bool CheckConstraint(object? value)
    {
        if(value == null) return false;
        int tmpObjValue;
        Type? type = value?.GetType();
        if (type?.IsArray ?? false)
        {
            if (!int.TryParse(type?.GetProperty("Length")?.GetValue(value)?.ToString(),
                out tmpObjValue)) return false;
        }
        else
        {
            if (!int.TryParse(value?.ToString(), out tmpObjValue)) return false;
        }
        if (!int.TryParse(Value?.ToString(), out int tmpValue)) return false;
        if (ConstraintComparison == Globals.ConstraintComparison.LessThanOrEqual &&
            tmpObjValue <= tmpValue) return true;
        if (ConstraintComparison == Globals.ConstraintComparison.GreaterThanOrEqual &&
            tmpObjValue >= tmpValue) return true;
        if (ConstraintComparison == Globals.ConstraintComparison.Equal &&
            tmpObjValue == tmpValue) return true;
        return false;
    }
}
