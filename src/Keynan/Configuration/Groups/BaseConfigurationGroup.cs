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

        protected T _deserializedResult;
        
        #endregion

        #region Properties

        [JsonIgnore]
        public string Name { get ; set ; }
        [JsonIgnore]
        public string Description { get ; set ; }
        [JsonIgnore]
        public string Configuration { get; set; }
        public string ID { get; set; }

        #endregion

        #region Constructor

        public BaseConfigurationGroup()
        {
            SetupConfigGroup();
            SetOrder();
        }

        #endregion

        #region Methods
        public virtual string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public abstract void SetupConfigGroup();

        public abstract void SetOrder();

        public abstract void AssignProperties();

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
        
        private MapperConfiguration BuildMapperConfiguration()
        {
            // Configure Automapper
            var config = new MapperConfiguration(cfg =>
            {
                var properties = GetType().GetProperties();
                var method = cfg.GetType().GetMethod("AddProfile", Type.EmptyTypes);

                foreach (var property in properties)
                {
                    Type propertyType = property.PropertyType;

                    // if the property is of BaseSetting, 
                    // then we should add it as part of the mapping
                    if (propertyType.IsSubclassOf(typeof(BaseSetting)))
                    {
                        var genericType = typeof(MappingProfile<>).MakeGenericType(new Type[] { propertyType });
                        var genericMethod = method.MakeGenericMethod(genericType);

                        genericMethod.Invoke(cfg, null);
                    }
                }
            });

            return config;
        }

        #endregion
    }
}
