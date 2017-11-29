using System;
using System.Linq;
using System.Threading.Tasks;

namespace MobileData
{
    public class ReceiveSync 
    {
        public SyncStatus SyncInfo;
        public int CompanyId;
        protected virtual string TableName { get; }
        protected virtual string DisplayName { get; }

        public ReceiveSync()
        {
        }

        public ReceiveSync(int companyId)
        {
            CompanyId = companyId;
            SyncInfo = SyncStatus.GetCompanySyncStatus(TableName, EnumSyncType.Lookup, GetType().Name, companyId, DisplayName);
        }

        public virtual Task<SyncResult> Receive(Guid token)
        {
            throw new NotImplementedException();
        }

        public virtual void CommitReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive }.Contains(SyncInfo.Status))
            {
                string sql = $"delete {TableName} where InSync<>1 and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);
                sql = $"update {TableName} set InSync=0 where CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        public virtual void RollbackReceive()
        {
            if ( new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive, EnumTableSyncStatus.ErrorInReceive}.Contains(SyncInfo.Status))
            {
                string sql = $"delete {TableName} where InSync=1 and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        public void SetStatus(EnumTableSyncStatus status)
        {
            string sql = $"update SyncStatus set Status='{status}' where SyncTable='{TableName}' and CompanyId={CompanyId}";
            MobileCommon.ExecuteNonQuery(sql);
            SyncInfo.Status = status;
        }

        public void UpdateStatus(EnumTableSyncStatus status)
        {
            SyncChangeStatus?.Invoke(this, status);
            SetStatus(status);
        }

        public event EventHandler<EnumTableSyncStatus> SyncChangeStatus;
    }
}
