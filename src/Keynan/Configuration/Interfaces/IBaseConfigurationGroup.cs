namespace Keynan.Configuration.Interfaces
{
    public interface IBaseConfigurationGroup : IStorableConfig
    {
        string Name { get; set; }
        string Description { get; set; }

        void SetOrder();
    }
}