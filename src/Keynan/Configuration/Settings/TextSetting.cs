using AutoMapper;
using Keynan.Configuration.Interfaces;
using Keynan.Configuration.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keynan.Configuration.Settings
{
    public abstract class TextSetting : StringSetting
    {
        [JsonIgnore]
        public bool MultiLine { get; set; } = false;
        [JsonIgnore]
        public bool HTMLText { get; set; } = false;
    }
}
