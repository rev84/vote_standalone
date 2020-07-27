using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models.Sqlite
{
    public class SubjectVotes
    {
        public static bool Replace(int SubjectId, int UserId, int Point, string Comment)
        {
            return MySqlite.Execute(
                "insert or replace into subject_votes " +
                "(user_id, subject_id, point, comment, updated_at) values " +
                "(?,?,?,?,?)",
                new object[] {
                    UserId, SubjectId,
                    Point, Comment, Utility.GetDatetime()
                }
            ) >= 1;
        }
    }
}
