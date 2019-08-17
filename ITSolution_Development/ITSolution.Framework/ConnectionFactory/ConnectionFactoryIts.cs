using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Text;
using System.Linq;
using System.Threading;
using ITSolution.Framework.Mensagem;

namespace ITSolution.Framework.ConnectionFactory
{
    /// <summary>
    /// Classe para gerar conexões com o banco de dados. Implemente a interface IConnectionFactory
    /// </summary>
    public class ConnectionFactoryIts : IConnectionFactory, ITransactionSql
    {
        #region Declaração de variavéis

        protected string connectionString;
        protected SqlConnection connection;
        protected SqlCommand sqlCommand;

        #endregion Fim da declaração de variavéis

        #region Properties

        public SqlTransaction Transaction { set; get; }
        public TransactionScope TransactionScope { get; private set; }

        public string DatabaseName { get { return this.connection != null ? this.connection.Database : null; } }

        public int ConnectionTimeout { get; }

        /// <summary>
        /// Conexao com o banco de dados
        /// </summary>
        /// <returns></returns>
        public SqlConnection Connection
        {
            get
            {
                return this.connection;
            }
        }
        #endregion

        #region Construtores

        /// <summary>
        /// Estabelece uma conexão com o banco de dados.
        /// </summary>  
        /// <param colName="connectionString"> </param>
        /// <param name="connectionString"> String de conexão com o banco de dados</param>
        /// <param name="timeOut">Tempo para fechamento automatica de conexão</param>
        public ConnectionFactoryIts(string connectionString, int timeOut = 0)
        {
            this.connectionString = connectionString;
            if (timeOut > 0)
                this.ConnectionTimeout = timeOut;
            else
                this.ConnectionTimeout = 1500;
        }

        #endregion

        #region Interface  IConnectionFactory

        /// <summary>
        /// Abre a conexão com o banco
        /// </summary>
        /// <returns></returns>
        public virtual bool OpenConnection()
        {
            Exception erro = null;
            try
            {

                this.connection = new SqlConnection(connectionString);

                //app.Catalog;
                this.connection.Open();
            }
            catch (ConfigurationErrorsException ec)
            {
                erro = ec;
            }
            catch (SqlException es)
            {
                erro = es;
            }
            catch (InvalidOperationException ex)
            {
                erro = ex;
            }

            if (erro != null)
            {
                LoggerUtilIts.GenerateLogs(erro, "Falha ao criar uma conexão!");
                return false;
            }

            return true;

        }

        /// <summary>
        /// Fecha a conexão com o banco de dados
        /// </summary>
        /// <returns>true se a conexão foi fechada ou false outros</returns>
        public virtual bool CloseConnection()
        {
            if (IsOpen())
            {
                try
                {
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// O status da conexão com o banco de dados.
        /// </summary>
        /// <returns>true se a conexão existe caso contrário false</returns> 
        public virtual bool IsOpen()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Fecha a conexão
        /// </summary>
        public void Dispose()
        {
            if (IsOpen())
            {
                this.CloseConnection();
            }
            GC.SuppressFinalize(this);
        }

        #endregion

        #region  Interface ITransactionSql


        /// <summary>
        /// Inicia a execução assíncrona da instrução Transact-SQL ou procedimento armazenado.
        /// </summary>
        /// <param name="querySql"></param>
        /// <returns>true se executado com sucesso caso contrário false</returns>
        public virtual void AddTransaction(string querySql)
        {

            // split script on GO command
            var commands = SplitCommandFromGo(querySql);

            //executando cada script quebrado no comando GO
            foreach (SqlCommand command in commands)
            {
                try
                {
                    //inicia a transação
                    var result = command.BeginExecuteNonQuery();

                    //executa do comando
                    command.EndExecuteNonQuery(result);

                    //query executed sucessful

                }
                catch (SqlException sqlException)
                {
                    //message
                    string errorMessage = LoggerUtilIts.GetInnerException(sqlException);

                    //exceção interna
                    Exception innerException = new Exception(command.CommandText);

                    //cria a exceção a ser lançada
                    throw new TransactionAbortedException(errorMessage, innerException);
                }
            }

        }

        /// <summary>
        /// Inicia a transação no banco
        /// </summary>
        public virtual void BeginTransaction()
        {
            //abre a conexão
            this.OpenConnection();

            //nivel de isolamento para conexão para permitir o rollback e desfazer as alterações no banco de dados.
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = System.Transactions.IsolationLevel.Serializable
            };
            //cria o escopo
            this.TransactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);

            //cria a transacao
            this.Transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted, "myTransaction");

        }

        /// <summary>
        /// Efetiva a transação no banco de dados
        /// </summary>
        public virtual void CommitTransaction()
        {
            using (TransactionScope)
            {
                //avisa o banco da transação 
                this.Transaction.Commit();

                //transaction complete
                this.TransactionScope.Complete();

                //encerra a conexão
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Desfaz as alterações no banco contidas na transação
        /// </summary>
        public virtual void RollbackTransaction()
        {
            //desafaz as alterações
            this.Transaction.Rollback();

        }

        /**
         * Métodos para auxiliar a interface
         * 
         */

        /// <summary>
        /// Executa uma instrução SQL quebrando o script no "GO"
        /// DDL - Data Definition Language 
        /// Comandos do tipo DDL: CREATE, ALTER ou DROP
        /// Usandos na criação dos objeto: tabelas, procedures, índices, relacionamentos etc.
        /// 
        /// DML - Data Manipulation Language
        /// 
        /// <br>Os comando são quebrado na keywork "GO"</br>
        /// 
        /// <br>A instrução é interrompida caso um comando falhe.</br>
        /// </summary>  
        /// <param name="querySql">Instrução SQL</param>
        /// <returns>O número de linhas afetadas ou -1 se nenhuma linha foi afetada.</returns>
        public int ExecuteBrokenNonQuery(string querySql)
        {
            int rowsAffected = 0;

            try
            {
                if (OpenConnection())
                {

                    using (this.connection)
                    {
                        // split script on GO command
                        IEnumerable<string> commandStrings = Regex.Split(querySql, @"^\s*GO\s*$",
                            RegexOptions.Multiline | RegexOptions.IgnoreCase);


                        foreach (string commandString in commandStrings)
                        {
                            if (commandString.Trim() != string.Empty)
                            {
                                using (var command = new SqlCommand(commandString, connection))
                                {
                                    rowsAffected += command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Falha na instrução SQL=>" + ex.Message);
                throw ex;
            }
            return rowsAffected;
        }

        /// <summary>
        /// Execute um script e executa o commit somnete de todas as instruções forem executadas com sucesso.
        /// </summary>
        /// <param name="querySql"></param>
        /// <param name="taskLogDelegate">Metódo anônimo</param>
        /// <returns>true se executado com sucesso caso contrário false</returns>
        public bool ExecuteNonQueryTransaction(string querySql, Delegate taskLogDelegate)
        {

            Dictionary<string, bool> statusScripts = new Dictionary<string, bool>();

            var tso = new TransactionOptions()
            {
                IsolationLevel = System.Transactions.IsolationLevel.Serializable
            };

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, tso))
            {
                try
                {
                    //open connection
                    OpenConnection();

                    // split script on GO command
                    List<SqlCommand> commands = SplitCommandFromGo(querySql);

                    //cria a transacao
                    this.Transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted, "myTransaction");

                    SqlException sqlException = null;

                    //executando cada script quebrado no comando GO
                    foreach (SqlCommand command in commands)
                    {
                        string commandString = command.CommandText;

                        try
                        {

                            command.Connection = this.connection;
                            command.Transaction = this.Transaction;
                            StringBuilder queryLog = new StringBuilder();
                            queryLog.Append("Preparing Command: ...\n");
                            queryLog.Append("--============================================================================\n");
                            queryLog.Append(commandString);
                            queryLog.Append("\n");
                            queryLog.Append("--============================================================================");
                            //delay for log screen
                            Thread.Sleep(10);
                            //passa o parametro e dispara o delegate
                            taskLogDelegate.DynamicInvoke(queryLog.ToString());

                            //inicia a transação
                            var result = command.BeginExecuteNonQuery();

                            //executa do comando
                            command.EndExecuteNonQuery(result);

                            //query executed sucessful
                            if (result.IsCompleted)
                            {
                                //salva o comando executado
                                statusScripts.Add(commandString, result.IsCompleted);
                            }
                        }
                        catch (SqlException sqlex)
                        {
                            //registra o log
                            sqlException = sqlex;
                            //guarda a ref pro erro
                            statusScripts.Add(commandString, false);

                        }
                    }


                    //se tudo deu ok
                    if (statusScripts.Count(s => s.Value == false) == 0)
                    {
                        //avisa o banco da transação 
                        this.Transaction.Commit();

                        //transaction complete
                        ts.Complete();

                        //encerra a conexão
                        CloseConnection();

                        //log
                        var queryLog = new StringBuilder();
                        queryLog.Append("Executing Query ...\n");

                        //limpa o log builder
                        queryLog.Clear();

                        queryLog.Append("============================================================================\n");
                        queryLog.Append("Query executed sucessfully !\n");
                        queryLog.Append("============================================================================\n");

                        //passa o parametro e dispara o delegate
                        taskLogDelegate.DynamicInvoke(queryLog.ToString());

                        return true;
                    }
                    else
                    {

                        //desafaz as alterações
                        this.Transaction.Rollback();

                        //recupera o comando que falhou
                        string command = statusScripts.FirstOrDefault(s => s.Value == false)
                            .ToString();

                        //message
                        string errorMessage = LoggerUtilIts.GetInnerException(sqlException);

                        //exceção interna
                        Exception innerException = new Exception(command);

                        //cria a exceção a ser lançada
                        TransactionAbortedException transactionAborted =
                            new TransactionAbortedException(errorMessage, innerException);


                        var log = new StringBuilder();
                        log.Append("****************************************************************************\n");
                        log.Append("Erro: ");
                        log.Append(errorMessage);
                        log.Append("\n****************************************************************************\n");

                        //passa o parametro e dispara o delegate
                        taskLogDelegate.DynamicInvoke(log.ToString());

                        //transaction aborted
                        throw transactionAborted;
                    }
                }
                catch (TransactionAbortedException tae)
                {
                    //transaction aborted
                    throw tae;
                }
                catch (Exception ex)
                {
                    StringBuilder logScreen = new StringBuilder("Falha durante a transação.");
                    logScreen.Append("Mensagem: " + LoggerUtilIts.GetInnerException(ex));

                    //others errors
                    throw new Exception(logScreen.ToString(), ex);
                }
            }

        }

        /// <summary>
        /// Prepara o query para execução
        /// <br>Comando serão quebrado na keywork "GO"</br>
        /// </summary>        
        public IAsyncResult ExecuteNonQuery(SqlCommand command)
        {

            try
            {
                command.Connection = this.connection;
                command.Transaction = this.Transaction;
                IAsyncResult result = command.BeginExecuteNonQuery();
                command.EndExecuteNonQuery(result);

                return result;
            }
            catch (SqlException sqlE)
            {
                //Transaction.Rollback();
                Console.WriteLine("Error: " + sqlE.Number + " Line: " + sqlE.LineNumber + " Message:" + sqlE.Message);
                throw sqlE;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw ex;
            }

        }

        #endregion

        #region Metodos Padrões

        /// <summary>
        /// Prepara uma instrução SQL a ser executada
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="querySql"></param>
        private void PrepareCommand(CommandType commandType, string querySql)
        {
            //criando o comando
            this.sqlCommand = connection.CreateCommand();
            //tipo de manipulação a ser executada
            this.sqlCommand.CommandType = commandType;
            //execute o comando
            this.sqlCommand.CommandText = querySql;
            //Tempo de execução em sec
            this.sqlCommand.CommandTimeout = this.ConnectionTimeout;

        }

        /// <summary>
        /// Executa script sql, retorna o numero de linhas afetadas ou -1 se nenhuma linha foi afetada.
        /// 
        /// O Script não pode conter o comando "GO"
        /// Lança SqlExcetion
        /// </summary>        
        public int ExecuteQuery(string querySql)
        {
            int rowsAffected = 0;

            try
            {
                OpenConnection();
                using (this.connection)
                {

                    using (var command = new SqlCommand(querySql, connection))
                    {
                        rowsAffected += command.ExecuteNonQuery();
                    }
                }
                return rowsAffected;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Falha na instrução SQL=>" + ex.Message);
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

        }

        /// <summary>
        /// Executando comando de textos tipo DML: Data Maniputlation language
        /// </summary>        
        /// <param name="querySql"></param>
        /// <returns></returns> A função retorna a primeira coluna ou a primeira linha de Identidade se uma nova linha foi inserida, null em caso de falha.
        public object ExecuteQueryScalar(string querySql)
        {
            if (OpenConnection())
            {
                try
                {     //se a conexao foi aberta

                    using (this.connection)
                    {

                        //criando o comando
                        PrepareCommand(CommandType.Text, querySql);
                        //executa o comando no banco de dados
                        return sqlCommand.ExecuteScalar();
                    }
                }
                catch (SqlException ex)
                {
                    XMessageIts.ExceptionJustMessage(ex, "Falha na conexão com o banco de dados");
                }
            }
            //falhou
            return null;
        }

        /// <summary>
        /// Executando comando de textos tipo DML: Data Maniputlation language
        /// Indexa um DataTable a partir do resultado da consulta
        /// </summary>        
        /// <param name="querySql"></param>
        /// <returns></returns>
        public DataTable ExecuteQueryDataTable(string querySql)
        {
            DataTable dataTable = new DataTable();
            if (OpenConnection())
            {
                try
                {


                    using (this.connection)
                    {
                        //criando o comando
                        PrepareCommand(CommandType.Text, querySql);
                        //adaptador para tabela
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        //indexa o dataTable
                        adapter.Fill(dataTable);
                    }
                }
                catch (SqlException ex)
                {
                    //XMessageIts.MensagemExcecaoMsg(ex, "Falha na instrução SQL");
                    throw ex;
                }
            }
            return dataTable;
        }

        /// <summary>
        /// Executa procedimentos 
        /// </summary>
        /// <param name="querySql"></param>
        /// <returns></returns>
        public bool ExecuteProcedureScalar(string querySql)
        {
            object flag = null;
            //se a conexao foi aberta
            if (OpenConnection())
            {
                try
                {

                    using (this.connection)
                    {
                        //criando o comando
                        PrepareCommand(CommandType.StoredProcedure, querySql);

                        //executa o comando no banco de dados
                        flag = sqlCommand.ExecuteScalar();
                    }
                }
                catch (SqlException ex)
                {
                    MessageIts.MensagemExcecao(ex, "Falha na conexão com o banco de dados");
                }
            }
            return flag != null;
        }

        /// <summary>
        /// Executa uma procedure
        /// </summary>
        /// <param name="querySql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteProcedure(string querySql, params SqlParameter[] parameters)
        {
            SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

            if (parameters != null)
            {
                foreach (SqlParameter p in parameters)
                {
                    sqlParameterCollection.Add(p);
                }
            }
            return ExecuteManipulation(CommandType.StoredProcedure, querySql, sqlParameterCollection);
        }

        /// <summary>
        /// Executa o comando ou procedimento no banco de dados. 
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="querySql"></param>
        /// <param name="sqlParameterCollection"></param>
        /// <returns></returns>Retorna um datatable com as colunas e dados do banco
        public DataTable ExecuteManipulation(CommandType commandType, string querySql, SqlParameterCollection sqlParameterCollection)
        {
            DataTable dataTable = new DataTable();
            //se a conexao foi aberta
            if (OpenConnection())
            {
                try
                {

                    using (this.connection)
                    {
                        PrepareCommand(commandType, querySql);

                        if (sqlParameterCollection != null)
                        {
                            //add o parametro no comando
                            foreach (SqlParameter paramentro in sqlParameterCollection)
                            {
                                //sqlCommand.Parameters.Add(new SqlParameter("@parameterName", value));
                                this.sqlCommand.Parameters.Add(new SqlParameter(paramentro.ParameterName, paramentro.Value));
                            }
                        }
                        //adaptador para tabela
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                        //indexa o dataTable
                        adapter.Fill(dataTable);
                    }
                }
                catch (SqlException ex)
                {
                    MessageIts.MensagemExcecao(ex, "Falha na conexão com o banco de dados");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dataTable;

        }

        public async Task<DataTable> ExecuteManipulationAsync(CommandType commandType, string querySql,
            SqlParameterCollection sqlParameterCollection)
        {
            return await Task.Run(() => ExecuteManipulation(commandType, querySql, sqlParameterCollection));
        }

        /// <summary>
        /// Quebra uma string SQL no comando GO
        /// </summary>
        /// <param name="querySql"></param>
        /// <returns>Lista de comandos SQL</returns>
        public List<SqlCommand> SplitCommandFromGo(string querySql)
        {
            //commands list
            List<SqlCommand> commands = new List<SqlCommand>();

            // split script on GO command
            IEnumerable<string> commandStrings = SplitFromGo(querySql);

            //cria um commando a ser executado
            foreach (string commandString in commandStrings)
            {
                if (commandString.Trim() != string.Empty)
                {
                    var command = new SqlCommand(commandString, null);
                    command.Connection = this.connection;
                    command.Transaction = this.Transaction;
                    commands.Add(command);
                }
            }
            return commands;
        }

        public List<string> GetDataBases()
        {
            var lista = new List<string>();

            try
            {
                //var scriptSQL = "EXEC sp_databases";Não funciona no azure
                string scriptSQL = "SELECT name, database_id, create_date FROM sys.databases ORDER BY name";
                var dataTable = ExecuteQueryDataTable(scriptSQL);

                foreach (DataRow row in dataTable.Rows) // Loop over the rows.
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        var columnName = column.ColumnName.ToString();

                        if (columnName == "DATABASE_NAME")
                        {
                            var database = DataGridViewUtil.GetValueDataRow(row, columnName);
                            lista.Add(database.ToString());
                        }

                    }
                    //foreach (var item in row.ItemArray) // Loop over the items.
                    //{
                    //    Console.WriteLine(item); // Invokes ToString abstract method.
                    //}
                }
            }
            catch (SqlException)
            {
            }

            return lista;
        }

        //Funciona no azure
        public string[] DataBases
        {
            get
            {
                try
                {

                    string scriptSQL = "SELECT name, database_id, create_date FROM sys.databases ORDER BY name";

                    var dataTable = ExecuteQueryDataTable(scriptSQL);
                    var lista = new string[dataTable.Rows.Count];
                    int i = 0;
                    foreach (DataRow row in dataTable.Rows) // Loop over the rows.
                    {

                        var database = DataGridViewUtil.GetValueDataRow(row, "name");
                        lista[i] = database.ToString();
                        i++;

                    }
                    return lista;

                }
                catch (SqlException)
                {
                    return new string[] { };
                }
            }
        }

        //Funciona no azure
        public string[] Tables
        {
            get
            {
                try
                {
                    string scriptSQL = " SELECT name FROM sys.tables ORDER BY name";

                    var dataTable = ExecuteQueryDataTable(scriptSQL);
                    var lista = new string[dataTable.Rows.Count];
                    int i = 0;
                    foreach (DataRow row in dataTable.Rows) // Loop over the rows.
                    {

                        var database = DataGridViewUtil.GetValueDataRow(row, "name");
                        lista[i] = database.ToString();
                        i++;

                    }
                    return lista;


                }
                catch (SqlException)
                {
                    return new string[] { };
                }
            }
        }

        // Não funciona no azure
        public DataTable GetDataBasesDetails()
        {
            try
            {
                /*var scriptSQL = @"SELECT  database_name = DB_NAME(database_id), 
                    log_size_mb = CAST(SUM(CASE WHEN type_desc = 'LOG' THEN size END) * 8. / 1024 AS DECIMAL(8, 2)),
                    row_size_mb = CAST(SUM(CASE WHEN type_desc = 'ROWS' THEN size END) * 8. / 1024 AS DECIMAL(8, 2)),
                    total_size_mb = CAST(SUM(size) * 8. / 1024 AS DECIMAL(8, 2)) 
                    FROM sys.master_files WITH(NOWAIT) 
                    WHERE database_id = DB_ID()-- for current db 
                    GROUP BY database_id";*/
                var scriptSQL = "EXEC sp_helpdb";
                DataTable dt = ExecuteQueryDataTable(scriptSQL);
                return dt;
            }
            catch (SqlException)
            {
                return new DataTable();
            }

        }

        #endregion

        #region Metodos estaticos

        /// <summary>
        /// Split script on GO command
        /// </summary>
        /// <param name="scriptSQL"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitFromGo(string scriptSQL)
        {
            // split script on GO command
            IEnumerable<string> commandStrings = Regex.Split(scriptSQL, @"^\s*GO\s*$",
                                     RegexOptions.Multiline | RegexOptions.IgnoreCase);

            return commandStrings;
        }

        /// Coluna          Descrição
        /// ServerName      Nome do servidor.
        /// InstanceName    Nome da instância do servidor.Em branco se o servidor estiver sendo executado como a instância padrão.
        /// IsClustered     Indica se o servidor faz parte de um cluster.
        /// Versão          Versão do servidor.Por exemplo:
        ///                 9,00.x (SQL Server 2005)
        ///                 10.0.xx(SQL Server 2008)
        ///                 10.50.x(SQL Server 2008 R2)
        ///                 11.0.xx(SQL Server 2012)
        public static DataTable GetDataSources()
        {
            try
            {
                DataTable dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
                //foreach (DataRow row in dt.Rows)
                //{
                //    foreach (DataColumn col in dt.Columns)
                //        Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                //    Console.WriteLine("============================");
                //}
                return dt;
            }
            catch (SqlException)
            {

                return new DataTable();
            }

        }

        #endregion

    }
}



