using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.GuidFormatControl
{
    public static class GuidControl
    {
        public static bool BeValidGuidPattern(Guid guid)
        {
            var pattern = new Regex(@"^A-Fa-f0-9]{8}-(?:[A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}$");
            return pattern.IsMatch(guid.ToString());
        }
    }
}
