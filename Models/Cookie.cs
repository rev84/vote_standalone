using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models
{
    public class Cookie
    {
        const string KEY_UUID = "uuid";

        public static string GetUuid()
        {
            return Get(KEY_UUID);
        }
        public static void SetUuid(string uuid)
        {
            Set(KEY_UUID, uuid);
        }

        private static void Set(string key, string value)
        {
            var opt = new CookieOptions()
            {
                Expires = new DateTimeOffset(DateTime.Now.AddDays(365))
            };
            System.Web.HttpContext.Current.Response.Cookies.Append(key, value, opt);
        }
        private static string Get(string key)
        {
            return System.Web.HttpContext.Current.Request.Cookies[key]?.ToString();
        }
    }
}
