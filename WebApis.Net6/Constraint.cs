using System.Reflection;

namespace WebApis.Net6
{
    public class Constraint
    {
        public object? MinValue { get; set; }
        public object? MaxValue { get; set; }

        public object? MaxCount { get; set; }

        public string? RegEx { get; set; }

        public bool CheckRanged(object? value)
        {
            switch(value)
            {
                case byte:
                case short:
                case int:
                    if (int.TryParse(value?.ToString(), out int tmpValue) &&
                        int.TryParse(MinValue?.ToString(), out int tmpMinValue) &&
                        int.TryParse(MaxValue?.ToString(), out int tmpMaxValue))
                    {
                        if (tmpValue >= tmpMinValue || tmpValue <= tmpMaxValue)
                        {
                            return true;
                        }
                    }
                    break;
                case long:
                case float:
                case double:
                case decimal:
                    if(decimal.TryParse(value?.ToString(), out decimal tmpDecimalValue) &&
                        decimal.TryParse(MinValue?.ToString(), out decimal tmpDecimalMinValue) &&
                        decimal.TryParse(MaxValue?.ToString(), out decimal tmpDecimalMaxValue))
                    {
                        if (tmpDecimalValue >= tmpDecimalMinValue || tmpDecimalValue <= tmpDecimalMaxValue)
                        {
                            return true;
                        }
                    }
                    break;
            }
            return false;
        }

        public bool CheckArrayCount(object? value)
        {
            Type? type = value?.GetType();
            if (!type?.IsArray ?? true) return false;
            if (!int.TryParse(type?.GetProperty("Length")?.GetValue(value)?.ToString(), out int valueLen)) return false;
            if (!int.TryParse(MaxCount?.ToString(), out int tmpMaxCount)) return false;
            if (valueLen <= tmpMaxCount) return true;
            return false;
        }

        public bool CheckConstraint(object? value)
        {
            if (value is null) return false;
            if (MinValue is not null && MaxValue is not null)
            {
                return CheckRanged(value);
            }
            if(MaxCount is not null)
            {
                return CheckArrayCount(value);
            }
            return false;
        }
    }
}
