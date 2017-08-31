using MobileData;
using MobileLEM;
using System.Windows.Forms;

namespace MobileMain
{
    public partial class ucMain : DevExpress.XtraEditors.XtraUserControl
    {
        ucPageLogHeader _pageLemEntry = new ucPageLogHeader();
        ucPageEditLem _pageEditLem = new ucPageEditLem();

        public ucMain()
        {
            InitializeComponent();
        }

        public void Init()
        {
            _pageLemEntry.Init();
            _pageLemEntry.Dock = DockStyle.Fill;
            _pageLemEntry.Parent = tpHeaderList;

            _pageEditLem.Init();
            _pageEditLem.Dock = DockStyle.Fill;
            _pageEditLem.Parent = tpEditLem;
        }

        private void hmTabControlProcess_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            CL_Dialog.PleaseWait.Hide();
        }

        private void hmTabControlProcess_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page == tpEditLem)
            {
                var currLog = _pageLemEntry.GetCurrentLog();

                if (currLog != null)
                {
                    _pageEditLem.SetCurrent(currLog);
                }
                else
                {
                    Common.Popups.ShowPopup("Must select a log header.");
                    e.Cancel = true;
                }
            }
        }
    }
}