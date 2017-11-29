namespace MobileLEM
{
    partial class ucSyncConfig
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
            this.dataSet1 = new System.Data.DataSet();
            this.tableSystem = new System.Data.DataTable();
            this.dataColSysId = new System.Data.DataColumn();
            this.dataColSysName = new System.Data.DataColumn();
            this.dataColSysSync = new System.Data.DataColumn();
            this.tableLookup = new System.Data.DataTable();
            this.dataColLookupId = new System.Data.DataColumn();
            this.dataColLookupName = new System.Data.DataColumn();
            this.dataColLookupSync = new System.Data.DataColumn();
            this.gcLookup = new DevExpress.XtraGrid.GridControl();
            this.gvLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLookupId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLookupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLookupSync = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkLookupSync = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.labelLookup = new DevExpress.XtraEditors.LabelControl();
            this.gcSystem = new DevExpress.XtraGrid.GridControl();
            this.gvSystem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSysId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSysName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSysSync = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkSysSync = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.labelSystem = new DevExpress.XtraEditors.LabelControl();
            this.btnLookupSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnLookupSelectNone = new DevExpress.XtraEditors.SimpleButton();
            this.btnSystemSelectNone = new DevExpress.XtraEditors.SimpleButton();
            this.btnSystemSelectAll = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLookupSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSysSync)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.tableSystem,
            this.tableLookup});
            // 
            // tableSystem
            // 
            this.tableSystem.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColSysId,
            this.dataColSysName,
            this.dataColSysSync});
            this.tableSystem.TableName = "tableSystem";
            // 
            // dataColSysId
            // 
            this.dataColSysId.ColumnName = "Id";
            this.dataColSysId.DataType = typeof(int);
            // 
            // dataColSysName
            // 
            this.dataColSysName.ColumnName = "Name";
            // 
            // dataColSysSync
            // 
            this.dataColSysSync.ColumnName = "Sync";
            this.dataColSysSync.DataType = typeof(bool);
            // 
            // tableLookup
            // 
            this.tableLookup.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColLookupId,
            this.dataColLookupName,
            this.dataColLookupSync});
            this.tableLookup.TableName = "tableLookup";
            // 
            // dataColLookupId
            // 
            this.dataColLookupId.ColumnName = "Id";
            this.dataColLookupId.DataType = typeof(int);
            // 
            // dataColLookupName
            // 
            this.dataColLookupName.ColumnName = "Name";
            // 
            // dataColLookupSync
            // 
            this.dataColLookupSync.ColumnName = "Sync";
            this.dataColLookupSync.DataType = typeof(bool);
            // 
            // gcLookup
            // 
            this.gcLookup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gcLookup.DataMember = "tableLookup";
            this.gcLookup.DataSource = this.dataSet1;
            this.gcLookup.Location = new System.Drawing.Point(25, 43);
            this.gcLookup.MainView = this.gvLookup;
            this.gcLookup.Name = "gcLookup";
            this.gcLookup.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkLookupSync});
            this.gcLookup.Size = new System.Drawing.Size(353, 439);
            this.gcLookup.TabIndex = 1;
            this.gcLookup.UseDisabledStatePainter = false;
            this.gcLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLookup});
            // 
            // gvLookup
            // 
            this.gvLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLookupId,
            this.colLookupName,
            this.colLookupSync});
            this.gvLookup.GridControl = this.gcLookup;
            this.gvLookup.Name = "gvLookup";
            this.gvLookup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLookup.OptionsView.ShowGroupPanel = false;
            this.gvLookup.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvLookup_CellValueChanged);
            // 
            // colLookupId
            // 
            this.colLookupId.FieldName = "Id";
            this.colLookupId.Name = "colLookupId";
            this.colLookupId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colLookupName
            // 
            this.colLookupName.FieldName = "Name";
            this.colLookupName.Name = "colLookupName";
            this.colLookupName.OptionsColumn.AllowEdit = false;
            this.colLookupName.Visible = true;
            this.colLookupName.VisibleIndex = 0;
            // 
            // colLookupSync
            // 
            this.colLookupSync.ColumnEdit = this.chkLookupSync;
            this.colLookupSync.FieldName = "Sync";
            this.colLookupSync.Name = "colLookupSync";
            this.colLookupSync.Visible = true;
            this.colLookupSync.VisibleIndex = 1;
            // 
            // chkLookupSync
            // 
            this.chkLookupSync.AutoHeight = false;
            this.chkLookupSync.Name = "chkLookupSync";
            // 
            // labelLookup
            // 
            this.labelLookup.Location = new System.Drawing.Point(25, 13);
            this.labelLookup.Name = "labelLookup";
            this.labelLookup.Size = new System.Drawing.Size(87, 13);
            this.labelLookup.TabIndex = 11;
            this.labelLookup.Text = "Company Lookups";
            // 
            // gcSystem
            // 
            this.gcSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gcSystem.DataMember = "tableSystem";
            this.gcSystem.DataSource = this.dataSet1;
            this.gcSystem.Location = new System.Drawing.Point(426, 43);
            this.gcSystem.MainView = this.gvSystem;
            this.gcSystem.Name = "gcSystem";
            this.gcSystem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkSysSync});
            this.gcSystem.Size = new System.Drawing.Size(353, 439);
            this.gcSystem.TabIndex = 12;
            this.gcSystem.UseDisabledStatePainter = false;
            this.gcSystem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSystem});
            // 
            // gvSystem
            // 
            this.gvSystem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSysId,
            this.colSysName,
            this.colSysSync});
            this.gvSystem.GridControl = this.gcSystem;
            this.gvSystem.Name = "gvSystem";
            this.gvSystem.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvSystem.OptionsView.ShowGroupPanel = false;
            this.gvSystem.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvSystem_CellValueChanged);
            // 
            // colSysId
            // 
            this.colSysId.FieldName = "Id";
            this.colSysId.Name = "colSysId";
            this.colSysId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colSysName
            // 
            this.colSysName.FieldName = "Name";
            this.colSysName.Name = "colSysName";
            this.colSysName.OptionsColumn.AllowEdit = false;
            this.colSysName.Visible = true;
            this.colSysName.VisibleIndex = 0;
            // 
            // colSysSync
            // 
            this.colSysSync.ColumnEdit = this.chkSysSync;
            this.colSysSync.FieldName = "Sync";
            this.colSysSync.Name = "colSysSync";
            this.colSysSync.Visible = true;
            this.colSysSync.VisibleIndex = 1;
            // 
            // chkSysSync
            // 
            this.chkSysSync.AutoHeight = false;
            this.chkSysSync.Name = "chkSysSync";
            // 
            // labelSystem
            // 
            this.labelSystem.Location = new System.Drawing.Point(426, 13);
            this.labelSystem.Name = "labelSystem";
            this.labelSystem.Size = new System.Drawing.Size(35, 13);
            this.labelSystem.TabIndex = 13;
            this.labelSystem.Text = "System";
            // 
            // btnLookupSelectAll
            // 
            this.btnLookupSelectAll.Location = new System.Drawing.Point(219, 14);
            this.btnLookupSelectAll.Name = "btnLookupSelectAll";
            this.btnLookupSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnLookupSelectAll.TabIndex = 14;
            this.btnLookupSelectAll.Text = "Select All";
            this.btnLookupSelectAll.Click += new System.EventHandler(this.btnLookupSelectAll_Click);
            // 
            // btnLookupSelectNone
            // 
            this.btnLookupSelectNone.Location = new System.Drawing.Point(303, 14);
            this.btnLookupSelectNone.Name = "btnLookupSelectNone";
            this.btnLookupSelectNone.Size = new System.Drawing.Size(75, 23);
            this.btnLookupSelectNone.TabIndex = 16;
            this.btnLookupSelectNone.Text = "Select None";
            this.btnLookupSelectNone.Click += new System.EventHandler(this.btnLookupSelectNone_Click);
            // 
            // btnSystemSelectNone
            // 
            this.btnSystemSelectNone.Location = new System.Drawing.Point(704, 14);
            this.btnSystemSelectNone.Name = "btnSystemSelectNone";
            this.btnSystemSelectNone.Size = new System.Drawing.Size(75, 23);
            this.btnSystemSelectNone.TabIndex = 18;
            this.btnSystemSelectNone.Text = "Select None";
            this.btnSystemSelectNone.Click += new System.EventHandler(this.btnSystemSelectNone_Click);
            // 
            // btnSystemSelectAll
            // 
            this.btnSystemSelectAll.Location = new System.Drawing.Point(620, 14);
            this.btnSystemSelectAll.Name = "btnSystemSelectAll";
            this.btnSystemSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSystemSelectAll.TabIndex = 17;
            this.btnSystemSelectAll.Text = "Select All";
            this.btnSystemSelectAll.Click += new System.EventHandler(this.btnSystemSelectAll_Click);
            // 
            // ucSyncConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSystemSelectNone);
            this.Controls.Add(this.btnSystemSelectAll);
            this.Controls.Add(this.btnLookupSelectNone);
            this.Controls.Add(this.btnLookupSelectAll);
            this.Controls.Add(this.labelSystem);
            this.Controls.Add(this.gcSystem);
            this.Controls.Add(this.labelLookup);
            this.Controls.Add(this.gcLookup);
            this.Name = "ucSyncConfig";
            this.Size = new System.Drawing.Size(1215, 540);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLookupSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSysSync)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet dataSet1;
        private System.Data.DataTable tableSystem;
        private System.Data.DataColumn dataColSysId;
        private System.Data.DataColumn dataColSysName;
        private System.Data.DataColumn dataColSysSync;
        private System.Data.DataTable tableLookup;
        private System.Data.DataColumn dataColLookupId;
        private System.Data.DataColumn dataColLookupName;
        private System.Data.DataColumn dataColLookupSync;
        private DevExpress.XtraGrid.GridControl gcLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLookup;
        private DevExpress.XtraGrid.Columns.GridColumn colLookupId;
        private DevExpress.XtraGrid.Columns.GridColumn colLookupName;
        private DevExpress.XtraGrid.Columns.GridColumn colLookupSync;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkLookupSync;
        private DevExpress.XtraEditors.LabelControl labelLookup;
        private DevExpress.XtraGrid.GridControl gcSystem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSystem;
        private DevExpress.XtraGrid.Columns.GridColumn colSysId;
        private DevExpress.XtraGrid.Columns.GridColumn colSysName;
        private DevExpress.XtraGrid.Columns.GridColumn colSysSync;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkSysSync;
        private DevExpress.XtraEditors.LabelControl labelSystem;
        private DevExpress.XtraEditors.SimpleButton btnLookupSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnLookupSelectNone;
        private DevExpress.XtraEditors.SimpleButton btnSystemSelectNone;
        private DevExpress.XtraEditors.SimpleButton btnSystemSelectAll;
    }
}
