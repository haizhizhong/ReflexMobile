namespace MobileLEM
{
    partial class ucPageEditLem
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
            this.labelCustName = new DevExpress.XtraEditors.LabelControl();
            this.labelCustAddress = new DevExpress.XtraEditors.LabelControl();
            this.labelReference = new DevExpress.XtraEditors.LabelControl();
            this.labelSheetNum = new DevExpress.XtraEditors.LabelControl();
            this.btnLoadTemplate = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadPrevDay = new DevExpress.XtraEditors.SimpleButton();
            this.gvEquipment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcEquipment = new DevExpress.XtraGrid.GridControl();
            this.tpEquipment = new DevExpress.XtraTab.XtraTabPage();
            this.tabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tpLabour = new DevExpress.XtraTab.XtraTabPage();
            this.labelProject = new DevExpress.XtraEditors.LabelControl();
            this.labelDate = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCustName
            // 
            this.labelCustName.Location = new System.Drawing.Point(300, 21);
            this.labelCustName.Name = "labelCustName";
            this.labelCustName.Size = new System.Drawing.Size(76, 13);
            this.labelCustName.TabIndex = 2;
            this.labelCustName.Text = "Customer Name";
            // 
            // labelCustAddress
            // 
            this.labelCustAddress.Location = new System.Drawing.Point(300, 40);
            this.labelCustAddress.Name = "labelCustAddress";
            this.labelCustAddress.Size = new System.Drawing.Size(88, 13);
            this.labelCustAddress.TabIndex = 3;
            this.labelCustAddress.Text = "Customer Address";
            // 
            // labelReference
            // 
            this.labelReference.Location = new System.Drawing.Point(459, 21);
            this.labelReference.Name = "labelReference";
            this.labelReference.Size = new System.Drawing.Size(105, 13);
            this.labelReference.TabIndex = 4;
            this.labelReference.Text = "Project PO/Reference";
            // 
            // labelSheetNum
            // 
            this.labelSheetNum.Location = new System.Drawing.Point(459, 40);
            this.labelSheetNum.Name = "labelSheetNum";
            this.labelSheetNum.Size = new System.Drawing.Size(90, 13);
            this.labelSheetNum.TabIndex = 5;
            this.labelSheetNum.Text = "LEM Sheet Number";
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadTemplate.Location = new System.Drawing.Point(968, 30);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(196, 23);
            this.btnLoadTemplate.TabIndex = 6;
            this.btnLoadTemplate.Text = "Load From Template";
            this.btnLoadTemplate.Click += new System.EventHandler(this.btnLoadTemplate_Click);
            // 
            // btnLoadPrevDay
            // 
            this.btnLoadPrevDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPrevDay.Location = new System.Drawing.Point(968, 59);
            this.btnLoadPrevDay.Name = "btnLoadPrevDay";
            this.btnLoadPrevDay.Size = new System.Drawing.Size(196, 23);
            this.btnLoadPrevDay.TabIndex = 7;
            this.btnLoadPrevDay.Text = "Load From Precious Day";
            this.btnLoadPrevDay.Click += new System.EventHandler(this.btnPrevDay_Click);
            // 
            // gvEquipment
            // 
            this.gvEquipment.GridControl = this.gcEquipment;
            this.gvEquipment.Name = "gvEquipment";
            // 
            // gcEquipment
            // 
            this.gcEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEquipment.Location = new System.Drawing.Point(0, 0);
            this.gcEquipment.MainView = this.gvEquipment;
            this.gcEquipment.Name = "gcEquipment";
            this.gcEquipment.Size = new System.Drawing.Size(942, 506);
            this.gcEquipment.TabIndex = 1;
            this.gcEquipment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEquipment});
            // 
            // tpEquipment
            // 
            this.tpEquipment.Name = "tpEquipment";
            this.tpEquipment.Size = new System.Drawing.Size(1179, 586);
            this.tpEquipment.Text = "Equipment";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(9, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabPage = this.tpLabour;
            this.tabControl1.Size = new System.Drawing.Size(1185, 614);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpLabour,
            this.tpEquipment});
            // 
            // tpEmployee
            // 
            this.tpLabour.Name = "tpEmployee";
            this.tpLabour.Size = new System.Drawing.Size(1179, 586);
            this.tpLabour.Text = "Employee Time";
            // 
            // labelProject
            // 
            this.labelProject.Location = new System.Drawing.Point(52, 21);
            this.labelProject.Name = "labelProject";
            this.labelProject.Size = new System.Drawing.Size(34, 13);
            this.labelProject.TabIndex = 9;
            this.labelProject.Text = "Project";
            // 
            // labelDate
            // 
            this.labelDate.Location = new System.Drawing.Point(52, 40);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(23, 13);
            this.labelDate.TabIndex = 10;
            this.labelDate.Text = "Date";
            // 
            // ucPageEditLem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelProject);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnLoadPrevDay);
            this.Controls.Add(this.btnLoadTemplate);
            this.Controls.Add(this.labelCustName);
            this.Controls.Add(this.labelSheetNum);
            this.Controls.Add(this.labelCustAddress);
            this.Controls.Add(this.labelReference);
            this.Name = "ucPageEditLem";
            this.Size = new System.Drawing.Size(1200, 714);
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void GvEmployee_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelCustName;
        private DevExpress.XtraEditors.LabelControl labelCustAddress;
        private DevExpress.XtraEditors.LabelControl labelReference;
        private DevExpress.XtraEditors.LabelControl labelSheetNum;
        private DevExpress.XtraEditors.SimpleButton btnLoadTemplate;
        private DevExpress.XtraEditors.SimpleButton btnLoadPrevDay;
        private DevExpress.XtraTab.XtraTabPage tpEquipment;
        private DevExpress.XtraTab.XtraTabControl tabControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEquipment;
        private DevExpress.XtraTab.XtraTabPage tpLabour;
        private DevExpress.XtraGrid.GridControl gcEquipment;
        private DevExpress.XtraEditors.LabelControl labelProject;
        private DevExpress.XtraEditors.LabelControl labelDate;
    }
}
