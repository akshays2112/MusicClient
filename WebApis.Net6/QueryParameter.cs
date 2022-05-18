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

        public object? SimpleValue { get; set; }

        public string? PropertyName { get; set; }

        public object? ObjInstance { get; set; }
    }
}
