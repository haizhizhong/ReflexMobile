using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MobileData
{
    public enum EnumTableSyncStatus              // table SyncStatus
    {
        ReadyToSync = 0,                    // !InSync + Complete

        Receiving = 1,                  // InSync + !Complete + Receive
        CompleteReceive = 2,            // InSync +  Complete + Receive
        ErrorInReceive = 3,             // InSync + !Complete + Receive  

        Sending = 11,
        CompleteSend = 12,
        ErrorInSend = 13,
    }

    public class EnumTableSyncStatusText
    {
        public static string GetText(EnumTableSyncStatus status)
        {
            if (status == EnumTableSyncStatus.ReadyToSync)
                return "Ready To Sync";
            else if (status == EnumTableSyncStatus.Receiving)
                return "Receiving Data";
            else if (status == EnumTableSyncStatus.CompleteReceive)
                return "Data Received";
            else if (status == EnumTableSyncStatus.ErrorInReceive)
                return "Error In Receiving";
            else if (status == EnumTableSyncStatus.Sending)
                return "Sending";
            else if (status == EnumTableSyncStatus.CompleteSend)
                return "Data Sent";
            else if (status == EnumTableSyncStatus.ErrorInSend)
                return "Error In Sending";

            return "????";
        }
    }

    public enum EnumRecordSyncStatus        // for each record SyncStatus field value
    {
        NoSubmit,
        Submiting,      //sending
        Submitted,
        Receiving,      //receiving
        Updating,       //receiving
    }

    public struct SyncResult
    {
        public bool Successful;
        public string Task;
        public string Message;

        public string DisplayMessage()
        {
            if (Successful)
                return Message;
            else 
            {
                if(Message.Contains("InternalServerError"))
                    return $"Error in syncing {Task}, probably lost internet connection.";
                else if (Message.Contains("NotFound"))
                    return $"Error in syncing {Task}, the web service is not found.";
                else if (Message.Contains("BadRequest"))
                    return $"Error in syncing {Task}, the web service has an exception.";
                else
                    return $"Error in syncing {Task}: {Message}";
            }
        }
    }

    public static class HttpClientExtend
    {
        public static void Init(this HttpClient client, Guid token)
        {
            client.Init();
            client.DefaultRequestHeaders.Add(MobileCommon.WebToken, token.ToString());
        }

        public static void Init(this HttpClient client)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebUri"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
