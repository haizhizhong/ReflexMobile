namespace MobileLEM
{
    partial class ucEmployeeSummary
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
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.dataSet1 = new System.Data.DataSet();
            this.tableLabour = new System.Data.DataTable();
            this.dataColEmpNum = new System.Data.DataColumn();
            this.dataColEmpName = new System.Data.DataColumn();
            this.dataColWorkClass = new System.Data.DataColumn();
            this.dataColTotalHours = new System.Data.DataColumn();
            this.dataColBillAmount = new System.Data.DataColumn();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLabour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSummary
            // 
            this.gcSummary.DataMember = "LabourTimeEntry";
            this.gcSummary.DataSource = this.dataSet1;
            this.gcSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSummary.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcSummary.Location = new System.Drawing.Point(0, 0);
            this.gcSummary.MainView = this.gvSummary;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.Size = new System.Drawing.Size(1044, 515);
            this.gcSummary.TabIndex = 3;
            this.gcSummary.UseDisabledStatePainter = false;
            this.gcSummary.UseEmbeddedNavigator = true;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
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
            this.dataColEmpNum,
            this.dataColEmpName,
            this.dataColWorkClass,
            this.dataColTotalHours,
            this.dataColBillAmount});
            this.tableLabour.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "EmpNum",
                        "WorkClass"}, true)});
            this.tableLabour.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColEmpNum,
        this.dataColWorkClass};
            this.tableLabour.TableName = "LabourTimeEntry";
            // 
            // dataColEmpNum
            // 
            this.dataColEmpNum.AllowDBNull = false;
            this.dataColEmpNum.ColumnName = "EmpNum";
            // 
            // dataColEmpName
            // 
            this.dataColEmpName.ColumnName = "EmployeeName";
            // 
            // dataColWorkClass
            // 
            this.dataColWorkClass.AllowDBNull = false;
            this.dataColWorkClass.ColumnName = "WorkClass";
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
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmpNum,
            this.colEmployeeName,
            this.colWorkClass,
            this.colTotalHours,
            this.colBillAmount});
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsBehavior.Editable = false;
            this.gvSummary.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowFooter = true;
            // 
            // colEmpNum
            // 
            this.colEmpNum.Caption = "Emp No";
            this.colEmpNum.FieldName = "EmpNum";
            this.colEmpNum.Name = "colEmpNum";
            this.colEmpNum.Visible = true;
            this.colEmpNum.VisibleIndex = 0;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsColumn.AllowEdit = false;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 96;
            // 
            // colWorkClass
            // 
            this.colWorkClass.FieldName = "WorkClass";
            this.colWorkClass.Name = "colWorkClass";
            this.colWorkClass.Visible = true;
            this.colWorkClass.VisibleIndex = 2;
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
            this.colTotalHours.VisibleIndex = 3;
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
            this.colBillAmount.VisibleIndex = 4;
            // 
            // ucEmployeeSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcSummary);
            this.Name = "ucEmployeeSummary";
            this.Size = new System.Drawing.Size(1044, 515);
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLabour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpNum;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkClass;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalHours;
        private DevExpress.XtraGrid.Columns.GridColumn colBillAmount;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable tableLabour;
        private System.Data.DataColumn dataColEmpNum;
        private System.Data.DataColumn dataColEmpName;
        private System.Data.DataColumn dataColWorkClass;
        private System.Data.DataColumn dataColTotalHours;
        private System.Data.DataColumn dataColBillAmount;
    }
}
