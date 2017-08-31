using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class Equipment      //
    {
        public enum EnumBillCycle
        {
            Yearly = 'Y',
            Monthly = 'M',
            Weekly = 'W',
            Dayly = 'D',
            Hourly = 'H',
            Unknown = 'U'
        }

        public int Id;
        public string EqpNum;
        public int CompanyId;

        public string AssetCode;
        public string Desc;
        public string ClassCode;

        public Dictionary<EnumBillCycle, decimal> BillRateList;

        public int EmpNum;          // for employee equipment

        static List<Equipment> _list;

        public static List<Equipment> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<Equipment>();
                    DataTable table = Common.ExecuteDataAdapter("select * from Equipment");
                    table.Select().ToList().ForEach(r => _list.Add(new Equipment
                    {
                        Id = (int)r["Id"],
                        EqpNum = $"{r["EqpNum"]}",
                        CompanyId = (int)r["CompanyId"],
                        AssetCode = $"{r["AssetCode"]}",
                        Desc = $"{r["Desc"]}",
                        ClassCode = $"{r["ClassCode"]}",
                        EmpNum = -1,
                        BillRateList = new Dictionary<EnumBillCycle, decimal>()
                    }));

                    table = Common.ExecuteDataAdapter("select * from EquipmentBillRate");
                    table.Select().ToList().ForEach(r =>
                    {
                        Equipment e = _list.Single(x => x.Id == Convert.ToInt32(r["EquipmentId"]));
                        e.BillRateList.Add((EnumBillCycle)(Convert.ToChar(r["BillCycle"])), Convert.ToDecimal(r["BillRate"]));
                    });
                }
                return _list;
            }
        }

        public static List<Equipment> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static Equipment GetEquipment(string eqpNum)
        {
            return List.SingleOrDefault(x => x.EqpNum == eqpNum && x.CompanyId == Company.CurrentId);
        }

        public static void Refresh()
        {
            _list = null;
        }

        public static async System.Threading.Tasks.Task Sync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Common.WebUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"api/Equipments?companyId={Company.CurrentId}");
                if (response.IsSuccessStatusCode)
                {
                    List<Equipment> list = await response.Content.ReadAsAsync<List<Equipment>>();

                    string sql = $"delete Equipment where companyId = {Company.CurrentId}";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert Equipment(EqpNum, CompanyId, AssetCode, [Desc], ClassCode) " +
                          $"values('{x.EqpNum}', {x.CompanyId}, '{x.AssetCode}', '{x.Desc}', '{x.ClassCode}')";
                        Common.ExecuteNonQuery(sql);
                    });

                    Refresh();
                }
            }
        }
    }
}
