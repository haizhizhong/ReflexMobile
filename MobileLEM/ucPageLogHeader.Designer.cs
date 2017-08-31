namespace MobileLEM
{
    partial class ucPageLogHeader
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
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.luStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.deToDate = new DevExpress.XtraEditors.DateEdit();
            this.deFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.luProject = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnSync = new DevExpress.XtraEditors.SimpleButton();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintEmail = new DevExpress.XtraEditors.SimpleButton();
            this.btnAttach = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dataSetHeader = new System.Data.DataSet();
            this.tableHeader = new System.Data.DataTable();
            this.dataColId = new System.Data.DataColumn();
            this.dataColLogDate = new System.Data.DataColumn();
            this.dataColLemNum = new System.Data.DataColumn();
            this.dataColLogStatus = new System.Data.DataColumn();
            this.dataColProjectId = new System.Data.DataColumn();
            this.dataColProjectName = new System.Data.DataColumn();
            this.dataColCustCode = new System.Data.DataColumn();
            this.dataColCustName = new System.Data.DataColumn();
            this.dataColSiteLocation = new System.Data.DataColumn();
            this.dataColStartDate = new System.Data.DataColumn();
            this.dataColCompDate = new System.Data.DataColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colLemNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luColProject = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiteLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstCompletionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColProject)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(263, 60);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(67, 22);
            this.btnClear.StyleController = this.layoutControl1;
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnClear);
            this.layoutControl1.Controls.Add(this.luStatus);
            this.layoutControl1.Controls.Add(this.deToDate);
            this.layoutControl1.Controls.Add(this.deFromDate);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.luProject);
            this.layoutControl1.Location = new System.Drawing.Point(5, 7);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2231, 164, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(350, 94);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // luStatus
            // 
            this.luStatus.Location = new System.Drawing.Point(65, 60);
            this.luStatus.Name = "luStatus";
            this.luStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Status", "Status", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.luStatus.Properties.DisplayMember = "Status";
            this.luStatus.Properties.NullText = "";
            this.luStatus.Properties.ValueMember = "Status";
            this.luStatus.Size = new System.Drawing.Size(108, 20);
            this.luStatus.StyleController = this.layoutControl1;
            this.luStatus.TabIndex = 11;
            this.luStatus.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.luStatus_Properties_ButtonPressed);
            // 
            // deToDate
            // 
            this.deToDate.EditValue = null;
            this.deToDate.Location = new System.Drawing.Point(230, 36);
            this.deToDate.Name = "deToDate";
            this.deToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deToDate.Size = new System.Drawing.Size(108, 20);
            this.deToDate.StyleController = this.layoutControl1;
            this.deToDate.TabIndex = 10;
            this.deToDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deToDate_ButtonClick);
            // 
            // deFromDate
            // 
            this.deFromDate.EditValue = null;
            this.deFromDate.Location = new System.Drawing.Point(65, 36);
            this.deFromDate.Name = "deFromDate";
            this.deFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFromDate.Size = new System.Drawing.Size(108, 20);
            this.deFromDate.StyleController = this.layoutControl1;
            this.deFromDate.TabIndex = 9;
            this.deFromDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deFromDate_ButtonClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(185, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(58, 22);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // luProject
            // 
            this.luProject.Location = new System.Drawing.Point(65, 12);
            this.luProject.Name = "luProject";
            this.luProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.luProject.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 30, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Project", "Project", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.luProject.Properties.DisplayMember = "Desc";
            this.luProject.Properties.NullText = "";
            this.luProject.Properties.ValueMember = "MatchId";
            this.luProject.Size = new System.Drawing.Size(273, 20);
            this.luProject.StyleController = this.layoutControl1;
            this.luProject.TabIndex = 4;
            this.luProject.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.luProject_ButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(350, 94);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.deFromDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(107, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(165, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "From Date";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.deToDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(165, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(165, 24);
            this.layoutControlItem4.Text = "To Date";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnSearch;
            this.layoutControlItem6.Location = new System.Drawing.Point(165, 48);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(0, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(46, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 2, 2);
            this.layoutControlItem6.Size = new System.Drawing.Size(78, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.luStatus;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(165, 26);
            this.layoutControlItem5.Text = "Status";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnClear;
            this.layoutControlItem7.Location = new System.Drawing.Point(243, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 2, 2);
            this.layoutControlItem7.Size = new System.Drawing.Size(87, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.luProject;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(330, 24);
            this.layoutControlItem1.Text = "Project";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 13);
            // 
            // btnSync
            // 
            this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSync.Location = new System.Drawing.Point(1001, 13);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(123, 23);
            this.btnSync.TabIndex = 1;
            this.btnSync.Text = "Sync System Data";
            this.btnSync.Click += new System.EventHandler(this.btnSync_ClickAsync);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(1001, 71);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(123, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit LEM Sheet";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnPrintEmail
            // 
            this.btnPrintEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintEmail.Location = new System.Drawing.Point(1001, 42);
            this.btnPrintEmail.Name = "btnPrintEmail";
            this.btnPrintEmail.Size = new System.Drawing.Size(123, 23);
            this.btnPrintEmail.TabIndex = 3;
            this.btnPrintEmail.Text = "Print/Email LEM Sheet";
            this.btnPrintEmail.Click += new System.EventHandler(this.btnPrintEmail_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttach.Location = new System.Drawing.Point(839, 42);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(139, 23);
            this.btnAttach.TabIndex = 4;
            this.btnAttach.Text = "Add Attachment";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataMember = "LemLogHeader";
            this.gridControl1.DataSource = this.dataSetHeader;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gridControl1.Location = new System.Drawing.Point(15, 107);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.luColProject,
            this.luColDate});
            this.gridControl1.Size = new System.Drawing.Size(1111, 472);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dataSetHeader
            // 
            this.dataSetHeader.DataSetName = "NewDataSet";
            this.dataSetHeader.Tables.AddRange(new System.Data.DataTable[] {
            this.tableHeader});
            // 
            // tableHeader
            // 
            this.tableHeader.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColId,
            this.dataColLogDate,
            this.dataColLemNum,
            this.dataColLogStatus,
            this.dataColProjectId,
            this.dataColProjectName,
            this.dataColCustCode,
            this.dataColCustName,
            this.dataColSiteLocation,
            this.dataColStartDate,
            this.dataColCompDate});
            this.tableHeader.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, true)});
            this.tableHeader.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColId};
            this.tableHeader.TableName = "LemLogHeader";
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
            // dataColProjectId
            // 
            this.dataColProjectId.ColumnName = "ProjectId";
            this.dataColProjectId.DataType = typeof(int);
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
            // dataColStartDate
            // 
            this.dataColStartDate.ColumnName = "StartDate";
            // 
            // dataColCompDate
            // 
            this.dataColCompDate.ColumnName = "EstCompletionDate";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colLogDate,
            this.colLemNum,
            this.colLogStatus,
            this.colProjectId,
            this.colProjectName,
            this.colCustomerCode,
            this.colCustomerName,
            this.colSiteLocation,
            this.colStartDate,
            this.colEstCompletionDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gridView1_RowDeleting);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colLogDate
            // 
            this.colLogDate.ColumnEdit = this.luColDate;
            this.colLogDate.FieldName = "LogDate";
            this.colLogDate.Name = "colLogDate";
            this.colLogDate.Visible = true;
            this.colLogDate.VisibleIndex = 0;
            // 
            // luColDate
            // 
            this.luColDate.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.luColDate.AutoHeight = false;
            this.luColDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColDate.Mask.UseMaskAsDisplayFormat = true;
            this.luColDate.Name = "luColDate";
            // 
            // colLemNum
            // 
            this.colLemNum.FieldName = "LemNum";
            this.colLemNum.Name = "colLemNum";
            this.colLemNum.OptionsColumn.AllowEdit = false;
            this.colLemNum.Visible = true;
            this.colLemNum.VisibleIndex = 1;
            // 
            // colLogStatus
            // 
            this.colLogStatus.FieldName = "LogStatus";
            this.colLogStatus.Name = "colLogStatus";
            this.colLogStatus.OptionsColumn.AllowEdit = false;
            this.colLogStatus.Visible = true;
            this.colLogStatus.VisibleIndex = 2;
            // 
            // colProjectId
            // 
            this.colProjectId.Caption = "Project #";
            this.colProjectId.ColumnEdit = this.luColProject;
            this.colProjectId.FieldName = "ProjectId";
            this.colProjectId.Name = "colProjectId";
            this.colProjectId.Visible = true;
            this.colProjectId.VisibleIndex = 3;
            // 
            // luColProject
            // 
            this.luColProject.AutoHeight = false;
            this.luColProject.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luColProject.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Project", "Project")});
            this.luColProject.DisplayMember = "Code";
            this.luColProject.Name = "luColProject";
            this.luColProject.NullText = "";
            this.luColProject.ValueMember = "MatchId";
            // 
            // colProjectName
            // 
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.OptionsColumn.AllowEdit = false;
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
            // colStartDate
            // 
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.OptionsColumn.AllowEdit = false;
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 8;
            // 
            // colEstCompletionDate
            // 
            this.colEstCompletionDate.FieldName = "EstCompletionDate";
            this.colEstCompletionDate.Name = "colEstCompletionDate";
            this.colEstCompletionDate.OptionsColumn.AllowEdit = false;
            this.colEstCompletionDate.Visible = true;
            this.colEstCompletionDate.VisibleIndex = 9;
            // 
            // ucPageLogHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnPrintEmail);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.btnSubmit);
            this.Name = "ucPageLogHeader";
            this.Size = new System.Drawing.Size(1142, 592);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luColProject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit luStatus;
        private DevExpress.XtraEditors.DateEdit deToDate;
        private DevExpress.XtraEditors.DateEdit deFromDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LookUpEdit luProject;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnSync;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
        private DevExpress.XtraEditors.SimpleButton btnPrintEmail;
        private DevExpress.XtraEditors.SimpleButton btnAttach;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Data.DataSet dataSetHeader;
        private System.Data.DataTable tableHeader;
        private System.Data.DataColumn dataColId;
        private System.Data.DataColumn dataColLogDate;
        private System.Data.DataColumn dataColLemNum;
        private System.Data.DataColumn dataColLogStatus;
        private System.Data.DataColumn dataColProjectId;
        private System.Data.DataColumn dataColProjectName;
        private System.Data.DataColumn dataColCustCode;
        private System.Data.DataColumn dataColCustName;
        private System.Data.DataColumn dataColSiteLocation;
        private System.Data.DataColumn dataColStartDate;
        private System.Data.DataColumn dataColCompDate;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colLogDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLemNum;
        private DevExpress.XtraGrid.Columns.GridColumn colLogStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectId;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colSiteLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEstCompletionDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luColProject;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit luColDate;
    }
}
