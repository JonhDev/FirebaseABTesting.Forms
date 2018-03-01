using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.FirebaseABTesting
{
    public interface IFirebaseABTesting
    {
        long CacheTimeout { get; set; }
        bool IsDeveloperModeEnable { get; }

        void DeveloperMode(bool enable);

        Task<bool> Fetch();
        string GetString(string key);
        bool GetBoolean(string key);
        double GetDouble(string key);
        long GetLong(string key);
    }
}
