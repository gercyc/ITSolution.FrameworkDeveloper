namespace ITSolution.Framework.ConnectionFactory
{
    public interface ITransactionSql
    {
        /// <summary>
        /// Inicia a execução assíncrona da instrução Transact-SQL ou procedimento armazenado.
        /// </summary>
        /// <param name="querySql"></param>
        /// <returns>true se executado com sucesso caso contrário false</returns>
        void AddTransaction(string querySql);

        /// <summary>
        /// Inicia a transação no banco
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Efetiva a transação no banco de dados
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Desfaz as alterações no banco contidas na transação
        /// </summary>
        void RollbackTransaction();
    }
}
