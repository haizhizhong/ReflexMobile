using HMConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class MobileCompanyInitProvider : ICompanyInitProvider
    {
        Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        public MobileCompanyInitProvider()
        {
            string sql = $"Select CompanyName, Shortname, Active From Company Where MatchID = {Company.CurrentId}";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            var setup = table.Select().Select(r => new
            {   CompanyName = Convert.ToString(r["CompanyName"]),
                ShortName = Convert.ToString(r["Shortname"]),
                Active = Convert.ToString(r["Active"])
            }).Single();

            _dictionary.Add(CompanyInitKeys.CompanyServer, MobileCommon.ServerName);
            _dictionary.Add(CompanyInitKeys.TRDB, MobileCommon.DatabaseName);
            _dictionary.Add(CompanyInitKeys.CompanyName, setup.CompanyName);
            _dictionary.Add(CompanyInitKeys.ShortCompanyName, setup.ShortName);
            _dictionary.Add(CompanyInitKeys.DMServer, MobileCommon.ServerName);
            _dictionary.Add(CompanyInitKeys.DMDB, MobileCommon.DatabaseName);
            _dictionary.Add(CompanyInitKeys.CompanyActive, setup.Active);
            _dictionary.Add(CompanyInitKeys.TrustedConnection, true.ToString());
        }

        public string GetString(string key)
        {
            return _dictionary.ContainsKey(key) ? _dictionary[key] : string.Empty;
        }

        public T GetValue<T>(string key, T oldValue) where T : struct
        {
            string str = GetString(key);
            return str == string.Empty ? oldValue : (T)Convert.ChangeType(str, typeof(T));
        }
    }
}
