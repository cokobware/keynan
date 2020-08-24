namespace Keynan.Configuration.Settings
{
    using Keynan.Resources.Configuration.General;
    using Newtonsoft.Json;

    public enum BooleanSettingTypeEnum
    {
        TrueFalse,
        YesNo,
        OnOff
    }

    public abstract class BooleanSetting : BaseSetting
    {
        [JsonIgnore]
        public BooleanSettingTypeEnum Type { get; set; } = BooleanSettingTypeEnum.TrueFalse;

        public bool Value { get; set; }

        public string DisplayValue()
        {
            string result = null;

            switch (this.Type)
            {
                case BooleanSettingTypeEnum.YesNo:
                    result = Value ? SettingsResource.YesNo_Yes : SettingsResource.YesNo_No;
                    break;
                case BooleanSettingTypeEnum.OnOff:
                    result = Value ? SettingsResource.OnOff_On : SettingsResource.OnOff_Off;
                    break;
                default:
                    result = Value.ToString();
                    break;
            }

            return result;
        }

    }


}