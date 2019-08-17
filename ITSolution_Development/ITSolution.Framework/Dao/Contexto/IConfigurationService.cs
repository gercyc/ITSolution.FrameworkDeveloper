namespace ITSolution.Framework.Dao.Contexto
{
    public interface IConfigurationService
    {
        string GetConnectionString(string key);
    }
}
