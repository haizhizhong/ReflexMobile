using DevExpress.XtraGrid.Columns;
using System;
using System.Data;
using WS_Popups;
using static WS_Popups.frmPopup;

namespace MobileLEM
{
    public static class GuiCommon
    {
        public static TUC_HMDevXManager.TUC_HMDevXManager HMDevXManager { get; set; }

        static frmPopup _frmPopup; 
        public static void ShowMessage(string msg)
        {
            if(_frmPopup==null)
                _frmPopup = new frmPopup(GuiCommon.HMDevXManager);

            _frmPopup.ShowPopup(msg);
        }

        public static PopupResult ShowMessage(string text, string caption, PopupType buttons)
        {
            if (_frmPopup == null)
                _frmPopup = new frmPopup(GuiCommon.HMDevXManager);

            return _frmPopup.ShowPopup(text, caption, buttons);
        }

        public static T GetValue<T>(this DataRow row, GridColumn col) where T : struct
        {
            return (T)row[col.FieldName];
        }

        public static string GetValueString(this DataRow row, GridColumn col)
        {
            return Convert.ToString(row[col.FieldName]);
        }

        public static object GetValue(this DataRow row, GridColumn col)
        {
            return row[col.FieldName];
        }
        public static T GetCharEnumValue<T>(this DataRow row, GridColumn col) where T : struct
        {
            return (T)Enum.ToObject(typeof(T), Convert.ToChar(row[col.FieldName]));
        }

        public static void SetValue(this DataRow row, GridColumn col, object value)
        {
            row[col.FieldName] = value;
        }
    }
}
