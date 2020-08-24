namespace Keynan.Configuration.Settings
{
    using System.Collections.Generic;

    public class MultipleSelectSetting : SelectSetting
    {
        private string _value;
        private List<string> _values;

        public new string Value {
            get { return _value; }
            set {
                _value = value;
                _values = new List<string>(_value.Split(','));
            }
        }

        public List<string> Values {
            get { return _values; }
            set {
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
            if (_values.Contains(value))
            {
                _values.Remove(value);
            }

            _value = _values.ToArray().ToString();
        }
    }
}
