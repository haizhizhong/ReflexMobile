namespace MobileLEM
{
    partial class ucLemAP
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
            this.components = new System.ComponentModel.Container();
            this.dataSet1 = new System.Data.DataSet();
            this.tableAP = new System.Data.DataTable();
            this.dataColId = new System.Data.DataColumn();
            this.dataColDate = new System.Data.DataColumn();
            this.dataColSselect = new System.Data.DataColumn();
            this.dataColInvoiceNum = new System.Data.DataColumn();
            this.dataColSupplier = new System.Data.DataColumn();
            this.dataColPONum = new System.Data.DataColumn();
            this.dataColProject = new System.Data.DataColumn();
            this.dataColInvoiceAmount = new System.Data.DataColumn();
            this.dataColMarkupAmount = new System.Data.DataColumn();
            this.dataColBillAmount = new System.Data.DataColumn();
            this.tableDetail = new System.Data.DataTable();
            this.dataDetailColId = new System.Data.DataColumn();
            this.dataDetailColLine = new System.Data.DataColumn();
            this.dataDetailColDesc = new System.Data.DataColumn();
            this.dataDetailColRef = new System.Data.DataColumn();
            this.dataDetailColAmt = new System.Data.DataColumn();
            this.dataDetailColMarkupPercent = new System.Data.DataColumn();
            this.dataDetailColMarkupAmount = new System.Data.DataColumn();
            this.dataDetailColBillAmount = new System.Data.DataColumn();
            this.gcAP = new DevExpress.XtraGrid.GridControl();
            this.gvAP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPONum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarkupAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailLineNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailMarkupPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailMarkupAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailBillAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.text = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableAP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.tableAP,
            this.tableDetail});
            // 
            // tableAP
            // 
            this.tableAP.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColId,
            this.dataColDate,
            this.dataColSselect,
            this.dataColInvoiceNum,
            this.dataColSupplier,
            this.dataColPONum,
            this.dataColProject,
            this.dataColInvoiceAmount,
            this.dataColMarkupAmount,
            this.dataColBillAmount});
            this.tableAP.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, true)});
            this.tableAP.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColId};
            this.tableAP.TableName = "tableAP";
            // 
            // dataColId
            // 
            this.dataColId.AllowDBNull = false;
            this.dataColId.ColumnName = "Id";
            this.dataColId.DataType = typeof(int);
            // 
            // dataColDate
            // 
            this.dataColDate.Caption = "Date";
            this.dataColDate.ColumnName = "InvoiceDate";
            this.dataColDate.DataType = typeof(System.DateTime);
            // 
            // dataColSselect
            // 
            this.dataColSselect.Caption = "Select";
            this.dataColSselect.ColumnName = "Select";
            this.dataColSselect.DataType = typeof(bool);
            // 
            // dataColInvoiceNum
            // 
            this.dataColInvoiceNum.Caption = "Invoice #";
            this.dataColInvoiceNum.ColumnName = "InvoiceNum";
            // 
            // dataColSupplier
            // 
            this.dataColSupplier.ColumnName = "Supplier";
            // 
            // dataColPONum
            // 
            this.dataColPONum.Caption = "PO #";
            this.dataColPONum.ColumnName = "PONum";
            // 
            // dataColProject
            // 
            this.dataColProject.Caption = "Project ";
            this.dataColProject.ColumnName = "Project";
            // 
            // dataColInvoiceAmount
            // 
            this.dataColInvoiceAmount.ColumnName = "InvoiceAmount";
            this.dataColInvoiceAmount.DataType = typeof(decimal);
            // 
            // dataColMarkupAmount
            // 
            this.dataColMarkupAmount.ColumnName = "MarkupAmount";
            this.dataColMarkupAmount.DataType = typeof(decimal);
            // 
            // dataColBillAmount
            // 
            this.dataColBillAmount.ColumnName = "BillAmount";
            this.dataColBillAmount.DataType = typeof(decimal);
            // 
            // tableDetail
            // 
            this.tableDetail.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataDetailColId,
            this.dataDetailColLine,
            this.dataDetailColDesc,
            this.dataDetailColRef,
            this.dataDetailColAmt,
            this.dataDetailColMarkupPercent,
            this.dataDetailColMarkupAmount,
            this.dataDetailColBillAmount});
            this.tableDetail.TableName = "PODetail";
            // 
            // dataDetailColId
            // 
            this.dataDetailColId.ColumnName = "Id";
            this.dataDetailColId.DataType = typeof(int);
            // 
            // dataDetailColLine
            // 
            this.dataDetailColLine.Caption = "Line#";
            this.dataDetailColLine.ColumnName = "LineNum";
            this.dataDetailColLine.DataType = typeof(int);
            // 
            // dataDetailColDesc
            // 
            this.dataDetailColDesc.ColumnName = "Description";
            // 
            // dataDetailColRef
            // 
            this.dataDetailColRef.ColumnName = "Reference";
            // 
            // dataDetailColAmt
            // 
            this.dataDetailColAmt.ColumnName = "Amount";
            this.dataDetailColAmt.DataType = typeof(decimal);
            // 
            // dataDetailColMarkupPercent
            // 
            this.dataDetailColMarkupPercent.ColumnName = "MarkupPercent";
            this.dataDetailColMarkupPercent.DataType = typeof(decimal);
            // 
            // dataDetailColMarkupAmount
            // 
            this.dataDetailColMarkupAmount.ColumnName = "MarkupAmount";
            this.dataDetailColMarkupAmount.DataType = typeof(decimal);
            // 
            // dataDetailColBillAmount
            // 
            this.dataDetailColBillAmount.ColumnName = "BillAmount";
            this.dataDetailColBillAmount.DataType = typeof(decimal);
            // 
            // gcAP
            // 
            this.gcAP.DataMember = "tableAP";
            this.gcAP.DataSource = this.dataSet1;
            this.gcAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAP.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gcAP.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcAP.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gcAP.Location = new System.Drawing.Point(2, 2);
            this.gcAP.MainView = this.gvAP;
            this.gcAP.Name = "gcAP";
            this.gcAP.Size = new System.Drawing.Size(1048, 360);
            this.gcAP.TabIndex = 0;
            this.gcAP.UseEmbeddedNavigator = true;
            this.gcAP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAP});
            // 
            // gvAP
            // 
            this.gvAP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colInvoiceDate,
            this.colSelect,
            this.colInvoiceNum,
            this.colSupplier,
            this.colPONum,
            this.colProject,
            this.colInvoiceAmount,
            this.colMarkupAmount,
            this.colBillAmount});
            this.gvAP.GridControl = this.gcAP;
            this.gvAP.Name = "gvAP";
            this.gvAP.OptionsView.ShowFooter = true;
            this.gvAP.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvAP_FocusedRowChanged);
            this.gvAP.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvAP_CellValueChanged);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.FieldName = "InvoiceDate";
            this.colInvoiceDate.Name = "colInvoiceDate";
            this.colInvoiceDate.OptionsColumn.AllowEdit = false;
            this.colInvoiceDate.Visible = true;
            this.colInvoiceDate.VisibleIndex = 0;
            // 
            // colSelect
            // 
            this.colSelect.FieldName = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Visible = true;
            this.colSelect.VisibleIndex = 1;
            // 
            // colInvoiceNum
            // 
            this.colInvoiceNum.FieldName = "InvoiceNum";
            this.colInvoiceNum.Name = "colInvoiceNum";
            this.colInvoiceNum.OptionsColumn.AllowEdit = false;
            this.colInvoiceNum.Visible = true;
            this.colInvoiceNum.VisibleIndex = 2;
            // 
            // colSupplier
            // 
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.OptionsColumn.AllowEdit = false;
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 3;
            // 
            // colPONum
            // 
            this.colPONum.FieldName = "PONum";
            this.colPONum.Name = "colPONum";
            this.colPONum.OptionsColumn.AllowEdit = false;
            this.colPONum.Visible = true;
            this.colPONum.VisibleIndex = 4;
            // 
            // colProject
            // 
            this.colProject.FieldName = "Project";
            this.colProject.Name = "colProject";
            this.colProject.OptionsColumn.AllowEdit = false;
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 5;
            // 
            // colInvoiceAmount
            // 
            this.colInvoiceAmount.DisplayFormat.FormatString = "c2";
            this.colInvoiceAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInvoiceAmount.FieldName = "InvoiceAmount";
            this.colInvoiceAmount.Name = "colInvoiceAmount";
            this.colInvoiceAmount.OptionsColumn.AllowEdit = false;
            this.colInvoiceAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InvoiceAmount", "{0:c2}")});
            this.colInvoiceAmount.Visible = true;
            this.colInvoiceAmount.VisibleIndex = 6;
            // 
            // colMarkupAmount
            // 
            this.colMarkupAmount.DisplayFormat.FormatString = "c2";
            this.colMarkupAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMarkupAmount.FieldName = "MarkupAmount";
            this.colMarkupAmount.Name = "colMarkupAmount";
            this.colMarkupAmount.OptionsColumn.AllowEdit = false;
            this.colMarkupAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MarkupAmount", "{0:c2}")});
            this.colMarkupAmount.Visible = true;
            this.colMarkupAmount.VisibleIndex = 7;
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
            this.colBillAmount.VisibleIndex = 8;
            // 
            // gcDetail
            // 
            this.gcDetail.DataMember = "PODetail";
            this.gcDetail.DataSource = this.dataSet1;
            this.gcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetail.EmbeddedNavigator.Enabled = false;
            this.gcDetail.Location = new System.Drawing.Point(2, 20);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.text});
            this.gcDetail.Size = new System.Drawing.Size(1048, 233);
            this.gcDetail.TabIndex = 2;
            this.gcDetail.UseDisabledStatePainter = false;
            this.gcDetail.UseEmbeddedNavigator = true;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailId,
            this.colDetailLineNum,
            this.colDetailDescription,
            this.colDetailReference,
            this.colDetailAmount,
            this.colDetailMarkupPercent,
            this.colDetailMarkupAmount,
            this.colDetailBillAmount});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsBehavior.Editable = false;
            this.gvDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDetail.OptionsView.ShowFooter = true;
            // 
            // colDetailId
            // 
            this.colDetailId.FieldName = "Id";
            this.colDetailId.Name = "colDetailId";
            this.colDetailId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colDetailLineNum
            // 
            this.colDetailLineNum.FieldName = "LineNum";
            this.colDetailLineNum.Name = "colDetailLineNum";
            this.colDetailLineNum.Visible = true;
            this.colDetailLineNum.VisibleIndex = 0;
            // 
            // colDetailDescription
            // 
            this.colDetailDescription.FieldName = "Description";
            this.colDetailDescription.Name = "colDetailDescription";
            this.colDetailDescription.Visible = true;
            this.colDetailDescription.VisibleIndex = 1;
            // 
            // colDetailReference
            // 
            this.colDetailReference.FieldName = "Reference";
            this.colDetailReference.Name = "colDetailReference";
            this.colDetailReference.Visible = true;
            this.colDetailReference.VisibleIndex = 2;
            // 
            // colDetailAmount
            // 
            this.colDetailAmount.DisplayFormat.FormatString = "c2";
            this.colDetailAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailAmount.FieldName = "Amount";
            this.colDetailAmount.Name = "colDetailAmount";
            this.colDetailAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:c2}")});
            this.colDetailAmount.Visible = true;
            this.colDetailAmount.VisibleIndex = 3;
            // 
            // colDetailMarkupPercent
            // 
            this.colDetailMarkupPercent.DisplayFormat.FormatString = "p2";
            this.colDetailMarkupPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailMarkupPercent.FieldName = "MarkupPercent";
            this.colDetailMarkupPercent.Name = "colDetailMarkupPercent";
            this.colDetailMarkupPercent.Visible = true;
            this.colDetailMarkupPercent.VisibleIndex = 4;
            // 
            // colDetailMarkupAmount
            // 
            this.colDetailMarkupAmount.DisplayFormat.FormatString = "c2";
            this.colDetailMarkupAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailMarkupAmount.FieldName = "MarkupAmount";
            this.colDetailMarkupAmount.Name = "colDetailMarkupAmount";
            this.colDetailMarkupAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MarkupAmount", "{0:c2}")});
            this.colDetailMarkupAmount.Visible = true;
            this.colDetailMarkupAmount.VisibleIndex = 5;
            // 
            // colDetailBillAmount
            // 
            this.colDetailBillAmount.DisplayFormat.FormatString = "c2";
            this.colDetailBillAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailBillAmount.FieldName = "BillAmount";
            this.colDetailBillAmount.Name = "colDetailBillAmount";
            this.colDetailBillAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BillAmount", "{0:c2}")});
            this.colDetailBillAmount.Visible = true;
            this.colDetailBillAmount.VisibleIndex = 6;
            // 
            // text
            // 
            this.text.AutoHeight = false;
            this.text.Name = "text";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcAP);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1052, 364);
            this.panelControl2.TabIndex = 6;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 364);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(1052, 5);
            this.splitterControl1.TabIndex = 7;
            this.splitterControl1.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcDetail);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 369);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1052, 255);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "AP Details";
            // 
            // ucLemAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "ucLemAP";
            this.Size = new System.Drawing.Size(1052, 624);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableAP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet1;
        private System.Data.DataTable tableAP;
        private System.Data.DataColumn dataColId;
        private System.Data.DataColumn dataColDate;
        private System.Data.DataColumn dataColSselect;
        private System.Data.DataColumn dataColInvoiceNum;
        private System.Data.DataColumn dataColSupplier;
        private System.Data.DataColumn dataColPONum;
        private System.Data.DataColumn dataColProject;
        private System.Data.DataColumn dataColInvoiceAmount;
        private System.Data.DataColumn dataColMarkupAmount;
        private System.Data.DataColumn dataColBillAmount;
        private DevExpress.XtraGrid.GridControl gcAP;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAP;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private System.Data.DataTable tableDetail;
        private System.Data.DataColumn dataDetailColId;
        private System.Data.DataColumn dataDetailColLine;
        private System.Data.DataColumn dataDetailColDesc;
        private System.Data.DataColumn dataDetailColRef;
        private System.Data.DataColumn dataDetailColAmt;
        private System.Data.DataColumn dataDetailColMarkupPercent;
        private System.Data.DataColumn dataDetailColMarkupAmount;
        private System.Data.DataColumn dataDetailColBillAmount;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNum;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colPONum;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colMarkupAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colBillAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailId;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailLineNum;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailReference;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailMarkupPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailMarkupAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailBillAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit text;
    }
}
