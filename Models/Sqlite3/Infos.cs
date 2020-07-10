using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace vote_standalone.Models.Sqlite3
{
    public class Infos
    {
        public const string KEY_NOW_SUBJECT_ID = "now_subject_id";

        public static int GetNowSubjectId(Sqlite3 sqlite = null)
        {
            return Convert.ToInt32(Get(KEY_NOW_SUBJECT_ID));
        }

        private static string Get(string key, Sqlite3 sqlite = null)
        {
            Sqlite3.Get(sqlite).GetOne(
                "select value from infos " +
                "where key = ? ",
                new object[] { key }
            );
            return "";
        }
    }
}
