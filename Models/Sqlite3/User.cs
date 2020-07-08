using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models.Sqlite3
{
    public class User
    {
        public static void Create(string name, string uuid, Sqlite3 sqlite = null)
        {
            Sqlite3.Get(sqlite).ExecuteSql(
                "insert into users "+
                "(name, uuid, created_at) values "+
                "(?, ?, ?) ",
                new object[] { name, uuid, Timer.GetDatetime()}
            );
        }
    }
}
