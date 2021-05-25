using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHelpers.Helpers
{
    public static class ObjectExtensions
    {
        public static string EmptyIfNull(this object value)
        {
            if (value == null)
                return "";
            return value.ToString();
        }
    }
}
