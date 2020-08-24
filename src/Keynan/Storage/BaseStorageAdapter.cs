using System;
using System.Collections.Generic;
using System.Text;
using Keynan.Configuration.Interfaces;

namespace Keynan.Storage
{
    public abstract class BaseStorageAdapter : IStorageAdapter
    {
        public abstract void SaveLookup(string ownerId, string lookupId, string lookupSettings);

        public abstract string LoadLookup(string ownerId, string lookupId);
    }
}
