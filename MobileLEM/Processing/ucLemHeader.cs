using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DM_CentralizedFSManager;
using HM_Report_Printer;
using HMBaseReporting;
using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static WS_Popups.frmPopup;
using static MobileLEM.GuiCommon;
using static MobileData.MobileCommon;
using static ReflexCommon.EnumCommon;
using System.Deployment.Application;
using System.Reflection;

namespace MobileLEM
{
    public partial class ucLemHeader : DevExpress.XtraEditors.XtraUserControl
    {
        private ucFileManager _fileMgr;

        public ucLemHeader()
        {
            InitializeComponent();

            luProject.Properties.DataSource = Project.AccessibleList().Select(p => new { Project = p.Name, Code = p.Code, MatchId = p.MatchId, DisplayName = p.DisplayName });
            luStatus.Properties.DataSource = GetEnums<EnumLogStatus>().Select(x => new { Status = GetEnumName(x) });

            luColProjectCode.DataSource = Project.AccessibleList().Select(p => new { MatchId = p.MatchId, Code = p.Code, Project = p.Name }).ToList();
            luColProjectName.DataSource = Project.AccessibleList().Select(p => new { MatchId = p.MatchId, Code = p.Code, Project = p.Name }).ToList();
            luColLogAllStatus.DataSource = GetEnums<EnumLogStatus>().Select(x => new { Status = GetEnumName(x), Enum = (char)x });
            luColLogStatus.DataSource = new EnumLogStatus[] { EnumLogStatus.Pending, EnumLogStatus.Approved }.Select(x => new { Status = GetEnumName(x), Enum = (char)x });

            _fileMgr = new ucFileManager(HMCon, HMDevXManager, DocumentViewerMode.All, false, "F", true);
            _fileMgr.Dock = DockStyle.Fill;
            _fileMgr.Parent = dpAttachment;
            _fileMgr.AttachmentsRemoved += AttachmentsRemoved;
            _fileMgr.AttachmentsAdded += AttachmentsAdded;
            _fileMgr.AttachmentsEdited += AttachmentsEdited;
            _fileMgr.Enabled = false;

            ClearAll();
        }

        public void ClearAll()
        {
            luProject.EditValue = null;
            deFromDate.EditValue = null;
            deToDate.EditValue = null;
            luStatus.EditValue = null;

            SetData(new List<LemHeader>());
            btnEmail.Enabled = false;
            btnPrint.Enabled = false;
            btnSubmit.Enabled = false;
        }

        private void AttachmentsAdded()
        {
            SetSubmitStatus(EnumSubmitStatus.Open);
        }

        private void AttachmentsRemoved(int repoId)
        {
            Attachment.DeleteAttach(DeleteHistory.LemHeaderAttach, repoId);
            SetSubmitStatus(EnumSubmitStatus.Open);
        }

        private void AttachmentsEdited(int repoId)
        {
            Attachment.SqlUpdateStatus(repoId);
            SetSubmitStatus(EnumSubmitStatus.Open);
        }

        public LemHeader GetCurrentLog()
        {
            var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            return row == null ? null : LemHeader.GetLogHeader(row.GetValue<int>(colId));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? project = (int?)luProject.EditValue;
            DateTime? from = (DateTime?)deFromDate.EditValue;
            DateTime? to = (DateTime?)deToDate.EditValue;
            EnumLogStatus? status = luStatus.EditValue==null ? null : (EnumLogStatus?)Enum.Parse( typeof(EnumLogStatus), (string)luStatus.EditValue);

            var logList = LemHeader.GetLogHeaderList(project, from, to, status, null);
            SetData(logList);
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

            ClearAll();
        }

        private void SetData(List<LemHeader> headerList)
        {
            tableHeader.Clear();
            headerList.Select(x => new { Header = x, project = Project.GetProject(x.ProjectId) }).ToList().ForEach(x =>
            {
                tableHeader.Rows.Add(
                  x.Header.Id,
                  x.Header.LogDate,
                  x.Header.LemNum,
                  x.Header.Description,
                  (char)x.Header.LogStatus,
                  GetEnumName(x.Header.SubmitStatus),
                  x.Header.ProjectId,
                  x.Header.ProjectId,
                  x.Header.ApprovalComments,
                  x.Header.EmailData!=null,
                  x.project?.CustomerCode,
                  x.project?.CustomerName,
                  x.project?.SiteLocation,
                  StrEx.GetDateString(x.project?.StartDate),
                  StrEx.GetDateString(x.project?.EstCompletionDate));
            });
            tableHeader.AcceptChanges();
        }

        public void RefreshCurrentRowStatus()
        {
            var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row != null)
            {
                int id = row.GetValue<int>(colId);
                LemHeader data = LemHeader.GetLogHeader(id);
                row.SetValue(colSubmitStatus, GetEnumName(data.SubmitStatus));
                btnSubmit.Enabled = GetEnumName(EnumSubmitStatus.Open) == row.GetValueString(colSubmitStatus);
                _fileMgr.Enabled = LemHeader.CheckEditable(row.GetCharEnumValue<EnumLogStatus>(colLogStatus));
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            CL_Dialog.PleaseWait.Show("Generating report...\r\nPlease Wait", ParentForm);

            string reportName = "LEMSheetApprovalX.rpt";
            if (File.Exists($"{Application.StartupPath}\\{reportName}"))
            {
                var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                try
                {
                    string userName = LoginUser.CurrUser.GetUserName();
                    using (SqlConnection sqlcon = new SqlConnection(MobileDB))
                    {
                        sqlcon.Open();

                        string sSQL = @"ReportLEMApproval";
                        SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", row.GetValue<int>(colId)));
                        cmd.Parameters.Add(new SqlParameter("@username", userName));
                        cmd.ExecuteNonQuery();
                    }

                    string[,] para = new string[2, 1];
                    para[0, 0] = "@username";
                    para[1, 0] = userName;

                    var hmReport = new HMReport($"{Application.StartupPath}\\{reportName}", ServerName, DatabaseName, para, HMCon);
                    string tempFile = Path.GetTempFileName();
                    hmReport.ExportReportToPDF(tempFile);
                    byte[] bytes = File.ReadAllBytes(tempFile);
                    LemHeader.SqlUpdateEmail(row.GetValue<int>(colId), bytes);
                    File.Delete(tempFile);
                    row.SetValue(colEmail, true);
                }
                catch (Exception ex)
                {
                    ShowMessage($"Error: {ex.Message}");
                }
            }
            else
            {
                ShowMessage($"The report {reportName} cannot be found.");
            }
            CL_Dialog.PleaseWait.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string reportName = "LEMSheetApprovalX.rpt";
            if (File.Exists($"{Application.StartupPath}\\{reportName}"))
            {
                var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                try
                {
                    string userName = LoginUser.CurrUser.GetUserName();
                    using (SqlConnection sqlcon = new SqlConnection(MobileDB))
                    {
                        sqlcon.Open();

                        string sSQL = @"ReportLEMApproval";
                        SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", row.GetValue<int>(colId)));
                        cmd.Parameters.Add(new SqlParameter("@username", userName));
                        cmd.ExecuteNonQuery();
                    }

                    string[,] para = new string[2, 1];
                    para[0, 0] = "@username";
                    para[1, 0] = userName;
                    using (frmHM_Report_Printer frmPrint = new frmHM_Report_Printer(HMCon, HMDevXManager, para, reportName, frmHM_Report_Printer.DBFlavor.TR))
                    {
                        frmPrint.SkipDataBase = true;
                        frmPrint.ReportPath = Application.StartupPath;
                        frmPrint.ShowDialog();
                    }
                }
                catch(Exception ex)
                {
                    ShowMessage($"Error: {ex.Message}");
                }
            }
            else
            {
                ShowMessage($"The report {reportName} cannot be found.");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (!LemHeader.CheckLevelCodeValid(row.GetValue<int>(colId)))
            {
                ShowMessage($"Not all the LEM records contain {Company.GetCurrCompany().GetLevelCodeText()}, please check.");
                return;
            }

            SetSubmitStatus(EnumSubmitStatus.Ready);
        }

        private void gridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (!LemHeader.CheckEditable(row.GetCharEnumValue<EnumLogStatus>(colLogStatus)))
            {
                e.Cancel = true;
                return;
            }

            if (new GridColumn[] { colProjectCode, colProjectName }.Contains(gridView1.FocusedColumn))
            {
                if (row.GetValue(colId) != DBNull.Value && LemHeader.CheckHasEntry(row.GetValue<int>(colId)))
                {
                    ShowMessage("This LEM Header contains Entries, cannot change the Project.");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.RowHandle);
            row.SetValue(colLogStatus, (char)EnumLogStatus.Pending);
            row.SetValue(colSubmitStatus, GetEnumName(EnumSubmitStatus.Open));
            row.SetValue(colLogDate, DateTime.Today);
            row.SetValue(colEmail, false);

            gridView1.FocusedColumn = gridView1.Columns.First(x => x.Visible);
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var LoadAttachments = new Action<int>((poId) =>
            {
                _fileMgr.DocumentFileLink = new FileLink[] { new FileLink(Attachment.LemHeaderId, poId, Company.CurrentId, FileLink.Database.TR, 0, true) };
            });

            DataRow row = gridView1.GetDataRow(e.FocusedRowHandle);
            if (row != null && row.GetValue(colId) != DBNull.Value)
            {
                LoadAttachments(row.GetValue<int>(colId));
                btnEmail.Enabled = true;
                btnPrint.Enabled = true;
                btnSubmit.Enabled = GetEnumName(EnumSubmitStatus.Open) == row.GetValueString(colSubmitStatus);
                _fileMgr.Enabled = LemHeader.CheckEditable(row.GetCharEnumValue<EnumLogStatus>(colLogStatus));
                _fileMgr.ReadOnly = !_fileMgr.Enabled;
            }
            else
            {
                LoadAttachments(-1);
                btnEmail.Enabled = false;
                btnPrint.Enabled = false;
                btnSubmit.Enabled = false;
                _fileMgr.Enabled = false;
                _fileMgr.ReadOnly = true;
            }
        }

        private void SetSubmitStatus(EnumSubmitStatus status)
        {
            var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row != null && row.GetValue(colSubmitStatus)!=DBNull.Value && ConvertEx.StringToEnum<EnumSubmitStatus>(row.GetValueString(colSubmitStatus)) != status)
            {
                row.SetValue(colSubmitStatus, GetEnumName(status));
                LemHeader.SqlUpdateSubmitStatus(row.GetValue<int>(colId), status);
                btnSubmit.Enabled = (status == EnumSubmitStatus.Open);
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (new GridColumn[] { colProjectCode, colProjectName }.Contains(e.Column))
            {
                DataRow row = gridView1.GetDataRow(e.RowHandle);
                int projectId = row.GetValue<int>(e.Column);
                Project project = Project.GetProject(projectId);

                row.SetValue(colProjectCode, projectId);
                row.SetValue(colProjectName, projectId);
                row.SetValue(colCustomerCode, project?.CustomerCode);
                row.SetValue(colCustomerName, project?.CustomerName);
                row.SetValue(colSiteLocation, project?.SiteLocation);
                row.SetValue(colStartDate, StrEx.GetDateString(project?.StartDate));
                row.SetValue(colEstCompletionDate, StrEx.GetDateString(project?.EstCompletionDate));

                row.SetValue(colLemNum, project.GetNextLemNum());
            }

            if (!gridView1.IsNewItemRow(e.RowHandle))
            {
                if (new GridColumn[] { colProjectCode, colProjectName, colLogDate, colLogStatus, colDescription }.Contains(e.Column))
                {
                    DataRow row = gridView1.GetDataRow(e.RowHandle);
                    row.SetValue(colSubmitStatus, GetEnumName(EnumSubmitStatus.Open));
                    LemHeader.SqlUpdate(row.GetValue<int>(colId), row.GetValue<DateTime>(colLogDate), row.GetValue<int>(colProjectCode), 
                        row.GetCharEnumValue<EnumLogStatus>(colLogStatus), row.GetValueString(colDescription));
                }
            }
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.RowHandle);
            if (row.GetValue(colProjectCode) == DBNull.Value || row.GetValue<int>(colProjectCode) <= 0)
            {
                e.Valid = false;
                e.ErrorText = "Must select a Project.";
                return;
            }
        }

        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.RowHandle);

            if (ShowMessage("Delete Record?", "Confirmation", PopupType.Yes_No) == PopupResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                LemHeader.SqlDelete(row.GetValue<int>(colId));
            }
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (gridView1.IsNewItemRow(e.RowHandle))
            {
                DataRow row = (e.Row as DataRowView).Row;
                row.SetValue(colId, LemHeader.SqlInsert(row.GetValue<DateTime>(colLogDate), row.GetValue<int>(colProjectCode), row.GetValueString(colLemNum), row.GetValueString(colDescription)));
                btnEmail.Enabled = true;
                btnPrint.Enabled = true;
                btnSubmit.Enabled = GetEnumName(EnumSubmitStatus.Open) == row.GetValueString(colSubmitStatus);
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == colLogStatus)
            {
                e.RepositoryItem = luColLogStatus;
            }
        }
    }
}
