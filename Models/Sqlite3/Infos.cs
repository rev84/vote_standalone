using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace vote_standalone.Models.Sqlite
{
    public class Infos
    {
        public const string KEY_NOW_SUBJECT_ID = "now_subject_id";

        public static int? GetNowSubjectId()
        {
            return Utility.ToNullableInt(Get(KEY_NOW_SUBJECT_ID));
        }

        private static string Get(string key)
        {
            return MySqlite.GetOne(
                "select value from infos " +
                "where key = ? ",
                new object[] { key }
            );
        }
    }
}
