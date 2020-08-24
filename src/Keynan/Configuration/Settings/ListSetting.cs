using System;
using System.Collections.Generic;
using System.Text;

namespace Keynan.Configuration.Settings
{
    public class ListSetting : BaseSetting
    {
        private string _value;
        private List<string> _values;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                _values = new List<string>(_value.Split(','));
            }
        }

        public List<string> Values
        {
            get { return _values; }
            set
            {
                _values = value;
                _value = _values.ToArray().ToString();
            }
        }

        public void Add(string value)
        {
            if (!_values.Contains(value))
            {
                _values.Add(value);
            }

            _value = _values.ToArray().ToString();
        }

        public void Remove(string value)
        {
            _values.RemoveAll(v => v.Contains(value));
            _value = _values.ToArray().ToString();
        }
    }
}
