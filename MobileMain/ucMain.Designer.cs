namespace MobileMain
{
    partial class ucMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hmTabControlTop = new HMTools.HMTabControl();
            this.hmNavigationBar1 = new HMTools.HMNavigationBar();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navBarGroupControlContainer3 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeList3 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.hmTabPageProcess = new HMTools.HMTabPage();
            this.hmTabControlProcess = new HMTools.HMTabControl();
            this.tpHeaderList = new HMTools.HMTabPage();
            this.tpEditLem = new HMTools.HMTabPage();
            this.tpFieldPO = new HMTools.HMTabPage();
            this.hmTabPageMaintenance = new HMTools.HMTabPage();
            this.hmTabControlMainten = new HMTools.HMTabControl();
            this.tpSyncDefaultConfig = new HMTools.HMTabPage();
            this.hmTabPageTools = new HMTools.HMTabPage();
            this.hmTabControlTools = new HMTools.HMTabControl();
            this.tpLemSheetQuery = new HMTools.HMTabPage();
            this.tpSyncManager = new HMTools.HMTabPage();
            this.tpToolEmpSum = new HMTools.HMTabPage();
            this.tpToolCostCodeSum = new HMTools.HMTabPage();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.hmTabControlTop)).BeginInit();
            this.hmTabControlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hmNavigationBar1)).BeginInit();
            this.hmNavigationBar1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
            this.navBarGroupControlContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList3)).BeginInit();
            this.hmTabPageProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hmTabControlProcess)).BeginInit();
            this.hmTabControlProcess.SuspendLayout();
            this.hmTabPageMaintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hmTabControlMainten)).BeginInit();
            this.hmTabControlMainten.SuspendLayout();
            this.hmTabPageTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hmTabControlTools)).BeginInit();
            this.hmTabControlTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // hmTabControlTop
            // 
            this.hmTabControlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hmTabControlTop.HM_IsRoot = true;
            this.hmTabControlTop.HM_NavigationBar = this.hmNavigationBar1;
            this.hmTabControlTop.HM_NextID = -12;
            this.hmTabControlTop.Location = new System.Drawing.Point(19, 0);
            this.hmTabControlTop.Name = "hmTabControlTop";
            this.hmTabControlTop.SelectedTabPage = this.hmTabPageProcess;
            this.hmTabControlTop.Size = new System.Drawing.Size(1074, 628);
            this.hmTabControlTop.TabIndex = 0;
            this.hmTabControlTop.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.hmTabPageProcess,
            this.hmTabPageMaintenance,
            this.hmTabPageTools});
            this.hmTabControlTop.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.hmTabControlTop_SelectedPageChanged);
            // 
            // hmNavigationBar1
            // 
            this.hmNavigationBar1.ActiveGroup = this.navBarGroup3;
            this.hmNavigationBar1.Controls.Add(this.navBarGroupControlContainer1);
            this.hmNavigationBar1.Controls.Add(this.navBarGroupControlContainer2);
            this.hmNavigationBar1.Controls.Add(this.navBarGroupControlContainer3);
            this.hmNavigationBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hmNavigationBar1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3});
            this.hmNavigationBar1.HM_DataRow.AppFlavor = "Main";
            this.hmNavigationBar1.HM_DataRow.AppStyle = "NewStyle";
            this.hmNavigationBar1.HM_DataRow.ID = 21773;
            this.hmNavigationBar1.HM_DataRow.ParentID = 0;
            this.hmNavigationBar1.HM_Module = "Reflex Field Services";
            this.hmNavigationBar1.HMTabControl = this.hmTabControlTop;
            this.hmNavigationBar1.Location = new System.Drawing.Point(0, 0);
            this.hmNavigationBar1.Name = "hmNavigationBar1";
            this.hmNavigationBar1.OptionsNavPane.ExpandedWidth = 221;
            this.hmNavigationBar1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.hmNavigationBar1.Size = new System.Drawing.Size(221, 601);
            this.hmNavigationBar1.TabIndex = 0;
            this.hmNavigationBar1.Text = "hmNavigationBar1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Processing";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup1.GroupClientHeight = 321;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer1.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer1.Controls.Add(this.treeList1);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(221, 442);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] {
            "LEM Sheets"}, -1);
            this.treeList1.AppendNode(new object[] {
            "Field POs"}, -1);
            this.treeList1.AppendNode(new object[] {
            "Field PO"}, -1);
            this.treeList1.EndUnboundLoad();
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.Size = new System.Drawing.Size(221, 442);
            this.treeList1.TabIndex = 1;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.MinWidth = 34;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer2.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer2.Controls.Add(this.treeList2);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(221, 442);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // treeList2
            // 
            this.treeList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2});
            this.treeList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList2.Location = new System.Drawing.Point(0, 0);
            this.treeList2.Name = "treeList2";
            this.treeList2.BeginUnboundLoad();
            this.treeList2.AppendNode(new object[] {
            "Upload / Download Default Configuration"}, -1);
            this.treeList2.EndUnboundLoad();
            this.treeList2.OptionsBehavior.Editable = false;
            this.treeList2.OptionsView.ShowColumns = false;
            this.treeList2.OptionsView.ShowHorzLines = false;
            this.treeList2.OptionsView.ShowIndicator = false;
            this.treeList2.OptionsView.ShowVertLines = false;
            this.treeList2.Size = new System.Drawing.Size(221, 442);
            this.treeList2.TabIndex = 2;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.MinWidth = 34;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            // 
            // navBarGroupControlContainer3
            // 
            this.navBarGroupControlContainer3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer3.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer3.Controls.Add(this.treeList3);
            this.navBarGroupControlContainer3.Name = "navBarGroupControlContainer3";
            this.navBarGroupControlContainer3.Size = new System.Drawing.Size(221, 442);
            this.navBarGroupControlContainer3.TabIndex = 2;
            // 
            // treeList3
            // 
            this.treeList3.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3});
            this.treeList3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList3.Location = new System.Drawing.Point(0, 0);
            this.treeList3.Name = "treeList3";
            this.treeList3.BeginUnboundLoad();
            this.treeList3.AppendNode(new object[] {
            "LEM Sheet Query"}, -1);
            this.treeList3.AppendNode(new object[] {
            "Upload / Download Assistant"}, -1);
            this.treeList3.EndUnboundLoad();
            this.treeList3.OptionsBehavior.Editable = false;
            this.treeList3.OptionsView.ShowColumns = false;
            this.treeList3.OptionsView.ShowHorzLines = false;
            this.treeList3.OptionsView.ShowIndicator = false;
            this.treeList3.OptionsView.ShowVertLines = false;
            this.treeList3.Size = new System.Drawing.Size(221, 442);
            this.treeList3.TabIndex = 0;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.MinWidth = 34;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Maintenance";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup2.GroupClientHeight = 414;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "Tools";
            this.navBarGroup3.ControlContainer = this.navBarGroupControlContainer3;
            this.navBarGroup3.Expanded = true;
            this.navBarGroup3.GroupClientHeight = 414;
            this.navBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // hmTabPageProcess
            // 
            this.hmTabPageProcess.Controls.Add(this.hmTabControlProcess);
            this.hmTabPageProcess.HM_DataRow.AppFlavor = "Main";
            this.hmTabPageProcess.HM_DataRow.AppStyle = "NewStyle";
            this.hmTabPageProcess.HM_DataRow.ID = 21774;
            this.hmTabPageProcess.HM_DataRow.ParentID = 21773;
            this.hmTabPageProcess.HM_Tree = this.treeList1;
            this.hmTabPageProcess.Name = "hmTabPageProcess";
            this.hmTabPageProcess.node = null;
            this.hmTabPageProcess.Size = new System.Drawing.Size(1068, 600);
            this.hmTabPageProcess.Text = "Processing";
            // 
            // hmTabControlProcess
            // 
            this.hmTabControlProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hmTabControlProcess.HM_IsRoot = false;
            this.hmTabControlProcess.HM_NavigationBar = null;
            this.hmTabControlProcess.HM_NextID = -1;
            this.hmTabControlProcess.Location = new System.Drawing.Point(0, 0);
            this.hmTabControlProcess.Name = "hmTabControlProcess";
            this.hmTabControlProcess.SelectedTabPage = this.tpHeaderList;
            this.hmTabControlProcess.Size = new System.Drawing.Size(1068, 600);
            this.hmTabControlProcess.TabIndex = 0;
            this.hmTabControlProcess.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpHeaderList,
            this.tpEditLem,
            this.tpFieldPO});
            this.hmTabControlProcess.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.hmTabControlProcess_SelectedPageChanged);
            this.hmTabControlProcess.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.hmTabControlProcess_SelectedPageChanging);
            // 
            // tpHeaderList
            // 
            this.tpHeaderList.HM_DataRow.AppFlavor = "Main";
            this.tpHeaderList.HM_DataRow.AppStyle = "NewStyle";
            this.tpHeaderList.HM_DataRow.ID = 21775;
            this.tpHeaderList.HM_DataRow.ParentID = 21774;
            this.tpHeaderList.HM_Tree = null;
            this.tpHeaderList.Name = "tpHeaderList";
            this.tpHeaderList.nodeID = 0;
            this.tpHeaderList.Size = new System.Drawing.Size(1062, 572);
            this.tpHeaderList.Text = "LEM Sheets";
            // 
            // tpEditLem
            // 
            this.tpEditLem.HM_DataRow.AppFlavor = "Main";
            this.tpEditLem.HM_DataRow.AppStyle = "NewStyle";
            this.tpEditLem.HM_DataRow.ID = 21776;
            this.tpEditLem.HM_DataRow.ParentID = 21774;
            this.tpEditLem.HM_Tree = null;
            this.tpEditLem.Name = "tpEditLem";
            this.tpEditLem.nodeID = 1;
            this.tpEditLem.Size = new System.Drawing.Size(1062, 572);
            this.tpEditLem.Text = "LEM Sheet Detail";
            // 
            // tpFieldPO
            // 
            this.tpFieldPO.HM_DataRow.AppFlavor = "Main";
            this.tpFieldPO.HM_DataRow.AppStyle = "NewStyle";
            this.tpFieldPO.HM_DataRow.ID = 21777;
            this.tpFieldPO.HM_DataRow.ParentID = 21774;
            this.tpFieldPO.HM_Tree = null;
            this.tpFieldPO.Name = "tpFieldPO";
            this.tpFieldPO.nodeID = 1;
            this.tpFieldPO.Size = new System.Drawing.Size(1062, 572);
            this.tpFieldPO.Text = "Field POs";
            // 
            // hmTabPageMaintenance
            // 
            this.hmTabPageMaintenance.Controls.Add(this.hmTabControlMainten);
            this.hmTabPageMaintenance.HM_DataRow.AppFlavor = "Main";
            this.hmTabPageMaintenance.HM_DataRow.AppStyle = "NewStyle";
            this.hmTabPageMaintenance.HM_DataRow.ID = 21778;
            this.hmTabPageMaintenance.HM_DataRow.ParentID = 21773;
            this.hmTabPageMaintenance.HM_Tree = this.treeList2;
            this.hmTabPageMaintenance.Name = "hmTabPageMaintenance";
            this.hmTabPageMaintenance.node = null;
            this.hmTabPageMaintenance.Size = new System.Drawing.Size(1068, 600);
            this.hmTabPageMaintenance.Text = "Maintenance";
            // 
            // hmTabControlMainten
            // 
            this.hmTabControlMainten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hmTabControlMainten.HM_IsRoot = false;
            this.hmTabControlMainten.HM_NavigationBar = null;
            this.hmTabControlMainten.HM_NextID = -1;
            this.hmTabControlMainten.Location = new System.Drawing.Point(0, 0);
            this.hmTabControlMainten.Name = "hmTabControlMainten";
            this.hmTabControlMainten.SelectedTabPage = this.tpSyncDefaultConfig;
            this.hmTabControlMainten.Size = new System.Drawing.Size(1068, 600);
            this.hmTabControlMainten.TabIndex = 0;
            this.hmTabControlMainten.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpSyncDefaultConfig});
            this.hmTabControlMainten.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.hmTabControlMainten_SelectedPageChanged);
            // 
            // tpSyncDefaultConfig
            // 
            this.tpSyncDefaultConfig.HM_DataRow.AppFlavor = "Main";
            this.tpSyncDefaultConfig.HM_DataRow.AppStyle = "NewStyle";
            this.tpSyncDefaultConfig.HM_DataRow.ID = 21783;
            this.tpSyncDefaultConfig.HM_DataRow.ParentID = 21778;
            this.tpSyncDefaultConfig.HM_Tree = null;
            this.tpSyncDefaultConfig.Name = "tpSyncDefaultConfig";
            this.tpSyncDefaultConfig.nodeID = 0;
            this.tpSyncDefaultConfig.Size = new System.Drawing.Size(1062, 572);
            this.tpSyncDefaultConfig.Text = "Upload / Download Default Configuration";
            // 
            // hmTabPageTools
            // 
            this.hmTabPageTools.Controls.Add(this.hmTabControlTools);
            this.hmTabPageTools.HM_DataRow.AppFlavor = "Main";
            this.hmTabPageTools.HM_DataRow.AppStyle = "NewStyle";
            this.hmTabPageTools.HM_DataRow.ID = 21779;
            this.hmTabPageTools.HM_DataRow.ParentID = 21773;
            this.hmTabPageTools.HM_Tree = this.treeList3;
            this.hmTabPageTools.Name = "hmTabPageTools";
            this.hmTabPageTools.node = null;
            this.hmTabPageTools.Size = new System.Drawing.Size(1068, 600);
            this.hmTabPageTools.Text = "Tools";
            // 
            // hmTabControlTools
            // 
            this.hmTabControlTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hmTabControlTools.HM_IsRoot = false;
            this.hmTabControlTools.HM_NavigationBar = null;
            this.hmTabControlTools.HM_NextID = -1;
            this.hmTabControlTools.Location = new System.Drawing.Point(0, 0);
            this.hmTabControlTools.Name = "hmTabControlTools";
            this.hmTabControlTools.SelectedTabPage = this.tpLemSheetQuery;
            this.hmTabControlTools.Size = new System.Drawing.Size(1068, 600);
            this.hmTabControlTools.TabIndex = 0;
            this.hmTabControlTools.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpLemSheetQuery,
            this.tpSyncManager,
            this.tpToolEmpSum,
            this.tpToolCostCodeSum});
            this.hmTabControlTools.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.hmTabControlTools_SelectedPageChanged);
            this.hmTabControlTools.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.hmTabControlTools_SelectedPageChanging);
            // 
            // tpLemSheetQuery
            // 
            this.tpLemSheetQuery.HM_DataRow.AppFlavor = "Main";
            this.tpLemSheetQuery.HM_DataRow.AppStyle = "NewStyle";
            this.tpLemSheetQuery.HM_DataRow.ID = 21781;
            this.tpLemSheetQuery.HM_DataRow.ParentID = 21779;
            this.tpLemSheetQuery.HM_Tree = null;
            this.tpLemSheetQuery.Name = "tpLemSheetQuery";
            this.tpLemSheetQuery.nodeID = 0;
            this.tpLemSheetQuery.Size = new System.Drawing.Size(1062, 572);
            this.tpLemSheetQuery.Text = "LEM Sheet Query";
            // 
            // tpSyncManager
            // 
            this.tpSyncManager.HM_DataRow.AppFlavor = "Main";
            this.tpSyncManager.HM_DataRow.AppStyle = "NewStyle";
            this.tpSyncManager.HM_DataRow.ID = 21782;
            this.tpSyncManager.HM_DataRow.ParentID = 21779;
            this.tpSyncManager.HM_Tree = null;
            this.tpSyncManager.Name = "tpSyncManager";
            this.tpSyncManager.nodeID = 1;
            this.tpSyncManager.Size = new System.Drawing.Size(1062, 572);
            this.tpSyncManager.Text = "Upload / Download Assistant";
            // 
            // tpToolEmpSum
            // 
            this.tpToolEmpSum.HM_DataRow.AppFlavor = "Main";
            this.tpToolEmpSum.HM_DataRow.AppStyle = "NewStyle";
            this.tpToolEmpSum.HM_DataRow.ID = 21788;
            this.tpToolEmpSum.HM_DataRow.ParentID = 21779;
            this.tpToolEmpSum.HM_Tree = null;
            this.tpToolEmpSum.Name = "tpToolEmpSum";
            this.tpToolEmpSum.nodeID = 1;
            this.tpToolEmpSum.Size = new System.Drawing.Size(1062, 572);
            this.tpToolEmpSum.Text = "Employee Summary";
            // 
            // tpToolCostCodeSum
            // 
            this.tpToolCostCodeSum.HM_DataRow.AppFlavor = "Main";
            this.tpToolCostCodeSum.HM_DataRow.AppStyle = "NewStyle";
            this.tpToolCostCodeSum.HM_DataRow.ID = 21789;
            this.tpToolCostCodeSum.HM_DataRow.ParentID = 21779;
            this.tpToolCostCodeSum.HM_Tree = null;
            this.tpToolCostCodeSum.Name = "tpToolCostCodeSum";
            this.tpToolCostCodeSum.nodeID = 1;
            this.tpToolCostCodeSum.Size = new System.Drawing.Size(1062, 572);
            this.tpToolCostCodeSum.Text = "Cost Code Summary";
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerLeft});
            this.dockManager1.DockingOptions.ShowCloseButton = false;
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
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerLeft.Controls.Add(this.dockPanel1);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(19, 628);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("fafa17dd-b99f-46e1-b345-4a4356ba2596");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(230, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(230, 628);
            this.dockPanel1.Text = "Navigator";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.hmNavigationBar1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(221, 601);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ucMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hmTabControlTop);
            this.Controls.Add(this.hideContainerLeft);
            this.Name = "ucMain";
            this.Size = new System.Drawing.Size(1093, 628);
            this.Load += new System.EventHandler(this.ucMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hmTabControlTop)).EndInit();
            this.hmTabControlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hmNavigationBar1)).EndInit();
            this.hmNavigationBar1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.navBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            this.navBarGroupControlContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList3)).EndInit();
            this.hmTabPageProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hmTabControlProcess)).EndInit();
            this.hmTabControlProcess.ResumeLayout(false);
            this.hmTabPageMaintenance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hmTabControlMainten)).EndInit();
            this.hmTabControlMainten.ResumeLayout(false);
            this.hmTabPageTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hmTabControlTools)).EndInit();
            this.hmTabControlTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HMTools.HMTabControl hmTabControlTop;
        private HMTools.HMTabPage hmTabPageProcess;
        private HMTools.HMTabPage hmTabPageMaintenance;
        private HMTools.HMTabPage hmTabPageTools;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private HMTools.HMNavigationBar hmNavigationBar1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer3;
        private DevExpress.XtraTreeList.TreeList treeList3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private HMTools.HMTabControl hmTabControlProcess;
        private HMTools.HMTabPage tpHeaderList;
        private HMTools.HMTabPage tpEditLem;
        private HMTools.HMTabPage tpFieldPO;
        private HMTools.HMTabControl hmTabControlTools;
        private HMTools.HMTabPage tpLemSheetQuery;
        private HMTools.HMTabPage tpSyncManager;
        private HMTools.HMTabPage tpToolEmpSum;
        private HMTools.HMTabPage tpToolCostCodeSum;
        private HMTools.HMTabControl hmTabControlMainten;
        private HMTools.HMTabPage tpSyncDefaultConfig;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
    }
}