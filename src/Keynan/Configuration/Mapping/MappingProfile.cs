namespace Keynan.Configuration.Mapping
{
    using AutoMapper;
    using Newtonsoft.Json.Linq;

    public class MappingProfile<T> : Profile
    {
        public MappingProfile()
        {
            // maps a JObject to the Value property of type T
            CreateMap<JObject, T>()
                .ForMember("Value", cfg => { cfg.MapFrom(jo => jo["Value"]); });
        }
    }
}
