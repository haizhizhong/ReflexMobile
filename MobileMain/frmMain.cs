using MobileData;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using HMConnection;
using System.Configuration;
using MobileLEM;
using System.Runtime.InteropServices;

namespace MobileMain
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();

            MobileCommon.ServerName = ConfigurationManager.AppSettings["ServerName"];
            MobileCommon.DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
            MobileCommon.MobileDB = $"Data Source ={MobileCommon.ServerName}; Initial Catalog = {MobileCommon.DatabaseName}; Integrated Security = True;";

            GuiCommon.HMDevXManager = new TUC_HMDevXManager.TUC_HMDevXManager(defaultLookAndFeel1);
            ReflexCommon.SqlCommon.ReportMessage += GuiCommon.ShowMessage;
            DataManage.ReportMessage += GuiCommon.ShowMessage;

            DataManage.CheckCreateDatabase();
            if (!DataManage.HasDBAccess())
            {
                GuiCommon.ShowMessage("Please contact your system administrator to grant you database access.");
                return;
            }

            DataManage.Purge();
        }

        private void frmForm_Load(object sender, EventArgs e)
        {
            gcLogin.Left = (this.Width / 2) - ((gcLogin.Width + 50) / 2);
            gcLogin.Top = (this.Height / 2) - ((gcLogin.Height + 75) / 2);

            gcLogin.Visible = true;
            teUsername.EditValue = Environment.UserName;
//            tePassword.EditValue = "Trustno1";         //todo
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

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        private void VerifiyUser()
        {
            if (CompanySyncProcess.GetSyncProcessEnum(CompanySyncProcess.NoCompany, EnumSyncType.System) != EnumSyncProcess.NotSyncing)
            {
                GuiCommon.ShowMessage("First time use or sync broken, need to Sync Users.");
                btnSync.Focus();
                return;
            }

            if (teUsername.EditValue == null)
            {
                GuiCommon.ShowMessage("Please enter a user name.");
                return;
            }

            if (tePassword.EditValue == null)
            {
                GuiCommon.ShowMessage("Please enter a password.");
                return;
            }

            IntPtr userHandle = IntPtr.Zero;
            bool winValid = LogonUser(teUsername.EditValue.ToString(),
                                            System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName,
                                            tePassword.EditValue.ToString(),
                                            2, 0, ref userHandle);
            if (!winValid)
            {
                GuiCommon.ShowMessage("Failed in windows authentication. Incorrect Username/Password.");
                return;
            }

            int? id = LoginUser.ValidUser(teUsername.EditValue.ToString());
            if (id == null)
            {
                GuiCommon.ShowMessage("Cannot find this user.");
                return;
            }
            else
            {
                LoginUser.CurrUser = LoginUser.GetUser(id.Value);
                DataManage.UpdateCodeVersion();
                if (LoginUser.MaxCodeVersion() != LoginUser.CurrUser.CodeVersion)
                {
                    GuiCommon.ShowMessage("Code verion is not correct, please log out and restart.");
                    return;
                }

                luCompany.Properties.DataSource = Company.List.Where( x=> LoginUser.CurrUser.AccessList.Select(a => a.CompanyId).Contains(x.MatchId)).Select( x=> new { CompanyID = x.MatchId, CompanyName = x.CompanyName });
                if (LoginUser.CurrUser.AccessList.Count == 1)
                {
                    luCompany.ItemIndex = 0;//autoload the only company
                }
            }
        }

        private void luCompany_EditValueChanged(object sender, EventArgs e)
        {
            Company.CurrentId = (int)luCompany.EditValue;
            myBar.ClearLinks();

            this.Text = $"Reflex {LoginUser.CurrUser.LoginName} has logged into {Company.GetCurrCompany().CompanyName}";

            DevExpress.XtraBars.BarLargeButtonItem mainItem = new DevExpress.XtraBars.BarLargeButtonItem(barManager1, $"Reflex Field Services");
            mainItem.Tag = 999;
            mainItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(TerminalItem_ItemClick);
            myBar.AddItem(mainItem);

            DevExpress.XtraBars.BarMdiChildrenListItem Windows = new DevExpress.XtraBars.BarMdiChildrenListItem();
            Windows.Caption = "&Windows";
            myBar.AddItem(Windows);

            DevExpress.XtraBars.BarLargeButtonItem About = new DevExpress.XtraBars.BarLargeButtonItem(barManager1, "About");
            About.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(About_ItemClick);
            myBar.AddItem(About);

            var providerList = new List<IInitProvider> { new MobileCompanyInitProvider(), new MobileUserInitProvider() };
            MobileCommon.HMCon = new HMCon(MobileCommon.DatabaseName, MobileCommon.ServerName, Company.CurrentId, LoginUser.CurrUser.MatchId, providerList);

            GuiCommon.HMDevXManager.AppInit(LoginUser.CurrUser.GetUserName());
            GuiCommon.HMDevXManager.FormInit(this);
        }

        private void TerminalItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraEditors.XtraForm newMDIChild = new DevExpress.XtraEditors.XtraForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Tag = 888;
            newMDIChild.Show();
            newMDIChild.Text = e.Item.Caption + " (" + Company.GetCurrCompany().CompanyName + ")";

            ucMain uc = new ucMain();
            uc.Size = newMDIChild.Size;
            uc.Dock = DockStyle.Fill;
            string keep = this.Text;
            uc.Parent = newMDIChild;
            tabbedView1.AddDocument(newMDIChild);

            this.Text = keep;
        }

        private void About_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreen2 ss = new SplashScreen2();
            ss.ShowDialog();
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

        private async void btnSync_ClickAsync(object sender, EventArgs e)
        {
            CL_Dialog.PleaseWait.Show("Data syncing...\r\nPlease Wait", ParentForm);

            SyncResult result = await DataSync.HandShakeAsync();
            if (result.Successful)
            {
                var resultSync = await DataSync.RunSyncSystem(DataSync.GetSyncSystemList());
                if (resultSync.Successful)
                {
                    string msg  = LoginUser.AddSqlUsers();
                    if (msg != null)
                    {
                        GuiCommon.ShowMessage(msg);
                    }
                }

                GuiCommon.ShowMessage(resultSync.DisplayMessage());
            }
            else
            {
                GuiCommon.ShowMessage(result.DisplayMessage());
            }

            CL_Dialog.PleaseWait.Hide();
        }
    }
}
