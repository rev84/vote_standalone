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



        public string GetOne(string sql, object[] parameters = null)
        {
            return GetSqledSQLiteCommand(sql, parameters).ExecuteScalar().ToString();
        }

        public Dictionary<string, string> GetLine(string sql, object[] parameters = null)
        {
            SQLiteDataReader sdr = GetSqledSQLiteCommand(sql, parameters).ExecuteReader();

            sdr.Read();
            var result = new Dictionary<string, string>();
            for (int index = 0; index < sdr.FieldCount; index++)
            {
                var name = sdr.GetName(index);
                var type = sdr.GetDataTypeName(index);
                var value = sdr.GetString(index);

                result.Add(name, value);
            }

            return result;
        }

        public List<Dictionary<string, string>> GetAll(string sql, object[] parameters = null)
        {
            var results = new List<Dictionary<string, string>>();
            SQLiteDataReader sdr = GetSqledSQLiteCommand(sql, parameters).ExecuteReader();

            while (sdr.Read())
            {
                var result = new Dictionary<string, string>();
                for (int index = 0; index < sdr.FieldCount; index++)
                {
                    var name = sdr.GetName(index);
                    var type = sdr.GetDataTypeName(index);
                    var value = sdr.GetString(index);

                    result.Add(name, value);
                }

                results.Add(result);
            }

            return results;
        }
        public int Execute(string sql, object[] parameters = null)
        {
            return GetSqledSQLiteCommand(sql, parameters).ExecuteNonQuery();
        }

        private SQLiteCommand GetSqledSQLiteCommand(string sql, object[] parameters = null)
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
            return cmd;
        }
    }
}
