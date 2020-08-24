using Keynan.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keynan.Configuration.Interfaces
{
    public interface IStorableConfig : IStorable
    {
        /// <summary>
        /// The unique ID of the configuration.
        /// </summary>
        string ID { get; set; }
        string Configuration { get; set; }

        string Serialize();
        void Deserialize();
    }
}