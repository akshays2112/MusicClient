using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApis.Net6
{
    public class QueryParameter
    {
        public string? Name { get; set; } = string.Empty;

        public string? SimpleValue { get; set; }

        public Type? Type { get; set; }

        public string? PropertyName { get; set; }

        public object? ObjInstance { get; set; }
    }
}
