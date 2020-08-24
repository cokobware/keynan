using System;
using System.Collections.Generic;
using System.Text;

namespace Keynan.Configuration.Settings
{
    public abstract class StringSetting : BaseSetting
    {
        public string Value { get; set; }

    }
}
