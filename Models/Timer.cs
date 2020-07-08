using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models.Sqlite3
{
    public class Timer
    {
        /// <summary>
        /// 現在時刻を取得
        /// </summary>
        /// <returns></returns>
        public static string GetDatetime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
