using Keynan.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keynan.Storage
{
    public interface IStorageAdapter
    {
        string LoadLookup(string owner, string configId);
        void SaveLookup(string owner, string configId, string settings);
    }
}
