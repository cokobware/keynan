namespace Keynan.Configuration.Settings
{
    using AutoMapper;
    using Keynan.Configuration.Interfaces;
    using Newtonsoft.Json;
    using System;

    public abstract class BaseSetting : IBaseSetting
    {
        protected Type _mappingProfileType;

        /// <summary>
        /// The name of the setting that will display
        /// </summary>
        [JsonIgnore]
        public string Name { get; set; }

        /// <summary>
        /// The description of what the setting does
        /// </summary>
        [JsonIgnore]
        public string Description { get; set; }
        
        /// <summary>
        /// The ordinal position of the setting and how it's displayed during editing
        /// </summary>
        [JsonIgnore]
        public int Order { get; set; }

        /// <summary>
        /// A name of the group that the setting belongs to. This is used for grouping settings together visually.
        /// </summary>
        [JsonIgnore]
        public string SettingGroup { get; set; }

        /// <summary>
        /// The Automapper mapping profile used to deserialize the setting from storage
        /// </summary>
        [JsonIgnore]
        public Profile MappingProfile { get; set; }
    }
}