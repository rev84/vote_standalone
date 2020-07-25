using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models
{
    public class Utility
    {
        public static string GenerateUuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static int? ToNullableInt(string str)
        {
            return int.TryParse(str, out var i) ? (int?)i : null;
        }

        public static string GetDatetime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
