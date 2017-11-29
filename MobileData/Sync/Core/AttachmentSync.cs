using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MobileData
{
    public class AttachmentSync : CoreSync
    {
        protected override string TableName { get { return "CFS_FileLink"; } }
        protected override string DisplayName { get { return "Attachment File"; } }

        public AttachmentSync(int companyId) : base(companyId)
        {
        }

        public List<Attachment> GetSendList()
        {
            List<SyncCoreMatch> matchList = SyncCoreMatch.GetMatchList("LemHeader");
            string linkIds = StrEx.GetIdListText(matchList.Select( x=>x.SourceId).ToList());

            string sql = $"select r.*, l.CompanyId, l.MatchId, l.ContextItem_ID, l.TableDotField, l.IdValue, l.Comment from CFS_FileRepository r join CFS_FileLink l on l.FileRepository_ID = r.ID " +
                $"where TableDotField='{Attachment.LemHeaderId}' and IdValue in ({linkIds}) and (SyncStatus='{EnumRecordSyncStatus.NoSubmit}' or SyncStatus is null)";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            List<Attachment> listLem = table.Select().Select(r => new Attachment(r)).ToList();
            listLem.ForEach(x => x.LinkMatchId = matchList.Single(m => m.SourceId == x.LinkMatchId).MatchId);

            matchList = SyncCoreMatch.GetMatchList("FieldPO");
            linkIds = StrEx.GetIdListText(matchList.Select(x => x.SourceId).ToList());

            sql = $"select r.*, l.CompanyId, l.MatchId, l.ContextItem_ID, l.TableDotField, l.IdValue, l.Comment from CFS_FileRepository r join CFS_FileLink l on l.FileRepository_ID = r.ID " +
                $"where TableDotField='{Attachment.FieldPOId}' and IdValue in ({linkIds}) and (SyncStatus='{EnumRecordSyncStatus.NoSubmit}' or SyncStatus is null)";
            table = MobileCommon.ExecuteDataAdapter(sql);
            List<Attachment> listPo = table.Select().Select(r => new Attachment(r)).ToList();
            listPo.ForEach(x => x.LinkMatchId = matchList.Single(m => m.SourceId == x.LinkMatchId).MatchId);

            listLem.AddRange(listPo);
            return listLem;
        }

        public override async Task<SyncResult> Send(Guid token, int syncId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);
                    UpdateStatus(EnumTableSyncStatus.Sending);
                    SyncCoreMatch.SqlDelete(TableName);

                    List<Attachment> list = GetSendList();
                    var query = HttpUtility.ParseQueryString($"syncId={syncId}");
                    foreach (Attachment item in list)
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync($"api/Attachments?{query.ToString()}", item);
                        if (response.IsSuccessStatusCode)
                        {
                            int matchId = await response.Content.ReadAsAsync<int>();
                            AfterSendRecord(item.RepositoryId);
                            SyncCoreMatch.SqlInsert(TableName, item.RepositoryId, matchId);
                        }
                        else
                        {
                            throw new Exception($"Post Response StatusCode={response.ReasonPhrase}");
                        }
                    }

                    UpdateStatus(EnumTableSyncStatus.CompleteSend);
                    return new SyncResult { Successful = true };
                }
            }
            catch (Exception e)
            {
                UpdateStatus(EnumTableSyncStatus.ErrorInSend);
                return new SyncResult { Successful = false, Task = TableName, Message = e.Message };
            }
        }

        public override void CommitSend()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Sending, EnumTableSyncStatus.CompleteSend }.Contains(SyncInfo.Status))
            {
                DataTable table = MobileCommon.ExecuteDataAdapter($"select FileRepository_ID from CFS_FileLink where SyncStatus='{EnumRecordSyncStatus.Submiting}' and CompanyID={CompanyId}");
                var repoIdList = table.Select().Select(r => (int)r["FileRepository_ID"]);
                foreach (int repoId in repoIdList)
                {
                    var match = SyncCoreMatch.GetMatch(TableName, repoId);
                    MobileCommon.ExecuteNonQuery($"update CFS_FileLink set MatchID={match.MatchId}, SyncStatus='{EnumRecordSyncStatus.Submitted}' where FileRepository_ID={repoId}");
                }

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }
    }
}
