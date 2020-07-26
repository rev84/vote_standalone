using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace vote_standalone.Models
{
    public class MySqlite
    {
        // Sqliteファイルの場所
        private const string SQLITE_FILE_PATH = ".\\Resources\\db.sqlite3";

        private static SQLiteConnectionStringBuilder sqlConnectionSb = null;
        private static SQLiteConnection cn = null;
        private static SQLiteTransaction ts = null;

        public static void Init()
        {
            if (sqlConnectionSb == null)
            {
                sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = SQLITE_FILE_PATH };
                cn = new SQLiteConnection(sqlConnectionSb.ToString());
            }
        }

        public static void Open()
        {
            Init();
            if (cn.State == System.Data.ConnectionState.Closed) {
                cn.Open();
            }
        }

        public static void BeginTransaction()
        {
            if (ts == null)
            {
                Open();
                ts = cn.BeginTransaction();
            }
        }

        public static void Rollback()
        {
            if (ts != null)
            {
                ts.Rollback();
                ts = null;
            }
        }

        public static void Commit()
        {
            if (ts != null)
            {
                ts.Commit();
                ts = null;
            }
        }

        public static void Close()
        {
            if (cn != null) cn.Close();
        }



        public static string GetOne(string sql, object[] parameters = null)
        {
            Open();
            var value = GetSqledSQLiteCommand(sql, parameters).ExecuteScalar();
            return value == null ? null : value.ToString();
        }

        public static Dictionary<string, object> GetLine(string sql, object[] parameters = null)
        {
            Open();
            SQLiteDataReader sdr = GetSqledSQLiteCommand(sql, parameters).ExecuteReader();

            sdr.Read();
            return LoadFromDataReader(sdr);
        }

        public static List<Dictionary<string, object>> GetAll(string sql, object[] parameters = null)
        {
            Open();
            var results = new List<Dictionary<string, object>>();
            SQLiteDataReader sdr = GetSqledSQLiteCommand(sql, parameters).ExecuteReader();

            while (sdr.Read())
            {
                results.Add(LoadFromDataReader(sdr));
            }

            return results;
        }

        public static int Execute(string sql, object[] parameters = null)
        {
            Open();
            return GetSqledSQLiteCommand(sql, parameters).ExecuteNonQuery();
        }

        public static int LastInsertedId()
        {
            Open();
            return Convert.ToInt32(GetOne("select last_insert_rowid()"));
        }

        private static SQLiteCommand GetSqledSQLiteCommand(string sql, object[] parameters = null)
        {
            Open();

            var cmd = new SQLiteCommand(cn)
            {
                CommandText = sql
            };
            if (parameters == null) return cmd;

            foreach (object p in parameters)
            {
                cmd.Parameters.Add(
                    new SQLiteParameter {
                        DbType = System.Data.DbType.String,
                        Value = p ?? DBNull.Value
                    }
                );
            }
            return cmd;
        }

        private static Dictionary<string, object> LoadFromDataReader(SQLiteDataReader sdr)
        {
            if (!sdr.HasRows) return null;

            Dictionary<string, object> result = new Dictionary<string, object>();
            for (int index = 0; index < sdr.FieldCount; index++)
            {
                var name = sdr.GetName(index);
                var type = sdr.GetDataTypeName(index);
                var value = sdr.GetValue(index);

                result.Add(name, value);
            }

            return result;
        }
    }
}
