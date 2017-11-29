using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class SystemInfo      //SystemInfo
    {
        public string DataBaseVersion;
        public int? KeepDays;

        public string CodeVersion;                  // just for sync, not in db
        public List<string> PatchScript;            // just for sync, not in db

        static SystemInfo _current;

        public static SystemInfo Current
        {
            get
            {
                if (_current == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter($"select top 1 * from SystemInfo");
                    _current = table.Select().Select(r => new SystemInfo
                    {
                        DataBaseVersion = Convert.ToString(r["DataBaseVersion"]),
                        KeepDays = ConvertEx.ToNullable<int>(r["KeepDays"])
                    }).SingleOrDefault();
                }

                return _current;
            }
        }

        public static void InsertRecord()
        {
            MobileCommon.ExecuteNonQuery($"insert SystemInfo(DataBaseVersion, KeepDays) values('1.0.0.0', 0)");
        }

        public static void UpdateDataBaseVersion(string ver)
        {
            MobileCommon.ExecuteNonQuery($"Update SystemInfo set DataBaseVersion='{ver}'");
            Current.DataBaseVersion = ver;
        }

        public static void UpdateKeepDays(int? keepDays)
        {
            MobileCommon.ExecuteNonQuery($"Update SystemInfo set KeepDays={StrEx.ValueOrNull(keepDays)}");
            Current.KeepDays = keepDays;
        }
    }
}
