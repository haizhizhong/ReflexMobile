using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.Equipment;

namespace MobileData
{
    public class Company      //Company
    {
        public int Id;
        public int MatchId;
        public string CompanyName;
        public string ShortName;
        public bool Active;

        public DayOfWeek WeekStart;   //hr_cntl.week_start
        public EnumGroupType EquipRateGroupType; //fa_setup.use_cat_class

        public int MaxLevelCode;
        public string Level1CodeDesc;
        public string Level2CodeDesc;
        public string Level3CodeDesc;
        public string Level4CodeDesc;

        public string CompanyAddress1;
        public string CompanyAddress2;
        public string CompanyAddress3;
        public string CompanyCity;
        public string CompanyState;
        public string CompanyZip;
        public string CompanyPhone;
        public string CompanyFax;
        public string CompanyEmail;
        public string CompanyWeb;

        public static int CurrentId { get; set; }

        static List<Company> _list;

        public static List<Company> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from Company");
                    _list = table.Select().Select(r => new Company
                    {
                        Id = (int)r["Id"],
                        MatchId = (int)r["MatchId"],
                        CompanyName = (string)r["CompanyName"],
                        ShortName = (string)r["ShortName"],
                        Active = (bool)r["Active"],

                        WeekStart = ConvertEx.IntToEnum<DayOfWeek>(r["WeekStart"]),
                        EquipRateGroupType = ConvertEx.CharToEnum<EnumGroupType>(r["EquipRateGroupType"]),
                        MaxLevelCode = (int)r["MaxLevelCode"],
                        Level1CodeDesc = (string)r["Level1CodeDesc"],
                        Level2CodeDesc = (string)r["Level2CodeDesc"],
                        Level3CodeDesc = (string)r["Level3CodeDesc"],
                        Level4CodeDesc = (string)r["Level4CodeDesc"],

                        CompanyAddress1 = (string)r["CompanyAddress1"],
                        CompanyAddress2 = (string)r["CompanyAddress2"],
                        CompanyAddress3 = (string)r["CompanyAddress3"],
                        CompanyCity = (string)r["CompanyCity"],
                        CompanyState = (string)r["CompanyState"],
                        CompanyZip = (string)r["CompanyZip"],
                        CompanyPhone = (string)r["CompanyPhone"],
                        CompanyFax = (string)r["CompanyFax"],
                        CompanyEmail = (string)r["CompanyEmail"],
                        CompanyWeb = (string)r["CompanyWeb"],
                    }).ToList();
                }
                return _list;
            }
        }

        public static Company GetCompany(int matchId)
        {
            return List.SingleOrDefault(x => x.MatchId == matchId);
        }

        public static Company GetCurrCompany()
        {
            return GetCompany(CurrentId);
        }

        public string GetLevelCodeText()
        {
            string text = "";

            if (MaxLevelCode >= 1)
                text += Level1CodeDesc;
            if (MaxLevelCode >= 2)
                text += $"/{Level2CodeDesc}";
            if (MaxLevelCode >= 3)
                text += $"/{Level3CodeDesc}";
            if (MaxLevelCode >= 4)
                text += $"/{Level4CodeDesc}";

            return text;
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
