namespace Keynan.Configuration.Mapping
{
    using AutoMapper;
    using Newtonsoft.Json.Linq;

    public class MappingProfile<T> : Profile
    {
        public MappingProfile()
        {
            CreateMap<JObject, T>()
                .ForMember("Value", cfg => { cfg.MapFrom(jo => jo["Value"]); });
        }
    }
}
