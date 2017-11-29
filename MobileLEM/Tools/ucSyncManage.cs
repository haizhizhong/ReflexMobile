using System;
using System.Data;
using MobileData;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;

namespace MobileLEM
{
    public partial class ucSyncManage : DevExpress.XtraEditors.XtraUserControl
    {
        class ColName
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Status = "Status";
            public const string Sync = "Sync";
            public const string Object = "Object";
        }

        public Action AfterSync;

        List<CoreSync> _coreSyncList;
        List<ReceiveSync> _lookupSyncList;
        List<SystemSync> _systemSyncList;

        public ucSyncManage()
        {
            InitializeComponent();
        }

        public void SetData()
        {
            tableCore.Clear();
            _coreSyncList = DataSync.GetSyncCoreList(Company.CurrentId);
            _coreSyncList.ForEach(x => x.SyncChangeStatus += Core_SyncChangeStatus);
            _coreSyncList.ForEach(x =>
            {
                tableCore.Rows.Add(
                    x.SyncInfo.Id,
                    x.SyncInfo.DisplayName,
                    EnumTableSyncStatusText.GetText(x.SyncInfo.Status)
                );
            });

            tableLookup.Clear();
            _lookupSyncList = DataSync.GetSyncLookupList(Company.CurrentId);
            _lookupSyncList.ForEach(x => x.SyncChangeStatus += Lookup_SyncChangeStatus);
            _lookupSyncList.ForEach(x =>
            {
                tableLookup.Rows.Add(
                    x.SyncInfo.Id,
                    x.SyncInfo.DisplayName,
                    EnumTableSyncStatusText.GetText(x.SyncInfo.Status),
                    x.SyncInfo.DoSync,
                    x
                );
            });

            tableSystem.Clear();
            _systemSyncList = DataSync.GetSyncSystemList();
            _systemSyncList.ForEach(x => x.SyncChangeStatus += System_SyncChangeStatus);

            _systemSyncList.ForEach(x =>
            {
                tableSystem.Rows.Add(
                    x.SyncInfo.Id,
                    x.SyncInfo.DisplayName,
                    EnumTableSyncStatusText.GetText(x.SyncInfo.Status),
                    x.SyncInfo.DoSync,
                    x
                );
            });

            tabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            SetupButtons();
        }

        private void gvLookup_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == ColName.Sync)
            {
                DataRow row = gvLookup.GetDataRow(e.RowHandle);
                ((ReceiveSync)row[ColName.Object]).SyncInfo.DoSync = (bool)row[ColName.Sync];
            }
        }

        private void gvSystem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == ColName.Sync)
            {
                DataRow row = gvSystem.GetDataRow(e.RowHandle);
                ((SystemSync)row[ColName.Object]).SyncInfo.DoSync = (bool)row[ColName.Sync];
            }
        }

        private async void btnCoreStart_ClickAsync(object sender, EventArgs e)
        {
            if (!HasInternetConnection())
                return;

            CL_Dialog.PleaseWait.Show("Data syncing...\r\nPlease Wait", ParentForm);

            SyncResult result = await DataSync.HandShakeAsync();
            if (result.Successful)
            {
                var resultSync = await DataSync.RunSyncCompanyCore(_coreSyncList);

                GuiCommon.ShowMessage(resultSync.DisplayMessage());
                AfterSync?.Invoke();
            }
            else
            {
                GuiCommon.ShowMessage(result.DisplayMessage());
            }
            CL_Dialog.PleaseWait.Hide();
        }

        private void Core_SyncChangeStatus(object sender, EnumTableSyncStatus status)
        {
            for (int i = 0; i < gvCore.RowCount; i++)
            {
                int handle = gvCore.GetRowHandle(i);
                DataRow row = gvCore.GetDataRow(handle);
                if ((int)row[ColName.Id] == ((CoreSync)sender).SyncInfo.Id)
                {
                    row[ColName.Status] = EnumTableSyncStatusText.GetText(status);
                    break;
                }
            }
        }

        private async void btnCoreCancel_ClickAsync(object sender, EventArgs e)
        {
            var result = await DataSync.CancelSyncCompanyCoreAsync(_coreSyncList);
            if (!result.Successful)
            {
                GuiCommon.ShowMessage(result.DisplayMessage());
            }
        }

        private async void btnLookupStart_ClickAsync(object sender, EventArgs e)
        {
            if (!HasInternetConnection())
                return;

            CL_Dialog.PleaseWait.Show("Data syncing...\r\nPlease Wait", ParentForm);

            SyncResult result = await DataSync.HandShakeAsync();
            if (result.Successful)
            {
                var resultSync = await DataSync.RunSyncCompanyLookups(_lookupSyncList);

                GuiCommon.ShowMessage(resultSync.DisplayMessage());
                AfterSync?.Invoke();
            }
            else
            {
                GuiCommon.ShowMessage(result.DisplayMessage());
            }
            CL_Dialog.PleaseWait.Hide();
        }

        private void Lookup_SyncChangeStatus(object sender, EnumTableSyncStatus status)
        {
            for (int i = 0; i < gvLookup.RowCount; i++)
            {
                int handle = gvLookup.GetRowHandle(i);
                DataRow row = gvLookup.GetDataRow(handle);
                if ((int)row[ColName.Id] == ((ReceiveSync)sender).SyncInfo.Id)
                {
                    row[ColName.Status] = EnumTableSyncStatusText.GetText(status);
                    break;
                }
            }
        }

        private void btnLookupCancel_Click(object sender, EventArgs e)
        {
            DataSync.CancelSyncCompanyLookups(_lookupSyncList);
        }

        private async void btnSystemStart_ClickAsync(object sender, EventArgs e)
        {
            if (!HasInternetConnection())
                return;

            CL_Dialog.PleaseWait.Show("Data syncing...\r\nPlease Wait", ParentForm);

            SyncResult result = await DataSync.HandShakeAsync();
            if (result.Successful)
            {
                var resultSync = await DataSync.RunSyncSystem(_systemSyncList);
                if (resultSync.Successful)
                {
                    string msg = LoginUser.AddSqlUsers();
                    if (msg != null)
                    {
                        GuiCommon.ShowMessage(msg);
                    }
                }

                GuiCommon.ShowMessage(resultSync.DisplayMessage());
                AfterSync?.Invoke();
            }
            else
            {
                GuiCommon.ShowMessage(result.DisplayMessage());
            }

            CL_Dialog.PleaseWait.Hide();
        }

        private void System_SyncChangeStatus(object sender, EnumTableSyncStatus status)
        {
            for (int i = 0; i < gvSystem.RowCount; i++)
            {
                int handle = gvSystem.GetRowHandle(i);
                DataRow row = gvSystem.GetDataRow(handle);
                if ((int)row[ColName.Id] == ((SystemSync)sender).SyncInfo.Id)
                {
                    row[ColName.Status] = EnumTableSyncStatusText.GetText(status);
                    break;
                }
            }
        }

        private void SetupButtons()
        {
            btnNext.Enabled = (tabControl.SelectedTabPageIndex < tabControl.TabPages.Count - 1);
            btnBack.Enabled = (tabControl.SelectedTabPageIndex > 0);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTabPageIndex--;
            SetupButtons();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTabPageIndex++;
            SetupButtons();
        }

        private void btnLookupSelectAll_Click(object sender, EventArgs e)
        {
            SetAllSync(gvLookup, true);
        }

        private void btnLookupSelectNone_Click(object sender, EventArgs e)
        {
            SetAllSync(gvLookup, false);
        }

        private void btnSystemSelectAll_Click(object sender, EventArgs e)
        {
            SetAllSync(gvSystem, true);
        }

        private void btnSystemSelectNone_Click(object sender, EventArgs e)
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
                if (row[ColName.Object] is SystemSync)
                    ((SystemSync)row[ColName.Object]).SyncInfo.DoSync = sync;
                else if (row[ColName.Object] is ReceiveSync)
                    ((ReceiveSync)row[ColName.Object]).SyncInfo.DoSync = sync;
            }
        }

        private bool HasInternetConnection()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                GuiCommon.ShowMessage("No internet connection, cannot sync.");
                return false;
            }

            return true;
        }
    }
}
