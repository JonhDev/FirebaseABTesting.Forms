using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.RemoteConfig;

namespace Plugin.FirebaseABTesting
{
    /// <summary>
    /// Interface for $safeprojectgroupname$
    /// </summary>
    public class FirebaseABTestingImplementation : IFirebaseABTesting
    {
        private FirebaseRemoteConfig _firebaseRemote;

        public long CacheTimeout { get; set; }
        public bool IsDeveloperModeEnable { get; private set; }

        public FirebaseABTestingImplementation()
        {
            CacheTimeout = 0;
            IsDeveloperModeEnable = true;
            _firebaseRemote = FirebaseRemoteConfig.Instance;
            FirebaseRemoteConfigSettings configSettings = new FirebaseRemoteConfigSettings.Builder()
                .SetDeveloperModeEnabled(true)
                .Build();
            _firebaseRemote.SetConfigSettings(configSettings);
        }

        public void DeveloperMode(bool enable)
        {
            IsDeveloperModeEnable = enable;
            FirebaseRemoteConfigSettings configSettings = new FirebaseRemoteConfigSettings.Builder()
                .SetDeveloperModeEnabled(enable)
                .Build();
            _firebaseRemote.SetConfigSettings(configSettings);
        }

        public async Task<bool> Fetch()
        {
            await _firebaseRemote.FetchAsync(CacheTimeout);
            return _firebaseRemote.ActivateFetched();
        }

        public string GetString(string key) => _firebaseRemote.GetString(key);

        public bool GetBoolean(string key) => _firebaseRemote.GetBoolean(key);

        public double GetDouble(string key) => _firebaseRemote.GetDouble(key);

        public long GetLong(string key) => _firebaseRemote.GetLong(key);
    }
}
