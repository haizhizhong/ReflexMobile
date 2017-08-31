namespace MobileLEM
{
    partial class ucTabEquipment
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
            this.dataColLevel1Id = new System.Data.DataColumn();
            this.dataColLevel2Id = new System.Data.DataColumn();
            this.dataColBillable = new System.Data.DataColumn();
            this.dataColQuantity = new System.Data.DataColumn();
            this.dataColBillCycle = new System.Data.DataColumn();
            this.dataColBillRate = new System.Data.DataColumn();
            this.dataColBillAmount = new System.Data.DataColumn();
            this.gvEquipment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEqpNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColEquip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colAssetDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEquipmentClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevel1Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLevel2Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel2All = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBillable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkColBillable = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textColQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBillCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColBillCycle = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBillRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableEquipEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColEquip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkColBillable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColBillCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2)).BeginInit();
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
            this.luColLevel2All,
            this.luColLevel2,
            this.luColEquip,
            this.luColLevel1,
            this.chkColBillable,
            this.textColQuantity,
            this.luColBillCycle});
            this.gcEquipment.Size = new System.Drawing.Size(942, 506);
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
            this.dataColLevel1Id,
            this.dataColLevel2Id,
            this.dataColBillable,
            this.dataColQuantity,
            this.dataColBillCycle,
            this.dataColBillRate,
            this.dataColBillAmount});
            this.tableEquipEntry.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, true)});
            this.tableEquipEntry.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColId};
            this.tableEquipEntry.TableName = "EquipTimeEntry";
            // 
            // dataColId
            // 
            this.dataColId.AllowDBNull = false;
            this.dataColId.ColumnName = "Id";
            this.dataColId.DataType = typeof(int);
            // 
            // dataColEqpNum
            // 
            this.dataColEqpNum.ColumnName = "EqpNum";
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
            // 
            // dataColEmployeeName
            // 
            this.dataColEmployeeName.ColumnName = "EmployeeName";
            // 
            // dataColLevel1Id
            // 
            this.dataColLevel1Id.ColumnName = "Level1Id";
            this.dataColLevel1Id.DataType = typeof(int);
            // 
            // dataColLevel2Id
            // 
            this.dataColLevel2Id.ColumnName = "Level2Id";
            this.dataColLevel2Id.DataType = typeof(int);
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
            this.colLevel1Id,
            this.colLevel2Id,
            this.colBillable,
            this.colQuantity,
            this.colBillCycle,
            this.colBillRate,
            this.colBillAmount});
            this.gvEquipment.GridControl = this.gcEquipment;
            this.gvEquipment.Name = "gvEquipment";
            this.gvEquipment.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvEquipment.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvEquipment_CustomRowCellEditForEditing);
            this.gvEquipment.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvEquipment_InitNewRow);
            this.gvEquipment.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvEquipment_CellValueChanged);
            this.gvEquipment.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gvEquipment_RowDeleting);
            this.gvEquipment.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvEquipment_ValidateRow);
            this.gvEquipment.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvEquipment_RowUpdated);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colEqpNum
            // 
            this.colEqpNum.Caption = "Equipment";
            this.colEqpNum.ColumnEdit = this.luColEquip;
            this.colEqpNum.FieldName = "EqpNum";
            this.colEqpNum.Name = "colEqpNum";
            this.colEqpNum.Visible = true;
            this.colEqpNum.VisibleIndex = 0;
            // 
            // luColEquip
            // 
            this.luColEquip.AutoHeight = false;
            this.luColEquip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColEquip.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AssetCode", "Asset #"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Desc")});
            this.luColEquip.DisplayMember = "FullDisplay";
            this.luColEquip.Name = "luColEquip";
            this.luColEquip.NullText = "";
            this.luColEquip.ValueMember = "EqpNum";
            // 
            // colAssetDescription
            // 
            this.colAssetDescription.FieldName = "AssetDescription";
            this.colAssetDescription.Name = "colAssetDescription";
            this.colAssetDescription.Visible = true;
            this.colAssetDescription.VisibleIndex = 1;
            // 
            // colEquipmentClass
            // 
            this.colEquipmentClass.FieldName = "EquipmentClass";
            this.colEquipmentClass.Name = "colEquipmentClass";
            this.colEquipmentClass.Visible = true;
            this.colEquipmentClass.VisibleIndex = 2;
            // 
            // colEmpNum
            // 
            this.colEmpNum.FieldName = "EmpNum";
            this.colEmpNum.Name = "colEmpNum";
            this.colEmpNum.Visible = true;
            this.colEmpNum.VisibleIndex = 3;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 4;
            // 
            // colLevel1Id
            // 
            this.colLevel1Id.Caption = "Level1 Code";
            this.colLevel1Id.ColumnEdit = this.luColLevel1;
            this.colLevel1Id.FieldName = "Level1Id";
            this.colLevel1Id.Name = "colLevel1Id";
            this.colLevel1Id.Visible = true;
            this.colLevel1Id.VisibleIndex = 5;
            // 
            // luColLevel1
            // 
            this.luColLevel1.AutoHeight = false;
            this.luColLevel1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColLevel1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MatchId", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Desc")});
            this.luColLevel1.DisplayMember = "FullDisplay";
            this.luColLevel1.Name = "luColLevel1";
            this.luColLevel1.NullText = "";
            this.luColLevel1.ValueMember = "MatchId";
            // 
            // colLevel2Id
            // 
            this.colLevel2Id.Caption = "Level2 Code";
            this.colLevel2Id.ColumnEdit = this.luColLevel2All;
            this.colLevel2Id.FieldName = "Level2Id";
            this.colLevel2Id.Name = "colLevel2Id";
            this.colLevel2Id.Visible = true;
            this.colLevel2Id.VisibleIndex = 6;
            // 
            // luColLevel2All
            // 
            this.luColLevel2All.AutoHeight = false;
            this.luColLevel2All.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColLevel2All.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MatchId", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Desc")});
            this.luColLevel2All.DisplayMember = "FullDisplay";
            this.luColLevel2All.Name = "luColLevel2All";
            this.luColLevel2All.NullText = "";
            this.luColLevel2All.ValueMember = "MatchId";
            // 
            // colBillable
            // 
            this.colBillable.Caption = "Billable";
            this.colBillable.ColumnEdit = this.chkColBillable;
            this.colBillable.FieldName = "Billable";
            this.colBillable.Name = "colBillable";
            this.colBillable.Visible = true;
            this.colBillable.VisibleIndex = 7;
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
            this.colQuantity.VisibleIndex = 8;
            // 
            // textColQuantity
            // 
            this.textColQuantity.AutoHeight = false;
            this.textColQuantity.Mask.EditMask = "n2";
            this.textColQuantity.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textColQuantity.Mask.UseMaskAsDisplayFormat = true;
            this.textColQuantity.Name = "textColQuantity";
            // 
            // colBillCycle
            // 
            this.colBillCycle.ColumnEdit = this.luColBillCycle;
            this.colBillCycle.FieldName = "BillCycle";
            this.colBillCycle.Name = "colBillCycle";
            this.colBillCycle.Visible = true;
            this.colBillCycle.VisibleIndex = 9;
            // 
            // luColBillCycle
            // 
            this.luColBillCycle.AutoHeight = false;
            this.luColBillCycle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColBillCycle.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Desc")});
            this.luColBillCycle.DisplayMember = "Desc";
            this.luColBillCycle.Name = "luColBillCycle";
            this.luColBillCycle.NullText = "";
            this.luColBillCycle.ValueMember = "Enum";
            // 
            // colBillRate
            // 
            this.colBillRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBillRate.FieldName = "BillRate";
            this.colBillRate.Name = "colBillRate";
            this.colBillRate.Visible = true;
            this.colBillRate.VisibleIndex = 10;
            // 
            // colBillAmount
            // 
            this.colBillAmount.DisplayFormat.FormatString = "c2";
            this.colBillAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBillAmount.FieldName = "BillAmount";
            this.colBillAmount.Name = "colBillAmount";
            this.colBillAmount.Visible = true;
            this.colBillAmount.VisibleIndex = 11;
            // 
            // luColLevel2
            // 
            this.luColLevel2.AutoHeight = false;
            this.luColLevel2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColLevel2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MatchId", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Desc")});
            this.luColLevel2.DisplayMember = "FullDisplay";
            this.luColLevel2.Name = "luColLevel2";
            this.luColLevel2.NullText = "";
            this.luColLevel2.ValueMember = "MatchId";
            // 
            // ucTabEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcEquipment);
            this.Name = "ucTabEquipment";
            this.Size = new System.Drawing.Size(942, 506);
            ((System.ComponentModel.ISupportInitialize)(this.gcEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableEquipEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColEquip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkColBillable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColBillCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcEquipment;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEquipment;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel2All;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel2;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable tableEquipEntry;
        private System.Data.DataColumn dataColId;
        private System.Data.DataColumn dataColEqpNum;
        private System.Data.DataColumn dataColAsset;
        private System.Data.DataColumn dataColEquipClass;
        private System.Data.DataColumn dataColEmpNum;
        private System.Data.DataColumn dataColEmployeeName;
        private System.Data.DataColumn dataColLevel1Id;
        private System.Data.DataColumn dataColLevel2Id;
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
        private DevExpress.XtraGrid.Columns.GridColumn colLevel1Id;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel2Id;
        private DevExpress.XtraGrid.Columns.GridColumn colBillable;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colBillCycle;
        private DevExpress.XtraGrid.Columns.GridColumn colBillRate;
        private DevExpress.XtraGrid.Columns.GridColumn colBillAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColEquip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkColBillable;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textColQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColBillCycle;
    }
}
