namespace MobileLEM
{
    partial class ucToolEmpSum
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpSearch = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnClear1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlSearch = new DevExpress.XtraLayout.LayoutControl();
            this.luProject = new DevExpress.XtraEditors.LookUpEdit();
            this.deFromDate = new DevExpress.XtraEditors.DateEdit();
            this.deToDate = new DevExpress.XtraEditors.DateEdit();
            this.luLemNumber = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dpActions = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dataSet1 = new System.Data.DataSet();
            this.tableLabour = new System.Data.DataTable();
            this.dataColEmpNum = new System.Data.DataColumn();
            this.dataColEmpName = new System.Data.DataColumn();
            this.dataColWorkClass = new System.Data.DataColumn();
            this.dataColProject = new System.Data.DataColumn();
            this.dataColTotalHours = new System.Data.DataColumn();
            this.dataColBillAmount = new System.Data.DataColumn();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.luLemNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.dpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLabour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
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
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.dpSearch);
            this.panelContainer1.Controls.Add(this.dpActions);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.ID = new System.Guid("4194760f-f7b5-49aa-9bda-652814b1fbc8");
            this.panelContainer1.Location = new System.Drawing.Point(902, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(240, 200);
            this.panelContainer1.Size = new System.Drawing.Size(240, 592);
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
            this.dpSearch.OriginalSize = new System.Drawing.Size(240, 317);
            this.dpSearch.Size = new System.Drawing.Size(240, 328);
            this.dpSearch.Text = "Search";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.btnClear1);
            this.controlContainer1.Controls.Add(this.btnSearch1);
            this.controlContainer1.Controls.Add(this.layoutControlSearch);
            this.controlContainer1.Location = new System.Drawing.Point(5, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(231, 300);
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
            this.layoutControlSearch.Controls.Add(this.luLemNumber);
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
            this.luProject.Location = new System.Drawing.Point(58, 12);
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
            this.luProject.Size = new System.Drawing.Size(142, 20);
            this.luProject.StyleController = this.layoutControlSearch;
            this.luProject.TabIndex = 0;
            this.luProject.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.luProject_ButtonClick);
            // 
            // deFromDate
            // 
            this.deFromDate.EditValue = null;
            this.deFromDate.Location = new System.Drawing.Point(58, 36);
            this.deFromDate.Name = "deFromDate";
            this.deFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFromDate.Size = new System.Drawing.Size(142, 20);
            this.deFromDate.StyleController = this.layoutControlSearch;
            this.deFromDate.TabIndex = 2;
            this.deFromDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deFromDate_ButtonClick);
            // 
            // deToDate
            // 
            this.deToDate.EditValue = null;
            this.deToDate.Location = new System.Drawing.Point(58, 60);
            this.deToDate.Name = "deToDate";
            this.deToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deToDate.Size = new System.Drawing.Size(142, 20);
            this.deToDate.StyleController = this.layoutControlSearch;
            this.deToDate.TabIndex = 3;
            this.deToDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deToDate_ButtonClick);
            // 
            // luLemNumber
            // 
            this.luLemNumber.Location = new System.Drawing.Point(58, 84);
            this.luLemNumber.Name = "luLemNumber";
            this.luLemNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luLemNumber.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LemNum", "Lem Num", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.luLemNumber.Properties.DisplayMember = "LemNum";
            this.luLemNumber.Properties.NullText = "";
            this.luLemNumber.Properties.ValueMember = "LemNum";
            this.luLemNumber.Size = new System.Drawing.Size(142, 20);
            this.luLemNumber.StyleController = this.layoutControlSearch;
            this.luLemNumber.TabIndex = 4;
            this.luLemNumber.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.luLemNumber_ButtonClick);
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
            this.layoutControlItem3.TextSize = new System.Drawing.Size(43, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.deToDate;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(192, 24);
            this.layoutControlItem8.Text = "To";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(43, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.luLemNumber;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(192, 28);
            this.layoutControlItem9.Text = "LEM Num";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(43, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.luProject;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(192, 24);
            this.layoutControlItem10.Text = "Project";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(43, 13);
            // 
            // dpActions
            // 
            this.dpActions.Controls.Add(this.dockPanel2_Container);
            this.dpActions.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dpActions.ID = new System.Guid("0a460efb-10d1-4789-9a06-553f221c67c4");
            this.dpActions.Location = new System.Drawing.Point(0, 328);
            this.dpActions.Name = "dpActions";
            this.dpActions.Options.ShowCloseButton = false;
            this.dpActions.Options.ShowMaximizeButton = false;
            this.dpActions.OriginalSize = new System.Drawing.Size(240, 256);
            this.dpActions.Size = new System.Drawing.Size(240, 264);
            this.dpActions.Text = "Actions";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(5, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(231, 237);
            this.dockPanel2_Container.TabIndex = 0;
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
            this.dataColProject,
            this.dataColTotalHours,
            this.dataColBillAmount});
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
            // dataColProject
            // 
            this.dataColProject.AllowDBNull = false;
            this.dataColProject.ColumnName = "Project";
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
            this.colProject,
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
            // colProject
            // 
            this.colProject.FieldName = "Project";
            this.colProject.Name = "colProject";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 3;
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
            this.colTotalHours.VisibleIndex = 4;
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
            this.colBillAmount.VisibleIndex = 5;
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
            this.gcSummary.Size = new System.Drawing.Size(902, 592);
            this.gcSummary.TabIndex = 4;
            this.gcSummary.UseDisabledStatePainter = false;
            this.gcSummary.UseEmbeddedNavigator = true;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // ucToolEmpSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcSummary);
            this.Controls.Add(this.panelContainer1);
            this.Name = "ucToolEmpSum";
            this.Size = new System.Drawing.Size(1142, 592);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.luLemNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.dpActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLabour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dpSearch;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraEditors.SimpleButton btnClear1;
        private DevExpress.XtraEditors.SimpleButton btnSearch1;
        private DevExpress.XtraLayout.LayoutControl layoutControlSearch;
        private DevExpress.XtraEditors.LookUpEdit luProject;
        private DevExpress.XtraEditors.LookUpEdit luLemNumber;
        private DevExpress.XtraEditors.DateEdit deFromDate;
        private DevExpress.XtraEditors.DateEdit deToDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraBars.Docking.DockPanel dpActions;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable tableLabour;
        private System.Data.DataColumn dataColEmpNum;
        private System.Data.DataColumn dataColEmpName;
        private System.Data.DataColumn dataColWorkClass;
        private System.Data.DataColumn dataColProject;
        private System.Data.DataColumn dataColTotalHours;
        private System.Data.DataColumn dataColBillAmount;
        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpNum;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkClass;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalHours;
        private DevExpress.XtraGrid.Columns.GridColumn colBillAmount;
    }
}
