namespace Keynan.UnitTests.Example
{
    using Keynan.Configuration.Groups;
    using Keynan.Configuration.Settings;
    using System.Collections.Generic;

    // Use a unique GUID to help differentiate this group from other groups.
    // You don't have to use this approach below. You can just assign it directly 
    // to the ID propertly of the Configuration Group implementation.
    public static partial class ExampleGroups
    {
        public static string ExampleConfigGroupID => "6F42CC17-FA23-4EF8-88D6-1C8AB6C96BD3"; 
    }

    // Our
    public class ExampleConfigGroup : BaseConfigurationGroup<ExampleConfigGroup>
    {
        // Settings as properties for the Configuration Group
        public FeatureASetting FeatureA { get; set; }
        public HowManyVideosSetting HowManyVideos { get; set; }
        public PickOneSetting PickOne { get; set; }
        public PickAnotherSetting PickAnother { get; set; }
        public EmailContactSetting EmailContact { get; set; }

        // Friendly group name, localized
        public new string Name => ExampleConfigurationGroupResource.Group_Name;

        // Friendly group description, localized
        public new string Description => ExampleConfigurationGroupResource.Group_Description;

        // A unique identifier for the group in your application. A guid works well,
        // however any unique string to your application will do.
        public new string ID => ExampleGroups.ExampleConfigGroupID;

        // Initializes the defined group Settings and assigns them 
        // to the group's properties.
        public override void SetupConfigGroup()
        {
            FeatureA = new FeatureASetting();
            HowManyVideos = new HowManyVideosSetting();
            PickOne = new PickOneSetting();
            PickAnother = new PickAnotherSetting();
            EmailContact = new EmailContactSetting();
        }

        // Sets the sort order for the Settings in the Configuration Group,
        // which can be used when displaying the Settings in an interface
        public override void SetOrder()
        {
            FeatureA.Order = 10;
            PickOne.Order = 15;
            PickAnother.Order = 16;
            HowManyVideos.Order = 20;
            EmailContact.Order = 5;
        }


        // Assign values from the deserialized result into their respective properties
        public override void AssignProperties()
        {
            FeatureA.Value = _deserializedResult.FeatureA.Value;
            HowManyVideos.Value = _deserializedResult.HowManyVideos.Value;
            PickOne.Value = _deserializedResult.PickOne.Value;
            PickAnother.Value = _deserializedResult.PickAnother.Value;
            EmailContact.Value = _deserializedResult.EmailContact.Value;
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
