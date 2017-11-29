using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class EmployeeSync : ReceiveSync
    {
        protected override string TableName { get { return "Employee"; } }
        protected override string DisplayName { get { return "Employee"; } }

        public EmployeeSync(int companyId) : base(companyId) 
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                Employee.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/Employees?companyId={Company.CurrentId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<Employee> list = await response.Content.ReadAsAsync<List<Employee>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert Employee(EmpNum, CompanyId, FirstName, LastName, WorkClassCode, OvertimeCode, InSync) " +
                              $"values({x.EmpNum}, {x.CompanyId}, '{StrEx.SqlEsc(x.FirstName)}', '{StrEx.SqlEsc(x.LastName)}', '{x.WorkClassCode}', '{x.OvertimeCode}', 1)";
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
