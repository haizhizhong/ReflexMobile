using System;
using System.Data;
using System.Data.SqlClient;
using WS_Popups;

namespace MobileData
{
    public class Common
    {
        public static string MobileDB { get; set; }

        public static string ServerName = "localhost\\SQLEXPRESS";
        public static string DatabaseName = "ReflexMobile";

        public static TUC_HMDevXManager.TUC_HMDevXManager HMDevXManager { get; set; }
        public static frmPopup Popups { get; set; }

        public static Uri WebUri = new Uri("http://localhost:52142/");

        public const int TimeEntryType = 8;    // from WS_PCDL_LogType

        public static DataTable ExecuteDataAdapter(string sql, string conn=null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn ?? Common.MobileDB))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    return table;
                }
            }
            catch (Exception)
            {
                Popups.ShowPopup("Sql Error: " + sql);
                return null;
            }
        }

        public static void ExecuteNonQuery(string sql, string conn = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn ?? Common.MobileDB))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                Popups.ShowPopup("Sql Error: " + sql);
            }
        }

        public static object ExecuteScalar(string sql, string conn = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn ?? Common.MobileDB))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                Popups.ShowPopup("Sql Error: " + sql);
                return null;
            }
        }
    }

    public static class ConvertEx
    {
        //public static object StringToNullable(object data) 
        //{
        //    return data == DBNull.Value ? null : (string)data;
        //}

        public static Nullable<T> ToNullable<T>(object data) where T : struct
        {
            return data == DBNull.Value ? (T?)null : (T)data;
        }

        public static T ToEnum<T>(char c) where T : struct
        {
            return (T)Enum.ToObject(typeof(T), c);
        }
    }

    public static class StringEx
    {
        public static string TextUnknown = "UnKnown";

        public static string GetDateString(DateTime? date)
        {
            return date?.ToShortDateString() ?? string.Empty;
        }

        public static string ToStringOrNull(object data)
        {
            return data == null ? "null" : $"'{data.ToString()}'";
        }

        public static string ToValueOrNull(object data)
        {
            return data == null ? "null" : $"'{data.ToString()}'";
        }
    }
}
