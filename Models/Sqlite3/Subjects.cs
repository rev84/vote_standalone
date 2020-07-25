using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models.Sqlite
{
    public class Subjects
    {
        public static bool IsExist(string title, string artist)
        {
            return Convert.ToInt32(MySqlite.GetOne(
                "select count(1) from subjects " +
                "where title = ? and artist = ? ",
                new object[] { title, artist }
            )) >= 1;
        }
        public static List<Dictionary<string, object>> GetAll()
        {
            return MySqlite.GetAll(
                "select id, user_id, title, artist, url, comment, created_at from subjects " +
                "where is_disabled = 0 " +
                "order by id asc "
            );
        }
        public static List<Dictionary<string, object>> GetMine(int? userId)
        {
            return MySqlite.GetAll(
                "select id, user_id, title, artist, url, comment, created_at from subjects " +
                "where user_id = ? and is_disabled = 0 " +
                "order by id asc ",
                new object[] { userId }
            );
        }
        public static bool Create(int? userId, string title, string artist, string url, string comment)
        {
            if (IsExist(title, artist)) return false;

            return MySqlite.Execute(
                "insert into subjects " +
                "(user_id, title, artist, url, comment, created_at) values " +
                "(?, ?, ?, ?, ?, ?) ",
                new object[] { userId, title, artist, url, comment, Utility.GetDatetime() }
            ) >= 1;
        }
    }
}
