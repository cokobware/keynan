using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keynan.Configuration.Settings
{
    public abstract class SelectSetting : BaseSetting
    {
        [JsonIgnore]
        public List<string> Items { get; set; }

        public string Value { get; set; }
    }
}
