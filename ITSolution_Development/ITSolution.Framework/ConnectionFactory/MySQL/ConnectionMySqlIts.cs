namespace ITSolution.Framework.ConnectionFactory.MySQL
{
    public class ConnectionMySqlIts : ConnectionFactoryIts
    {
        public ConnectionMySqlIts(string connectionString, int timeOut = 0) : base(connectionString, timeOut)
        {
        }
    }
}
