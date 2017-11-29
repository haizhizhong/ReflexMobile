using System;
using System.Linq;
using System.Threading.Tasks;

namespace MobileData
{
    public class SystemSync
    {
        public SyncStatus SyncInfo;

        protected virtual string TableName { get; }
        protected virtual string DisplayName { get; }

        public SystemSync()
        {
            SyncInfo = SyncStatus.GetSystemSyncStatus(TableName, GetType().Name, DisplayName);
        }

        public virtual Task<SyncResult> Receive()
        {
            throw new NotImplementedException();
        }

        public virtual void CommitReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive }.Contains(SyncInfo.Status))
            {
                string sql = $"delete {TableName} where InSync<>1";
                MobileCommon.ExecuteNonQuery(sql);

                sql = $"update {TableName} set InSync=0";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        public virtual void RollbackReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive, EnumTableSyncStatus.ErrorInReceive }.Contains(SyncInfo.Status))
            {
                string sql = $"delete {TableName} where InSync=1";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        public event EventHandler<EnumTableSyncStatus> SyncChangeStatus;

        public void UpdateStatus(EnumTableSyncStatus status)
        {
            SyncChangeStatus?.Invoke(this, status);
            SyncInfo.Status = status;
        }
    }
}
