using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using HMConnection;
using MobileData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static WS_Popups.frmPopup;

namespace MobileLEM
{
    public partial class ucPageLogHeader : DevExpress.XtraEditors.XtraUserControl
    {
        class ColName
        {
            public const string Id = "Id";
            public const string LogDate = "LogDate";
            public const string LemNum = "LemNum";
            public const string LogStatus = "LogStatus";
            public const string ProjectId = "ProjectId";
            public const string ProjectName = "ProjectName";
            public const string CustomerCode = "CustomerCode";
            public const string CustomerName = "CustomerName";
            public const string SiteLocation = "SiteLocation";
            public const string StartDate = "StartDate";
            public const string EstCompletionDate = "EstCompletionDate";
        }

        public ucPageLogHeader()
        {
            InitializeComponent();
        }

        public void Init()
        {
            luProject.Properties.DataSource = Project.AccessibleList().Select( p=> new { Project = p.Name, Code = p.Code, MatchId = p.MatchId, Desc = $"{p.Code}-{p.Name}" });

            luStatus.Properties.DataSource = Enum.GetValues(typeof(EnumLogStatus)).Cast<EnumLogStatus>().Select( status=> new { Status = Enum.GetName(typeof(EnumLogStatus), status) });
            luStatus.EditValue = Enum.GetName(typeof(EnumLogStatus), EnumLogStatus.Open);

            luColProject.DataSource = Project.AccessibleList().Select(p => new { MatchId = p.MatchId, Code = p.Code, Project = p.Name }).Distinct().ToList();

            SetData(new List<LemLogHeader>());
            SetButtonsForRow(false);
        }

        public LemLogHeader GetCurrentLog()
        {
            var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            return row == null ? null : LemLogHeader.GetLogHeader((int)row[ColName.Id]);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? project = (int?)luProject.EditValue;
            DateTime? from = (DateTime?)deFromDate.EditValue;
            DateTime? to = (DateTime?)deToDate.EditValue;
            string status = (string)luStatus.EditValue;

            var logList = LemLogHeader.GetLogHeaderList(project, from, to, status);
            SetData(logList);
        }

        private bool GridG_AllowDelete(object sender, DataRow row)
        {
            if (!CanEdit(row))
            {
                Common.Popups.ShowPopup("Cannot delete a submitted record.");
                return false;
            }

            if (Common.Popups.ShowPopup(this, "Delete Record?", "Confirmation", PopupType.Yes_No) == PopupResult.Yes)
            {
                var curr = LemLogHeader.GetLogHeader((int)row[ColName.Id]);
                string sql = $"INSERT INTO DeleteHistory(TableName, MatchId, CompanyId, TimeStamp) values('LemLogHeader', {curr.MatchId}, {curr.CompanyId}, getdate())";
                Common.ExecuteNonQuery(sql);

                return true;
            }
            return false;
        }

        private void luProject_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            luProject.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : luProject.EditValue;
        }

        private void luStatus_Properties_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            luStatus.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : luStatus.EditValue;
        }

        private void deFromDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            deFromDate.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : deFromDate.EditValue;
        }

        private void deToDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            deToDate.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : deToDate.EditValue;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            luProject.EditValue = null;
            deFromDate.EditValue = null;
            deToDate.EditValue = null;
            luStatus.EditValue = null;

            SetData(new List<LemLogHeader>());
        }

        private void SetData(List<LemLogHeader> logList)
        {
            tableHeader.Clear();
            logList.Select(x => new { log = x, project = Project.GetProject(x.ProjectId) }).ToList().ForEach(x =>
            {
                tableHeader.Rows.Add(
                  x.log.Id,
                  x.log.LogDate,
                  x.log.LemNum,
                  Enum.GetName(typeof(EnumLogStatus), x.log.LogStatus),
                  x.log.ProjectId,
                  x.project?.Name,
                  x.project?.CustomerCode,
                  x.project?.CustomerName,
                  x.project?.SiteLocation,
                  StringEx.GetDateString(x.project?.StartDate),
                  StringEx.GetDateString(x.project?.EstCompletionDate));
            });
            tableHeader.AcceptChanges();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {

        }

        private async void btnSync_ClickAsync(object sender, EventArgs e)
        {
            CL_Dialog.PleaseWait.Show("Data syncing...\r\nPlease Wait", null);

            await DataSync.RunSyncAsync();
            CL_Dialog.PleaseWait.Hide();
        }

        private void btnPrintEmail_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            row[ColName.LogStatus] = Enum.GetName(typeof(EnumLogStatus), EnumLogStatus.Submitted);

            LemLogHeader.SqlUpdateSubmit((int)row[ColName.Id]);
            SetButtonsForRow(false);
        }

        private void SetButtonsForRow(bool enabled)
        {
            btnAttach.Enabled = enabled;
            btnSubmit.Enabled = enabled;
        }

        private void gridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !CanEdit(gridView1.FocusedRowHandle);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.RowHandle);
            row[ColName.LogStatus] = Enum.GetName(typeof(EnumLogStatus), EnumLogStatus.Open);
            row[ColName.LogDate] = DateTime.Today;
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SetButtonsForRow(CanEdit(e.FocusedRowHandle));
        }

        bool CanEdit(int rh)
        {
            if (gridView1.IsNewItemRow(rh))
                return true;

            if (rh < 0)
                return false;

            var row = gridView1.GetDataRow(rh);
            return CanEdit(row);
        }

        bool CanEdit(DataRow row)
        {
            return Enum.GetName(typeof(EnumLogStatus), EnumLogStatus.Open) == $"{row[ColName.LogStatus]}";
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == ColName.ProjectId)
            {
                DataRow row = gridView1.GetDataRow(e.RowHandle);
                Project project = Project.GetProject((int)row[ColName.ProjectId]);
                row[ColName.ProjectName] = project?.Name;
                row[ColName.CustomerCode] = project?.CustomerCode;
                row[ColName.CustomerName] = project?.CustomerName;
                row[ColName.SiteLocation] = project?.SiteLocation;
                row[ColName.StartDate] = StringEx.GetDateString(project?.StartDate);
                row[ColName.EstCompletionDate] = StringEx.GetDateString(project?.EstCompletionDate);

                row[ColName.LemNum] = project.GetNextLemNum();
            }

            if (!gridView1.IsNewItemRow(e.RowHandle))
            {
                if (new string[] { ColName.ProjectId, ColName.LogDate }.Contains(e.Column.FieldName))
                {
                    DataRow row = gridView1.GetDataRow(e.RowHandle);
                    LemLogHeader.SqlUpdate((int)row[ColName.Id], (DateTime)row[ColName.LogDate], (int)row[ColName.ProjectId]);
                }
            }
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.RowHandle);
            if (row[ColName.ProjectId] == DBNull.Value || Convert.ToInt32(row[ColName.ProjectId]) <= 0)
            {
                e.Valid = false;
                e.ErrorText = "Must select a Project.";
                return;
            }

            if (row[ColName.Id] == DBNull.Value)
            {
                row[ColName.Id] = -1;
            }
        }

        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.RowHandle);

            if (!CanEdit(row))
            {
                Common.Popups.ShowPopup("Cannot delete a submitted record.");
                e.Cancel = true;
            }
            else if (Common.Popups.ShowPopup(this, "Delete Record?", "Confirmation", PopupType.Yes_No) == PopupResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                LemLogHeader.SqlDelete((int)row[ColName.Id]);
            }
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (gridView1.IsNewItemRow(e.RowHandle))
            {
                DataRowView row = e.Row as DataRowView;
                row[ColName.Id] = LemLogHeader.SqlInsert((DateTime)row[ColName.LogDate], (int)row[ColName.ProjectId], (string)row[ColName.LemNum]);
            }
        }
    }
}
