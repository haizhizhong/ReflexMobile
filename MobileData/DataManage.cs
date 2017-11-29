using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using ReflexCommon;
using System.Text.RegularExpressions;

namespace MobileData
{
    public class DataManage
    {
        public delegate void ShowErrorDelegate(string msg);
        public static event ShowErrorDelegate ReportMessage;

        public static void CheckCreateDatabase()
        {
            try
            {
                string conStr = $"server={MobileCommon.ServerName};Trusted_Connection=yes";
                string sql = $"SELECT database_id FROM sys.databases WHERE Name = '{MobileCommon.DatabaseName}'";
                if (SqlCommon.ExecuteScalar(sql, conStr) == null)
                {
                    sql = $"Create Database {MobileCommon.DatabaseName}";
                    SqlCommon.ExecuteNonQuery(sql, conStr);

                    string fileName = ApplicationDeployment.IsNetworkDeployed ? $"{ApplicationDeployment.CurrentDeployment.DataDirectory}\\CreateDB.sql" : "CreateDB.sql";
                    FileInfo fileInfo = new FileInfo(fileName);
                    string script = fileInfo.OpenText().ReadToEnd();
                    RunPatch(script);

                    SystemInfo.InsertRecord();
                }
            }
            catch (Exception e)
            {
                ReportMessage?.Invoke(e.Message);
            }
        }

        public static bool HasDBAccess()
        {
            string sql = $"select * from Company";
            return MobileCommon.ExecuteNonQuery(sql);
        }

        public static void UpdateCodeVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                try
                {
                    string ver = MobileCommon.CurrentCodeVersion;
                    if (LoginUser.CurrUser.CodeVersion != ver)
                    {
                        LoginUser.UpdateCodeVersion(ver);
                    }
                }
                catch (Exception e)
                {
                    ReportMessage?.Invoke(e.Message);
                }
            }
        }

        public static void CheckAddSqlUser(string loginUser)
        {
            try
            {
                string fileName = ApplicationDeployment.IsNetworkDeployed ? $"{ApplicationDeployment.CurrentDeployment.DataDirectory}\\AddSqlUser.sql" : "AddSqlUser.sql";
                FileInfo fileInfo = new FileInfo(fileName);
                string script = fileInfo.OpenText().ReadToEnd();
                var domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
                domain = domain.Replace(".local", "");
                script = script.Replace("_UserPlaceHolder_", $"{domain}\\{loginUser}");
                RunPatch(script);
            }
            catch (Exception e)
            {
                ReportMessage?.Invoke(e.Message);
            }
        }

        public static void RunPatch(string script)
        {
            try
            {
                script = script.Replace("[ReflexMobile]", $"[{MobileCommon.DatabaseName}]");

                using (SqlConnection connection = new SqlConnection(MobileCommon.MobileDB))
                {
                    //Server server = new Server(new ServerConnection(connection));
                    //server.ConnectionContext.ExecuteNonQuery(script);

                    IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                    connection.Open();
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (var command = new SqlCommand(commandString, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ReportMessage?.Invoke(e.Message);
            }
        }

        public static void Purge()
        {
            try
            {
                int? days = SystemInfo.Current.KeepDays;
                if (days is null || days == 0)
                    return;

                DateTime purgeDate = DateTime.Today.AddDays(-days.Value);

                string sql = $"select id from LemHeader where LogStatus='{(char)EnumLogStatus.Billed}' and LogDate<'{purgeDate}'";
                DataTable table = MobileCommon.ExecuteDataAdapter(sql);

                List<int> lemHeaderList = table.Select().ToList().Select(r => (int)r["id"]).ToList();
                string lemHeaderListText = "0";
                lemHeaderList.ForEach(id => lemHeaderListText += $",{id}");

                MobileCommon.ExecuteNonQuery($"delete EquipTimeEntry where LogHeaderId in ({lemHeaderListText})");

                table = MobileCommon.ExecuteDataAdapter($"select Id from LabourTimeEntry where LogHeaderId in ({lemHeaderListText})");
                List<int> subIdList = table.Select().ToList().Select(r => (int)r["Id"]).ToList();
                subIdList.ForEach(id => LabourTimeEntry.SqlForceDelete(id));

                table = MobileCommon.ExecuteDataAdapter($"select FileRepository_ID from CFS_FileLink where IDValue in ({lemHeaderListText}) and TableDotField='{Attachment.LemHeaderId}'");
                subIdList = table.Select().ToList().Select(r => (int)r["FileRepository_ID"]).ToList();
                subIdList.ForEach(id => Attachment.SqlForceDelete(id));

                MobileCommon.ExecuteNonQuery($"delete LemHeader where Id in ({lemHeaderListText})");

                MobileCommon.ExecuteNonQuery($"delete DeleteHistory where SyncStatus='{EnumRecordSyncStatus.Submitted}' and TimeStamp<'{purgeDate}'");

                sql = $"select id from FieldPO where SyncStatus='{EnumRecordSyncStatus.Submitted}' and PODate<'{purgeDate}'";
                table = MobileCommon.ExecuteDataAdapter(sql);
                subIdList = table.Select().ToList().Select(r => (int)r["Id"]).ToList();
                subIdList.ForEach(id => FieldPO.SqlDelete(id));

                sql = $"select id from LemAP where SyncStatus='{EnumRecordSyncStatus.Submitted}' and InvoiceDate<'{purgeDate}'";
                table = MobileCommon.ExecuteDataAdapter(sql);
                subIdList = table.Select().ToList().Select(r => (int)r["Id"]).ToList();
                subIdList.ForEach(id => LemAP.SqlForceDelete(id));
            }
            catch (Exception e)
            {
                ReportMessage?.Invoke(e.Message);
            }
        }
    }
}
