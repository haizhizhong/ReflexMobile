using System;
using System.Linq;
using System.Threading.Tasks;

namespace MobileData
{
    public class CoreSync : ReceiveSync
    {
        public CoreSync(int companyId)
        {
            CompanyId = companyId;
            SyncInfo = SyncStatus.GetCompanySyncStatus(TableName, EnumSyncType.Core, GetType().Name, companyId, DisplayName);
        }

        public virtual Task<SyncResult> Send(Guid token, int syncId)
        {
            throw new NotImplementedException();
        }

        public void AfterSendRecord(int id)
        {
            string sql = $"Update {TableName} set SyncStatus='{EnumRecordSyncStatus.Submiting}' where id={id}";
            MobileCommon.ExecuteNonQuery(sql);
        }

        public virtual void CommitSend()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Sending, EnumTableSyncStatus.CompleteSend }.Contains(SyncInfo.Status))
            {
                string sql = $"update {TableName} set SyncStatus='{EnumRecordSyncStatus.Submitted}' where SyncStatus='{EnumRecordSyncStatus.Submiting}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        public virtual void RollbackSend()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Sending, EnumTableSyncStatus.CompleteSend, EnumTableSyncStatus.ErrorInSend }.Contains(SyncInfo.Status))
            {
                string sql = $"update {TableName} set SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where SyncStatus='{EnumRecordSyncStatus.Submiting}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------
#pragma warning disable 1998
        public override async Task<SyncResult> Receive(Guid token)
        {
            UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            return new SyncResult { Successful = true };
        }
#pragma warning restore 1998

        public virtual void BeforeReceiveRecord(int matchId)
        {
            string sql = $"Update {TableName} set SyncStatus='{EnumRecordSyncStatus.Updating}' where CompanyId={CompanyId} and MatchId={matchId}";
            MobileCommon.ExecuteNonQuery(sql);
        }

        public override void CommitReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive }.Contains(SyncInfo.Status))
            {
                string sql = $"delete {TableName} where SyncStatus='{EnumRecordSyncStatus.Updating}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                sql = $"update {TableName} set SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where SyncStatus='{EnumRecordSyncStatus.Receiving}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        public override void RollbackReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive, EnumTableSyncStatus.ErrorInReceive }.Contains(SyncInfo.Status))
            {
                string sql = $"delete {TableName} where SyncStatus='{EnumRecordSyncStatus.Receiving}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                sql = $"update {TableName} set SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where SyncStatus='{EnumRecordSyncStatus.Updating}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }
    }
}
