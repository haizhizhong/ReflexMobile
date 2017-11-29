using System.Data;
using MobileData;
using DevExpress.XtraGrid.Views.Grid;
using System;

namespace MobileLEM
{
    public partial class ucSyncConfig : DevExpress.XtraEditors.XtraUserControl
    {
        class ColName
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Sync = "Sync";
        }

        public ucSyncConfig()
        {
            InitializeComponent();
        }

        public void SetData()
        {
            tableLookup.Clear();
            DataSync.GetSyncLookupList(Company.CurrentId).ForEach(x =>
            {
                tableLookup.Rows.Add(
                    x.SyncInfo.Id,
                    x.SyncInfo.DisplayName,
                    x.SyncInfo.DoSync
                );
            });

            tableSystem.Clear();
            DataSync.GetSyncSystemList().ForEach(x =>
            {
                tableSystem.Rows.Add(
                    x.SyncInfo.Id,
                    x.SyncInfo.DisplayName,
                    x.SyncInfo.DoSync
                );
            });
        }

        private void gvLookup_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == ColName.Sync)
            {
                DataRow row = gvLookup.GetDataRow(e.RowHandle);
                SyncStatus.SqlSetDoSync((int)row[ColName.Id], (bool)row[ColName.Sync]);
            }
        }

        private void gvSystem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == ColName.Sync)
            {
                DataRow row = gvSystem.GetDataRow(e.RowHandle);
                SyncStatus.SqlSetDoSync((int)row[ColName.Id], (bool)row[ColName.Sync]);
            }
        }

        private void btnLookupSelectAll_Click(object sender, System.EventArgs e)
        {
            SetAllSync(gvLookup, true);
        }

        private void btnLookupSelectNone_Click(object sender, System.EventArgs e)
        {
            SetAllSync(gvLookup, false);
        }

        private void btnSystemSelectAll_Click(object sender, System.EventArgs e)
        {
            SetAllSync(gvSystem, true);
        }

        private void btnSystemSelectNone_Click(object sender, System.EventArgs e)
        {
            SetAllSync(gvSystem, false);
        }

        private void SetAllSync(GridView gv, bool sync)
        {
            for (int i = 0; i < gv.RowCount; i++)
            {
                int handle = gv.GetRowHandle(i);
                DataRow row = gv.GetDataRow(handle);
                row[ColName.Sync] = sync;
                SyncStatus.SqlSetDoSync((int)row[ColName.Id], sync);
            }
        }
    }
}
