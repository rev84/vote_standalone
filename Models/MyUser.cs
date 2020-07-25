using Microsoft.AspNetCore.Identity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vote_standalone.Models.Sqlite;

namespace vote_standalone.Models
{
    public class MyUser
    {
        [ThreadStatic]
        private static Dictionary<string, object> user = null;

        public static bool Login(string uuid)
        {
            user = Users.GetUser(uuid);
            return IsLogin();
        }

        public static bool IsLogin()
        {
            return user != null;
        }

        public static int? GetId()
        {
            return IsLogin() ? Utility.ToNullableInt(user["id"].ToString()) : null;
        }
        public static string GetName()
        {
            return IsLogin() ? user["name"].ToString() : null;
        }

        public static void CreateUser()
        {
            string uuid = Utility.GenerateUuid();
            try
            {
                MySqlite.BeginTransaction();
                Users.Create(uuid, RequestHelper.GetIp());
                MySqlite.Commit();
            }
            catch (Exception e)
            {
                MySqlite.Rollback();
                throw e;
            }

            Cookie.SetUuid(uuid);
            Login(uuid);
        }
    }
}
