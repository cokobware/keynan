namespace Keynan.UnitTests.Example
{
    using Keynan.Configuration.Groups;
    using Keynan.Configuration.Settings;
    using System.Collections.Generic;

    public static partial class ExampleGroups
    {
        // use a unique GUID to help differentiate this group
        public static string ExampleConfigGroupID => "6F42CC17-FA23-4EF8-88D6-1C8AB6C96BD3"; 
    }

    public class ExampleConfigGroup : BaseConfigurationGroup<ExampleConfigGroup>
    {
        // Settings
        public FeatureASetting FeatureA { get; set; }
        public HowManyVideosSetting HowManyVideos { get; set; }
        public PickOneSetting PickOne { get; set; }
        public PickAnotherSetting PickAnother { get; set; }
        public EmailContactSetting EmailContact { get; set; }

        public new string Name => ExampleConfigurationGroupResource.Group_Name;
        public new string Description => ExampleConfigurationGroupResource.Group_Description;
        public new string ID => ExampleGroups.ExampleConfigGroupID;

        public override void SetupConfigGroup()
        {
            FeatureA = new FeatureASetting();
            HowManyVideos = new HowManyVideosSetting();
            PickOne = new PickOneSetting();
            PickAnother = new PickAnotherSetting();
            EmailContact = new EmailContactSetting();
        }

        // Methods
        public override void SetOrder()
        {
            FeatureA.Order = 10;
            PickOne.Order = 15;
            PickAnother.Order = 16;
            HowManyVideos.Order = 20;
            EmailContact.Order = 5;
        }

        public override void AssignProperties()
        {
            // Assign all properties 
            this.FeatureA.Value = _deserializedResult.FeatureA.Value;
            this.HowManyVideos.Value = _deserializedResult.HowManyVideos.Value;
            this.PickOne.Value = _deserializedResult.PickOne.Value;
            this.PickAnother.Value = _deserializedResult.PickAnother.Value;
            this.EmailContact.Value = _deserializedResult.EmailContact.Value;
        }
    }

    #region Settings
    public class FeatureASetting : BooleanSetting
    {
        public FeatureASetting()
        {
            Name = ExampleConfigurationGroupResource.FeatureA_Name;
            Description = ExampleConfigurationGroupResource.FeatureA_Description;
            Type = BooleanSettingTypeEnum.OnOff;
        }
    }

    public class HowManyVideosSetting : IntegerSetting
    {
        public HowManyVideosSetting()
        {
            Name = ExampleConfigurationGroupResource.HowManyVideos_Name;
            Description = ExampleConfigurationGroupResource.HowManyVideos_Description;
        }
    }

    public class PickOneSetting : SelectSetting
    {
        public PickOneSetting()
        {
            Name = ExampleConfigurationGroupResource.PickOne_Name;
            Description = ExampleConfigurationGroupResource.PickOne_Description;
            SettingGroup = "Pickers";

            Items = new List<string>()
            {
                ExampleConfigurationGroupResource.PickOne_ListItem1,
                ExampleConfigurationGroupResource.PickOne_ListItem2,
                ExampleConfigurationGroupResource.PickOne_ListItem3
            };
        }
    }

    public class PickAnotherSetting : SelectSetting
    {
        public PickAnotherSetting()
        {
            Name = ExampleConfigurationGroupResource.PickAnother_Name;
            Description = ExampleConfigurationGroupResource.PickAnother_Description;
            SettingGroup = "Pickers";

            Items = new List<string>()
            {
                ExampleConfigurationGroupResource.PickAnother_ListItem1,
                ExampleConfigurationGroupResource.PickAnother_ListItem2,
                ExampleConfigurationGroupResource.PickAnother_ListItem3
            };
        }
    }

    public class EmailContactSetting : EmailAddressSetting
    {
        public EmailContactSetting()
        {
            Name = ExampleConfigurationGroupResource.PickAnother_Name;
            Description = ExampleConfigurationGroupResource.PickAnother_Description;
        }
    }

    #endregion
}
