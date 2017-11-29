using System;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using MobileData;
using static WS_Popups.frmPopup;
using DM_CentralizedFSManager;
using System.Windows.Forms;
using ReflexCommon;
using DevExpress.XtraGrid.Columns;
using static ReflexCommon.EnumCommon;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace MobileLEM
{
    public partial class ucFieldPO : XtraUserControl
    {
        private ucFileManager _fileMgr;

        public ucFieldPO()
        {
            InitializeComponent();

            btnSubmit.Enabled = false;

            _fileMgr = new ucFileManager(MobileCommon.HMCon, GuiCommon.HMDevXManager, DocumentViewerMode.All, false, "F", true);
            _fileMgr.Dock = DockStyle.Fill;
            _fileMgr.Parent = dpAttachment;
            _fileMgr.AttachmentsRemoved += AttachmentsRemoved;
            _fileMgr.AttachmentsAdded += AttachmentsAdded;
            _fileMgr.AttachmentsEdited += AttachmentsEdited;
            _fileMgr.Enabled = false;

            luColSupplier.DataSource = Supplier.ListForCompany().Select(s => new { SupplierCode = s.SupplierCode, SupplierName = s.SupplierName });
            luColSupplierName.DataSource = Supplier.ListForCompany().Select(s => new { SupplierCode = s.SupplierCode, SupplierName = s.SupplierName });

            luColProjectCode.DataSource = Project.AccessibleList().Select(p => new { MatchId = p.MatchId, Code = p.Code, Project = p.Name }).ToList();
            luColProjectName.DataSource = Project.AccessibleList().Select(p => new { MatchId = p.MatchId, Code = p.Code, Project = p.Name }).ToList();

            var level1CodeList = LevelOneCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code=code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luDetailLevel1All.DataSource = level1CodeList.OrderBy(x => x.MatchId);

            var level2CodeList = LevelTwoCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luDetailLevel2All.DataSource = level2CodeList.OrderBy(x => x.MatchId);

            var level3CodeList = LevelThreeCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luDetailLevel3All.DataSource = level3CodeList.OrderBy(x => x.MatchId);

            var level4CodeList = LevelFourCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luDetailLevel4All.DataSource = level4CodeList.OrderBy(x => x.MatchId);

            luDetailComponent.DataSource = Enum.GetValues(typeof(EnumComponentType)).Cast<EnumComponentType>().Select(x => new { Type = Enum.GetName(typeof(EnumComponentType), x), Enum = (char)x });

            int maxLevel = Company.GetCurrCompany().MaxLevelCode;
            var SetColumn = new Action<GridColumn, int, string>((col, level, caption) =>
            {
                col.Visible = maxLevel >= level;
                col.OptionsColumn.ShowInCustomizationForm = maxLevel >= level;
                col.Caption = caption;
            });

            SetColumn(colDetailLevel4Code, 4, Company.GetCurrCompany().Level4CodeDesc);
            SetColumn(colDetailLevel3Code, 3, Company.GetCurrCompany().Level3CodeDesc);
            SetColumn(colDetailLevel2Code, 2, Company.GetCurrCompany().Level2CodeDesc);
            SetColumn(colDetailLevel1Code, 1, Company.GetCurrCompany().Level1CodeDesc);
        }

        private void AttachmentsRemoved(int repoId)
        {
            Attachment.DeleteAttach(DeleteHistory.FieldPOAttach, repoId);
            SetSubmitStatus(EnumSubmitStatus.Open);
        }

        private void AttachmentsEdited(int repoId)
        {
            Attachment.SqlUpdateStatus(repoId);
            SetSubmitStatus(EnumSubmitStatus.Open);
        }

        private void AttachmentsAdded()
        {
            SetSubmitStatus(EnumSubmitStatus.Open);
        }

        public void SetData()
        {
            SetDetailsEnabled(false);

            tablePO.Clear();
            FieldPO.GetAllPO().ForEach(x =>
                tablePO.Rows.Add( 
                    x.Id, 
                    x.PODate, 
                    Enum.GetName( typeof(EnumSubmitStatus), x.SubmitStatus),
                    x.PONum, 
                    x.SupplierCode, 
                    x.SupplierCode,
                    x.ProjectId,
                    x.ProjectId,
                    Project.GetProject(x.ProjectId)?.Billable ?? false, 
                    x.POAmount)
                );
            tablePO.AcceptChanges();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvDetail.RowCount > 0)
            {
                SetSubmitStatus(EnumSubmitStatus.Ready);
                btnSubmit.Enabled = false;
            }
            else
            {
                GuiCommon.ShowMessage("PO must contain at least 1 detail record.");
            }
        }

        private void gvPO_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row = gvPO.GetDataRow(e.RowHandle);
            row[colPODate.FieldName] = DateTime.Today;
            row[colStatus.FieldName] = Enum.GetName(typeof(EnumSubmitStatus), EnumSubmitStatus.Open);
            row[colPOAmount.FieldName] = 0;

            gvPO.FocusedColumn = gvPO.Columns.First(x => x.Visible);
        }

        private void gvPO_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = gvPO.GetDataRow(e.RowHandle);
            if (e.Column == colSupplierCode || e.Column == colSupplierName)
            {
                string code = (string)row[e.Column.FieldName];
                row[colSupplierCode.FieldName] = code;
                row[colSupplierName.FieldName] = code;
            }
            else if (e.Column == colProjectCode || e.Column == colProjectName)
            {
                int projectId = (int)row[e.Column.FieldName];
                row[colProjectCode.FieldName] = projectId;
                row[colProjectName.FieldName] = projectId;
                row[colBillable.FieldName] = Project.GetProject(projectId)?.Billable ?? false;
            }

            if (!gvPO.IsNewItemRow(e.RowHandle))
            {
                if (new GridColumn[] { colPODate, colPONumber, colSupplierCode, colSupplierName, colProjectCode, colProjectName, colBillable }.Contains(e.Column))
                {
                    FieldPO.SqlUpdate((int)row[colId.FieldName], (DateTime)row[colPODate.FieldName], Convert.ToString(row[colPONumber.FieldName]),
                        (string)row[colSupplierCode.FieldName], (int)row[colProjectCode.FieldName], (bool)row[colBillable.FieldName]);
                    row[colStatus.FieldName] = Enum.GetName(typeof(EnumSubmitStatus), EnumSubmitStatus.Open);
                    btnSubmit.Enabled = true;
                }
            }
        }

        private void gvPO_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = gvPO.GetDataRow(e.RowHandle);

            var EnsureMandatoryColumn = new Func<GridColumn, string, bool>((col, msg) =>
            {
                if (row[col.FieldName] == DBNull.Value)
                {
                    e.Valid = false;
                    e.ErrorText = msg;
                    return true;
                }
                return false;
            });

            if (EnsureMandatoryColumn(colPODate, "Need to enter PO date.")) return;
            if (EnsureMandatoryColumn(colSupplierCode, "Need to select a Supplier.")) return;
            if (EnsureMandatoryColumn(colProjectCode, "Need to select a Project.")) return;
        }

        private void gvPO_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (gvPO.IsNewItemRow(e.RowHandle))
            {
                DataRowView row = e.Row as DataRowView;
                row[colId.FieldName] = FieldPO.SqlInsert((DateTime)row[colPODate.FieldName], Convert.ToString(row[colPONumber.FieldName]), (string)row[colSupplierCode.FieldName], 
                    (int)row[colProjectCode.FieldName], (bool)row[colBillable.FieldName]);

                btnSubmit.Enabled = (string)row[colStatus.FieldName] == Enum.GetName(typeof(EnumSubmitStatus), EnumSubmitStatus.Open);
                SetDetailsEnabled(true);
            }
        }

        private void gvPO_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            DataRow row = gvPO.GetDataRow(e.RowHandle);
            if ((string)row[colStatus.FieldName] == Enum.GetName(typeof(EnumSubmitStatus), EnumSubmitStatus.Submitted))
            {
                e.Cancel = true;
                GuiCommon.ShowMessage("Cannot delete a submitted PO.");
                return;
            }

            if (GuiCommon.ShowMessage("Delete Record?", "Confirmation", PopupType.Yes_No) == PopupResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                FieldPO.SqlDelete((int)row[colId.FieldName]);
            }
        }

        private void gvPO_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var LoadAttachments = new Action<int>((poId) =>
           {
               //_fileMgr.ReadOnly = (poId == -1);
               _fileMgr.DocumentFileLink = new FileLink[] { new FileLink(Attachment.FieldPOId, poId, Company.CurrentId, FileLink.Database.TR, 0, true) };
           });

            tablePODetail.Clear();

            DataRow row = gvPO.GetDataRow(e.FocusedRowHandle);
            if (row != null && row[colId.FieldName] != DBNull.Value)
            {
                FieldPO po = FieldPO.GetFieldPO((int)row[colId.FieldName]);
                po.GetPODetails();

                po.DetailList.ForEach(x =>
                    tablePODetail.Rows.Add(
                        x.Id,
                        x.LineNum,
                        x.Description,
                        x.Level1Id,
                        x.Level2Id,
                        x.Level3Id,
                        x.Level4Id,
                        x.Component,
                        x.Billable,
                        x.Amount)
                    );
                tablePODetail.AcceptChanges();

                LoadAttachments((int)row[colId.FieldName]);
                btnSubmit.Enabled = (string)row[colStatus.FieldName] == Enum.GetName(typeof(EnumSubmitStatus), EnumSubmitStatus.Open);
                bool enabled = (string)row[colStatus.FieldName] != Enum.GetName(typeof(EnumSubmitStatus), EnumSubmitStatus.Submitted);
                SetDetailsEnabled(enabled);
            }
            else
            {
                LoadAttachments(-1);
                btnSubmit.Enabled = false;
                SetDetailsEnabled(false);
            }
        }

        void SetDetailsEnabled(bool enabled)
        {
            _fileMgr.Enabled = enabled;
            _fileMgr.ReadOnly = !enabled;

            gvDetail.OptionsBehavior.Editable = enabled;
            gvDetail.OptionsSelection.EnableAppearanceFocusedCell = enabled;
        }

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row = gvDetail.GetDataRow(e.RowHandle);
            row[colDetailBillable.FieldName] = (bool)gvPO.GetFocusedDataRow()[colBillable.FieldName];
            row[colDetailAmount.FieldName] = 0;

            gvDetail.FocusedColumn = gvDetail.Columns.First(x => x.Visible);
            SequenceDetails();
        }

        private void gvDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = gvDetail.GetDataRow(e.RowHandle);
            if (e.Column == colDetailLevel1Code)
            {
                row[colDetailLevel2Code.FieldName] = DBNull.Value;
                row[colDetailLevel3Code.FieldName] = DBNull.Value;
                row[colDetailLevel4Code.FieldName] = DBNull.Value;
            }
            else if (e.Column == colDetailLevel2Code)
            {
                row[colDetailLevel3Code.FieldName] = DBNull.Value;
                row[colDetailLevel4Code.FieldName] = DBNull.Value;
            }
            else if (e.Column == colDetailLevel3Code)
            {
                row[colDetailLevel4Code.FieldName] = DBNull.Value;
            }
            else if (e.Column == colDetailAmount)
            {
                UpdatePOAmount();
            }

            if (!gvDetail.IsNewItemRow(e.RowHandle))
            {
                if (new GridColumn[] { colDetailDescription, colDetailLevel1Code, colDetailLevel2Code, colDetailLevel3Code, colDetailLevel4Code, colDetailComponent, colDetailBillable, colDetailAmount }.Contains(e.Column))
                {
                    FieldPODetail.SqlUpdate((int)row[colDetailId.FieldName], (string)row[colDetailDescription.FieldName],
                        ConvertEx.ToNullable<int>(row[colDetailLevel1Code.FieldName]), ConvertEx.ToNullable<int>(row[colDetailLevel2Code.FieldName]),
                        ConvertEx.ToNullable<int>(row[colDetailLevel3Code.FieldName]), ConvertEx.ToNullable<int>(row[colDetailLevel4Code.FieldName]),
                        ConvertEx.CharToEnum<EnumComponentType>(row[colDetailComponent.FieldName]), (bool)row[colDetailBillable.FieldName], (decimal)row[colDetailAmount.FieldName]);

                    SetSubmitStatus(EnumSubmitStatus.Open);
                }
            }
        }

        private void UpdatePOAmount()
        {
            decimal total = 0;
            for (int i = 0; i < gvDetail.RowCount; i++)
            {
                int handle = gvDetail.GetRowHandle(i);
                total += (decimal)gvDetail.GetRowCellValue(handle, colDetailAmount.FieldName);
            }

            DataRow poRow = gvPO.GetFocusedDataRow();
            poRow[colPOAmount.FieldName] = total;
            SetSubmitStatus(EnumSubmitStatus.Open);
            FieldPO.SqlUpdateAmount((int)poRow[colId.FieldName], total);
        }

        private void SetSubmitStatus(EnumSubmitStatus status)
        {
            DataRow row = gvPO.GetFocusedDataRow();
            if (row != null && row[colStatus.FieldName] != DBNull.Value && ConvertEx.StringToEnum<EnumSubmitStatus>(row[colStatus.FieldName]) != status)
            {
                row[colStatus.FieldName] = Enum.GetName(typeof(EnumSubmitStatus), status);
                FieldPO.SqlUpdateStatus((int)row[colId.FieldName], status);
                btnSubmit.Enabled = (status == EnumSubmitStatus.Open);
            }
        }

        private void SequenceDetails()
        {
            for (int i = 0; i < gvDetail.RowCount; i++)
            {
                int handle = gvDetail.GetRowHandle(i);
                DataRow row = gvDetail.GetDataRow(handle);
                if (handle >= 0)
                {
                    if ((int)row[colDetailPOLine.FieldName] != handle+1)
                    {
                        row[colDetailPOLine.FieldName] = handle+1;
                        FieldPODetail.SqlUpdateLineNum((int)row[colDetailId.FieldName], handle+1);
                    }
                }
                else
                {
                    row[colDetailPOLine.FieldName] = i+1;
                }
            }
        }

        private void gvDetail_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (gvDetail.IsNewItemRow(e.RowHandle))
            {
                int poId = (int)gvPO.GetFocusedDataRow()[colId.FieldName];
                DataRowView row = e.Row as DataRowView;
                row[colDetailId.FieldName] = FieldPODetail.SqlInsert(poId, (int)row[colDetailPOLine.FieldName], (string)row[colDetailDescription.FieldName],
                    ConvertEx.ToNullable<int>(row[colDetailLevel1Code.FieldName]), ConvertEx.ToNullable<int>(row[colDetailLevel2Code.FieldName]),
                    ConvertEx.ToNullable<int>(row[colDetailLevel3Code.FieldName]), ConvertEx.ToNullable<int>(row[colDetailLevel4Code.FieldName]),
                    ConvertEx.CharToEnum<EnumComponentType>(row[colDetailComponent.FieldName]), (bool)row[colDetailBillable.FieldName], (decimal)row[colDetailAmount.FieldName]);

                SetSubmitStatus(EnumSubmitStatus.Open);
            }
        }

        private void gvDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = gvDetail.GetDataRow(e.RowHandle);

            var EnsureMandatoryColumn = new Func<GridColumn, string, bool>((col, msg) =>
            {
                if (row[col.FieldName] == DBNull.Value)
                {
                    e.Valid = false;
                    e.ErrorText = msg;
                    return true;
                }
                return false;
            });

            if (EnsureMandatoryColumn(colDetailDescription, "Need to enter a description.")) return;
            if (colDetailLevel1Code.Visible && EnsureMandatoryColumn(colDetailLevel1Code, $"Need to select a {colDetailLevel1Code.Caption}.")) return;
            if (colDetailLevel2Code.Visible && EnsureMandatoryColumn(colDetailLevel2Code, $"Need to select a {colDetailLevel2Code.Caption}.")) return;
            if (colDetailLevel3Code.Visible && EnsureMandatoryColumn(colDetailLevel3Code, $"Need to select a {colDetailLevel3Code.Caption}.")) return;
            if (colDetailLevel4Code.Visible && EnsureMandatoryColumn(colDetailLevel4Code, $"Need to select a {colDetailLevel4Code.Caption}.")) return;
            if (EnsureMandatoryColumn(colDetailComponent, $"Need to select a Component Type.")) return;
            if (EnsureMandatoryColumn(colDetailAmount, "Need to enter an Amount.")) return;

            if (Convert.ToDecimal(row[colDetailAmount.FieldName]) <= 0)
            {
                e.Valid = false;
                e.ErrorText = "Amount must bigger than 0.";
                return;  
            }
        }

        private void gvDetail_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            int projectId = (int)gvPO.GetFocusedDataRow()[colProjectCode.FieldName];

            DataRow row = gvDetail.GetDataRow(e.RowHandle);
            if (e.Column == colDetailLevel1Code)
            {
                var codeList = LevelOneCode.ListForProject(projectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luDetailLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luDetailLevel;
            }
            else if (e.Column == colDetailLevel2Code)
            {
                int level1Id = row[colDetailLevel1Code.FieldName] == DBNull.Value ? -1 : (int)row[colDetailLevel1Code.FieldName];
                var codeList = LevelTwoCode.SubList(level1Id, projectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luDetailLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luDetailLevel;
            }
            else if (e.Column == colDetailLevel3Code)
            {
                int level2Id = row[colDetailLevel2Code.FieldName] == DBNull.Value ? -1 : (int)row[colDetailLevel2Code.FieldName];
                var codeList = LevelThreeCode.SubList(level2Id, projectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luDetailLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luDetailLevel;
            }
            else if (e.Column == colDetailLevel4Code)
            {
                int level3Id = row[colDetailLevel3Code.FieldName] == DBNull.Value ? -1 : (int)row[colDetailLevel3Code.FieldName];
                var codeList = LevelFourCode.SubList(level3Id, projectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luDetailLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luDetailLevel;
            }
        }

        private void gvDetail_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            DataRow row = gvDetail.GetDataRow(e.RowHandle);
            FieldPODetail.SqlDelete((int)row[colDetailId.FieldName]);
        }

        private void gvDetail_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            UpdatePOAmount();
            SequenceDetails();

            SetSubmitStatus(EnumSubmitStatus.Open);
        }

        private void LookupEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                (sender as LookUpEdit).EditValue = null;
            }
        }

        private void gvPO_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var row = gvPO.GetDataRow(gvPO.FocusedRowHandle);
            e.Cancel = GetEnumName(EnumSubmitStatus.Submitted) == Convert.ToString(row[colStatus.FieldName]);
        }

        private void gvDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;

            if (column == colDetailAmount)
            {
                if (e.Value != null && Convert.ToInt32(e.Value) < 0)
                {
                    e.ErrorText = "Invalid Amount.";
                    e.Valid = false;
                    return;
                }
            }
        }
    }
}
