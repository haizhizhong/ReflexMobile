using System.Data;
using System.Linq;
using MobileData;
using System;
using static WS_Popups.frmPopup;
using DevExpress.XtraGrid.Views.Grid;
using static MobileData.Equipment;

namespace MobileLEM
{
    public partial class ucTabEquipment : DevExpress.XtraEditors.XtraUserControl
    {
        LemLogHeader _headerRecord;

        class ColName
        {
            public const string Id = "Id";
            public const string EquipNum = "EquipNum";
            public const string AssetDescription = "AssetDescription";
            public const string EquipmentClass = "EquipmentClass";
            public const string EmpNum = "EmpNum";
            public const string EmployeeName = "EmployeeName";
            public const string Level1Code = "Level1Code";
            public const string Level2Code = "Level2Code";
            public const string Billable = "Billable";
            public const string Quantity = "Quantity";
            public const string BillCycle = "BillCycle";
            public const string BillRate = "BillRate";
            public const string BillAmount = "BillAmount";
        };

        public ucTabEquipment()
        {
            InitializeComponent();
        }

         public void Init()
         {
            luColEquip.DataSource = Equipment.ListForCompany().Select(e => new { EqpNum = e.EqpNum, AssetCode = e.AssetCode, Desc = e.Desc, FullDisplay = $"{e.AssetCode}\t\t{e.Desc}\t\t{EquipmentClass.GetEquipmentClass(e.ClassCode)?.Desc}" }).Distinct().ToList();

            var level1CodeList = LevelOneCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Desc = code.Desc, FullDisplay = $"{code.MatchId}\t{code.Desc}" }).Distinct().ToList();
            level1CodeList.Add(new { MatchId = -1, Desc = StringEx.TextUnknown, FullDisplay = "" });
            luColLevel1.DataSource = level1CodeList.OrderBy(x => x.MatchId);

            var level2CodeList = LevelTwoCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Desc = code.Desc, FullDisplay = $"{code.MatchId}\t{code.Desc}" }).Distinct().ToList();
            level2CodeList.Add(new { MatchId = -1, Desc = StringEx.TextUnknown, FullDisplay = "" });
            luColLevel2All.DataSource = level2CodeList.OrderBy(x => x.MatchId);

            luColBillCycle.DataSource = Enum.GetValues(typeof(EnumBillCycle)).Cast<EnumBillCycle>().Select(x => new { Enum = (char)x, Desc = Enum.GetName(typeof(EnumBillCycle), x) });
        }

        public void SetModify(LemLogHeader header)
        {
            _headerRecord = header;
            SetEnabled();

            tableEquipEntry.Clear();
            EquipTimeEntry.GetEquipEntryList(header.Id).ToList().ForEach( x=>
            {
                var equip = Equipment.GetEquipment(x.EqpNum);
                double? billRate = null;
                if (equip != null && equip.BillRateList.ContainsKey(x.BillCycle))
                {
                    billRate = (double?)equip.BillRateList[x.BillCycle];
                }

                tableEquipEntry.Rows.Add(
                    x.Id,
                    x.EqpNum,
                    equip.Desc ?? "",
                    EquipmentClass.GetEquipmentClass(equip.ClassCode)?.Desc ?? "",
                    Employee.GetEmployee(equip.EmpNum)?.EmpNum.ToString() ?? "",
                    Employee.GetEmployee(equip.EmpNum)?.GetFullName() ?? "",
                    x.Level1Id,
                    x.Level2Id,
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
            if (e.Column.FieldName == ColName.Level2Code)
            {
                DataRow row = gvEquipment.GetDataRow(e.RowHandle);
                if (row != null)
                {
                    int level1Id = (int)row[ColName.Level1Code];
                    var codeList = LevelTwoCode.SubList(level1Id).Select(code => new { MatchId = code.MatchId, Desc = code.Desc, FullDisplay = $"{code.MatchId}\t{code.Desc}" }).Distinct().ToList();
                    codeList.Insert(0, new { MatchId = -1, Desc = StringEx.TextUnknown, FullDisplay = "" });
                    luColLevel2.DataSource = codeList.OrderBy(x => x.MatchId);
                    e.RepositoryItem = luColLevel2;
                }
            }
        }

        private void gvEquipment_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow row = gvEquipment.GetDataRow(e.RowHandle);
            var project = Project.GetProject(_headerRecord.ProjectId);
            row[ColName.Billable] = project.Billable;
        }

        private void gvEquipment_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == ColName.EquipNum)
            {
                DataRow row = gvEquipment.GetDataRow(e.RowHandle);
                var equip = Equipment.GetEquipment(Convert.ToString(row[ColName.EquipNum]));
                row[ColName.AssetDescription] = equip.Desc;
                row[ColName.EquipmentClass] = EquipmentClass.GetEquipmentClass(equip.ClassCode)?.Desc ?? "";
                row[ColName.EmpNum] = Employee.GetEmployee(equip.EmpNum)?.EmpNum.ToString() ?? "";
                row[ColName.EmployeeName] = Employee.GetEmployee(equip.EmpNum)?.GetFullName() ?? "";

                RefreshBillRate(row);
            }

            if (e.Column.FieldName == ColName.Level1Code)
            {
                DataRow row = gvEquipment.GetDataRow(e.RowHandle);
                row[ColName.Level2Code] = -1;
            }

            if (e.Column.FieldName == ColName.BillCycle)
            {
                DataRow row = gvEquipment.GetDataRow(e.RowHandle);
                RefreshBillRate(row);
            }

            if (e.Column.FieldName == ColName.Quantity)
            {
                DataRow row = gvEquipment.GetDataRow(e.RowHandle);
                RefreshBillAmount(row);
            }

            if (!gvEquipment.IsNewItemRow(e.RowHandle))
            {
                if (new string[] { ColName.EquipNum, ColName.Level1Code, ColName.Level2Code, ColName.Billable, ColName.Quantity, ColName.BillCycle }.Contains(e.Column.FieldName))
                {
                    DataRow row = gvEquipment.GetDataRow(e.RowHandle);
                    EquipTimeEntry.SqlUpdate((int)row[ColName.Id], (string)row[ColName.EquipNum], ConvertEx.ToNullable<int>(row[ColName.Level1Code]), ConvertEx.ToNullable<int>(row[ColName.Level2Code]),
                        (bool)row[ColName.Billable], (decimal)row[ColName.Quantity], ConvertEx.ToEnum<EnumBillCycle>((char)row[ColName.BillCycle]), ConvertEx.ToNullable<decimal>(row[ColName.BillAmount]));
                }
            }
        }

        void RefreshBillRate(DataRow row)
        {
            var equip = Equipment.GetEquipment(Convert.ToString(row[ColName.EquipNum]));
            if (equip != null && row[ColName.BillCycle] != DBNull.Value)
            {
                EnumBillCycle cycle = ConvertEx.ToEnum<EnumBillCycle>((char)row[ColName.BillCycle]);
                if (equip.BillRateList.ContainsKey(cycle))
                {
                    row[ColName.BillRate] = equip.BillRateList[cycle];
                }
                else
                {
                    row[ColName.BillRate] = DBNull.Value;
                }
            }
            else
            {
                row[ColName.BillRate] = DBNull.Value;
            }
            RefreshBillAmount(row);
        }

        void RefreshBillAmount(DataRow row)
        {
            if (row[ColName.BillRate] != DBNull.Value && row[ColName.Quantity] != DBNull.Value)
            {
                row[ColName.BillAmount] = Convert.ToDecimal(row[ColName.BillRate]) * Convert.ToDecimal(row[ColName.Quantity]);
            }
            else
            {
                row[ColName.BillAmount] = DBNull.Value;
            }
        }

        private void gvEquipment_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = gvEquipment.GetDataRow(e.RowHandle);
            if (row[ColName.EquipNum] == DBNull.Value || Convert.ToInt32(row[ColName.EquipNum]) <= 0)
            {
                e.Valid = false;
                e.ErrorText = "Must select an Equipmant.";
                return;
            }

            if (row[ColName.Quantity] == DBNull.Value)
            {
                e.Valid = false;
                e.ErrorText = "Need to enter Quntity.";
                return;
            }

            if (row[ColName.BillCycle] == DBNull.Value)
            {
                e.Valid = false;
                e.ErrorText = "Must select a Bill Cycle.";
                return;
            }

            if (row[ColName.Id] == DBNull.Value)
            {
                row[ColName.Id] = -1;
            }
        }

        void SetEnabled()
        {
            gcEquipment.Enabled = (_headerRecord.LogStatus == EnumLogStatus.Open);
        }

        public void LoadFromPrevDay()
        {
            if (EquipTimeEntry.CopyDataFromPrevDay(_headerRecord.ProjectId, _headerRecord.LogDate, _headerRecord.Id))
            {
                SetModify(_headerRecord);
            }
            else
            {
                Common.Popups.ShowPopup("The data of previous day is not available.");
            }
        }

        public void LoadFromTemplate()
        {
            if (EquipTimeEntry.CopyDataFromTemplate(_headerRecord.ProjectId, _headerRecord.LogDate, _headerRecord.Id))
            {
                SetModify(_headerRecord);
            }
            else
            {
                Common.Popups.ShowPopup("The data of template is not available.");
            }
        }

        private void gvEquipment_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (gvEquipment.IsNewItemRow(e.RowHandle))
            {
                DataRowView row = e.Row as DataRowView;
                row[ColName.Id] = EquipTimeEntry.SqlInsert(_headerRecord.Id, (string)row[ColName.EquipNum], ConvertEx.ToNullable<int>(row[ColName.Level1Code]), ConvertEx.ToNullable<int>(row[ColName.Level2Code]),
                    (bool)row[ColName.Billable], (decimal)row[ColName.Quantity], ConvertEx.ToEnum<EnumBillCycle>((char)row[ColName.BillCycle]), ConvertEx.ToNullable<decimal>(row[ColName.BillAmount]));
            }
        }

        private void gvEquipment_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (Common.Popups.ShowPopup(this, "Delete Record?", "Confirmation", PopupType.Yes_No) == PopupResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DataRow row = gvEquipment.GetDataRow(e.RowHandle);
                EquipTimeEntry.SqlDelete((int)row[ColName.Id]);
            }
        }
    }
}
