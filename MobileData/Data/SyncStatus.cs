using System.Data;
using ReflexCommon;
using System.Linq;

namespace MobileData
{
    public enum EnumSyncType
    {
        Core,
        Lookup,
        System
    }

    public class SyncStatus
    {
        public int Id;
        public string SyncTable;
        public string SyncName;
        public string DisplayName;
        public int? CompanyId;
        public bool DoSync;
        public EnumSyncType SyncType;
        public EnumTableSyncStatus Status;

        public SyncStatus()
        {
        }

        public SyncStatus(DataRow row)
        {
            Id = (int)row["Id"];
            CompanyId = ConvertEx.ToNullable<int>( row["CompanyId"]);
            SyncTable = (string)row["SyncTable"];
            SyncName = (string)row["SyncName"];
            DisplayName = (string)row["DisplayName"];
            DoSync = (bool)row["DoSync"];
            SyncType = ConvertEx.StringToEnum<EnumSyncType>(row["SyncType"]);
            Status = ConvertEx.StringToEnum<EnumTableSyncStatus>(row["Status"]);
        }

        public static SyncStatus GetSyncStatus(int id)
        {
            DataTable table = MobileCommon.ExecuteDataAdapter($"select * from SyncStatus where id={id}");
            return table.Select().Select(r => new SyncStatus(r)).Single();
        }

        public static SyncStatus GetSystemSyncStatus(string syncTable, string syncName, string displayName)
        {
            DataTable table = MobileCommon.ExecuteDataAdapter($"select * from SyncStatus where SyncName='{syncName}' and SyncType='{EnumSyncType.System}'");
            if (table.Rows.Count > 0)
            {
                return table.Select().Select( r=> new SyncStatus(r)).Single();
            }
            else
            {
                string sql = $"insert into SyncStatus(CompanyId, SyncTable, SyncType, Status, DoSync, SyncName, DisplayName) " +
                    $"values(null, '{syncTable}', '{EnumSyncType.System}', '{EnumTableSyncStatus.ReadyToSync}', 1, '{syncName}', '{displayName}')";
                MobileCommon.ExecuteNonQuery(sql);

                table = MobileCommon.ExecuteDataAdapter($"select * from SyncStatus where SyncName='{syncName}' and SyncType='{EnumSyncType.System}'");
                return table.Select().Select(r => new SyncStatus(r)).Single();
            }
        }

        public static SyncStatus GetCompanySyncStatus(string syncTable, EnumSyncType syncType, string syncName, int companyId, string displayName)
        {
            DataTable table = MobileCommon.ExecuteDataAdapter($"select * from SyncStatus where SyncName='{syncName}' and CompanyId={companyId}");
            if (table.Rows.Count > 0)
            {
                return table.Select().Select(r => new SyncStatus(r)).Single();
            }
            else
            {
                string sql = $"insert into SyncStatus(CompanyId, SyncTable, SyncType, Status, DoSync, SyncName, DisplayName) " +
                    $"values({companyId}, '{syncTable}', '{syncType}', '{EnumTableSyncStatus.ReadyToSync}', 1, '{syncName}', '{displayName}')";
                MobileCommon.ExecuteNonQuery(sql);

                table = MobileCommon.ExecuteDataAdapter($"select * from SyncStatus where SyncName='{syncName}' and CompanyId={companyId}");
                return table.Select().Select(r => new SyncStatus(r)).Single();
            }
        }

        public static void SqlSetDoSync(int id, bool dosync)
        {
            string sql = $"update SyncStatus set DoSync='{dosync}' where id={id}";
            MobileCommon.ExecuteNonQuery(sql);
        }
    }
}
