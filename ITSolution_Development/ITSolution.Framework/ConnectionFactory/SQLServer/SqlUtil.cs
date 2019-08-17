// Padrão Singleton

namespace ITSolution.Framework.ConnectionFactory.SQLServer
{
    /// <summary>

    /// Essa classe encapsula as classes BackupSQL e RestoreSQL
    /// </summary>
    public sealed class SqlUtil 
    {
        private static SqlUtil _instance ;
        public BackupSql Backup { get; private set; }
        public RestoreBackupSql Restore { get; private set; }
        private SqlUtil()
        {
            this.Backup = new BackupSql();
            this.Restore = new RestoreBackupSql();
        }

        public static SqlUtil Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SqlUtil();
                }
                return _instance;
            }
        }

    }
}
