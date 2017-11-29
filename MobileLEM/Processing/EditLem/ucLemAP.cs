using System;
using System.Data;
using DevExpress.XtraEditors;
using MobileData;

namespace MobileLEM
{
    public partial class ucLemAP : XtraUserControl
    {
        LemHeader _headerRecord;
        class MColName
        {
            public const string Id = "Id";
            public const string InvoiceDate = "InvoiceDate";
            public const string Select = "Select";
            public const string InvoiceNum = "InvoiceNum";
            public const string Supplier = "Supplier";
            public const string PONum = "PONum";
            public const string Project = "Project";
            public const string InvoiceAmount = "InvoiceAmount";
            public const string MarkupAmount = "MarkupAmount";
            public const string BillAmount = "BillAmount";
        };

        class DColName
        {
            public const string Id = "Id";
            public const string LineNum = "LineNum";
            public const string Description = "Description";
            public const string Reference = "Reference";
            public const string Amount = "Amount";
            public const string MarkupPercent = "MarkupPercent";
            public const string MarkupAmount = "MarkupAmount";
            public const string BillAmount = "BillAmount";
        };

        public ucLemAP()
        {
            InitializeComponent();
        }

        public void SetCurrent(LemHeader header)
        {
            _headerRecord = header;
            SetEnabled(_headerRecord.CheckEditable());

            tableAP.Clear();
            LemAP.GetLemAP(header.ProjectId, header.Id).ForEach(x =>
                tableAP.Rows.Add(
                    x.Id,
                    x.InvoiceDate,
                    x.HeaderId== header.Id,
                    x.InvoiceNum,
                    Supplier.GetSupplier(x.SupplierCode).SupplierName,
                    x.PONum,
                    Project.GetProject(x.ProjectId).DisplayName,
                    x.InvoiceAmount,
                    x.MarkupAmount,
                    x.BillAmount)
                );
            tableAP.AcceptChanges();
        }

        private void gvAP_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == MColName.Select)
            {
                DataRow row = gvAP.GetDataRow(e.RowHandle);
                LemAP.SqlUpdateLemAP( (int)row[MColName.Id], (bool)row[MColName.Select] ? (int?)_headerRecord.Id : null);

                LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
            }
        }

        private void gvAP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            tableDetail.Clear();
            DataRow row = gvAP.GetDataRow(e.FocusedRowHandle);
            if (row != null && row[MColName.Id] != DBNull.Value)
            {
                LemAPDetail.GetLemAPDetails((int)row[MColName.Id]).ForEach(x =>
                    tableDetail.Rows.Add(
                        x.MatchId,
                        x.LineNum,
                        x.Description,
                        x.Reference,
                        x.Amount,
                        x.MarkupPercent / 100,
                        x.MarkupAmount,
                        x.BillAmount)
                    );
                tableDetail.AcceptChanges();
            }
        }

        void SetEnabled(bool enabled)
        {
            gvAP.OptionsBehavior.Editable = enabled;
            gvAP.OptionsSelection.EnableAppearanceFocusedCell = enabled;

            gvDetail.OptionsBehavior.Editable = false;
            gvDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
        }
    }
}
