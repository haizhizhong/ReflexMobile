using MobileData;
using System;
using System.Linq;
using System.Windows.Forms;
using WS_Popups;

namespace MobileMain
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();

            Common.HMDevXManager = new TUC_HMDevXManager.TUC_HMDevXManager(defaultLookAndFeel1);
            Common.MobileDB = $"Data Source =localhost\\SQLEXPRESS; Initial Catalog = ReflexMobile; Integrated Security = True;";
            Common.Popups = new frmPopup(Common.HMDevXManager);
        }

        private void frmForm_Load(object sender, EventArgs e)
        {
            gcLogin.Left = (this.Width / 2) - ((gcLogin.Width + 50) / 2);
            gcLogin.Top = (this.Height / 2) - ((gcLogin.Height + 75) / 2);

            gcLogin.Visible = true;
            teUsername.EditValue = System.Environment.UserName;
            tePassword.Focus();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (gcLogin.Visible)
            {
                gcLogin.Left = (this.Width / 2) - (gcLogin.Width / 2);
                gcLogin.Top = (this.Height / 2) - (gcLogin.Height / 2);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            VerifiyUser();
        }

        private void VerifiyUser()
        {
            if (teUsername.EditValue == null)
            {
                Common.Popups.ShowPopup(this, "Please enter a user name.");
                return;
            }
            //if (tePassword.EditValue == null)
            //{
            //    Common.Popups.ShowPopup(this, "Please enter a password.");
            //    return;
            //}

            int? id = LoginUser.ValidUser(teUsername.EditValue.ToString(), tePassword.EditValue?.ToString() ?? "");
            if (id == null)
            {
                Common.Popups.ShowPopup(this, "Incorrect Username / Password.");
                return;
            }
            else
            {
                LoginUser.CurrUser = LoginUser.GetUser(id.Value);

                Common.HMDevXManager.AppInit(LoginUser.CurrUser.UserName);
                Common.HMDevXManager.FormInit(this);

                luCompany.Properties.DataSource = Company.List.Where( x=> LoginUser.CurrUser.CompanyList.Contains(x.MatchId)).Select( x=> new { CompanyID = x.MatchId, CompanyName = x.CompanyName });
                if (LoginUser.CurrUser.CompanyList.Count == 1)
                {
                    luCompany.ItemIndex = 0;//autoload the only company
                }
            }
        }

        private void luCompany_EditValueChanged(object sender, EventArgs e)
        {
            Company.CurrentId = (int)luCompany.EditValue;
            myBar.ClearLinks();

            DevExpress.XtraBars.BarLargeButtonItem TerminalItem = new DevExpress.XtraBars.BarLargeButtonItem(barManager1, "Reflex Mobile");
            TerminalItem.Tag = 999;
            TerminalItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(TerminalItem_ItemClick);
            myBar.AddItem(TerminalItem);

            DevExpress.XtraBars.BarMdiChildrenListItem Windows = new DevExpress.XtraBars.BarMdiChildrenListItem();
            Windows.Caption = "&Windows";
            myBar.AddItem(Windows);

            DevExpress.XtraBars.BarLargeButtonItem About = new DevExpress.XtraBars.BarLargeButtonItem(barManager1, "About");
            About.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(About_ItemClick);
            myBar.AddItem(About);
        }

        private void TerminalItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraEditors.XtraForm newMDIChild = new DevExpress.XtraEditors.XtraForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Tag = 888;
            newMDIChild.Show();
            newMDIChild.Text = e.Item.Caption + " (" + Company.GetCompany(Company.CurrentId).CompanyName + ")";

            ucMain uc = new ucMain();
            uc.Init();
            uc.Size = newMDIChild.Size;
            uc.Dock = DockStyle.Fill;
            uc.Parent = newMDIChild;
            tabbedView1.AddDocument(newMDIChild);
        }

        private void About_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void tabbedView1_DocumentAdded(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            if (tabbedView1.Documents.Count > 0)
            {
                try
                {
                    panelControl1.Hide();
                    pnlLogin.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                    layoutControl1.Parent = pnlLogin;
                }
                catch
                {
                    //This is done to prevent a cannot access a disposed object message as this only appears when were tring to close out of the 
                    //applicaiton anyway. This way the message is negated.
                }
            }
        }

        private void tabbedView1_DocumentRemoved(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            if (tabbedView1.Documents.Count == 0)
            {
                try
                {
                    panelControl1.Visible = true;
                    gcLogin.Visible = true;
                    gcLogin.BringToFront();
                    layoutControl1.Parent = gcLogin;
                    layoutControl1.Dock = DockStyle.Fill;
                    pnlLogin.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                }
                catch
                {
                    //This is done to prevent a cannot access a disposed object message as this only appears when were tring to close out of the 
                    //applicaiton anyway. This way the message is negated.
                }
            }
        }

        private void tePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                VerifiyUser();
        }
    }
}
