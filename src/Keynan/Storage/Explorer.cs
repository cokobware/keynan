namespace Keynan.Storage
{
    using Keynan.Configuration.Interfaces;
    using System;

    /// <summary>
    /// This is the mechanism that 
    /// </summary>
    public class Explorer
    {
        private IStorageAdapter _adapter;
        private string _owner;
        private string _configID;

        public IStorageAdapter StorageAdapter { get => _adapter; set => _adapter = value; }
        public string Owner { get => _owner; set => _owner = value; }
        public string ConfigID { get => _configID; set => _configID = value; }

        public Explorer(IStorageAdapter storageAdapter, string owner, string configID)
        {
            _adapter = storageAdapter;
            _owner = owner;
            _configID = configID;
        }

        public T GetConfiguration<T>() where T : IBaseConfigurationGroup
        {
            var result = _adapter.LoadLookup(_owner, _configID);

            if (result != null)
            {
                var config = (T)Activator.CreateInstance(typeof(T), new object[] { });
                config.Configuration = result;
                config.Deserialize();

                return config;
            }
            else
            {
                // load default config
                return default(T);
            }
        }
    }
}