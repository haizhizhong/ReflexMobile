namespace MobileLEM
{
    partial class ucEditLem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEditLem));
            this.labelCustName = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.labelSheetNum = new DevExpress.XtraEditors.LabelControl();
            this.labelReference = new DevExpress.XtraEditors.LabelControl();
            this.labelCustAddress = new DevExpress.XtraEditors.LabelControl();
            this.labelDate = new DevExpress.XtraEditors.LabelControl();
            this.labelProject = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gvEquipment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcEquipment = new DevExpress.XtraGrid.GridControl();
            this.tpEquipment = new DevExpress.XtraTab.XtraTabPage();
            this.tpCostCodeSummary = new DevExpress.XtraTab.XtraTabPage();
            this.tpEmployeeSummary = new DevExpress.XtraTab.XtraTabPage();
            this.tpLabour = new DevExpress.XtraTab.XtraTabPage();
            this.tabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tpLemAP = new DevExpress.XtraTab.XtraTabPage();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpInfo = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel4_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpActions = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnLoadPrevDay = new ReflexEditors.RHyperLinkEdit();
            this.btnLoadTemplate = new ReflexEditors.RHyperLinkEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            this.dpInfo.SuspendLayout();
            this.dockPanel4_Container.SuspendLayout();
            this.dpActions.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadPrevDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadTemplate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCustName
            // 
            this.labelCustName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCustName.Location = new System.Drawing.Point(83, 46);
            this.labelCustName.Name = "labelCustName";
            this.labelCustName.Size = new System.Drawing.Size(76, 13);
            this.labelCustName.StyleController = this.layoutControl1;
            this.labelCustName.TabIndex = 2;
            this.labelCustName.Text = "Customer Name";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelSheetNum);
            this.layoutControl1.Controls.Add(this.labelReference);
            this.layoutControl1.Controls.Add(this.labelCustAddress);
            this.layoutControl1.Controls.Add(this.labelCustName);
            this.layoutControl1.Controls.Add(this.labelDate);
            this.layoutControl1.Controls.Add(this.labelProject);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1216, 73, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(302, 329);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // labelSheetNum
            // 
            this.labelSheetNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSheetNum.Location = new System.Drawing.Point(83, 80);
            this.labelSheetNum.Name = "labelSheetNum";
            this.labelSheetNum.Size = new System.Drawing.Size(90, 13);
            this.labelSheetNum.StyleController = this.layoutControl1;
            this.labelSheetNum.TabIndex = 5;
            this.labelSheetNum.Text = "LEM Sheet Number";
            // 
            // labelReference
            // 
            this.labelReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReference.Location = new System.Drawing.Point(83, 97);
            this.labelReference.Name = "labelReference";
            this.labelReference.Size = new System.Drawing.Size(105, 13);
            this.labelReference.StyleController = this.layoutControl1;
            this.labelReference.TabIndex = 4;
            this.labelReference.Text = "Project PO/Reference";
            // 
            // labelCustAddress
            // 
            this.labelCustAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCustAddress.Location = new System.Drawing.Point(83, 63);
            this.labelCustAddress.Name = "labelCustAddress";
            this.labelCustAddress.Size = new System.Drawing.Size(88, 13);
            this.labelCustAddress.StyleController = this.layoutControl1;
            this.labelCustAddress.TabIndex = 3;
            this.labelCustAddress.Text = "Customer Address";
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.Location = new System.Drawing.Point(83, 29);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(23, 13);
            this.labelDate.StyleController = this.layoutControl1;
            this.labelDate.TabIndex = 7;
            this.labelDate.Text = "Date";
            // 
            // labelProject
            // 
            this.labelProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProject.Location = new System.Drawing.Point(83, 12);
            this.labelProject.Name = "labelProject";
            this.labelProject.Size = new System.Drawing.Size(64, 13);
            this.labelProject.StyleController = this.layoutControl1;
            this.labelProject.TabIndex = 6;
            this.labelProject.Text = "Project Name";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(302, 329);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.labelProject;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(282, 17);
            this.layoutControlItem1.Text = "Project";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.labelDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 17);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(282, 17);
            this.layoutControlItem2.Text = "Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.labelCustName;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(282, 17);
            this.layoutControlItem3.Text = "Customer";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.labelCustAddress;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 51);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(282, 17);
            this.layoutControlItem4.Text = "Address";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.labelSheetNum;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 68);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(282, 17);
            this.layoutControlItem6.Text = "LEM Sheet #";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.labelReference;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 85);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(282, 17);
            this.layoutControlItem5.Text = "PO/Reference";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(68, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 102);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(282, 207);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
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
            this.tpEquipment.Size = new System.Drawing.Size(877, 682);
            this.tpEquipment.Text = "Equipment";
            // 
            // tpCostCodeSummary
            // 
            this.tpCostCodeSummary.Name = "tpCostCodeSummary";
            this.tpCostCodeSummary.Size = new System.Drawing.Size(877, 682);
            this.tpCostCodeSummary.Text = "Cost Code Summary";
            // 
            // tpEmployeeSummary
            // 
            this.tpEmployeeSummary.Name = "tpEmployeeSummary";
            this.tpEmployeeSummary.Size = new System.Drawing.Size(877, 682);
            this.tpEmployeeSummary.Text = "Employee Summary";
            // 
            // tpLabour
            // 
            this.tpLabour.Name = "tpLabour";
            this.tpLabour.Size = new System.Drawing.Size(877, 682);
            this.tpLabour.Text = "Employee Time";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabPage = this.tpLabour;
            this.tabControl1.Size = new System.Drawing.Size(883, 710);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpLabour,
            this.tpEquipment,
            this.tpLemAP,
            this.tpEmployeeSummary,
            this.tpCostCodeSummary});
            this.tabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControl1_SelectedPageChanged);
            // 
            // tpLemAP
            // 
            this.tpLemAP.Name = "tpLemAP";
            this.tpLemAP.Size = new System.Drawing.Size(877, 682);
            this.tpLemAP.Text = "LEM AP";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
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
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("7c88e70b-4a34-4d26-bcea-036ec89cfbcc");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 714);
            this.dockPanel1.Text = "dockPanel1";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 687);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel2.ID = new System.Guid("31732b57-c344-4722-a991-02f7f61f0516");
            this.dockPanel2.Location = new System.Drawing.Point(998, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel2.SavedIndex = 0;
            this.dockPanel2.Size = new System.Drawing.Size(200, 714);
            this.dockPanel2.Text = "dockPanel2";
            this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(5, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(191, 687);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.dpInfo);
            this.panelContainer1.Controls.Add(this.dpActions);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.ID = new System.Guid("3b581760-99b4-40b3-b3c9-464a21cc3bba");
            this.panelContainer1.Location = new System.Drawing.Point(887, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(311, 200);
            this.panelContainer1.Size = new System.Drawing.Size(311, 714);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dpInfo
            // 
            this.dpInfo.Controls.Add(this.dockPanel4_Container);
            this.dpInfo.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dpInfo.ID = new System.Guid("3cf0860e-f4ca-4b5f-820f-1c088711b97d");
            this.dpInfo.Location = new System.Drawing.Point(0, 0);
            this.dpInfo.Name = "dpInfo";
            this.dpInfo.Options.ShowCloseButton = false;
            this.dpInfo.Options.ShowMaximizeButton = false;
            this.dpInfo.OriginalSize = new System.Drawing.Size(240, 357);
            this.dpInfo.Size = new System.Drawing.Size(311, 357);
            this.dpInfo.Text = "Information";
            // 
            // dockPanel4_Container
            // 
            this.dockPanel4_Container.Controls.Add(this.layoutControl1);
            this.dockPanel4_Container.Location = new System.Drawing.Point(5, 23);
            this.dockPanel4_Container.Name = "dockPanel4_Container";
            this.dockPanel4_Container.Size = new System.Drawing.Size(302, 329);
            this.dockPanel4_Container.TabIndex = 0;
            // 
            // dpActions
            // 
            this.dpActions.Controls.Add(this.dockPanel3_Container);
            this.dpActions.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dpActions.ID = new System.Guid("1b996946-3a4f-423b-b468-47e69312d8ea");
            this.dpActions.Location = new System.Drawing.Point(0, 357);
            this.dpActions.Name = "dpActions";
            this.dpActions.Options.ShowCloseButton = false;
            this.dpActions.Options.ShowMaximizeButton = false;
            this.dpActions.OriginalSize = new System.Drawing.Size(240, 357);
            this.dpActions.Size = new System.Drawing.Size(311, 357);
            this.dpActions.Text = "Actions";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.btnLoadPrevDay);
            this.dockPanel3_Container.Controls.Add(this.btnLoadTemplate);
            this.dockPanel3_Container.Location = new System.Drawing.Point(5, 23);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(302, 330);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // btnLoadPrevDay
            // 
            this.btnLoadPrevDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPrevDay.EditValue = "Load From Previous Day";
            this.btnLoadPrevDay.Location = new System.Drawing.Point(25, 56);
            this.btnLoadPrevDay.Name = "btnLoadPrevDay";
            this.btnLoadPrevDay.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadPrevDay.Properties.Appearance.Options.UseBackColor = true;
            this.btnLoadPrevDay.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnLoadPrevDay.Properties.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadPrevDay.Properties.Image")));
            this.btnLoadPrevDay.RESG_ImageType = ReflexImgSrc.Image.ImageType.Calendar;
            this.btnLoadPrevDay.Size = new System.Drawing.Size(229, 30);
            this.btnLoadPrevDay.TabIndex = 9;
            this.btnLoadPrevDay.Click += new System.EventHandler(this.btnPrevDay_Click);
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadTemplate.EditValue = "Load From Template";
            this.btnLoadTemplate.Location = new System.Drawing.Point(25, 20);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadTemplate.Properties.Appearance.Options.UseBackColor = true;
            this.btnLoadTemplate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnLoadTemplate.Properties.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadTemplate.Properties.Image")));
            this.btnLoadTemplate.RESG_ImageType = ReflexImgSrc.Image.ImageType.Task;
            this.btnLoadTemplate.Size = new System.Drawing.Size(255, 30);
            this.btnLoadTemplate.TabIndex = 8;
            this.btnLoadTemplate.Click += new System.EventHandler(this.btnLoadTemplate_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tabControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(887, 714);
            this.panelControl2.TabIndex = 13;
            // 
            // ucEditLem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelContainer1);
            this.Name = "ucEditLem";
            this.Size = new System.Drawing.Size(1198, 714);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.panelContainer1.ResumeLayout(false);
            this.dpInfo.ResumeLayout(false);
            this.dockPanel4_Container.ResumeLayout(false);
            this.dpActions.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadPrevDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadTemplate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private DevExpress.XtraGrid.Views.Grid.GridView gvEquipment;
        private DevExpress.XtraGrid.GridControl gcEquipment;
        private DevExpress.XtraTab.XtraTabPage tpEquipment;
        private DevExpress.XtraTab.XtraTabPage tpCostCodeSummary;
        private DevExpress.XtraTab.XtraTabPage tpEmployeeSummary;
        private DevExpress.XtraTab.XtraTabPage tpLabour;
        private DevExpress.XtraTab.XtraTabControl tabControl1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dpInfo;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel4_Container;
        private DevExpress.XtraBars.Docking.DockPanel dpActions;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private ReflexEditors.RHyperLinkEdit btnLoadPrevDay;
        private ReflexEditors.RHyperLinkEdit btnLoadTemplate;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraEditors.LabelControl labelProject;
        private DevExpress.XtraEditors.LabelControl labelDate;
        private DevExpress.XtraTab.XtraTabPage tpLemAP;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}
