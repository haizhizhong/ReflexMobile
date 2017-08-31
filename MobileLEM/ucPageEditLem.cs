using System;
using MobileData;
using System.Windows.Forms;

namespace MobileLEM
{
    public partial class ucPageEditLem : DevExpress.XtraEditors.XtraUserControl
    {
        ucTabLabour tabLabour = new ucTabLabour();
        ucTabEquipment tabEquipment = new ucTabEquipment();

        public ucPageEditLem()
        {
            InitializeComponent();
        }

        public void Init()
        {
            tabLabour.Init();
            tabLabour.Dock = DockStyle.Fill;
            tpLabour.Controls.Add(tabLabour);

            tabEquipment.Init();
            tabEquipment.Dock = DockStyle.Fill;
            tpEquipment.Controls.Add(tabEquipment);
        }

        public void SetCurrent(LemLogHeader header)
        {
            var project = Project.GetProject(header.ProjectId);
            labelProject.Text = $"{project.Code} - {project.Name}";
            labelDate.Text = header.LogDate.ToString("yyyy/MM/dd");
            labelCustName.Text = project.CustomerName;
            labelCustAddress.Text = project.CustomerAddress;

            labelReference.Text = "";
            labelSheetNum.Text = header.LemNum;

            SetEnabled(header);

            tabLabour.SetModify(header);
            tabEquipment.SetModify(header);

            tabControl1.SelectedTabPage = tpLabour;
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

        void SetEnabled(LemLogHeader header)
        {
            bool enabled = (header.LogStatus == EnumLogStatus.Open);

            Parent.Text = enabled ? "Edit LEM" : "View LEM";
            btnLoadPrevDay.Enabled = enabled;
            btnLoadTemplate.Enabled = enabled;
        }
    }
}
