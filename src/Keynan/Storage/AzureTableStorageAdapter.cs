//namespace Keynan.Storage
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Text;
//    using Keynan.Configuration.Interfaces;
//    using Microsoft.Azure;
//    using Microsoft.Azure.Storage;
//    using Keynan.DataAccess;

//    public class AzureTableStorageAdapter : BaseStorageAdapter

//    {
//        private string _storageConnectionString;
//        private string _tableReference { get; set; }

//        public AzureTableStorageAdapter(string connectionString, string tableReference)
//        {
//            _storageConnectionString = connectionString;
//            _tableReference = tableReference;
//        }

//        public override string LoadLookup(string ownerId, string lookupId)
//        {
//            var azureTable = new AzureTable()
//            {
//                ConnectionString = _storageConnectionString,
//                TableReference = _tableReference
//            };

//            var retrievedResult = azureTable.Get<LookupEntity>(ownerId, lookupId);

//            if (retrievedResult.Result != null)
//            {
//                return ((LookupEntity)retrievedResult.Result).Settings;
//            }
//            else
//            {
//                return null;
//            }
//        }

//        public override void SaveLookup(string ownerId, string lookupId, string lookupSettings)
//        {
//            var azureTable = new Keynan.DataAccess.AzureTable()
//            {
//                ConnectionString = _storageConnectionString,
//                TableReference = _tableReference
//            };

//            azureTable.Set(configEntity);
//        }

//    }
//}
