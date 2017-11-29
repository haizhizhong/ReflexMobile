using System;
using System.Data;

namespace MobileData
{
    public class DeleteHistory
    {
        public int Id;
        public int CompanyId;

        public string TableName;
        public int MatchId;
        public DateTime TimeStamp;

        public const string LemHeaderAttach = "LemHeaderAttach";
        public const string FieldPOAttach = "FieldPOAttach";
        public const string LemHeader = "LemHeader";
        public const string LabourTimeEntry = "LabourTimeEntry";
        public const string EquipTimeEntry = "EquipTimeEntry";
        public const string LemAPUnselect = "LemAPUnselect";

        public DeleteHistory()
        {
        }

        public DeleteHistory(DataRow row)
        {
            Id = (int)row["Id"];
            CompanyId = (int)row["CompanyId"];
            TableName = (string)row["TableName"];
            MatchId = (int)row["MatchId"];
            TimeStamp = (DateTime)row["TimeStamp"];
        }

        public static void SqlInsert(string tableName, int matchId)
        {
            string sql = $"INSERT INTO DeleteHistory(TableName, MatchId, CompanyId, TimeStamp) " +
                $"values('{tableName}', {matchId}, {Company.CurrentId}, getdate())";
            MobileCommon.ExecuteNonQuery(sql);
        }

        public void SqlExecute()
        {
            if (TableName == LemHeader)
            {
                MobileCommon.ExecuteNonQuery( $"delete LemHeader where MatchId={MatchId} and CompanyId={CompanyId} and deleted=1");
            }
            else if (TableName == LabourTimeEntry)
            {
                int id = (int)MobileCommon.ExecuteScalar( $"select id from LabourTimeEntry where MatchId={MatchId} and CompanyId={CompanyId} and deleted=1");
                MobileData.LabourTimeEntry.SqlForceDelete(id);
            }
            else if (TableName == EquipTimeEntry)
            {
                MobileCommon.ExecuteNonQuery($"delete EquipTimeEntry where MatchId={MatchId} and CompanyId={CompanyId} and Deleted=1");
            }
            else if (TableName == LemHeaderAttach || TableName == FieldPOAttach)
            {
                int repoId = (int)MobileCommon.ExecuteScalar($"select FileRepository_ID from CFS_FileLink where CompanyId={CompanyId} and MatchId={MatchId}");
                Attachment.SqlForceDelete(repoId);
            }
        }

        public static void UndeleteAll(int companyId)
        {
            MobileCommon.ExecuteNonQuery($"update LemHeader set Deleted=0 where CompanyId={companyId} and Deleted=1");
            MobileCommon.ExecuteNonQuery($"update LabourTimeEntry set Deleted=0 where CompanyId={companyId} and Deleted=1");
            MobileCommon.ExecuteNonQuery($"update EquipTimeEntry set Deleted=0 where CompanyId={companyId} and Deleted=1");

            MobileCommon.ExecuteNonQuery($"update CFS_FileLink set TableDotField=Replace(TableDotField, '_DEL','') where CompanyId={companyId} and TableDotField='%_DEL'");
        }
    }
}
