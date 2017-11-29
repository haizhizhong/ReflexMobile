namespace MobileLEM
{
    partial class ucEquipmentEntry
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
            this.gcEquipment = new DevExpress.XtraGrid.GridControl();
            this.dataSet1 = new System.Data.DataSet();
            this.tableEquipEntry = new System.Data.DataTable();
            this.dataColId = new System.Data.DataColumn();
            this.dataColEqpNum = new System.Data.DataColumn();
            this.dataColAsset = new System.Data.DataColumn();
            this.dataColEquipClass = new System.Data.DataColumn();
            this.dataColEmpNum = new System.Data.DataColumn();
            this.dataColEmployeeName = new System.Data.DataColumn();
            this.dataColChangeOrder = new System.Data.DataColumn();
            this.dataColLevel1Code = new System.Data.DataColumn();
            this.dataColLevel2Code = new System.Data.DataColumn();
            this.dataColLevel3Code = new System.Data.DataColumn();
            this.dataColLevel4Code = new System.Data.DataColumn();
            this.dataColBillable = new System.Data.DataColumn();
            this.dataColQuantity = new System.Data.DataColumn();
            this.dataColBillCycle = new System.Data.DataColumn();
            this.dataColBillRate = new System.Data.DataColumn();
            this.dataColBillAmount = new System.Data.DataColumn();
            this.gvEquipment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEqpNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColEquipNum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colAssetDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColAssertNum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEquipmentClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textColQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBillCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColBillCycleAll = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBillRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luColBillCycle = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableEquipEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColEquipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColAssertNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luChangeOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel1All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel3All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel4All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkColBillable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColBillCycleAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColBillCycle)).BeginInit();
            this.SuspendLayout();
            // 
            // gcEquipment
            // 
            this.gcEquipment.DataMember = "EquipTimeEntry";
            this.gcEquipment.DataSource = this.dataSet1;
            this.gcEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEquipment.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcEquipment.Location = new System.Drawing.Point(0, 0);
            this.gcEquipment.MainView = this.gvEquipment;
            this.gcEquipment.Name = "gcEquipment";
            this.gcEquipment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.luColLevel1All,
            this.luColLevel2All,
            this.luColLevel3All,
            this.luColLevel4All,
            this.luColLevel,
            this.luColEquipNum,
            this.luColAssertNum,
            this.chkColBillable,
            this.textColQuantity,
            this.luColBillCycleAll,
            this.luColBillCycle,
            this.luChangeOrder});
            this.gcEquipment.Size = new System.Drawing.Size(1317, 602);
            this.gcEquipment.TabIndex = 1;
            this.gcEquipment.UseDisabledStatePainter = false;
            this.gcEquipment.UseEmbeddedNavigator = true;
            this.gcEquipment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEquipment});
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.tableEquipEntry});
            // 
            // tableEquipEntry
            // 
            this.tableEquipEntry.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColId,
            this.dataColEqpNum,
            this.dataColAsset,
            this.dataColEquipClass,
            this.dataColEmpNum,
            this.dataColEmployeeName,
            this.dataColChangeOrder,
            this.dataColLevel1Code,
            this.dataColLevel2Code,
            this.dataColLevel3Code,
            this.dataColLevel4Code,
            this.dataColBillable,
            this.dataColQuantity,
            this.dataColBillCycle,
            this.dataColBillRate,
            this.dataColBillAmount});
            this.tableEquipEntry.TableName = "EquipTimeEntry";
            // 
            // dataColId
            // 
            this.dataColId.ColumnName = "Id";
            this.dataColId.DataType = typeof(int);
            // 
            // dataColEqpNum
            // 
            this.dataColEqpNum.ColumnName = "EquipNum";
            // 
            // dataColAsset
            // 
            this.dataColAsset.ColumnName = "AssetDescription";
            // 
            // dataColEquipClass
            // 
            this.dataColEquipClass.ColumnName = "EquipmentClass";
            // 
            // dataColEmpNum
            // 
            this.dataColEmpNum.ColumnName = "EmpNum";
            this.dataColEmpNum.DataType = typeof(int);
            // 
            // dataColEmployeeName
            // 
            this.dataColEmployeeName.ColumnName = "EmployeeName";
            // 
            // dataColChangeOrder
            // 
            this.dataColChangeOrder.ColumnName = "ChangeOrder";
            this.dataColChangeOrder.DataType = typeof(int);
            // 
            // dataColLevel1Code
            // 
            this.dataColLevel1Code.ColumnName = "Level1Code";
            this.dataColLevel1Code.DataType = typeof(int);
            // 
            // dataColLevel2Code
            // 
            this.dataColLevel2Code.ColumnName = "Level2Code";
            this.dataColLevel2Code.DataType = typeof(int);
            // 
            // dataColLevel3Code
            // 
            this.dataColLevel3Code.ColumnName = "Level3Code";
            this.dataColLevel3Code.DataType = typeof(int);
            // 
            // dataColLevel4Code
            // 
            this.dataColLevel4Code.ColumnName = "Level4Code";
            this.dataColLevel4Code.DataType = typeof(int);
            // 
            // dataColBillable
            // 
            this.dataColBillable.ColumnName = "Billable";
            this.dataColBillable.DataType = typeof(bool);
            // 
            // dataColQuantity
            // 
            this.dataColQuantity.ColumnName = "Quantity";
            this.dataColQuantity.DataType = typeof(decimal);
            // 
            // dataColBillCycle
            // 
            this.dataColBillCycle.ColumnName = "BillCycle";
            this.dataColBillCycle.DataType = typeof(char);
            // 
            // dataColBillRate
            // 
            this.dataColBillRate.ColumnName = "BillRate";
            this.dataColBillRate.DataType = typeof(decimal);
            // 
            // dataColBillAmount
            // 
            this.dataColBillAmount.ColumnName = "BillAmount";
            this.dataColBillAmount.DataType = typeof(decimal);
            // 
            // gvEquipment
            // 
            this.gvEquipment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colEqpNum,
            this.colAssetDescription,
            this.colEquipmentClass,
            this.colEmpNum,
            this.colEmployeeName,
            this.colChangeOrder,
            this.colLevel1Code,
            this.colLevel2Code,
            this.colLevel3Code,
            this.colLevel4Code,
            this.colBillable,
            this.colQuantity,
            this.colBillCycle,
            this.colBillRate,
            this.colBillAmount});
            this.gvEquipment.GridControl = this.gcEquipment;
            this.gvEquipment.Name = "gvEquipment";
            this.gvEquipment.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvEquipment.OptionsView.ShowFooter = true;
            this.gvEquipment.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvEquipment_CustomRowCellEditForEditing);
            this.gvEquipment.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvEquipment_InitNewRow);
            this.gvEquipment.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvEquipment_CellValueChanged);
            this.gvEquipment.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gvEquipment_RowDeleting);
            this.gvEquipment.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvEquipment_ValidateRow);
            this.gvEquipment.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvEquipment_RowUpdated);
            this.gvEquipment.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvEquipment_ValidatingEditor);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colEqpNum
            // 
            this.colEqpNum.Caption = "Asset Code";
            this.colEqpNum.ColumnEdit = this.luColEquipNum;
            this.colEqpNum.FieldName = "EquipNum";
            this.colEqpNum.Name = "colEqpNum";
            this.colEqpNum.Visible = true;
            this.colEqpNum.VisibleIndex = 0;
            // 
            // luColEquipNum
            // 
            this.luColEquipNum.AutoHeight = false;
            this.luColEquipNum.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luColEquipNum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColEquipNum.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AssetCode", 60, "Asset #"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", 100, "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Class", 60, "Class"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", 60, "Category")});
            this.luColEquipNum.DisplayMember = "AssetCode";
            this.luColEquipNum.Name = "luColEquipNum";
            this.luColEquipNum.NullText = "";
            this.luColEquipNum.ValueMember = "EqpNum";
            // 
            // colAssetDescription
            // 
            this.colAssetDescription.Caption = "Description";
            this.colAssetDescription.ColumnEdit = this.luColAssertNum;
            this.colAssetDescription.FieldName = "AssetDescription";
            this.colAssetDescription.Name = "colAssetDescription";
            this.colAssetDescription.Visible = true;
            this.colAssetDescription.VisibleIndex = 1;
            // 
            // luColAssertNum
            // 
            this.luColAssertNum.AutoHeight = false;
            this.luColAssertNum.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luColAssertNum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColAssertNum.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AssetCode", 60, "Asset #"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", 100, "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Class", 60, "Class"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", 60, "Category")});
            this.luColAssertNum.DisplayMember = "DisplayName";
            this.luColAssertNum.Name = "luColAssertNum";
            this.luColAssertNum.NullText = "";
            this.luColAssertNum.ValueMember = "EqpNum";
            // 
            // colEquipmentClass
            // 
            this.colEquipmentClass.FieldName = "EquipmentClass";
            this.colEquipmentClass.Name = "colEquipmentClass";
            this.colEquipmentClass.OptionsColumn.AllowEdit = false;
            this.colEquipmentClass.Visible = true;
            this.colEquipmentClass.VisibleIndex = 2;
            // 
            // colEmpNum
            // 
            this.colEmpNum.Caption = "Emp No";
            this.colEmpNum.FieldName = "EmpNum";
            this.colEmpNum.Name = "colEmpNum";
            this.colEmpNum.OptionsColumn.AllowEdit = false;
            this.colEmpNum.Visible = true;
            this.colEmpNum.VisibleIndex = 3;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsColumn.AllowEdit = false;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 4;
            // 
            // colChangeOrder
            // 
            this.colChangeOrder.Caption = "ChangeOrder";
            this.colChangeOrder.ColumnEdit = this.luChangeOrder;
            this.colChangeOrder.FieldName = "ChangeOrder";
            this.colChangeOrder.Name = "colChangeOrder";
            this.colChangeOrder.Visible = true;
            this.colChangeOrder.VisibleIndex = 5;
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
            this.colLevel1Code.VisibleIndex = 6;
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
            this.colLevel2Code.VisibleIndex = 7;
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
            this.colLevel3Code.VisibleIndex = 8;
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
            this.colLevel4Code.VisibleIndex = 9;
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
            this.colBillable.VisibleIndex = 10;
            // 
            // chkColBillable
            // 
            this.chkColBillable.AutoHeight = false;
            this.chkColBillable.Name = "chkColBillable";
            this.chkColBillable.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colQuantity
            // 
            this.colQuantity.ColumnEdit = this.textColQuantity;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 11;
            // 
            // textColQuantity
            // 
            this.textColQuantity.AutoHeight = false;
            this.textColQuantity.Mask.EditMask = "n2";
            this.textColQuantity.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textColQuantity.Mask.UseMaskAsDisplayFormat = true;
            this.textColQuantity.MaxLength = 6;
            this.textColQuantity.Name = "textColQuantity";
            // 
            // colBillCycle
            // 
            this.colBillCycle.ColumnEdit = this.luColBillCycleAll;
            this.colBillCycle.FieldName = "BillCycle";
            this.colBillCycle.Name = "colBillCycle";
            this.colBillCycle.Visible = true;
            this.colBillCycle.VisibleIndex = 12;
            // 
            // luColBillCycleAll
            // 
            this.luColBillCycleAll.AutoHeight = false;
            this.luColBillCycleAll.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColBillCycleAll.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Description")});
            this.luColBillCycleAll.DisplayMember = "Desc";
            this.luColBillCycleAll.Name = "luColBillCycleAll";
            this.luColBillCycleAll.NullText = "";
            this.luColBillCycleAll.ValueMember = "Enum";
            // 
            // colBillRate
            // 
            this.colBillRate.DisplayFormat.FormatString = "c2";
            this.colBillRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBillRate.FieldName = "BillRate";
            this.colBillRate.Name = "colBillRate";
            this.colBillRate.OptionsColumn.AllowEdit = false;
            this.colBillRate.Visible = true;
            this.colBillRate.VisibleIndex = 13;
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
            this.colBillAmount.VisibleIndex = 14;
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
            // luColBillCycle
            // 
            this.luColBillCycle.AutoHeight = false;
            this.luColBillCycle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColBillCycle.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Cycle", "Cycle"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BillRate", "Bill Rate"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsDefault", "Default")});
            this.luColBillCycle.DisplayMember = "Cycle";
            this.luColBillCycle.Name = "luColBillCycle";
            this.luColBillCycle.NullText = "";
            this.luColBillCycle.ValueMember = "Enum";
            // 
            // ucEquipmentEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcEquipment);
            this.Name = "ucEquipmentEntry";
            this.Size = new System.Drawing.Size(1317, 602);
            ((System.ComponentModel.ISupportInitialize)(this.gcEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableEquipEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColEquipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColAssertNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luChangeOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel1All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel3All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel4All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkColBillable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColBillCycleAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColBillCycle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcEquipment;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEquipment;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable tableEquipEntry;
        private System.Data.DataColumn dataColId;
        private System.Data.DataColumn dataColEqpNum;
        private System.Data.DataColumn dataColAsset;
        private System.Data.DataColumn dataColEquipClass;
        private System.Data.DataColumn dataColEmpNum;
        private System.Data.DataColumn dataColEmployeeName;
        private System.Data.DataColumn dataColChangeOrder;
        private System.Data.DataColumn dataColLevel1Code;
        private System.Data.DataColumn dataColLevel2Code;
        private System.Data.DataColumn dataColLevel3Code;
        private System.Data.DataColumn dataColLevel4Code;
        private System.Data.DataColumn dataColBillable;
        private System.Data.DataColumn dataColQuantity;
        private System.Data.DataColumn dataColBillCycle;
        private System.Data.DataColumn dataColBillRate;
        private System.Data.DataColumn dataColBillAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colEqpNum;
        private DevExpress.XtraGrid.Columns.GridColumn colAssetDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colEquipmentClass;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpNum;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel1Code;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel2Code;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel3Code;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel4Code;
        private DevExpress.XtraGrid.Columns.GridColumn colBillable;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colBillCycle;
        private DevExpress.XtraGrid.Columns.GridColumn colBillRate;
        private DevExpress.XtraGrid.Columns.GridColumn colBillAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColEquipNum;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColAssertNum;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel1All;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel2All;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel3All;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel4All;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkColBillable;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textColQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColBillCycleAll;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColBillCycle;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luChangeOrder;
    }
}
