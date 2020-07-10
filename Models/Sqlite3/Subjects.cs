using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models.Sqlite3
{
    public class Subjects
    {
        
        public static void GetNow(Sqlite3 sqlite = null)
        {
            int nowSubjectId = Infos.GetNowSubjectId();
            Sqlite3.Get(sqlite).GetOne(
                "select * users "+
                "(name, uuid, created_at) values "+
                "(?, ?, ?) ",
                new object[] { nowSubjectId }
            );
        }
    }
}
