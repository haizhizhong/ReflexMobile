using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MobileData
{
    public class EquipmentClass   // fa_class
    {
        public int Id;
        public int CompanyId;

        public string Code;
        public string Desc;

        static List<EquipmentClass> _list;

        public static List<EquipmentClass> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<EquipmentClass>();
                    DataTable table = Common.ExecuteDataAdapter("select * from EquipmentClass");
                    table.Select().ToList().ForEach(r => _list.Add(new EquipmentClass
                    {
                        Id = r.Field<int>("Id"),
                        CompanyId = r.Field<int>("CompanyId"),
                        Code = r.Field<string>("Code"),
                        Desc = r.Field<string>("Desc"),
                    }));
                }

                return _list;
            }
        }

        public static List<EquipmentClass> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static EquipmentClass GetEquipmentClass(string code)
        {
            return List.SingleOrDefault(x => x.Code == code && x.CompanyId == Company.CurrentId);
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

                HttpResponseMessage response = await client.GetAsync($"api/EquipmentClasses?companyId={Company.CurrentId}");
                if (response.IsSuccessStatusCode)
                {
                    List<EquipmentClass> list = await response.Content.ReadAsAsync<List<EquipmentClass>>();

                    string sql = $"delete EquipmentClass where companyId = {Company.CurrentId}";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert EquipmentClass(CompanyId, Code, [Desc]) " +
                          $"values({x.CompanyId}, '{x.Code}', '{x.Desc}')";
                        Common.ExecuteNonQuery(sql);
                    });

                    Refresh();
                }
            }
        }
    }
}
