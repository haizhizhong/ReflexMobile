using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using MobileData;
using MobileLEM;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MobileMain
{
    public partial class ucMain : XtraUserControl
    {
        ucLemHeader tabLemHeader;
        ucEditLem tabEditLem;
        ucFieldPO tabFieldPO;

        ucSyncConfig tabSyncConfig;

        ucLemSheetQuery tabLemSheetQuery;
        ucSyncManage tabSyncManager;
        ucToolEmpSum tabToolEmpSum;
        ucToolCostCodeSum tabToolCostCodeSum;

        public ucMain()
        {
            InitializeComponent();

            ActiveProcessTab(tpHeaderList);
        }

        private void InitTab(XtraTabPage tab, XtraUserControl control)
        {
            control.Dock = DockStyle.Fill;
            control.Parent = tab;
            GuiCommon.HMDevXManager.FormInit(control);
        }

        private void ClearAll()
        {
            if (tabLemHeader != null)
            {
                tabLemHeader.Dispose();
                tabLemHeader = null;
            }

            if (tabFieldPO != null)
            {
                tabFieldPO.Dispose();
                tabFieldPO = null;
            }

            if (tabEditLem != null)
            {
                tabEditLem.Dispose();
                tabEditLem = null;
            }

            if (tabLemSheetQuery != null)
            {
                tabLemSheetQuery.ClearAll();
            }
        }

        private void hmTabControlProcess_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            ActiveProcessTab(e.Page);
        }

        private void ActiveProcessTab(XtraTabPage tabPage)
        {
            if (tabPage != null && tabPage.PageVisible)
            {
                if (tabPage == tpHeaderList)
                {
                    if (tabLemHeader == null)
                    {
                        tabLemHeader = new ucLemHeader();
                        InitTab(tpHeaderList, tabLemHeader);
                    }
                    else
                    {
                        tabLemHeader.RefreshCurrentRowStatus();
                    }
                }
                else if (tabPage == tpEditLem)
                {
                    if (tabEditLem == null)
                    {
                        tabEditLem = new ucEditLem();
                        InitTab(tpEditLem, tabEditLem);
                    }

                    var currLog = tabLemHeader.GetCurrentLog();
                    if (currLog != null)
                    {
                        tabEditLem.SetCurrentHeader(currLog);
                    }
                }
                else if (tabPage == tpFieldPO)
                {
                    if (tabFieldPO == null)
                    {
                        tabFieldPO = new ucFieldPO();
                        InitTab(tpFieldPO, tabFieldPO);
                    }
                    tabFieldPO.SetData();
                }
            }
            CL_Dialog.PleaseWait.Hide();
        }

        private void hmTabControlMainten_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            ActiveMaintenanceTab(e.Page);
        }

        private void ActiveMaintenanceTab(XtraTabPage tabPage)
        {
            if (tabPage != null && tabPage.PageVisible)
            {
                if (tabPage == tpSyncDefaultConfig)
                {
                    if (tabSyncConfig == null)
                    {
                        tabSyncConfig = new ucSyncConfig();
                        InitTab(tpSyncDefaultConfig, tabSyncConfig);
                    }

                    tabSyncConfig.SetData();
                }
            }
            CL_Dialog.PleaseWait.Hide();
        }

        private void hmTabControlTools_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            ActiveToolsTab(e.Page);
        }

        private void ActiveToolsTab(XtraTabPage tabPage)
        {
            if (tabPage != null && tabPage.PageVisible)
            {
                if (tabPage == tpLemSheetQuery)
                {
                    if (tabLemSheetQuery == null)
                    {
                        tabLemSheetQuery = new ucLemSheetQuery();
                        InitTab(tpLemSheetQuery, tabLemSheetQuery);
                    }
                }
                else if (tabPage == tpSyncManager)
                {
                    if (tabSyncManager == null)
                    {
                        tabSyncManager = new ucSyncManage();
                        InitTab(tpSyncManager, tabSyncManager);
                        tabSyncManager.AfterSync += ClearAll;
                    }
                    tabSyncManager.SetData();
                }
                else if (tabPage == tpToolEmpSum)
                {
                    if (tabToolEmpSum == null)
                    {
                        tabToolEmpSum = new ucToolEmpSum();
                        InitTab(tpToolEmpSum, tabToolEmpSum);
                    }
                    tabToolEmpSum.ClearAll();
                }
                else if (tabPage == tpToolCostCodeSum)
                {
                    if (tabToolCostCodeSum == null)
                    {
                        tabToolCostCodeSum = new ucToolCostCodeSum();
                        InitTab(tpToolCostCodeSum, tabToolCostCodeSum);
                    }
                    tabToolCostCodeSum.ClearAll();
                }
            }
            CL_Dialog.PleaseWait.Hide();
        }

        private void hmTabControlProcess_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tpEditLem)
            {
                if (tabLemHeader.GetCurrentLog() == null)
                {
                    GuiCommon.ShowMessage("Must select a log header.");
                    e.Cancel = true;
                }
            }
        }

        private void ucMain_Load(object sender, EventArgs e)
        {
            hmNavigationBar1.SetMOBSecurity(LoginUser.CurrUser.AccessList.Single(x => x.CompanyId == Company.CurrentId).Department, Company.CurrentId, MobileCommon.MobileDB);

            if (CompanySyncProcess.GetSyncProcessEnum(Company.CurrentId, EnumSyncType.Lookup) != EnumSyncProcess.NotSyncing)
            {
                GuiCommon.ShowMessage("Last Lookup Sync was broken, please finish or cancel it.");
                hmTabControlTop.SelectedTabPage = hmTabPageTools;
                hmTabControlTools.SelectedTabPage = tpSyncManager;
            }
            if (new EnumSyncProcess[] { EnumSyncProcess.NotSyncing, EnumSyncProcess.CoreHalfWay }.Contains(CompanySyncProcess.GetSyncProcessEnum(Company.CurrentId, EnumSyncType.Core)) == false)
            {
                GuiCommon.ShowMessage("Last Core Sync was broken, please finish or cancel it.");
                hmTabControlTop.SelectedTabPage = hmTabPageTools;
                hmTabControlTools.SelectedTabPage = tpSyncManager;
            }
        }

        private void hmTabControlTop_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page == hmTabPageProcess)
            {
                ActiveProcessTab(tpHeaderList);
            }
            else if (e.Page == hmTabPageMaintenance)
            {
                ActiveMaintenanceTab(tpSyncDefaultConfig);
            }
            else if (e.Page == hmTabPageTools)
            {
                ActiveToolsTab(tpLemSheetQuery);
            }
        }

        private void hmTabControlTools_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.PrevPage == tpSyncManager)
            {
                if (CompanySyncProcess.GetSyncProcessEnum(CompanySyncProcess.NoCompany, EnumSyncType.System) != EnumSyncProcess.NotSyncing)
                {
                    GuiCommon.ShowMessage("System Sync is broken, please run it again.");
                    e.Cancel = true;
                    return;
                }

                var syncStatus = CompanySyncProcess.GetSyncProcessEnum(Company.CurrentId, EnumSyncType.Lookup);
                if (syncStatus == EnumSyncProcess.LookupSyncing)
                {
                    GuiCommon.ShowMessage("Lookup Sync is broken, please finish or cancel it.");
                    e.Cancel = true;
                    return;
                }

                syncStatus = CompanySyncProcess.GetSyncProcessEnum(Company.CurrentId, EnumSyncType.Core);
                if (syncStatus == EnumSyncProcess.CoreSending)
                {
                    GuiCommon.ShowMessage("Core Sync is broken in sending data, please finish or cancel it.");
                    e.Cancel = true;
                    return;
                }
                else if (syncStatus == EnumSyncProcess.CoreReceiving)
                {
                    GuiCommon.ShowMessage("Core Sync is broken in receiving data, please finish or cancel it.");
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}