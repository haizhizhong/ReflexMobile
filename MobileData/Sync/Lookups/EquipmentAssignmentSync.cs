using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileData
{
    public class EquipmentAssignmentSync : ReceiveSync
    {
        protected override string TableName { get { return "EquipmentAssignment"; } }
        protected override string DisplayName { get { return "Equipment Assignment"; } }

        public EquipmentAssignmentSync(int companyId) : base(companyId) 
        {
        }

        public override async Task<SyncResult> Receive(Guid token)
        {
            try
            {
                EquipmentAssignment.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/EquipmentAssignments?companyId={Company.CurrentId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<EquipmentAssignment> list = await response.Content.ReadAsAsync<List<EquipmentAssignment>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert EquipmentAssignment(CompanyId, EqpNum, EmpNum, AssignedDate, ReleasedDate, EarnGroup, EarnCode, inSync) " +
                              $"values({x.CompanyId}, '{x.EqpNum}', {x.EmpNum}, {StrEx.StrOrNull(x.AssignedDate)}, {StrEx.StrOrNull(x.ReleasedDate)}, {StrEx.StrOrNull(x.EarnGroup)}, {StrEx.StrOrNull(x.EarnCode)}, 1)";
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
