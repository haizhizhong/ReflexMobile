using System.Data;
using System.Linq;
using MobileData;
using System;
using static WS_Popups.frmPopup;
using DevExpress.XtraGrid.Views.Grid;
using static MobileData.Equipment;
using DevExpress.XtraEditors;
using ReflexCommon;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;

namespace MobileLEM
{
    public partial class ucEquipmentEntry : DevExpress.XtraEditors.XtraUserControl
    {
        LemHeader _headerRecord;

        public ucEquipmentEntry()
        {
            InitializeComponent();

            luColEquipNum.DataSource = Equipment.ListForCompany().Select(e => new
            {
                EqpNum = e.EqpNum,
                AssetCode = e.AssetCode,
                DisplayName = e.DisplayName,
                Class = EquipmentClass.GetEquipmentClass(e.ClassCode)?.Desc,
                Category = EquipmentCategory.GetEquipmentCategory(e.CategoryCode)?.Desc
            }).ToList();

            luColAssertNum.DataSource = Equipment.ListForCompany().Select(e => new
            {
                EqpNum = e.EqpNum,
                AssetCode = e.AssetCode,
                DisplayName = e.DisplayName,
                Class = EquipmentClass.GetEquipmentClass(e.ClassCode)?.Desc,
                Category = EquipmentCategory.GetEquipmentCategory(e.CategoryCode)?.Desc
            }).ToList();

            var level1CodeList = LevelOneCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luColLevel1All.DataSource = level1CodeList.OrderBy(x => x.MatchId);

            var level2CodeList = LevelTwoCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luColLevel2All.DataSource = level2CodeList.OrderBy(x => x.MatchId);

            var level3CodeList = LevelThreeCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luColLevel3All.DataSource = level3CodeList.OrderBy(x => x.MatchId);

            var level4CodeList = LevelFourCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luColLevel4All.DataSource = level4CodeList.OrderBy(x => x.MatchId);

            luColBillCycleAll.DataSource = Enum.GetValues(typeof(EnumBillCycle)).Cast<EnumBillCycle>().Select(x => new { Enum = (char)x, Desc = Enum.GetName(typeof(EnumBillCycle), x) });

            int maxLevel = Company.GetCurrCompany().MaxLevelCode;
            var SetColumn = new Action<GridColumn, int, string>((col, level, caption) =>
            {
                col.Visible = maxLevel >= level;
                col.OptionsColumn.ShowInCustomizationForm = maxLevel >= level;
                col.Caption = caption;
            });

            SetColumn(colLevel4Code, 4, Company.GetCurrCompany().Level4CodeDesc);
            SetColumn(colLevel3Code, 3, Company.GetCurrCompany().Level3CodeDesc);
            SetColumn(colLevel2Code, 2, Company.GetCurrCompany().Level2CodeDesc);
            SetColumn(colLevel1Code, 1, Company.GetCurrCompany().Level1CodeDesc);
        }

        public void SetCurrent(LemHeader header)
        {
            _headerRecord = header;
            SetEnabled(_headerRecord.CheckEditable());

            var changeOrderList = ChangeOrder.ListForProject(_headerRecord.ProjectId).Select(cs => new { EstimateId = cs.EstimateId, DisplayName = cs.DisplayName }).Distinct().ToList();
            luChangeOrder.DataSource = changeOrderList;

            tableEquipEntry.Clear();
            EquipTimeEntry.GetEquipEntryList(header.Id).ToList().ForEach(x =>
            {
               var equip = Equipment.GetEquipment(x.EqpNum);
               double? billRate = null;
               if (equip != null)
               {
                   var list = equip.GetBillRateList(_headerRecord.ProjectId);
                   billRate = (double?)list.SingleOrDefault(c => c.BillCycle == x.BillCycle)?.BillRate;
                }

                tableEquipEntry.Rows.Add(
                   x.Id,
                   x.EqpNum,
                   x.EqpNum,
                   EquipmentClass.GetEquipmentClass(equip.ClassCode)?.DisplayName ?? "",
                   x.EmpNum,
                   x.EmpNum != null ? Employee.GetEmployee(x.EmpNum.Value).DisplayName : "",
                   x.ChangeOrderId,
                   x.Level1Id,
                   x.Level2Id,
                   x.Level3Id,
                   x.Level4Id,
                   x.Billable,
                   x.Quantity,
                   (char)x.BillCycle,
                   billRate,
                   x.BillAmount);
            });
            tableEquipEntry.AcceptChanges();
        }

        private void gvEquipment_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            DataRow row = gvEquipment.GetDataRow(e.RowHandle);
            if (e.Column == colBillCycle)
            {
                var equip = Equipment.GetEquipment(Convert.ToString(row[colEqpNum.FieldName]));
                var list = equip.GetBillRateList(_headerRecord.ProjectId);
                list.Add(new EquipmentBillRate { BillCycle = EnumBillCycle.Unknown, BillRate = 0, IsDefault = false });

                luColBillCycle.DataSource = list.Select(x => new
                {
                    Enum = (char)x.BillCycle,
                    Cycle = Enum.GetName(typeof(EnumBillCycle), x.BillCycle),
                    BillRate = (x.BillRate == 0 ? "" : x.BillRate.ToString("N2")),
                    IsDefault = x.IsDefault ? "*" : ""
                });
                e.RepositoryItem = luColBillCycle;
            }
            else if (e.Column == colLevel1Code)
            {
                var codeList = LevelOneCode.ListForProject(_headerRecord.ProjectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luColLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luColLevel;
            }
            else if (e.Column == colLevel2Code)
            {
                int level1Id = row[colLevel1Code.FieldName] == DBNull.Value ? -1 : (int)row[colLevel1Code.FieldName];
                var codeList = LevelTwoCode.SubList(level1Id, _headerRecord.ProjectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luColLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luColLevel;
            }
            else if (e.Column == colLevel3Code)
            {
                int level2Id = row[colLevel2Code.FieldName] == DBNull.Value ? -1 : (int)row[colLevel2Code.FieldName];
                var codeList = LevelThreeCode.SubList(level2Id, _headerRecord.ProjectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luColLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luColLevel;
            }
            else if (e.Column == colLevel4Code)
            {
                int level3Id = row[colLevel3Code.FieldName] == DBNull.Value ? -1 : (int)row[colLevel3Code.FieldName];
                var codeList = LevelThreeCode.SubList(level3Id, _headerRecord.ProjectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luColLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luColLevel;
            }
        }

        private void gvEquipment_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow row = gvEquipment.GetDataRow(e.RowHandle);
            var project = Project.GetProject(_headerRecord.ProjectId);
            row[colBillable.FieldName] = project.Billable;

            gvEquipment.FocusedColumn = gvEquipment.Columns.First(x => x.Visible);
        }

        private void gvEquipment_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = gvEquipment.GetDataRow(e.RowHandle);
            if (e.Column == colEqpNum || e.Column == colAssetDescription)
            {
                string eqtNum = Convert.ToString(row[e.Column.FieldName]);
                row[colEqpNum.FieldName] = eqtNum;
                row[colAssetDescription.FieldName] = eqtNum;
                var equip = Equipment.GetEquipment(eqtNum);
                row[colEquipmentClass.FieldName] = EquipmentClass.GetEquipmentClass(equip.ClassCode)?.DisplayName ?? "";

                Employee employee = (equip.OwnerType == EnumOwnerType.Employee) ? EquipmentAssignment.GetEmployee(equip.EqpNum, _headerRecord.LogDate) : null;
                row[colEmpNum.FieldName] = (object)employee?.EmpNum ?? DBNull.Value;
                row[colEmployeeName.FieldName] = employee?.DisplayName ?? "";

                RefreshBillRate(row);
            }
            else if (e.Column == colLevel1Code)
            {
                row[colLevel2Code.FieldName] = DBNull.Value;
                row[colLevel3Code.FieldName] = DBNull.Value;
                row[colLevel4Code.FieldName] = DBNull.Value;
            }
            else if (e.Column == colLevel2Code)
            {
                row[colLevel3Code.FieldName] = DBNull.Value;
                row[colLevel4Code.FieldName] = DBNull.Value;
            }
            else if (e.Column == colLevel3Code)
            {
                row[colLevel4Code.FieldName] = DBNull.Value;
            }
            else if (e.Column == colBillCycle)
            {
                RefreshBillRate(row);
            }
            else if (e.Column == colQuantity)
            {
                RefreshBillAmount(row);
            }

            if (!gvEquipment.IsNewItemRow(e.RowHandle))
            {
                if (new GridColumn[] { colEqpNum, colAssetDescription, colChangeOrder, colLevel1Code, colLevel2Code, colLevel3Code, colLevel4Code, colBillable, colQuantity, colBillCycle }.Contains(e.Column))
                {
                    EquipTimeEntry.SqlUpdate((int)row[colId.FieldName], (string)row[colEqpNum.FieldName], ConvertEx.ToNullable<int>(row[colEmpNum.FieldName]), ConvertEx.ToNullable<int>(row[colChangeOrder.FieldName]),
                        ConvertEx.ToNullable<int>(row[colLevel1Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel2Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel3Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel4Code.FieldName]),
                        (bool)row[colBillable.FieldName], ConvertEx.ToNullable<decimal>(row[colQuantity.FieldName]) ?? 0, ConvertEx.CharToEnum<EnumBillCycle>(row[colBillCycle.FieldName]), ConvertEx.ToNullable<decimal>(row[colBillAmount.FieldName]));

                    LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
                }
            }
        }

        void RefreshBillRate(DataRow row)
        {
            var equip = Equipment.GetEquipment(Convert.ToString(row[colEqpNum.FieldName]));
            if (equip != null && row[colBillCycle.FieldName] != DBNull.Value)
            {
                EnumBillCycle cycle = ConvertEx.CharToEnum<EnumBillCycle>(row[colBillCycle.FieldName]);
                var list = equip.GetBillRateList(_headerRecord.ProjectId);
                row[colBillRate.FieldName] = (object)list.SingleOrDefault(x => x.BillCycle == cycle)?.BillRate ?? DBNull.Value;
            }
            else
            {
                row[colBillRate.FieldName] = DBNull.Value;
            }
            RefreshBillAmount(row);
        }

        void RefreshBillAmount(DataRow row)
        {
            if (row[colBillRate.FieldName] != DBNull.Value && row[colQuantity.FieldName] != DBNull.Value)
            {
                row[colBillAmount.FieldName] = Convert.ToDecimal(row[colBillRate.FieldName]) * Convert.ToDecimal(row[colQuantity.FieldName]);
            }
            else
            {
                row[colBillAmount.FieldName] = DBNull.Value;
            }
        }

        private void gvEquipment_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = gvEquipment.GetDataRow(e.RowHandle);

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

            if (EnsureMandatoryColumn(colEqpNum, "Must select an Equipment.")) return;
            if (EnsureMandatoryColumn(colQuantity, "Need to enter Quantity.")) return;
            if (EnsureMandatoryColumn(colBillCycle, "Must select a Bill Cycle.")) return;

            if (colLevel1Code.Visible && EnsureMandatoryColumn(colLevel1Code, $"Need to select a {colLevel1Code.Caption}.")) return;
            if (colLevel2Code.Visible && EnsureMandatoryColumn(colLevel2Code, $"Need to select a {colLevel2Code.Caption}.")) return;
            if (colLevel3Code.Visible && EnsureMandatoryColumn(colLevel3Code, $"Need to select a {colLevel3Code.Caption}.")) return;
            if (colLevel4Code.Visible && EnsureMandatoryColumn(colLevel4Code, $"Need to select a {colLevel4Code.Caption}.")) return;
        }

        void SetEnabled(bool enabled)
        {
            gvEquipment.OptionsBehavior.Editable = enabled;
            gvEquipment.OptionsSelection.EnableAppearanceFocusedCell = enabled;
        }

        public void LoadFromPrevDay()
        {
            if (EquipTimeEntry.CopyDataFromPrevDay(_headerRecord.ProjectId, _headerRecord.LogDate, _headerRecord.Id))
            {
                SetCurrent(_headerRecord);
                LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
            }
            else
            {
                GuiCommon.ShowMessage("The previous day data is not available.");
            }
        }

        public void LoadFromTemplate()
        {
            if (EquipTimeEntry.CopyDataFromTemplate(_headerRecord.ProjectId, _headerRecord.LogDate, _headerRecord.Id))
            {
                SetCurrent(_headerRecord);
                LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
            }
            else
            {
                GuiCommon.ShowMessage("The template data is not available.");
            }
        }

        private void gvEquipment_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (gvEquipment.IsNewItemRow(e.RowHandle))
            {
                DataRowView row = e.Row as DataRowView;
                row[colId.FieldName] = EquipTimeEntry.SqlInsert(_headerRecord.Id, (string)row[colEqpNum.FieldName], ConvertEx.ToNullable<int>(row[colEmpNum.FieldName]), ConvertEx.ToNullable<int>(row[colChangeOrder.FieldName]),
                    ConvertEx.ToNullable<int>(row[colLevel1Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel2Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel3Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel4Code.FieldName]),
                    (bool)row[colBillable.FieldName], ConvertEx.ToNullable<decimal>(row[colQuantity.FieldName]) ?? 0, ConvertEx.CharToEnum<EnumBillCycle>(row[colBillCycle.FieldName]), ConvertEx.ToNullable<decimal>(row[colBillAmount.FieldName]));

                LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
            }
        }

        private void gvEquipment_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (GuiCommon.ShowMessage("Delete Record?", "Confirmation", PopupType.Yes_No) == PopupResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DataRow row = gvEquipment.GetDataRow(e.RowHandle);
                EquipTimeEntry.DeleteEntry((int)row[colId.FieldName]);

                LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
            }
        }

        private void LookupEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                (sender as LookUpEdit).EditValue = null;
            }
        }

        private void gvEquipment_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;

            if (column == colQuantity)
            {
                if (e.Value != null && Convert.ToInt32(e.Value) < 0)
                {
                    e.ErrorText = "Invalid Quantity value.";
                    e.Valid = false;
                    return; 
                }
            }
        }
    }
}
