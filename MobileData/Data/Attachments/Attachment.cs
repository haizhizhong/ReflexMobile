using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class Attachment
    {
        public int RepositoryId;
        public int CompanyId;
        public int? MatchId;
        public int LinkMatchId;
        public int ContextItemId;
        public string TableDotField;        // + LinkMatchId to match record
        public string Comment;
        public string FileName;
        public byte[] FileData;
        public string FileTypeDescription;
        public DateTime DateAdded;
        public string MimeType;
        public int ContactId;
        public bool InternalOnly;

        public const string LemHeaderId = "LemHeader.Id";
        public const string FieldPOId = "FieldPO.Id";

        public Attachment()
        {
        }

        public Attachment(DataRow r)
        {
            RepositoryId = Convert.ToInt32(r["Id"]);
            LinkMatchId = Convert.ToInt32(r["IdValue"]);
            CompanyId = Convert.ToInt32(r["CompanyId"]);
            MatchId = ConvertEx.ToNullable<int>(r["MatchId"]);
            ContextItemId = Convert.ToInt32(r["ContextItem_ID"]);
            TableDotField = Convert.ToString(r["TableDotField"]);
            Comment = Convert.ToString(r["Comment"]);
            FileName = Convert.ToString(r["FileName"]);
            FileData = ConvertEx.ToNullableObj<byte[]>(r["FileData"]);
            FileTypeDescription = Convert.ToString(r["FileTypeDescription"]);
            DateAdded = Convert.ToDateTime(r["DateAdded"]);
            MimeType = Convert.ToString(r["Mime_type"]);
            ContactId = Convert.ToInt32(r["ContactID"]);
            InternalOnly = Convert.ToBoolean(r["InternalOnly"]);
        }

        public static List<Attachment> GetAttachList(string tableDotField, int linkId)
        {
            string sql = $"select r.*, l.CompanyId, l.MatchId, l.ContextItem_ID, l.TableDotField, l.IdValue, l.Comment " +
                $"from CFS_FileRepository r join CFS_FileLink l on l.FileRepository_ID = r.ID where l.TableDotField='{tableDotField}' and l.IdValue={linkId}";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            return table.Select().Select(r => new Attachment(r)).ToList();
        }

        public static void DeleteAttach(string tableName, int repoId)
        {
            string sql = $"select matchId from CFS_FileLink where FileRepository_ID={repoId}";
            int? matchId = ConvertEx.ToNullable<int>(MobileCommon.ExecuteScalar(sql));
            if (matchId != null)
            {
                MobileCommon.ExecuteNonQuery($"update CFS_FileLink set TableDotField=TableDotField+'_DEL' where FileRepository_ID={repoId}");

                DeleteHistory.SqlInsert(tableName, matchId.Value);
            }
            else
            {
                SqlForceDelete(repoId);
            }
        }

        public static void SqlForceDelete(int repoId)
        {
            MobileCommon.ExecuteNonQuery($"delete CFS_FileLink where FileRepository_ID={repoId}");
            MobileCommon.ExecuteNonQuery($"delete CFS_FileRepository where Id={repoId}");
        }

        public static void SqlUpdateStatus(int repoId)
        {
            string sql = $"update CFS_FileLink set SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where FileRepository_ID={repoId}";
            MobileCommon.ExecuteNonQuery(sql);
        }
    }
}
