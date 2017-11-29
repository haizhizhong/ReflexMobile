using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class Project        //PY_ProjectLookUp (proj_header, PROJ_CONTACTS)
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public string Name;
        public int Code;
        public int CustomerId;
        public string SiteLocation;
        public DateTime? StartDate;
        public DateTime? EstCompletionDate;

        public string CustomerCode;
        public string CustomerName;
        public string CustomerAddress;
        public string POReference;
        public bool Billable;

        public string SiteAddress;
        public string SiteCity;
        public string SiteState;
        public string SiteZip;
        public string CustomerAddress2;
        public string CustomerAddress3;
        public string CustomerCity;
        public string CustomerState;
        public string CustomerZip;
        public string ProjectExtendedDescription;

        public string DisplayName => $"{Code} - {Name}"; 

        static List<Project> _list;

        public string GetNextLemNum()
        {
            string sql = $"select isnull(max(left(REPLACE(l.LemNum, Concat(p.Code,'-'), ''), 4)),0) from LemHeader l join project p on l.ProjectId=p.MatchId where l.projectid = {MatchId}";
            int last = Convert.ToInt32(MobileCommon.ExecuteScalar(sql));

            return $"{Code}-{last + 1,4}".Replace(" ", "0");
        }

        static List<Project> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from Project");
                    _list = table.Select().Select(r => new Project
                    {
                        Id = (int)r["ID"],
                        MatchId = (int)r["MatchId"],
                        CompanyId = (int)r["CompanyId"],
                        Name = (string)r["Name"],
                        Code = (int)r["Code"],
                        CustomerId = (int)r["CustomerId"],
                        CustomerCode = (string)r["CustomerCode"],
                        CustomerName = (string)r["CustomerName"],
                        CustomerAddress = (string)r["CustomerAddress"],
                        SiteLocation = (string)r["SiteLocation"],
                        StartDate = ConvertEx.ToNullable<DateTime>(r["StartDate"]),
                        EstCompletionDate = ConvertEx.ToNullable<DateTime>(r["EstCompletionDate"]),
                        Billable = (bool)(r["Billable"]),
                        POReference = Convert.ToString(r["POReference"]),
                        SiteAddress = Convert.ToString(r["SiteAddress"]),
                        SiteCity = Convert.ToString(r["SiteCity"]),
                        SiteState = Convert.ToString(r["SiteState"]),
                        SiteZip = Convert.ToString(r["SiteZip"]),
                        CustomerAddress2 = Convert.ToString(r["CustomerAddress2"]),
                        CustomerAddress3 = Convert.ToString(r["CustomerAddress3"]),
                        CustomerCity = Convert.ToString(r["CustomerCity"]),
                        CustomerState = Convert.ToString(r["CustomerState"]),
                        CustomerZip = Convert.ToString(r["CustomerZip"]),
                        ProjectExtendedDescription = Convert.ToString(r["ProjectExtendedDescription"])
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<Project> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<Project> AccessibleList()
        {
            return ListForCompany().Where(x => LoginUser.CurrUser.ProjectList.Where(p=>p.CompanyId==Company.CurrentId).Select(p=>p.ProjectId).Contains(x.MatchId)).ToList();
        }

        public static Project GetProject(int id)
        {
            return ListForCompany().SingleOrDefault(x => x.MatchId == id);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
