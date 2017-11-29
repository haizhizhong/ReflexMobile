using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.IO;
using System.Diagnostics;
using MobileData;

namespace MobileMain
{
    public partial class SplashScreen2 : SplashScreen
    {
        public SplashScreen2()
        {
            InitializeComponent();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            labelVersion.Text = $"Reflex ERP ver {MobileCommon.CurrentCodeVersion}, database ver {SystemInfo.Current.DataBaseVersion}";
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void hyperLinkEdit7_MouseHover(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.HyperLinkEdit h = (DevExpress.XtraEditors.HyperLinkEdit)sender;
            h.BackColor = SystemColors.Highlight;
            h.ForeColor = SystemColors.HighlightText;
        }

        private void hyperLinkEdit7_MouseLeave(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.HyperLinkEdit h = (DevExpress.XtraEditors.HyperLinkEdit)sender;
            h.ForeColor = SystemColors.HotTrack;
            h.BackColor = Color.Transparent;
        }

        private void hyperLinkEdit7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SplashScreen2_Shown(object sender, EventArgs e)
        {
            hyperLinkEdit1.Focus();
            memoEdit1.SelectionLength = 0;
        }

        private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = ("www.ReflexERP.com");
            process.StartInfo.Verb = "open";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            try
            {
                process.Start();
            }
            catch { }

        }
    }
}