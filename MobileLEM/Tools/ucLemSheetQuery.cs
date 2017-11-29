using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DM_CentralizedFSManager;
using MobileData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MobileLEM
{
    public partial class ucLemSheetQuery : DevExpress.XtraEditors.XtraUserControl
    {
        class ColName
        {
            public const string Id = "Id";
            public const string LogDate = "LogDate";
            public const string LemNum = "LemNum";
            public const string LogStatus = "LogStatus";
            public const string ProjectCode = "ProjectCode";
            public const string ProjectName = "ProjectName";
            public const string CustomerCode = "CustomerCode";
            public const string CustomerName = "CustomerName";
            public const string SiteLocation = "SiteLocation";
            public const string LemTotal = "LemTotal";
        }

        private ucFileManager _fileMgr;

        public ucLemSheetQuery()
        {
            InitializeComponent();

            Init();
            SetData(new List<LemHeader>());

            _fileMgr = new ucFileManager(MobileCommon.HMCon, GuiCommon.HMDevXManager, DocumentViewerMode.All, true, "F", true);
            _fileMgr.Dock = DockStyle.Fill;
            _fileMgr.Parent = dpAttachment;
            _fileMgr.ReadOnly = true;
        }

        public void Init()
        {
            luProject.Properties.DataSource = Project.AccessibleList().Select(p => new { Project = p.Name, Code = p.Code, MatchId = p.MatchId, DisplayName = p.DisplayName });
            luLogStatus.Properties.DataSource = Enum.GetValues(typeof(EnumLogStatus)).Cast<EnumLogStatus>().Select(status => new { Status = Enum.GetName(typeof(EnumLogStatus), status) });
        }

        public void ClearAll()
        {
            Init();
            SetData(new List<LemHeader>());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? project = (int?)luProject.EditValue;
            DateTime? from = (DateTime?)deFromDate.EditValue;
            DateTime? to = (DateTime?)deToDate.EditValue;
            EnumLogStatus? status = luLogStatus.EditValue==null ? null : (EnumLogStatus?)Enum.Parse( typeof(EnumLogStatus), (string)luLogStatus.EditValue);

            var logList = LemHeader.GetLogHeaderList(project, from, to, status, null);
            SetData(logList);
        }

        private void luProject_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            luProject.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : luProject.EditValue;
        }

        private void luStatus_Properties_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            luLogStatus.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : luLogStatus.EditValue;
        }

        private void deFromDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            deFromDate.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : deFromDate.EditValue;
        }

        private void deToDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            deToDate.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : deToDate.EditValue;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            luProject.EditValue = null;
            deFromDate.EditValue = null;
            deToDate.EditValue = null;
            luLogStatus.EditValue = null;

            SetData(new List<LemHeader>());
        }

        private void SetData(List<LemHeader> headerList)
        {
            tableHeader.Clear();
            headerList.Select(x => new { header = x, project = Project.GetProject(x.ProjectId) }).ToList().ForEach(x =>
            {
                tableHeader.Rows.Add(
                  x.header.Id,
                  x.header.LogDate,
                  x.header.LemNum,
                  Enum.GetName(typeof(EnumLogStatus), x.header.LogStatus),
                  x.project?.Code,
                  x.project?.DisplayName,
                  x.project?.CustomerCode,
                  x.project?.CustomerName,
                  x.project?.SiteLocation,
                  x.header.GetLemTotal());
            });
            tableHeader.AcceptChanges();
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var LoadAttachments = new Action<int>((poId) =>
            {
                _fileMgr.DocumentFileLink = new FileLink[] { new FileLink(Attachment.LemHeaderId, poId, Company.CurrentId, FileLink.Database.TR, 0, true) };
            });

            DataRow row = gridView1.GetDataRow(e.FocusedRowHandle);
            if (row != null && row[ColName.Id] != DBNull.Value)
            {
                LoadAttachments((int)row[ColName.Id]);
            }
            else
            {
                LoadAttachments(-1);
            }
        }
    }
}
