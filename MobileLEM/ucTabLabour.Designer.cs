namespace MobileLEM
{
    partial class ucTabLabour
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
            this.dataColLevel1 = new System.Data.DataColumn();
            this.dataColLevel2 = new System.Data.DataColumn();
            this.dataColBillable = new System.Data.DataColumn();
            this.dataColTotalHours = new System.Data.DataColumn();
            this.dataColBillAmount = new System.Data.DataColumn();
            this.gvLabour = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColEmployee = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevel1Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLevel2Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel2All = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBillable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkColBillable = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colTotalHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColLevel2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luColWorkClass = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.textColHours = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.textColAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLabour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLabour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLabour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkColBillable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColWorkClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColAmount)).BeginInit();
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
            this.luColLevel2All,
            this.luColLevel2,
            this.luColEmployee,
            this.luColWorkClass,
            this.luColLevel1,
            this.chkColBillable,
            this.textColHours,
            this.textColAmount});
            this.gcLabour.Size = new System.Drawing.Size(1112, 507);
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
            this.dataColLevel1,
            this.dataColLevel2,
            this.dataColBillable,
            this.dataColTotalHours,
            this.dataColBillAmount});
            this.tableLabour.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, true)});
            this.tableLabour.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColId};
            this.tableLabour.TableName = "LabourTimeEntry";
            // 
            // dataColId
            // 
            this.dataColId.AllowDBNull = false;
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
            // 
            // dataColWorkClass
            // 
            this.dataColWorkClass.ColumnName = "WorkClass";
            this.dataColWorkClass.DataType = typeof(int);
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
            // dataColBillable
            // 
            this.dataColBillable.ColumnName = "Billable";
            this.dataColBillable.DataType = typeof(bool);
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
            this.colLevel1Code,
            this.colLevel2Code,
            this.colBillable,
            this.colTotalHours,
            this.colBillAmount});
            this.gvLabour.GridControl = this.gcLabour;
            this.gvLabour.Name = "gvLabour";
            this.gvLabour.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLabour.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvEmployee_CustomRowCellEditForEditing);
            this.gvLabour.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvEmployee_InitNewRow);
            this.gvLabour.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvEmployee_CellValueChanged);
            this.gvLabour.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gvLabour_RowDeleting);
            this.gvLabour.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvEmployee_ValidateRow);
            this.gvLabour.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvLabour_RowUpdated);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colEmpNum
            // 
            this.colEmpNum.ColumnEdit = this.luColEmployee;
            this.colEmpNum.FieldName = "EmpNum";
            this.colEmpNum.Name = "colEmpNum";
            this.colEmpNum.Visible = true;
            this.colEmpNum.VisibleIndex = 0;
            // 
            // luColEmployee
            // 
            this.luColEmployee.AutoHeight = false;
            this.luColEmployee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColEmployee.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpNum", "Emp #"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.luColEmployee.DisplayMember = "EmpNum";
            this.luColEmployee.Name = "luColEmployee";
            this.luColEmployee.NullText = "";
            this.luColEmployee.ValueMember = "EmpNum";
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsColumn.AllowEdit = false;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            // 
            // colWorkClass
            // 
            this.colWorkClass.ColumnEdit = this.luColWorkClass;
            this.colWorkClass.FieldName = "WorkClass";
            this.colWorkClass.Name = "colWorkClass";
            this.colWorkClass.Visible = true;
            this.colWorkClass.VisibleIndex = 2;
            // 
            // colLevel1Code
            // 
            this.colLevel1Code.Caption = "Level1 Code";
            this.colLevel1Code.ColumnEdit = this.luColLevel1;
            this.colLevel1Code.FieldName = "Level1Code";
            this.colLevel1Code.Name = "colLevel1Code";
            this.colLevel1Code.Visible = true;
            this.colLevel1Code.VisibleIndex = 3;
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
            // colLevel2Code
            // 
            this.colLevel2Code.Caption = "Level2 Code";
            this.colLevel2Code.ColumnEdit = this.luColLevel2All;
            this.colLevel2Code.FieldName = "Level2Code";
            this.colLevel2Code.Name = "colLevel2Code";
            this.colLevel2Code.Visible = true;
            this.colLevel2Code.VisibleIndex = 4;
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
            this.colBillable.VisibleIndex = 5;
            // 
            // chkColBillable
            // 
            this.chkColBillable.AutoHeight = false;
            this.chkColBillable.Name = "chkColBillable";
            this.chkColBillable.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colTotalHours
            // 
            this.colTotalHours.DisplayFormat.FormatString = "n2";
            this.colTotalHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalHours.FieldName = "TotalHours";
            this.colTotalHours.Name = "colTotalHours";
            this.colTotalHours.OptionsColumn.AllowEdit = false;
            this.colTotalHours.Visible = true;
            this.colTotalHours.VisibleIndex = 6;
            // 
            // colBillAmount
            // 
            this.colBillAmount.DisplayFormat.FormatString = "c2";
            this.colBillAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBillAmount.FieldName = "BillAmount";
            this.colBillAmount.Name = "colBillAmount";
            this.colBillAmount.OptionsColumn.AllowEdit = false;
            this.colBillAmount.Visible = true;
            this.colBillAmount.VisibleIndex = 7;
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
            // luColWorkClass
            // 
            this.luColWorkClass.AutoHeight = false;
            this.luColWorkClass.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColWorkClass.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "WorkClass #")});
            this.luColWorkClass.DisplayMember = "Desc";
            this.luColWorkClass.Name = "luColWorkClass";
            this.luColWorkClass.NullText = "";
            this.luColWorkClass.ValueMember = "MatchId";
            // 
            // textColHours
            // 
            this.textColHours.AutoHeight = false;
            this.textColHours.Mask.EditMask = "n2";
            this.textColHours.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textColHours.Mask.UseMaskAsDisplayFormat = true;
            this.textColHours.Name = "textColHours";
            // 
            // textColAmount
            // 
            this.textColAmount.AutoHeight = false;
            this.textColAmount.Mask.EditMask = "c2";
            this.textColAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textColAmount.Mask.UseMaskAsDisplayFormat = true;
            this.textColAmount.Name = "textColAmount";
            // 
            // ucTabLabour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcLabour);
            this.Name = "ucTabLabour";
            this.Size = new System.Drawing.Size(1112, 507);
            ((System.ComponentModel.ISupportInitialize)(this.gcLabour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLabour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLabour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkColBillable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColLevel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColWorkClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcLabour;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLabour;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel2All;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel2;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable tableLabour;
        private System.Data.DataColumn dataColId;
        private System.Data.DataColumn dataColEmpNum;
        private System.Data.DataColumn dataColEmpName;
        private System.Data.DataColumn dataColWorkClass;
        private System.Data.DataColumn dataColLevel1;
        private System.Data.DataColumn dataColLevel2;
        private System.Data.DataColumn dataColBillable;
        private System.Data.DataColumn dataColTotalHours;
        private System.Data.DataColumn dataColBillAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpNum;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkClass;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel1Code;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel2Code;
        private DevExpress.XtraGrid.Columns.GridColumn colBillable;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalHours;
        private DevExpress.XtraGrid.Columns.GridColumn colBillAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColEmployee;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColWorkClass;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColLevel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkColBillable;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textColHours;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textColAmount;
    }
}
