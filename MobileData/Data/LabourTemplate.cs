using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class LabourTemplate     // costing_work_class_emp
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public int ProjectId;
        public int EmpNum;
        public string WorkClassCode;
        public DateTime? StartDate;
        public DateTime? EndDate;

        static List<LabourTemplate> _list;

        static List<LabourTemplate> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from LabourTemplate");
                    _list = table.Select().Select(r => new LabourTemplate
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        MatchId = Convert.ToInt32(r["MatchId"]),
                        CompanyId = Convert.ToInt32(r["CompanyId"]),
                        ProjectId = Convert.ToInt32(r["ProjectId"]),
                        EmpNum = Convert.ToInt32(r["EmpNum"]),
                        WorkClassCode = Convert.ToString(r["WorkClassCode"]),
                        StartDate = ConvertEx.ToNullable<DateTime>(r["StartDate"]),
                        EndDate = ConvertEx.ToNullable<DateTime>(r["EndDate"])
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<LabourTemplate> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<LabourTemplate> ListForProject(int projectId)
        {
            return ListForCompany().Where(x => x.ProjectId == projectId).ToList();
        }

        public static List<LabourTemplate> GetTemplate(int projectId, DateTime currDate)
        {
            var codeList = ProjectWorkClass.ListForProject(projectId).Where(x => x.Schedulable == true).Select(x => x.WorkClassCode);
            return ListForProject(projectId).Where(x => (x.StartDate == null || x.StartDate < currDate) && (x.EndDate == null || x.EndDate > currDate) && codeList.Contains(x.WorkClassCode)).ToList();
        }

        public static string GetWorkClass(int projectId, int empNum, DateTime currDate)
        {
            var list = GetTemplate(projectId, currDate);
            return list.FirstOrDefault(x => x.EmpNum == empNum)?.WorkClassCode ?? null;
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
