namespace Keynan.Configuration.Groups
{
    using AutoMapper;
    using Keynan.Configuration.Mapping;
    using Keynan.Configuration.Settings;
    using Keynan.Configuration.Interfaces;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using Keynan.Interfaces;

    public abstract class BaseConfigurationGroup<T> : IBaseConfigurationGroup, IStorable
    {
        #region Fields
        /// <summary>
        /// Stores the results from deserialization.
        /// </summary>
        protected T _deserializedResult;
        
        #endregion

        #region Properties

        /// <summary>
        /// Name of the Configuration Group. Does not serialize.
        /// </summary>
        [JsonIgnore]
        public string Name { get ; set ; }

        /// <summary>
        /// Description of the Configuration Group. Does not serialize.
        /// </summary>
        [JsonIgnore]
        public string Description { get ; set ; }

        /// <summary>
        /// Holds the serialized version of the Configuration Group. Does not serialize.
        /// </summary>
        [JsonIgnore]
        public string Configuration { get; set; }


        /// <summary>
        /// Identifier of the configuration. Can be whatever you want. Guids are a good option.
        /// </summary>
        public string ID { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructior, establishing the Settings for the Configuration Group, and their ordering.
        /// </summary>
        public BaseConfigurationGroup()
        {
            SetupConfigGroup();
            SetOrder();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Serializes the Configuration Group to JSON.
        /// </summary>
        /// <returns>JSON string</returns>
        public virtual string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Initializes the defined group Settings and assigns them 
        /// to the group's properties. Since each Configuration Group
        /// is different, each group has to set up their own.
        /// Used in initialization.
        /// </summary>
        public abstract void SetupConfigGroup();

        /// <summary>
        /// Sets the sort order for the Settings in the Configuration Group,
        /// which can be used when displaying the Settings in an interface.
        /// Used in initialization.
        /// </summary>
        public abstract void SetOrder();

        /// <summary>
        /// Assigns the Setting properties needed to populate the Configuration
        /// Group. Used in deserialization.
        /// </summary>
        public abstract void AssignProperties();

        /// <summary>
        /// This deserializes the JSON into a usable Configuration Group 
        /// instance of type T.
        /// </summary>
        public void Deserialize()
        {
            // Configure Automapper
            var config = BuildMapperConfiguration();
            var mapper = config.CreateMapper();

            // grab the object and Deserialize it to a JObject
            var jsonObj = JObject.Parse(Configuration);
            _deserializedResult = mapper.Map<T>(jsonObj);

            // this assigns the properties needed to populate the object
            AssignProperties();
        }

        /// <summary>
        /// This builds the AutoMapper configuration, which does some of the
        /// heavy lifting.
        /// </summary>
        /// <returns></returns>
        private MapperConfiguration BuildMapperConfiguration()
        {
            // Configure Automapper
            // We only want to map our properties that are of BaseSetting type.
            var config = new MapperConfiguration(cfg =>
            {
                // get all properties of this object
                var properties = GetType().GetProperties();

                // get the method for AddProfile to be used below
                var method = cfg.GetType().GetMethod("AddProfile", Type.EmptyTypes);

                // loop through each property on this object and inspect it
                foreach (var property in properties)
                {
                    // get the actual type for this property
                    Type propertyType = property.PropertyType;

                    // if the property is of subclass BaseSetting, 
                    // then we should add it as part of the mapping
                    if (propertyType.IsSubclassOf(typeof(BaseSetting)))
                    {
                        // this enables mapping from a JObject via the MappingProfile<T> object to T
                        var genericType = typeof(MappingProfile<>).MakeGenericType(new Type[] { propertyType });

                        // assign the generic type created to the AddProfile generic method
                        var genericMethod = method.MakeGenericMethod(genericType);

                        // invoke the AddProfile method for this property
                        genericMethod.Invoke(cfg, null);
                    }
                }
            });

            return config;
        }

        #endregion
    }
}
