namespace MobileLEM
{
    partial class ucLemSheetQuery
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dataSet = new System.Data.DataSet();
            this.tableHeader = new System.Data.DataTable();
            this.dataColId = new System.Data.DataColumn();
            this.dataColLogDate = new System.Data.DataColumn();
            this.dataColLemNum = new System.Data.DataColumn();
            this.dataColLogStatus = new System.Data.DataColumn();
            this.dataColProjectCode = new System.Data.DataColumn();
            this.dataColProjectName = new System.Data.DataColumn();
            this.dataColCustCode = new System.Data.DataColumn();
            this.dataColCustName = new System.Data.DataColumn();
            this.dataColSiteLocation = new System.Data.DataColumn();
            this.dataColLemTotal = new System.Data.DataColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLemNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiteLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLemTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dpAttachment = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpSearch = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnClear1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlSearch = new DevExpress.XtraLayout.LayoutControl();
            this.luProject = new DevExpress.XtraEditors.LookUpEdit();
            this.deFromDate = new DevExpress.XtraEditors.DateEdit();
            this.deToDate = new DevExpress.XtraEditors.DateEdit();
            this.luLogStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dpActions = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerBottom.SuspendLayout();
            this.dpAttachment.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            this.dpSearch.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlSearch)).BeginInit();
            this.layoutControlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luLogStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.dpActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "LemHeader";
            this.gridControl1.DataSource = this.dataSet;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(902, 573);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseDisabledStatePainter = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "NewDataSet";
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.tableHeader});
            // 
            // tableHeader
            // 
            this.tableHeader.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColId,
            this.dataColLogDate,
            this.dataColLemNum,
            this.dataColLogStatus,
            this.dataColProjectCode,
            this.dataColProjectName,
            this.dataColCustCode,
            this.dataColCustName,
            this.dataColSiteLocation,
            this.dataColLemTotal});
            this.tableHeader.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, true)});
            this.tableHeader.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColId};
            this.tableHeader.TableName = "LemHeader";
            // 
            // dataColId
            // 
            this.dataColId.AllowDBNull = false;
            this.dataColId.ColumnName = "Id";
            this.dataColId.DataType = typeof(int);
            // 
            // dataColLogDate
            // 
            this.dataColLogDate.ColumnName = "LogDate";
            this.dataColLogDate.DataType = typeof(System.DateTime);
            // 
            // dataColLemNum
            // 
            this.dataColLemNum.ColumnName = "LemNum";
            // 
            // dataColLogStatus
            // 
            this.dataColLogStatus.ColumnName = "LogStatus";
            // 
            // dataColProjectCode
            // 
            this.dataColProjectCode.ColumnName = "ProjectCode";
            // 
            // dataColProjectName
            // 
            this.dataColProjectName.ColumnName = "ProjectName";
            // 
            // dataColCustCode
            // 
            this.dataColCustCode.ColumnName = "CustomerCode";
            // 
            // dataColCustName
            // 
            this.dataColCustName.ColumnName = "CustomerName";
            // 
            // dataColSiteLocation
            // 
            this.dataColSiteLocation.ColumnName = "SiteLocation";
            // 
            // dataColLemTotal
            // 
            this.dataColLemTotal.Caption = "LEM Total";
            this.dataColLemTotal.ColumnName = "LemTotal";
            this.dataColLemTotal.DataType = typeof(decimal);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colLogDate,
            this.colLemNum,
            this.colLogStatus,
            this.colProjectCode,
            this.colProjectName,
            this.colCustomerCode,
            this.colCustomerName,
            this.colSiteLocation,
            this.colLemTotal});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colLogDate
            // 
            this.colLogDate.FieldName = "LogDate";
            this.colLogDate.Name = "colLogDate";
            this.colLogDate.Visible = true;
            this.colLogDate.VisibleIndex = 0;
            // 
            // colLemNum
            // 
            this.colLemNum.Caption = "LEM Number";
            this.colLemNum.FieldName = "LemNum";
            this.colLemNum.Name = "colLemNum";
            this.colLemNum.OptionsColumn.AllowEdit = false;
            this.colLemNum.Visible = true;
            this.colLemNum.VisibleIndex = 1;
            // 
            // colLogStatus
            // 
            this.colLogStatus.Caption = "Status";
            this.colLogStatus.FieldName = "LogStatus";
            this.colLogStatus.Name = "colLogStatus";
            this.colLogStatus.OptionsColumn.AllowEdit = false;
            this.colLogStatus.Visible = true;
            this.colLogStatus.VisibleIndex = 2;
            // 
            // colProjectCode
            // 
            this.colProjectCode.Caption = "Project #";
            this.colProjectCode.FieldName = "ProjectCode";
            this.colProjectCode.Name = "colProjectCode";
            this.colProjectCode.Visible = true;
            this.colProjectCode.VisibleIndex = 3;
            // 
            // colProjectName
            // 
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.Visible = true;
            this.colProjectName.VisibleIndex = 4;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.FieldName = "CustomerCode";
            this.colCustomerCode.Name = "colCustomerCode";
            this.colCustomerCode.OptionsColumn.AllowEdit = false;
            this.colCustomerCode.Visible = true;
            this.colCustomerCode.VisibleIndex = 5;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.AllowEdit = false;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 6;
            // 
            // colSiteLocation
            // 
            this.colSiteLocation.FieldName = "SiteLocation";
            this.colSiteLocation.Name = "colSiteLocation";
            this.colSiteLocation.OptionsColumn.AllowEdit = false;
            this.colSiteLocation.Visible = true;
            this.colSiteLocation.VisibleIndex = 7;
            // 
            // colLemTotal
            // 
            this.colLemTotal.DisplayFormat.FormatString = "c2";
            this.colLemTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLemTotal.FieldName = "LemTotal";
            this.colLemTotal.Name = "colLemTotal";
            this.colLemTotal.OptionsColumn.AllowEdit = false;
            this.colLemTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LemTotal", "{0:c2}")});
            this.colLemTotal.Visible = true;
            this.colLemTotal.VisibleIndex = 8;
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerBottom});
            this.dockManager1.DockingOptions.ShowCloseButton = false;
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1});
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
            // hideContainerBottom
            // 
            this.hideContainerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerBottom.Controls.Add(this.dpAttachment);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(0, 573);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(1142, 19);
            // 
            // dpAttachment
            // 
            this.dpAttachment.Controls.Add(this.dockPanel1_Container);
            this.dpAttachment.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpAttachment.ID = new System.Guid("812243a8-b1d2-4a12-b2f7-36c7bdf28fc2");
            this.dpAttachment.Location = new System.Drawing.Point(0, 0);
            this.dpAttachment.Name = "dpAttachment";
            this.dpAttachment.OriginalSize = new System.Drawing.Size(200, 304);
            this.dpAttachment.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpAttachment.SavedIndex = 0;
            this.dpAttachment.Size = new System.Drawing.Size(1142, 304);
            this.dpAttachment.Text = "Attachment";
            this.dpAttachment.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 24);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1134, 276);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.dpSearch);
            this.panelContainer1.Controls.Add(this.dpActions);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.ID = new System.Guid("4194760f-f7b5-49aa-9bda-652814b1fbc8");
            this.panelContainer1.Location = new System.Drawing.Point(902, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(240, 200);
            this.panelContainer1.Size = new System.Drawing.Size(240, 573);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dpSearch
            // 
            this.dpSearch.Controls.Add(this.controlContainer1);
            this.dpSearch.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dpSearch.FloatVertical = true;
            this.dpSearch.ID = new System.Guid("b61ddcb3-9c5b-41c4-8113-247d8a610251");
            this.dpSearch.Location = new System.Drawing.Point(0, 0);
            this.dpSearch.Name = "dpSearch";
            this.dpSearch.Options.ShowCloseButton = false;
            this.dpSearch.Options.ShowMaximizeButton = false;
            this.dpSearch.OriginalSize = new System.Drawing.Size(225, 307);
            this.dpSearch.Size = new System.Drawing.Size(240, 317);
            this.dpSearch.Text = "Search";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.btnClear1);
            this.controlContainer1.Controls.Add(this.btnSearch1);
            this.controlContainer1.Controls.Add(this.layoutControlSearch);
            this.controlContainer1.Location = new System.Drawing.Point(5, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(231, 289);
            this.controlContainer1.TabIndex = 0;
            // 
            // btnClear1
            // 
            this.btnClear1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear1.Location = new System.Drawing.Point(109, 175);
            this.btnClear1.Name = "btnClear1";
            this.btnClear1.Size = new System.Drawing.Size(75, 23);
            this.btnClear1.TabIndex = 2;
            this.btnClear1.Text = "Clear";
            this.btnClear1.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch1
            // 
            this.btnSearch1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch1.Location = new System.Drawing.Point(28, 175);
            this.btnSearch1.Name = "btnSearch1";
            this.btnSearch1.Size = new System.Drawing.Size(75, 23);
            this.btnSearch1.TabIndex = 1;
            this.btnSearch1.Text = "Search";
            this.btnSearch1.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // layoutControlSearch
            // 
            this.layoutControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControlSearch.Controls.Add(this.luProject);
            this.layoutControlSearch.Controls.Add(this.deFromDate);
            this.layoutControlSearch.Controls.Add(this.deToDate);
            this.layoutControlSearch.Controls.Add(this.luLogStatus);
            this.layoutControlSearch.Location = new System.Drawing.Point(7, 13);
            this.layoutControlSearch.Name = "layoutControlSearch";
            this.layoutControlSearch.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1253, 222, 450, 400);
            this.layoutControlSearch.Root = this.layoutControlGroupSearch;
            this.layoutControlSearch.Size = new System.Drawing.Size(212, 120);
            this.layoutControlSearch.TabIndex = 0;
            this.layoutControlSearch.Text = "layoutControl2";
            // 
            // luProject
            // 
            this.luProject.Location = new System.Drawing.Point(49, 12);
            this.luProject.Name = "luProject";
            this.luProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luProject.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 30, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Project", "Project", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.luProject.Properties.DisplayMember = "DisplayName";
            this.luProject.Properties.NullText = "";
            this.luProject.Properties.ValueMember = "MatchId";
            this.luProject.Size = new System.Drawing.Size(151, 20);
            this.luProject.StyleController = this.layoutControlSearch;
            this.luProject.TabIndex = 4;
            this.luProject.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.luProject_ButtonClick);
            // 
            // deFromDate
            // 
            this.deFromDate.EditValue = null;
            this.deFromDate.Location = new System.Drawing.Point(49, 36);
            this.deFromDate.Name = "deFromDate";
            this.deFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFromDate.Size = new System.Drawing.Size(151, 20);
            this.deFromDate.StyleController = this.layoutControlSearch;
            this.deFromDate.TabIndex = 9;
            this.deFromDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deFromDate_ButtonClick);
            // 
            // deToDate
            // 
            this.deToDate.EditValue = null;
            this.deToDate.Location = new System.Drawing.Point(49, 60);
            this.deToDate.Name = "deToDate";
            this.deToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deToDate.Size = new System.Drawing.Size(151, 20);
            this.deToDate.StyleController = this.layoutControlSearch;
            this.deToDate.TabIndex = 10;
            this.deToDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deToDate_ButtonClick);
            // 
            // luLogStatus
            // 
            this.luLogStatus.Location = new System.Drawing.Point(49, 84);
            this.luLogStatus.Name = "luLogStatus";
            this.luLogStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luLogStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Status", "Status", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.luLogStatus.Properties.DisplayMember = "Status";
            this.luLogStatus.Properties.NullText = "";
            this.luLogStatus.Properties.ValueMember = "Status";
            this.luLogStatus.Size = new System.Drawing.Size(151, 20);
            this.luLogStatus.StyleController = this.layoutControlSearch;
            this.luLogStatus.TabIndex = 11;
            this.luLogStatus.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.luStatus_Properties_ButtonPressed);
            // 
            // layoutControlGroupSearch
            // 
            this.layoutControlGroupSearch.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupSearch.GroupBordersVisible = false;
            this.layoutControlGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10});
            this.layoutControlGroupSearch.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupSearch.Name = "Root";
            this.layoutControlGroupSearch.Size = new System.Drawing.Size(212, 120);
            this.layoutControlGroupSearch.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.deFromDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(192, 24);
            this.layoutControlItem3.Text = "From ";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(34, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.deToDate;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(192, 24);
            this.layoutControlItem8.Text = "To";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(34, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.luLogStatus;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(192, 28);
            this.layoutControlItem9.Text = "Status";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(34, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.luProject;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(192, 24);
            this.layoutControlItem10.Text = "Project";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(34, 13);
            // 
            // dpActions
            // 
            this.dpActions.Controls.Add(this.dockPanel2_Container);
            this.dpActions.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dpActions.ID = new System.Guid("0a460efb-10d1-4789-9a06-553f221c67c4");
            this.dpActions.Location = new System.Drawing.Point(0, 317);
            this.dpActions.Name = "dpActions";
            this.dpActions.Options.ShowCloseButton = false;
            this.dpActions.Options.ShowMaximizeButton = false;
            this.dpActions.OriginalSize = new System.Drawing.Size(225, 266);
            this.dpActions.Size = new System.Drawing.Size(240, 256);
            this.dpActions.Text = "Actions";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(5, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(231, 229);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // ucLemSheetQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.hideContainerBottom);
            this.Name = "ucLemSheetQuery";
            this.Size = new System.Drawing.Size(1142, 592);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerBottom.ResumeLayout(false);
            this.dpAttachment.ResumeLayout(false);
            this.panelContainer1.ResumeLayout(false);
            this.dpSearch.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlSearch)).EndInit();
            this.layoutControlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luLogStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.dpActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Data.DataSet dataSet;
        private System.Data.DataTable tableHeader;
        private System.Data.DataColumn dataColId;
        private System.Data.DataColumn dataColLogDate;
        private System.Data.DataColumn dataColLemNum;
        private System.Data.DataColumn dataColLogStatus;
        private System.Data.DataColumn dataColProjectCode;
        private System.Data.DataColumn dataColProjectName;
        private System.Data.DataColumn dataColCustCode;
        private System.Data.DataColumn dataColCustName;
        private System.Data.DataColumn dataColSiteLocation;
        private System.Data.DataColumn dataColLemTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colLogDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLemNum;
        private DevExpress.XtraGrid.Columns.GridColumn colLogStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colSiteLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colLemTotal;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
        private DevExpress.XtraBars.Docking.DockPanel dpAttachment;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dpSearch;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraEditors.SimpleButton btnClear1;
        private DevExpress.XtraEditors.SimpleButton btnSearch1;
        private DevExpress.XtraLayout.LayoutControl layoutControlSearch;
        private DevExpress.XtraEditors.LookUpEdit luProject;
        private DevExpress.XtraEditors.LookUpEdit luLogStatus;
        private DevExpress.XtraEditors.DateEdit deFromDate;
        private DevExpress.XtraEditors.DateEdit deToDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraBars.Docking.DockPanel dpActions;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
    }
}
