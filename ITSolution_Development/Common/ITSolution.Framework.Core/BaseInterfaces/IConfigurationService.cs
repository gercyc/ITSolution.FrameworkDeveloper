namespace ITSolution.Framework.Core.BaseInterfaces
{
    public interface IConfigurationService
    {
        string GetConnectionString(string key);
    }
}
