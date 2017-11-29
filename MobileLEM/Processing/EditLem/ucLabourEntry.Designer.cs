namespace MobileLEM
{
    partial class ucLabourEntry
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gcLabour = new DevExpress.XtraGrid.GridControl();
            this.dataSet1 = new System.Data.DataSet();
            this.tableLabour = new System.Data.DataTable();
            this.dataColId = new System.Data.DataColumn();
            this.dataColEmpNum = new System.Data.DataColumn();
            this.dataColEmpName = new System.Data.DataColumn();
            this.dataColWorkClass = new System.Data.DataColumn();
            this.dataColChangeOrder = new System.Data.DataColumn();
            this.dataColLevel1 = new System.Data.DataColumn();
            this.dataColLevel2 = new System.Data.DataColumn();
            this.dataColLevel3 = new System.Data.DataColumn();
            this.dataColLevel4 = new System.Data.DataColumn();
            this.dataColBillable = new System.Data.DataColumn();
            this.dataColManual = new System.Data.DataColumn();
            this.dataColIncludedHours = new System.Data.DataColumn();
            this.dataColTotalHours = new System.Data.DataColumn();
            this.dataColBillAmount = new System.Data.DataColumn();
            this.gvLabour = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColEmpNum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColEmpName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colWorkClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColWorkClass = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colChangeOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luChangeOrder = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLevel1Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel1All = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLevel2Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel2All = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLevel3Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel3All = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLevel4Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel4All = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBillable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkColBillable = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colManual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkColManual = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIncludedHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textColHours = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.textColAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.luColLevel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLabour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLabour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLabour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColEmpNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColEmpName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColWorkClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luChangeOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel1All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel3All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel4All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkColBillable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkColManual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // gcLabour
            // 
            this.gcLabour.DataMember = "LabourTimeEntry";
            this.gcLabour.DataSource = this.dataSet1;
            this.gcLabour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLabour.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcLabour.Location = new System.Drawing.Point(0, 0);
            this.gcLabour.MainView = this.gvLabour;
            this.gcLabour.Name = "gcLabour";
            this.gcLabour.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.luColLevel1All,
            this.luColLevel2All,
            this.luColLevel3All,
            this.luColLevel4All,
            this.luColEmpNum,
            this.luColEmpName,
            this.luColWorkClass,
            this.chkColBillable,
            this.textColHours,
            this.textColAmount,
            this.luColLevel,
            this.luChangeOrder,
            this.chkColManual});
            this.gcLabour.Size = new System.Drawing.Size(1301, 577);
            this.gcLabour.TabIndex = 2;
            this.gcLabour.UseDisabledStatePainter = false;
            this.gcLabour.UseEmbeddedNavigator = true;
            this.gcLabour.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLabour});
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.tableLabour});
            // 
            // tableLabour
            // 
            this.tableLabour.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColId,
            this.dataColEmpNum,
            this.dataColEmpName,
            this.dataColWorkClass,
            this.dataColChangeOrder,
            this.dataColLevel1,
            this.dataColLevel2,
            this.dataColLevel3,
            this.dataColLevel4,
            this.dataColBillable,
            this.dataColManual,
            this.dataColIncludedHours,
            this.dataColTotalHours,
            this.dataColBillAmount});
            this.tableLabour.TableName = "LabourTimeEntry";
            // 
            // dataColId
            // 
            this.dataColId.ColumnName = "Id";
            this.dataColId.DataType = typeof(int);
            // 
            // dataColEmpNum
            // 
            this.dataColEmpNum.ColumnName = "EmpNum";
            this.dataColEmpNum.DataType = typeof(int);
            // 
            // dataColEmpName
            // 
            this.dataColEmpName.ColumnName = "EmployeeName";
            this.dataColEmpName.DataType = typeof(int);
            // 
            // dataColWorkClass
            // 
            this.dataColWorkClass.ColumnName = "WorkClass";
            // 
            // dataColChangeOrder
            // 
            this.dataColChangeOrder.ColumnName = "ChangeOrder";
            this.dataColChangeOrder.DataType = typeof(int);
            // 
            // dataColLevel1
            // 
            this.dataColLevel1.ColumnName = "Level1Code";
            this.dataColLevel1.DataType = typeof(int);
            // 
            // dataColLevel2
            // 
            this.dataColLevel2.ColumnName = "Level2Code";
            this.dataColLevel2.DataType = typeof(int);
            // 
            // dataColLevel3
            // 
            this.dataColLevel3.ColumnName = "Level3Code";
            this.dataColLevel3.DataType = typeof(int);
            // 
            // dataColLevel4
            // 
            this.dataColLevel4.ColumnName = "Level4Code";
            this.dataColLevel4.DataType = typeof(int);
            // 
            // dataColBillable
            // 
            this.dataColBillable.ColumnName = "Billable";
            this.dataColBillable.DataType = typeof(bool);
            // 
            // dataColManual
            // 
            this.dataColManual.ColumnName = "Manual";
            this.dataColManual.DataType = typeof(bool);
            // 
            // dataColIncludedHours
            // 
            this.dataColIncludedHours.ColumnName = "IncludedHours";
            this.dataColIncludedHours.DataType = typeof(decimal);
            // 
            // dataColTotalHours
            // 
            this.dataColTotalHours.ColumnName = "TotalHours";
            this.dataColTotalHours.DataType = typeof(decimal);
            // 
            // dataColBillAmount
            // 
            this.dataColBillAmount.ColumnName = "BillAmount";
            this.dataColBillAmount.DataType = typeof(decimal);
            // 
            // gvLabour
            // 
            this.gvLabour.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colEmpNum,
            this.colEmployeeName,
            this.colWorkClass,
            this.colChangeOrder,
            this.colLevel1Code,
            this.colLevel2Code,
            this.colLevel3Code,
            this.colLevel4Code,
            this.colBillable,
            this.colManual,
            this.colIncludedHours,
            this.colTotalHours,
            this.colBillAmount});
            this.gvLabour.GridControl = this.gcLabour;
            this.gvLabour.Name = "gvLabour";
            this.gvLabour.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLabour.OptionsView.ColumnAutoWidth = false;
            this.gvLabour.OptionsView.ShowFooter = true;
            this.gvLabour.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvEmployee_CustomRowCellEditForEditing);
            this.gvLabour.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvEmployee_InitNewRow);
            this.gvLabour.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvEmployee_CellValueChanged);
            this.gvLabour.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gvLabour_RowDeleting);
            this.gvLabour.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvEmployee_ValidateRow);
            this.gvLabour.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvLabour_RowUpdated);
            this.gvLabour.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvLabour_ValidatingEditor);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colEmpNum
            // 
            this.colEmpNum.Caption = "Emp No";
            this.colEmpNum.ColumnEdit = this.luColEmpNum;
            this.colEmpNum.FieldName = "EmpNum";
            this.colEmpNum.Name = "colEmpNum";
            this.colEmpNum.Visible = true;
            this.colEmpNum.VisibleIndex = 0;
            // 
            // luColEmpNum
            // 
            this.luColEmpNum.AutoHeight = false;
            this.luColEmpNum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColEmpNum.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpNum", "Emp #"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", "Name")});
            this.luColEmpNum.DisplayMember = "EmpNum";
            this.luColEmpNum.Name = "luColEmpNum";
            this.luColEmpNum.NullText = "";
            this.luColEmpNum.ValueMember = "EmpNum";
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.ColumnEdit = this.luColEmpName;
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            // 
            // luColEmpName
            // 
            this.luColEmpName.AutoHeight = false;
            this.luColEmpName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColEmpName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpNum", "Emp #"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", "Name")});
            this.luColEmpName.DisplayMember = "DisplayName";
            this.luColEmpName.Name = "luColEmpName";
            this.luColEmpName.NullText = "";
            this.luColEmpName.ValueMember = "EmpNum";
            // 
            // colWorkClass
            // 
            this.colWorkClass.ColumnEdit = this.luColWorkClass;
            this.colWorkClass.FieldName = "WorkClass";
            this.colWorkClass.Name = "colWorkClass";
            this.colWorkClass.Visible = true;
            this.colWorkClass.VisibleIndex = 2;
            // 
            // luColWorkClass
            // 
            this.luColWorkClass.AutoHeight = false;
            this.luColWorkClass.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColWorkClass.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", "WorkClass #")});
            this.luColWorkClass.DisplayMember = "DisplayName";
            this.luColWorkClass.Name = "luColWorkClass";
            this.luColWorkClass.NullText = "";
            this.luColWorkClass.ValueMember = "Code";
            // 
            // colChangeOrder
            // 
            this.colChangeOrder.Caption = "Change Order";
            this.colChangeOrder.ColumnEdit = this.luChangeOrder;
            this.colChangeOrder.FieldName = "ChangeOrder";
            this.colChangeOrder.Name = "colChangeOrder";
            this.colChangeOrder.Visible = true;
            this.colChangeOrder.VisibleIndex = 3;
            // 
            // luChangeOrder
            // 
            this.luChangeOrder.AutoHeight = false;
            this.luChangeOrder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luChangeOrder.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", "Change Order")});
            this.luChangeOrder.DisplayMember = "DisplayName";
            this.luChangeOrder.Name = "luChangeOrder";
            this.luChangeOrder.NullText = "";
            this.luChangeOrder.ValueMember = "EstimateId";
            this.luChangeOrder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.LookupEdit_ButtonClick);
            // 
            // colLevel1Code
            // 
            this.colLevel1Code.Caption = "Level1 Code";
            this.colLevel1Code.ColumnEdit = this.luColLevel1All;
            this.colLevel1Code.FieldName = "Level1Code";
            this.colLevel1Code.Name = "colLevel1Code";
            this.colLevel1Code.Visible = true;
            this.colLevel1Code.VisibleIndex = 4;
            // 
            // luColLevel1All
            // 
            this.luColLevel1All.AutoHeight = false;
            this.luColLevel1All.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luColLevel1All.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Description")});
            this.luColLevel1All.DisplayMember = "DisplayName";
            this.luColLevel1All.Name = "luColLevel1All";
            this.luColLevel1All.NullText = "";
            this.luColLevel1All.ValueMember = "MatchId";
            this.luColLevel1All.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.LookupEdit_ButtonClick);
            // 
            // colLevel2Code
            // 
            this.colLevel2Code.Caption = "Level2 Code";
            this.colLevel2Code.ColumnEdit = this.luColLevel2All;
            this.colLevel2Code.FieldName = "Level2Code";
            this.colLevel2Code.Name = "colLevel2Code";
            this.colLevel2Code.Visible = true;
            this.colLevel2Code.VisibleIndex = 5;
            // 
            // luColLevel2All
            // 
            this.luColLevel2All.AutoHeight = false;
            this.luColLevel2All.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luColLevel2All.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Description")});
            this.luColLevel2All.DisplayMember = "DisplayName";
            this.luColLevel2All.Name = "luColLevel2All";
            this.luColLevel2All.NullText = "";
            this.luColLevel2All.ValueMember = "MatchId";
            this.luColLevel2All.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.LookupEdit_ButtonClick);
            // 
            // colLevel3Code
            // 
            this.colLevel3Code.Caption = "Level3 Code";
            this.colLevel3Code.ColumnEdit = this.luColLevel3All;
            this.colLevel3Code.FieldName = "Level3Code";
            this.colLevel3Code.Name = "colLevel3Code";
            this.colLevel3Code.Visible = true;
            this.colLevel3Code.VisibleIndex = 6;
            // 
            // luColLevel3All
            // 
            this.luColLevel3All.AutoHeight = false;
            this.luColLevel3All.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luColLevel3All.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Description")});
            this.luColLevel3All.DisplayMember = "DisplayName";
            this.luColLevel3All.Name = "luColLevel3All";
            this.luColLevel3All.NullText = "";
            this.luColLevel3All.ValueMember = "MatchId";
            this.luColLevel3All.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.LookupEdit_ButtonClick);
            // 
            // colLevel4Code
            // 
            this.colLevel4Code.Caption = "Level4 Code";
            this.colLevel4Code.ColumnEdit = this.luColLevel4All;
            this.colLevel4Code.FieldName = "Level4Code";
            this.colLevel4Code.Name = "colLevel4Code";
            this.colLevel4Code.Visible = true;
            this.colLevel4Code.VisibleIndex = 7;
            // 
            // luColLevel4All
            // 
            this.luColLevel4All.AutoHeight = false;
            this.luColLevel4All.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luColLevel4All.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Description")});
            this.luColLevel4All.DisplayMember = "DisplayName";
            this.luColLevel4All.Name = "luColLevel4All";
            this.luColLevel4All.NullText = "";
            this.luColLevel4All.ValueMember = "MatchId";
            this.luColLevel4All.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.LookupEdit_ButtonClick);
            // 
            // colBillable
            // 
            this.colBillable.Caption = "Billable";
            this.colBillable.ColumnEdit = this.chkColBillable;
            this.colBillable.FieldName = "Billable";
            this.colBillable.Name = "colBillable";
            this.colBillable.Visible = true;
            this.colBillable.VisibleIndex = 8;
            // 
            // chkColBillable
            // 
            this.chkColBillable.AutoHeight = false;
            this.chkColBillable.Name = "chkColBillable";
            this.chkColBillable.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colManual
            // 
            this.colManual.Caption = "Manual";
            this.colManual.ColumnEdit = this.chkColManual;
            this.colManual.FieldName = "Manual";
            this.colManual.Name = "colManual";
            this.colManual.Visible = true;
            this.colManual.VisibleIndex = 10;
            // 
            // chkColManual
            // 
            this.chkColManual.AutoHeight = false;
            this.chkColManual.Name = "chkColManual";
            this.chkColManual.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colIncludedHours
            // 
            this.colIncludedHours.FieldName = "IncludedHours";
            this.colIncludedHours.Name = "colIncludedHours";
            // 
            // colTotalHours
            // 
            this.colTotalHours.DisplayFormat.FormatString = "n2";
            this.colTotalHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalHours.FieldName = "TotalHours";
            this.colTotalHours.Name = "colTotalHours";
            this.colTotalHours.OptionsColumn.AllowEdit = false;
            this.colTotalHours.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalHours", "{0:n2}")});
            this.colTotalHours.Visible = true;
            this.colTotalHours.VisibleIndex = 9;
            // 
            // colBillAmount
            // 
            this.colBillAmount.DisplayFormat.FormatString = "c2";
            this.colBillAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBillAmount.FieldName = "BillAmount";
            this.colBillAmount.Name = "colBillAmount";
            this.colBillAmount.OptionsColumn.AllowEdit = false;
            this.colBillAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BillAmount", "{0:c2}")});
            this.colBillAmount.Visible = true;
            this.colBillAmount.VisibleIndex = 11;
            // 
            // textColHours
            // 
            this.textColHours.AutoHeight = false;
            this.textColHours.Mask.EditMask = "n2";
            this.textColHours.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textColHours.Mask.UseMaskAsDisplayFormat = true;
            this.textColHours.MaxLength = 6;
            this.textColHours.Name = "textColHours";
            // 
            // textColAmount
            // 
            this.textColAmount.AutoHeight = false;
            this.textColAmount.Mask.EditMask = "c2";
            this.textColAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textColAmount.Mask.UseMaskAsDisplayFormat = true;
            this.textColAmount.MaxLength = 8;
            this.textColAmount.Name = "textColAmount";
            // 
            // luColLevel
            // 
            this.luColLevel.AutoHeight = false;
            this.luColLevel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luColLevel.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Description")});
            this.luColLevel.DisplayMember = "DisplayName";
            this.luColLevel.Name = "luColLevel";
            this.luColLevel.NullText = "";
            this.luColLevel.ValueMember = "MatchId";
            this.luColLevel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.LookupEdit_ButtonClick);
            // 
            // ucLabourEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcLabour);
            this.Name = "ucLabourEntry";
            this.Size = new System.Drawing.Size(1301, 577);
            ((System.ComponentModel.ISupportInitialize)(this.gcLabour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLabour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLabour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColEmpNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColEmpName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColWorkClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luChangeOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel1All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel3All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel4All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkColBillable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkColManual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcLabour;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLabour;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable tableLabour;
        private System.Data.DataColumn dataColId;
        private System.Data.DataColumn dataColEmpNum;
        private System.Data.DataColumn dataColEmpName;
        private System.Data.DataColumn dataColWorkClass;
        private System.Data.DataColumn dataColChangeOrder;
        private System.Data.DataColumn dataColLevel1;
        private System.Data.DataColumn dataColLevel2;
        private System.Data.DataColumn dataColLevel3;
        private System.Data.DataColumn dataColLevel4;
        private System.Data.DataColumn dataColBillable;
        private System.Data.DataColumn dataColManual;
        private System.Data.DataColumn dataColIncludedHours;
        private System.Data.DataColumn dataColTotalHours;
        private System.Data.DataColumn dataColBillAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpNum;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkClass;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel1Code;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel2Code;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel3Code;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel4Code;
        private DevExpress.XtraGrid.Columns.GridColumn colBillable;
        private DevExpress.XtraGrid.Columns.GridColumn colManual;
        private DevExpress.XtraGrid.Columns.GridColumn colIncludedHours;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalHours;
        private DevExpress.XtraGrid.Columns.GridColumn colBillAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColEmpNum;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColEmpName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColWorkClass;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkColBillable;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textColHours;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textColAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel1All;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel2All;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel3All;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel4All;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luChangeOrder;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkColManual;
    }
}
