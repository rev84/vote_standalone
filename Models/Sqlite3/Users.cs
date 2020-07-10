using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models.Sqlite3
{
    public class Users
    {
        public static void Create(string name, string uuid, string ip, Sqlite3 sqlite = null)
        {
            // IPエラー
            var ipCount = Convert.ToInt32(Sqlite3.Get(sqlite).GetOne(
                "select count(1) from users " +
                "where ip = ? ",
                new object[] { ip }
            ));
            if (ipCount >= 1) throw new Exception();

            Sqlite3.Get(sqlite).Execute(
                "insert into users "+
                "(name, uuid, ip, created_at) values "+
                "(?, ?, ?, ?) ",
                new object[] { name, uuid, ip, Timer.GetDatetime()}
            );
        }
    }
}
