using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models.Sqlite
{
    public class Subjects
    {
        public static List<Dictionary<string, object>> GetAll()
        {
            return MySqlite.GetAll(
                "select user_id, title, artist, url, comment, created_at from subjects "
            );
        }
        public static bool Create(string title, string artist, string url, string comment)
        {
            return MySqlite.Execute(
                "insert into subjects " +
                "(title, artist, url, comment, created_at) values " +
                "(?, ?, ?, ?, ?) ",
                new object[] { title, artist, url, comment, Utility.GetDatetime() }
            ) >= 1;
        }
    }
}
