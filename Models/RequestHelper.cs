using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models
{
    public class RequestHelper
    {
        public static string GetIp()
        {
            return System.Web.HttpContext.Current.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
