using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ReflexCommon;

namespace MobileData
{
    public class SyncCoreMatch
    {
        public int Id;
        public string SyncTable;
        public int SourceId;
        public int MatchId;
        public string SyncMatch;

        public static SyncCoreMatch GetMatch(string syncTable, int srcId)
        {
            DataTable table = MobileCommon.ExecuteDataAdapter($"select * from SyncCoreMatch where SyncTable='{syncTable}' and SourceId={srcId}");
            return table.Select().Select(r => new SyncCoreMatch
            {
                Id = (int)r["Id"],
                SyncTable = syncTable,
                SourceId = srcId,
                MatchId = (int)r["MatchId"],
                SyncMatch = Convert.ToString(r["SyncMatch"])
            }).SingleOrDefault();
        }

        public static List<SyncCoreMatch> GetMatchList(string syncTable)
        {
            DataTable table = MobileCommon.ExecuteDataAdapter($"select * from SyncCoreMatch where SyncTable='{syncTable}'");
            return table.Select().Select( r=> new SyncCoreMatch
            {
                Id = (int)r["Id"],
                SyncTable = syncTable,
                SourceId = (int)r["SourceId"],
                MatchId = (int)r["MatchId"],
                SyncMatch = Convert.ToString(r["SyncMatch"])
            }).ToList();
        }

        public static void SqlInsert(string syncTable, int srcId, int matchId, string syncMatch = null)
        {
            MobileCommon.ExecuteNonQuery($"Insert SyncCoreMatch(SyncTable, SourceId, MatchId, SyncMatch) values('{syncTable}',{srcId},{matchId},{StrEx.StrOrNull(syncMatch)})");
        }

        public static void SqlUpdate(string syncTable, int matchId, string syncMatch)
        {
            MobileCommon.ExecuteNonQuery($"Update SyncCoreMatch set SyncMatch='{syncMatch}' where SyncTable='{syncTable}' and MatchId={matchId}");
        }

        public static void SqlDelete(string syncTable)
        {
            MobileCommon.ExecuteNonQuery($"Delete SyncCoreMatch where SyncTable='{syncTable}'");
        }
    }
}
