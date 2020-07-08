using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace vote_standalone.Models.Sqlite3
{
    public class Sqlite3
    {
        // Sqliteファイルの場所
        private const string SQLITE_FILE_PATH = ".\\Resources\\db.sqlite3";

        private SQLiteConnectionStringBuilder sqlConnectionSb;
        private SQLiteConnection cn;
        private SQLiteTransaction ts = null;

        public Sqlite3()
        {
            sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = SQLITE_FILE_PATH };
            cn = new SQLiteConnection(sqlConnectionSb.ToString());
        }

        public static Sqlite3 Get(Sqlite3 sqlite = null)
        {
            return sqlite ?? new Sqlite3();
        }

        public void Open()
        {
            if (cn.State == System.Data.ConnectionState.Closed) {
                cn.Open();
            }
        }

        public void BeginTransaction()
        {
            if (ts == null)
            {
                Open();
                ts = cn.BeginTransaction();
            }
        }

        public void Rollback()
        {
            if (ts != null)
            {
                ts.Rollback();
                ts = null;
            }
        }

        public void Commit()
        {
            if (ts != null)
            {
                ts.Commit();
                ts = null;
            }
        }

        public void Close()
        {
            cn.Close();
        }

        public object ExecuteSql(string sql, object[] parameters = null)
        {
            Open();

            var cmd = new SQLiteCommand(cn);
            cmd.CommandText = sql;
            foreach (object p in parameters)
            {
                cmd.Parameters.Add(
                    new SQLiteParameter {
                        DbType = System.Data.DbType.String,
                        Value = p
                    }
                );
            }
            return cmd.ExecuteScalar();
        }
    }
}
