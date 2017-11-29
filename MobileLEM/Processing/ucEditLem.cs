using System;
using MobileData;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraEditors;
using System.Collections.Generic;

namespace MobileLEM
{
    public partial class ucEditLem : DevExpress.XtraEditors.XtraUserControl
    {
        LemHeader _headerRecord;

        ucLabourEntry tabLabour;
        ucEquipmentEntry tabEquipment;
        ucEmployeeSummary tabEmployeeSummary;
        ucCostCodeSummary tabCostCodeSummary;
        ucLemAP tabLemAP;

        public ucEditLem()
        {
            InitializeComponent();
            this.Disposed += UcEditLem_Disposed;
        }

        private void UcEditLem_Disposed(object sender, EventArgs e)
        {
            if (tabLabour != null)
                tabLabour.Dispose();
            if (tabEquipment != null)
                tabEquipment.Dispose();
            if (tabEmployeeSummary != null)
                tabEmployeeSummary.Dispose();
            if (tabCostCodeSummary != null)
                tabCostCodeSummary.Dispose();
            if (tabLemAP != null)
                tabLemAP.Dispose();
        }

        void InitTab(XtraTabPage tab, XtraUserControl control)
        {
            control.Dock = DockStyle.Fill;
            control.Parent = tab;
            GuiCommon.HMDevXManager.FormInit(control);
        }

        public void SetCurrentHeader(LemHeader header)
        {
            _headerRecord = header;

            var project = Project.GetProject(header.ProjectId);
            labelProject.Text = project.DisplayName;
            labelDate.Text = header.LogDate.ToString("yyyy/MM/dd");
            labelCustName.Text = project.CustomerName;
            labelCustAddress.Text = project.CustomerAddress;
            labelSheetNum.Text = header.LemNum;
            labelReference.Text = project.POReference ?? "";
            SetEnabled(_headerRecord.CheckEditable());

            if (tabControl1.SelectedTabPage == tpLabour)
            {
                SetCurrentPage(tpLabour);
            }
            else
            {
                tabControl1.SelectedTabPage = tpLabour;
            }
        }

        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTabPage == tpLabour)
            {
                tabLabour.LoadFromTemplate();
            }
            else
            {
                tabEquipment.LoadFromTemplate();
            }
        }

        private void btnPrevDay_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTabPage == tpLabour)
            {
                tabLabour.LoadFromPrevDay();
            }
            else
            {
                tabEquipment.LoadFromPrevDay();
            }
        }

        void SetEnabled(bool enabled)
        {
            Parent.Text = enabled ? "Edit LEM" : "View LEM";
            btnLoadTemplate.Enabled = enabled;
            btnLoadPrevDay.Enabled = enabled;
        }

        private void tabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            SetCurrentPage(e.Page);
        }

        private void SetCurrentPage(XtraTabPage page)
        {
            if (page == tpLabour)
            {
                btnLoadPrevDay.Visible = true;
                btnLoadTemplate.Visible = true;

                if (tabLabour == null)
                {
                    tabLabour = new ucLabourEntry();
                    InitTab(tpLabour, tabLabour);
                }
                tabLabour.SetCurrent(_headerRecord);
            }
            else if (page == tpEquipment)
            {
                btnLoadPrevDay.Visible = true;
                btnLoadTemplate.Visible = true;

                if (tabEquipment == null)
                {
                    tabEquipment = new ucEquipmentEntry();
                    InitTab(tpEquipment, tabEquipment);
                }
                tabEquipment.SetCurrent(_headerRecord);
            }
            else if (page == tpEmployeeSummary)
            {
                btnLoadPrevDay.Visible = false;
                btnLoadTemplate.Visible = false;

                if (tabEmployeeSummary == null)
                {
                    tabEmployeeSummary = new ucEmployeeSummary();
                    InitTab(tpEmployeeSummary, tabEmployeeSummary);
                }

                tabEmployeeSummary.SetCurrent(_headerRecord);
            }
            else if (page == tpCostCodeSummary)
            {
                btnLoadPrevDay.Visible = false;
                btnLoadTemplate.Visible = false;

                if (tabCostCodeSummary == null)
                {
                    tabCostCodeSummary = new ucCostCodeSummary();
                    InitTab(tpCostCodeSummary, tabCostCodeSummary);
                }

                tabCostCodeSummary.SetCurrent(_headerRecord);
            }
            else if (page == tpLemAP)
            {
                btnLoadPrevDay.Visible = false;
                btnLoadTemplate.Visible = false;

                if (tabLemAP == null)
                {
                    tabLemAP = new ucLemAP();
                    InitTab(tpLemAP, tabLemAP);
                }

                tabLemAP.SetCurrent(_headerRecord);
            }
        }
    }
}
