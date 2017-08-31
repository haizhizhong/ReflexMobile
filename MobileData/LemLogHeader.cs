using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public enum EnumLogStatus
    {
        Submitted,
        Open,
        Committed
    }

    public class LemLogHeader         //  WS_PCDL_LogHeader, WS_PCDL_LogEntry
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public DateTime LogDate;
        public EnumLogStatus LogStatus;
        public string LemNum;
        public int ProjectId;

        public static List<LemLogHeader> GetLogHeaderList(int? projectId, DateTime? fromDate, DateTime? toDate, string status)
        {
            List<LemLogHeader> list = new List<LemLogHeader>();

            string sql = $"select * from LemLogHeader where CompanyId={Company.CurrentId}";
            sql += projectId == null ? "" : $" and ProjectId={projectId}";
            sql += fromDate == null ? "" : $" and LogDate>='{fromDate}'";
            sql += toDate == null ? "" : $" and LogDate<='{toDate}'";
            sql += string.IsNullOrEmpty(status) ? "" : $" and LogStatus='{status}'";

            DataTable table = Common.ExecuteDataAdapter(sql);
            table.Select().ToList().ForEach(r => list.Add(
                new LemLogHeader
                {
                    Id = (int)r["Id"],
                    MatchId = (int)r["MatchId"],
                    CompanyId = (int)r["CompanyId"],
                    LogDate = Convert.ToDateTime(r["LogDate"]),
                    LogStatus = (EnumLogStatus)Enum.Parse(typeof(EnumLogStatus), $"{r["LogStatus"]}"),
                    ProjectId = (int)r["ProjectId"],
                    LemNum = Convert.ToString(r["LemNum"])
                }
            ));

            return list;
        }

        public static LemLogHeader GetLogHeader(int id)
        {
            string sql = $"select * from LemLogHeader where Id={id}";
            DataTable table = Common.ExecuteDataAdapter(sql);
            LemLogHeader log = new LemLogHeader
            {
                Id = (int)table.Rows[0]["Id"],
                MatchId = (int)table.Rows[0]["MatchId"],
                CompanyId = (int)table.Rows[0]["CompanyId"],
                LogDate = Convert.ToDateTime(table.Rows[0]["LogDate"]),
                LogStatus = (EnumLogStatus)Enum.Parse(typeof(EnumLogStatus), $"{table.Rows[0]["LogStatus"]}"),
                ProjectId = (int)table.Rows[0]["ProjectId"],
                LemNum = Convert.ToString(table.Rows[0]["LemNum"])
            };

            return log;
        }

        public static int SqlInsert(DateTime logDate, int projectId, string lemNum)
        {
            string sql = $"insert LemLogHeader(MatchId, CompanyId, LogDate, LogStatus, ProjectId, LemNum, TimeStamp) " +
                $"values(-1, {Company.CurrentId}, '{logDate}', '{EnumLogStatus.Open}', {projectId}, '{lemNum}', getdate()); " +
                $"Select CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(Common.ExecuteScalar(sql));
        }

        public static void SqlDelete(int id)
        {
            var curr = LemLogHeader.GetLogHeader(id);

            string sql = $" delete LemLogHeader where id={id}";
            Common.ExecuteNonQuery(sql);

            sql = $"INSERT INTO DeleteHistory(TableName, MatchId, CompanyId, TimeStamp) values('LemLogHeader', {curr.MatchId}, {curr.CompanyId}, getdate())";
            Common.ExecuteNonQuery(sql);
        }

        public static void SqlUpdate(int id, DateTime logDate, int projectId)
        {
            string sql = $"Update LemLogHeader set LogDate='{logDate}', ProjectId={projectId}, TimeStamp=getdate() where id={id}";
            Common.ExecuteNonQuery(sql);
        }

        public static void SqlUpdateSubmit(int id)
        {
            string sql = $"Update LemLogHeader set LogStatus='{(char)EnumLogStatus.Submitted}', TimeStamp=getdate() where id={id}";
            Common.ExecuteNonQuery(sql);
        }

        public static void SqlUpdateMatchId(int id, int matchId)
        {
            string sql = $"Update LemLogHeader set MatchId={matchId} where id={id}";
//            Common.ExecuteNonQuery(sql);
        }

        public static List<LemLogHeader> GetSendList(DateTime lastUpdateTime)
        {
            List<LemLogHeader> list = new List<LemLogHeader>();

            string sql = $"select * from LemLogHeader";

            DataTable table = Common.ExecuteDataAdapter(sql);
            table.Select().ToList().ForEach(r => list.Add(
                new LemLogHeader
                {
                    Id = (int)r["Id"],
                    MatchId = (int)r["MatchId"],
                    CompanyId = (int)r["CompanyId"],
                    LogDate = Convert.ToDateTime(r["LogDate"]),
                    LogStatus = (EnumLogStatus)Enum.Parse(typeof(EnumLogStatus), $"{r["LogStatus"]}"),
                    ProjectId = (int)r["ProjectId"],
                    LemNum = Convert.ToString(r["LemNum"])
                }
            ));

            return list;
        }

        public static async System.Threading.Tasks.Task Sync(DateTime lastUpdateTime)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Common.WebUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                List<LemLogHeader> sendList = GetSendList(lastUpdateTime);
                foreach (LemLogHeader item in sendList)
                {
                    HttpResponseMessage res = await client.PostAsJsonAsync($"api/LemLogHeader", item);
                    if (res.IsSuccessStatusCode)
                    {
                        int matchId = await res.Content.ReadAsAsync<int>();
                        SqlUpdateMatchId( item.Id, matchId);
                    }
                }

                //HttpResponseMessage response = await client.GetAsync($"api/LemLogHeader?companyId={Company.CurrentId},lastUpdateTime={lastUpdateTime}");
                //if (response.IsSuccessStatusCode)
                //{
                //    var jsonAsString = await response.Content.ReadAsStringAsync();
                //    List<LemLogHeader> list = JsonConvert.DeserializeObject<List<LemLogHeader>>(jsonAsString);

                //    list.ForEach(x =>
                //    {
                //        sql = $"insert Project(MatchId, CompanyId, Name, Code, CustomerId, CustomerCode, CustomerName, CustomerAddress, SiteLocation, StartDate, EstCompletionDate, Billable) " +
                //          $"values({x.MatchId}, {x.CompanyId}, '{x.Name}', {x.Code}, {x.CustomerId}, '{x.CustomerCode}', '{x.CustomerName}', '{x.CustomerAddress}', '{x.SiteLocation}', {StringEx.ToStringOrNull(x.StartDate)}, {StringEx.ToStringOrNull(x.EstCompletionDate)}, '{x.Billable}')";
                //        Common.ExecuteNonQuery(sql);
                //    });
                //}
            }
        }
    }
}
