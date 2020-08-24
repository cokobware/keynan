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
    public abstract class IntegerSetting : BaseSetting
    {
        public int Value { get; set; }

    }


}
