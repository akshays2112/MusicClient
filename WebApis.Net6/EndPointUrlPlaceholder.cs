using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApis.Net6
{
    public class EndPointUrlPlaceholder
    {
        public string? Placeholder { get; set; } = string.Empty;

        public string? Value { get; set; }

        public Type? Type { get; set; }

        public string? PropertyName { get; set; }

        public object? objInstance { get; set; }
    }
}
