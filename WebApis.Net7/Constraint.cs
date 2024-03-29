﻿namespace WebApis.Net7;

public class Constraint
{
    public object? Value { get; set; }

    public int ConstraintComparison { get; set; }

    public string? RegEx { get; set; }

    public bool CheckConstraint(object? value)
    {
        if (value == null) return false;
        int tmpObjValue = 0, tmpValue = 0;
        Type? type = value?.GetType();
        if (type?.IsArray ?? false)
        {
            if (!int.TryParse(type?.GetProperty(
                (ConstraintComparison & ((int)WApiGlobals.ConstraintComparison.Length)) > 0 ? "Length" :
                (ConstraintComparison & ((int)WApiGlobals.ConstraintComparison.Count)) > 0 ? "Count" :
                string.Empty)?.GetValue(value)?.ToString(),
                out tmpObjValue)) return false;
        }
        else
        {
            if (!int.TryParse(value?.ToString(), out tmpObjValue)) return false;
        }
        if (!int.TryParse(Value?.ToString(), out tmpValue)) return false;
        if ((ConstraintComparison & ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual)) > 0 &&
            tmpObjValue <= tmpValue) return true;
        if ((ConstraintComparison & ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual)) > 0 &&
            tmpObjValue >= tmpValue) return true;
        if ((ConstraintComparison & ((int)WApiGlobals.ConstraintComparison.Equal)) > 0 &&
            tmpObjValue == tmpValue) return true;
        return false;
    }
}
