using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models.Sqlite
{
    public class Users
    {
        public static void Create(string uuid, string ip)
        {
            // IPエラー
            var ipCount = Convert.ToInt32(MySqlite.GetOne(
                "select count(1) from users " +
                "where ip = ? ",
                new object[] { ip }
            ));
            if (ipCount >= 1) throw new Exception();

            MySqlite.Execute(
                "insert into users "+
                "(uuid, ip, created_at) values "+
                "(?, ?, ?) ",
                new object[] { uuid, ip, Utility.GetDatetime()}
            );
            // 匿名ネームに変える
            int id = MySqlite.LastInsertedId();
            MySqlite.Execute(
                "update users " +
                "set name = ? " +
                "where id = ? ",
                new object[] { "匿名"+id.ToString(), id }
            );
        }

        public static Dictionary<string, object> GetUser(string uuid)
        {
            return MySqlite.GetLine(
                "select * from users " +
                "where uuid = ? ",
                new object[] { uuid }
            );
        }
    }
}
