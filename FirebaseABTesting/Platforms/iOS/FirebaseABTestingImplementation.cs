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
        private RemoteConfig _firebaseConfig;
        private TaskCompletionSource<bool> _result;

        public long CacheTimeout { get; set; }
        public bool IsDeveloperModeEnable { get; private set; }

        public FirebaseABTestingImplementation()
        {
            CacheTimeout = 0;
            IsDeveloperModeEnable = true;
            _firebaseConfig = RemoteConfig.SharedInstance;
            var configSettings = new RemoteConfigSettings(IsDeveloperModeEnable);
            _firebaseConfig.ConfigSettings = configSettings;
            //_firebaseConfig.SetDefaults("default_values"); <-- Default values
        }

        public void DeveloperMode(bool enable)
        {
            IsDeveloperModeEnable = enable;
            var configSettings = new RemoteConfigSettings(enable);
            _firebaseConfig.ConfigSettings = configSettings;
        }

        public async Task<bool> Fetch()
        {
            _result?.TrySetCanceled();
            _result = new TaskCompletionSource<bool>();
            _firebaseConfig.Fetch(0, (status, error) =>
            {
                if (status == RemoteConfigFetchStatus.Success)
                {
                    _firebaseConfig.ActivateFetched();
                    _result.SetResult(true);
                }
                else
                {
                    _result.SetResult(false);
                }
            });
            return await _result.Task;
        }

        public string GetString(string key) => _firebaseConfig[key].StringValue;

        public bool GetBoolean(string key) => _firebaseConfig[key].BoolValue;

        public double GetDouble(string key) => _firebaseConfig[key].NumberValue.DoubleValue;

        public long GetLong(string key) => _firebaseConfig[key].NumberValue.LongValue;
    }
}
