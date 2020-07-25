using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models
{
    public class RequestHelper
    {
        public const string ITEM_SQLiteConnectionStringBuilder = "SQLiteConnectionStringBuilder";
        public const string ITEM_SQLiteConnection = "SQLiteConnection";
        public const string ITEM_SQLiteTransaction = "SQLiteTransaction";

        public static string GetIp()
        {
            return System.Web.HttpContext.Current.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        public static object GetVal(string key)
        {
            return System.Web.HttpContext.Current.Items[key];
        }

        public static void SetVal(string key, object value)
        {
            System.Web.HttpContext.Current.Items[key] = value;
        }
    }
}
