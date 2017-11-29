using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;

namespace MobileData
{
    public class CompanySync : SystemSync
    {
        protected override string TableName { get { return "Company"; } }
        protected override string DisplayName { get { return "Company"; } }

        public override async System.Threading.Tasks.Task<SyncResult> Receive()
        {
            try
            {
                Company.Refresh();

                using (HttpClient client = new HttpClient())
                {
                    client.Init();

                    HttpResponseMessage response = await client.GetAsync("api/Companies");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<Company> list = await response.Content.ReadAsAsync<List<Company>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert Company(MatchId, CompanyName, ShortName, Active, WeekStart, " +
                                        $"EquipRateGroupType, MaxLevelCode, Level1CodeDesc, Level2CodeDesc, Level3CodeDesc, Level4CodeDesc, " +
                                        $"CompanyAddress1, CompanyAddress2, CompanyAddress3, CompanyCity, CompanyState, CompanyZip, CompanyPhone, CompanyFax, " +
                                        $"CompanyEmail, CompanyWeb, InSync) " +
                                    $"values({x.MatchId}, '{StrEx.SqlEsc(x.CompanyName)}', '{x.ShortName}', '{x.Active}', {(Int16)x.WeekStart}, " +
                                        $"'{(char)x.EquipRateGroupType}', {x.MaxLevelCode}, '{x.Level1CodeDesc}', '{x.Level2CodeDesc}', '{x.Level3CodeDesc}', '{x.Level4CodeDesc}', " +
                                        $"'{StrEx.SqlEsc(x.CompanyAddress1)}', '{StrEx.SqlEsc(x.CompanyAddress2)}', '{StrEx.SqlEsc(x.CompanyAddress3)}', '{x.CompanyCity}', '{x.CompanyState}', " +
                                        $"'{x.CompanyZip}', '{x.CompanyPhone}', '{x.CompanyFax}', '{x.CompanyEmail}', '{x.CompanyWeb}', 1)";
                            MobileCommon.ExecuteNonQuery(sql);
                        });

                        UpdateStatus(EnumTableSyncStatus.CompleteReceive);
                        return new SyncResult { Successful = true };
                    }
                    throw new Exception($"Response StatusCode={response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                UpdateStatus(EnumTableSyncStatus.ErrorInReceive);
                return new SyncResult { Successful = false, Task = TableName, Message = e.Message };
            }
        }
    }
}
