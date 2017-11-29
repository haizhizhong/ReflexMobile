using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static System.Convert;

namespace MobileData
{
    public class ChangeOrder
    {
        public int Id;
        public int CompanyId;
        public int ProjectId;
        public int EstimateId;

        public int? ChangeOrderNum;
        public string ChangeOrderName;

        public string DisplayName => $"{(ChangeOrderNum?.ToString() ?? "")}\t{ChangeOrderName}";

        static List<ChangeOrder> _list;

        static List<ChangeOrder> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from ChangeOrder");
                    _list = table.Select().Select(r => new ChangeOrder
                    {
                        Id = ToInt32(r["ID"]),
                        CompanyId = ToInt32(r["CompanyId"]),
                        ProjectId = ToInt32(r["ProjectId"]),
                        EstimateId = ToInt32(r["EstimateId"]),
                        ChangeOrderNum = ToInt32(r["ChangeOrderNum"]),
                        ChangeOrderName = Convert.ToString(r["ChangeOrderName"])
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<ChangeOrder> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<ChangeOrder> ListForProject(int projectId)
        {
            return ListForCompany().Where(x => x.ProjectId == projectId).ToList();
        }

        public static ChangeOrder GetChangeOrder(int projectId, int? estId)
        {
            return ListForProject(projectId).SingleOrDefault(x => x.EstimateId == estId);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
