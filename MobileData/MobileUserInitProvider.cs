using HMConnection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileData
{
    public class MobileUserInitProvider : IUserInitProvider
    {
        Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        public MobileUserInitProvider()
        {
            _dictionary.Add(UserInitKeys.MLUser, LoginUser.CurrUser.GetUserName());
            _dictionary.Add(UserInitKeys.Department, LoginUser.CurrUser.AccessList.Single(x=>x.CompanyId==Company.CurrentId).Department);
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
