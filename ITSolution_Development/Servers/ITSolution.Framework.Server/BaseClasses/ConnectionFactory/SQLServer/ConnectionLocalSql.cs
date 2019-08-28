namespace ITSolution.Framework.ConnectionFactory.SQLServer
{
    public class ConnectionLocalSql : ConnectionFactoryIts
    {
     

        public ConnectionLocalSql() : base("Data Source = (local); Integrated Security = True")
        {
        }

        public ConnectionLocalSql(string connectionString) : base(connectionString)
        {
        }

       
    }
}
