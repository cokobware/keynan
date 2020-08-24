using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace Keynan.Configuration.Settings
{
    public abstract class UriSetting : StringSetting
    {
        private string _value;

        public new string Value
        {
            get { return _value; }
            set {
                Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out Uri validatedUri);
                _value = validatedUri.AbsoluteUri;
            }
        }
    }
}
