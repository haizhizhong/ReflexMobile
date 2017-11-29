using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Deployment.Application;
using System.DirectoryServices.AccountManagement;

namespace MobileData
{
    public static class DataSync
    {
        public static async Task<SyncResult> HandShakeAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init();

                    var query = HttpUtility.ParseQueryString(string.Empty);
                    query["codeVer"] = MobileCommon.CurrentCodeVersion;
                    query["dbVer"] = SystemInfo.Current.DataBaseVersion.ToString();
                    HttpResponseMessage response = await client.GetAsync($"api/SystemInfo?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        SystemInfo serverInfo = await response.Content.ReadAsAsync<SystemInfo>();

                        if (serverInfo.CodeVersion != MobileCommon.CurrentCodeVersion)
                        {
                            return new SyncResult { Successful=false, Task="HandShake", Message= "Application version is not correct, please log out and restart." };
                        }

                        if (serverInfo.DataBaseVersion != SystemInfo.Current.DataBaseVersion)
                        {
                            foreach (string script in serverInfo.PatchScript)
                            {
                                DataManage.RunPatch(script);
                            }

                            SystemInfo.UpdateDataBaseVersion(serverInfo.DataBaseVersion);
                        }

                        if (serverInfo.KeepDays != SystemInfo.Current.KeepDays)
                        {
                            SystemInfo.UpdateKeepDays(serverInfo.KeepDays);
                        }

                        return new SyncResult { Successful = true, Task = "HandShake"};
                    }
                }
                return new SyncResult { Successful = false, Task = "HandShake", Message = "Bad request to the Server." };
            }
            catch (Exception e)
            {
                return new SyncResult { Successful = false, Task = "HandShake", Message=e.Message };
            }
        }

        public static List<SystemSync> GetSyncSystemList()
        {
            List<SystemSync> list = new List<SystemSync>();

            list.Add(new CompanySync());
            list.Add(new SecurityFunctionSync());
            list.Add(new SysSecuritySync());
            list.Add(new LoginUserSync());
            list.Add(new ContextGroupSync());
            list.Add(new ContextItemSync());
            list.Add(new ContextUsageSync());

            return list;
        }

        public static async Task<SyncResult> RunSyncSystem(List<SystemSync> list)
        {
            list = list.Where(x => x.SyncInfo.DoSync).ToList();

            CompanySyncProcess.SetSyncProcess(CompanySyncProcess.NoCompany, EnumSyncType.System, EnumSyncProcess.SystemSyncing, 0);
            DateTime startTime = DateTime.Now;
            List<SyncResult> taskResultList = new List<SyncResult>();
            foreach (SystemSync sync in list)
            {
                var task = sync.Receive();
                taskResultList.Add(await task);
            }

            if (!taskResultList.Any(x => !x.Successful))
            {
                list.ForEach(x => x.CommitReceive());

                CompanySyncProcess.SetSyncProcess(CompanySyncProcess.NoCompany, EnumSyncType.System, EnumSyncProcess.NotSyncing, 0);
                return new SyncResult { Successful = true, Message = $"Data sync was successful. ({(int)(DateTime.Now - startTime).TotalSeconds} seconds)" };
            }
            else
            {
                list.ForEach(x => x.RollbackReceive());
                CompanySyncProcess.SetSyncProcess(CompanySyncProcess.NoCompany, EnumSyncType.System, EnumSyncProcess.NotSyncing, 0);
                return taskResultList.First(x => !x.Successful);
            }
        }

        public static async Task<Guid> RunSyncAuth()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init();

                    string authStr = $"{LoginUser.CurrUser.LoginName}";
                    var encode = Encoding.ASCII.GetBytes(authStr);
                    authStr = Convert.ToBase64String(encode);
                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {authStr}");

                    HttpResponseMessage response = await client.GetAsync($"api/Authenticate");
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.Headers.Contains(MobileCommon.WebToken))
                        {
                            return new Guid(response.Headers.GetValues(MobileCommon.WebToken).First());
                        }
                    }
                }
            }
            catch
            {
            }

            return Guid.Empty;
        }

        public static List<ReceiveSync> GetSyncLookupList(int companyId)
        {
            List<ReceiveSync> list = new List<ReceiveSync>();

            list.Add(new SecuritySync(companyId));
            list.Add(new SupplierSync(companyId));
            list.Add(new EmployeeSync(companyId));
            list.Add(new WorkClassSync(companyId));
            list.Add(new LevelOneCodeSync(companyId));
            list.Add(new LevelTwoCodeSync(companyId));
            list.Add(new LevelThreeCodeSync(companyId));
            list.Add(new LevelFourCodeSync(companyId));
            list.Add(new TimeCodeSync(companyId));

            list.Add(new EquipmentSync(companyId));
            list.Add(new EquipmentDefaultBillRateSync(companyId));
            list.Add(new EquipmentClassSync(companyId));
            list.Add(new EquipmentCategorySync(companyId));
            list.Add(new EquipmentAssignmentSync(companyId));
            list.Add(new EquipmentBillRateSync(companyId));
            list.Add(new EquipmentGroupBillRateSync(companyId));

            list.Add(new ProjectSync(companyId));
            list.Add(new ProjectWorkClassSync(companyId));
            list.Add(new ProjectEquipmentClassSync(companyId));
            list.Add(new ChangeOrderSync(companyId));
            list.Add(new OvertimeLimitSync(companyId));
            list.Add(new LabourTemplateSync(companyId));
            list.Add(new EquipmentTemplateSync(companyId));

            list.Add(new CostCodeMappingSync(companyId));
            list.Add(new DefaultEarningSync(companyId));
            list.Add(new ProjectLevelCodeSync(companyId));
            return list;
        }

        public static async Task<SyncResult> RunSyncCompanyLookups(List<ReceiveSync> list)
        {
            list = list.Where(x => x.SyncInfo.DoSync).ToList();

            Guid token = await RunSyncAuth();
            List<SyncResult> taskResultList = new List<SyncResult>();
            DateTime startTime = DateTime.Now;
            CompanySyncProcess.SetSyncProcess(Company.CurrentId, EnumSyncType.Lookup, EnumSyncProcess.LookupSyncing, 0);

            foreach (ReceiveSync sync in list)
            {
                if (sync.SyncInfo.Status != EnumTableSyncStatus.CompleteReceive)
                {
                    var task = sync.Receive(token);
                    taskResultList.Add(await task);
                }
            }

            if (!taskResultList.Any(x => !x.Successful))
            {
                list.ForEach(x => x.CommitReceive());
                CompanySyncProcess.SetSyncProcess(Company.CurrentId, EnumSyncType.Lookup, EnumSyncProcess.NotSyncing, 0);
                return new SyncResult { Successful = true, Message = $"Data sync was successful. ({(int)(DateTime.Now - startTime).TotalSeconds} seconds)" };
            }
            else
            {
                return taskResultList.First(x => !x.Successful);
            }
        }

        public static void CancelSyncCompanyLookups(List<ReceiveSync> list)
        {
            list = list.Where(x => x.SyncInfo.DoSync).ToList();

            foreach (ReceiveSync sync in list)
            {
                if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.ErrorInReceive, EnumTableSyncStatus.CompleteReceive }.Contains(sync.SyncInfo.Status))
                {
                    sync.RollbackReceive();
                }
            }
            CompanySyncProcess.SetSyncProcess(Company.CurrentId, EnumSyncType.Lookup, EnumSyncProcess.NotSyncing, 0);
        }

        public static List<CoreSync> GetSyncCoreList(int companyId)
        {
            List<CoreSync> list = new List<CoreSync>();

            list.Add(new LemHeaderSync(companyId));
            list.Add(new FieldPOSync(companyId));
            list.Add(new LemAPSync(companyId));
            list.Add(new LabourTimeEntrySync(companyId));
            list.Add(new EquipTimeEntrySync(companyId));
            list.Add(new DeleteHistorySync(companyId));
            list.Add(new AttachmentSync(companyId));
            return list;
        }

        public static async Task<int> GetSyncId()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init();

                    var query = HttpUtility.ParseQueryString(string.Empty);
                    query["companyId"] = Company.CurrentId.ToString();
                    query["clientMac"] = MobileCommon.MachineMac;
                    HttpResponseMessage response = await client.GetAsync($"api/SyncProcess?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<int>();
                    }
                }
            }
            catch
            {
            }

            return -1;
        }

        public static async Task<bool> FinishSync(int syncId, bool commit)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init();

                    var query = HttpUtility.ParseQueryString($"syncId={syncId}");
                    HttpResponseMessage response = await client.PostAsJsonAsync($"api/SyncProcess?{query.ToString()}", commit);
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static async Task<SyncResult> RunSyncCompanyCore(List<CoreSync> list)
        {
            Guid token = await RunSyncAuth();
            if (token == Guid.Empty)
            {
                return new SyncResult { Successful = false, Message = $"Cannot get a sync token." };
            }

            List<SyncResult> taskResultList = new List<SyncResult>();
            DateTime startTime = DateTime.Now;

            int syncId;
            bool doItAgain = false;

            if (new EnumSyncProcess[] { EnumSyncProcess.CoreHalfWay, EnumSyncProcess.CoreReceiving }.Contains(CompanySyncProcess.GetSyncProcessEnum(Company.CurrentId, EnumSyncType.Core)))
            {
                syncId = CompanySyncProcess.GetSyncProcess(Company.CurrentId, EnumSyncType.Core).SyncId;
                doItAgain = true;
            }
            else
            {
                if (EnumSyncProcess.CoreSending == CompanySyncProcess.GetSyncProcessEnum(Company.CurrentId, EnumSyncType.Core))
                {
                    syncId = CompanySyncProcess.GetSyncProcess(Company.CurrentId, EnumSyncType.Core).SyncId;
                }
                else
                {
                    syncId = await GetSyncId();
                    if (syncId == -1)
                    {
                        return new SyncResult { Successful = false, Message = $"Cannot get a SyncId." };
                    }
                    CompanySyncProcess.SetSyncProcess(Company.CurrentId, EnumSyncType.Core, EnumSyncProcess.CoreSending, syncId);
                }

                foreach (CoreSync sync in list)
                {
                    if (sync.SyncInfo.Status != EnumTableSyncStatus.CompleteSend)
                    {
                        var task = sync.Send(token, syncId);
                        taskResultList.Add(await task);
                    }
                }

                if (!taskResultList.Any(x => !x.Successful))
                {
                    // Commit Sync
                    if (await FinishSync(syncId, true))
                    {
                        list.ForEach(x => x.CommitSend());
                        CompanySyncProcess.SetSyncProcess(Company.CurrentId, EnumSyncType.Core, EnumSyncProcess.CoreHalfWay, syncId);
                        taskResultList.Clear();
                    }
                    else
                    {
                        return new SyncResult { Successful = false, Message = $"The Web server cannot finish sync process." };
                    }
                }
                else
                {
                    return taskResultList.First(x => !x.Successful);
                }
            }

            CompanySyncProcess.SetSyncProcess(Company.CurrentId, EnumSyncType.Core, EnumSyncProcess.CoreReceiving, syncId);
            foreach (CoreSync sync in list)
            {
                if (sync.SyncInfo.Status != EnumTableSyncStatus.CompleteReceive)
                {
                    var task = sync.Receive(token);
                    taskResultList.Add(await task);
                }
            }

            if (!taskResultList.Any(x => !x.Successful))
            {
                list.ForEach(x => x.CommitReceive());
                CompanySyncProcess.SetSyncProcess(Company.CurrentId, EnumSyncType.Core, EnumSyncProcess.NotSyncing, 0);

                if (doItAgain)
                    return await RunSyncCompanyCore(list);

                return new SyncResult { Successful = true, Message = $"Data sync was successful. ({(int)(DateTime.Now - startTime).TotalSeconds} seconds)" };
            }
            else
            {
                return taskResultList.First(x => !x.Successful);
            }
        }

        public static async Task<SyncResult> CancelSyncCompanyCoreAsync(List<CoreSync> list)
        {
            var curProcess = CompanySyncProcess.GetSyncProcessEnum(Company.CurrentId, EnumSyncType.Core);
            if (curProcess == EnumSyncProcess.CoreSending)
            {
                int syncId = CompanySyncProcess.GetSyncProcess(Company.CurrentId, EnumSyncType.Core).SyncId;

                if (await FinishSync(syncId, false))
                {
                    foreach (CoreSync sync in list)
                    {
                        if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Sending, EnumTableSyncStatus.ErrorInSend, EnumTableSyncStatus.CompleteSend }.Contains(sync.SyncInfo.Status))
                        {
                            sync.RollbackSend();
                        }
                    }
                    CompanySyncProcess.SetSyncProcess(Company.CurrentId, EnumSyncType.Core, EnumSyncProcess.NotSyncing, 0);
                }
                else
                {
                    return new SyncResult { Successful = false, Message = "Cannot cancel the sync process." };
                }
            }
            else if (curProcess == EnumSyncProcess.CoreReceiving)
            {
                foreach (CoreSync sync in list)
                {
                    if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.ErrorInReceive, EnumTableSyncStatus.CompleteReceive }.Contains(sync.SyncInfo.Status))
                    {
                        sync.RollbackReceive();
                    }
                }
                CompanySyncProcess.SetSyncProcess(Company.CurrentId, EnumSyncType.Core, EnumSyncProcess.CoreHalfWay, CompanySyncProcess.GetSyncProcess(Company.CurrentId, EnumSyncType.Core).SyncId);
            }

            return new SyncResult { Successful = true};
        }
    }
}
