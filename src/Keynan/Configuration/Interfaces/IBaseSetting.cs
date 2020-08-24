namespace Keynan.Configuration.Interfaces
{
    public interface IBaseSetting
    {
        string Name { get; set;  }
        string Description { get; set; }
        int Order { get; set; }
    }
}
