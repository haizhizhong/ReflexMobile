using ReflexCommon;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public enum EnumSyncProcess
    {
        NotSyncing,
        SystemSyncing,
        LookupSyncing,
        CoreSending,
        CoreHalfWay,
        CoreReceiving
    }

    public class CompanySyncProcess
    {
        public int CompanyId;
        public EnumSyncProcess SyncProcess;
        public EnumSyncType SyncType;
        public int SyncId;

        public const int NoCompany = -1;

        static List<CompanySyncProcess> _list;

        public static List<CompanySyncProcess> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from CompanySyncProcess");
                    _list = table.Select().Select(r => new CompanySyncProcess
                    {
                        CompanyId = (int)r["CompanyId"],
                        SyncType = ConvertEx.StringToEnum<EnumSyncType>(r["SyncType"]),
                        SyncProcess = ConvertEx.StringToEnum<EnumSyncProcess>(r["SyncProcess"]),
                        SyncId = (int)r["SyncId"],
                    }).ToList();
                }
                return _list;
            }
        }

        public static CompanySyncProcess GetSyncProcess(int companyId, EnumSyncType syncType)
        {
            return List.SingleOrDefault(x => x.CompanyId == companyId && x.SyncType==syncType);
        }

        public static EnumSyncProcess GetSyncProcessEnum(int companyId, EnumSyncType syncType)
        {
            return GetSyncProcess(companyId, syncType)?.SyncProcess ?? (companyId == NoCompany ? EnumSyncProcess.SystemSyncing : EnumSyncProcess.NotSyncing);
        }

        public static void SetSyncProcess(int companyId, EnumSyncType syncType, EnumSyncProcess process, int syncId)
        {
            CompanySyncProcess item = GetSyncProcess(companyId, syncType);

            if (item != null)
            {
                item.SyncProcess = process;
                item.SyncId = syncId;
                string sql = $"Update CompanySyncProcess set SyncProcess='{process}', SyncId={syncId} where CompanyId={companyId} and SyncType='{syncType}'";
                MobileCommon.ExecuteNonQuery(sql);
            }
            else
            {
                _list.Add(new CompanySyncProcess() { CompanyId = companyId, SyncType=syncType, SyncProcess = process, SyncId = syncId });
                string sql = $"insert CompanySyncProcess(CompanyId, SyncType, SyncProcess, SyncId) values({companyId}, '{syncType}', '{process}', {syncId})";
                MobileCommon.ExecuteNonQuery(sql);
            }
        }
    }
}
