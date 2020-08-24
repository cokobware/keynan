using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace Keynan.Configuration.Settings
{
    public abstract class EmailAddressSetting : StringSetting
    {
        private string _value;

        public new string Value {
            get { return _value; }
            set { _value = (new MailAddress(value)).Address; }
        }
    }
}
