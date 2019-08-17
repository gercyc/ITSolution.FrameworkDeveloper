namespace ITSolution.Framework.ConnectionFactory
{
    /*
     * 21/08/2015       Gercy Campos            Inclusão dos métodos de conexão Oracle
     * */

    /// <summary>
    /// Classe abstrata para gerar conexões conexões com o banco de dados. 
    /// </summary>
    public abstract class ConnectionFactoryOracleIts  
    {
        /*
        #region Declaração de variavéis
        protected SqlConnection connection;
        protected String connectionString;
        protected SqlCommand sqlCommand;

        protected OracleConnection connectionOracle;
        protected OracleCommand oracleCommand;

        protected TypeConnection typeConnection;

        #endregion Fim da declaração de variavéis
        
        /// <summary>
        /// Estabelece uma conexão com o banco de dados.
        /// </summary>  
        /// <param colName="connectionString">String de conexão com o banco de dados</param> 
        public ConnectionFactoryOracleIts(String connectionString)
        {
            try
            {
                this.connectionString = connectionString;

                this.connection = new SqlConnection(connectionString);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha ao estabelecer conexão com banco de dados\n\n"
                    + ex.ToString());
                //para tudo q esta fazendo
                throw ex;
            }

        }

        /// <summary>
        /// Controi uma conexão, este construtor pode ser usando tanto para oracle ou sql server
        /// bastando informar somente os parametros necessários
        /// </summary>
        /// <param name="connectionString">String SQL, se o tipo for SQL Server</param>
        /// <param name="typeConnection">Tipo de banco de dados</param>
        /// <param name="aliasOracle">Alias do TNSNAMES</param>
        /// <param name="userOracle">Schema/Usuário</param>
        /// <param name="passOracle">Senha</param>
        public ConnectionFactoryOracleIts(String connectionString, TypeConnection typeConnection,
            String aliasOracle, String userOracle, String passOracle)
        {
            try
            {
                this.connectionString = connectionString;
                if (typeConnection == TypeConnection.SqlServer)
                {
                    this.connection = new SqlConnection(connectionString);
                    this.typeConnection = typeConnection;
                }
                else if (typeConnection == TypeConnection.Oracle)
                {
                    String connectionStringOracle =
                        String.Format(@"Data Source={0};User Id={1};Password={2};",
               aliasOracle, userOracle, passOracle);
                    this.connectionString = connectionStringOracle;
                    this.connectionOracle = new OracleConnection(this.connectionString);
                    this.typeConnection = typeConnection;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha ao estabelecer conexão com banco de dados\n\n"
                    + ex.ToString());
                //para tudo q esta fazendo
                throw ex;
            }

        }

        /// <summary>
        /// Abre a conexão com o banco
        /// </summary>
        /// <returns></returns>
        public virtual bool OpenConnection()
        {
            Exception erro = null;
            try
            {
                if (typeConnection == TypeConnection.SqlServer)
                    connection.Open();
                else if (typeConnection == TypeConnection.Oracle)
                    connectionOracle.Open();
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
                XMessageIts.MensagemExcecao(erro);
                return false;
            }

            return true;

        }

        /// <summary>
        /// Conexao com o banco de dados
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            return this.connection;
        }

        public OracleConnection GetConnectionOracle()
        {
            return this.connectionOracle;
        }

        /// <summary>
        /// Fecha first connectionString com o banco de dados
        /// </summary>
        public bool CloseConnection()
        {
            if (IsOpen())
            {
                if (typeConnection == TypeConnection.SqlServer)
                {

                    connection.Close();
                    return true;
                }
                else if (typeConnection == TypeConnection.Oracle)
                {
                    connectionOracle.Close();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// O status da conexão com o banco de dados.
        /// </summary>
        /// <returns></returns> true se conectado existe caso contrário false
        public bool IsOpen()
        {
            if (typeConnection == TypeConnection.SqlServer)
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    return true;
                }
            }
            else if (typeConnection == TypeConnection.Oracle)
            {
                if (connectionOracle != null && connectionOracle.State == ConnectionState.Open)
                {
                    return true;
                }
            }

            return false;
        }

        private void PrepareCommand(CommandType commandType, String scriptSql)
        {
            if (typeConnection == TypeConnection.SqlServer)
            {
                //criando o comando
                sqlCommand = connection.CreateCommand();
                //tipo de manipulação first ser executada
                sqlCommand.CommandType = commandType;
                //execute o comando
                sqlCommand.CommandText = scriptSql;
                //Tempo de execução em sec
                sqlCommand.CommandTimeout = 1800;
            }
            else if (typeConnection == TypeConnection.Oracle)
            {
                oracleCommand = connectionOracle.CreateCommand();
                oracleCommand.CommandType = commandType;
                oracleCommand.CommandText = scriptSql;
                oracleCommand.CommandTimeout = 1800;
            }

        }


        /// <summary>
        /// Executando comando de textos tipo DML: Data Maniputlation language
        /// </summary>        
        /// <param colName="scriptSql"></param>
        /// <returns></returns> A função retorna o novo CPF da coluna de Identidade se uma nova linha foi inserida, 0 em caso de falha.
        public object ExecuteQueryScalar(String scriptSql)
        {
            try
            {

                //se a conexao foi aberta
                if (OpenConnection())
                {
                    if (typeConnection == TypeConnection.SqlServer)
                    {
                        //criando o comando
                        PrepareCommand(CommandType.Text, scriptSql);
                        //executa o comando no banco de dados
                        return sqlCommand.ExecuteScalar();
                    }
                    else if (typeConnection == TypeConnection.Oracle)
                    {
                        PrepareCommand(CommandType.Text, scriptSql);
                        return oracleCommand.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageIts.MensagemExcecao(ex, "Falha na conexão com o banco de dados");
            }
            finally
            {
                CloseConnection();
            }
            //falhou
            return 0;
        }

        /// <summary>
        /// Executando comando de textos tipo DML: Data Maniputlation language
        /// Indexa um DataTable first partir do resultado da consulta
        /// </summary>        
        /// <param colName="scriptSql"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(String scriptSql)
        {
            DataTable dataTable = new DataTable();

            try
            {
                if (OpenConnection())
                {
                    if (typeConnection == TypeConnection.SqlServer)
                    {
                        //criando o comando
                        PrepareCommand(CommandType.Text, scriptSql);
                        //adaptador para tabela
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        //indexa o dataTable
                        adapter.Fill(dataTable);
                    }
                    else if (typeConnection == TypeConnection.Oracle)
                    {
                        PrepareCommand(CommandType.Text, scriptSql);
                        OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                        oracleDataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageIts.MensagemExcecao(ex, "Falha na conexão com o banco de dados");
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        /// <summary>
        /// Executa procedimentos 
        /// </summary>
        /// <param colName="scriptSql"></param>
        /// <returns></returns>
        public bool ExecuteProcedureScalar(String scriptSql)
        {
            object flag = false;
            try
            {
                //se a conexao foi aberta

                if (OpenConnection())
                {
                    if (typeConnection == TypeConnection.SqlServer)
                    {
                        //criando o comando
                        PrepareCommand(CommandType.StoredProcedure, scriptSql);

                        //executa o comando no banco de dados
                        flag = sqlCommand.ExecuteScalar();
                    }
                    else if (typeConnection == TypeConnection.Oracle)
                    {
                        PrepareCommand(CommandType.StoredProcedure, scriptSql);
                        flag = oracleCommand.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageIts.MensagemExcecao(ex, "Falha na conexão com o banco de dados");
            }
            finally
            {
                CloseConnection();
            }
            return flag != null;
        }

        /// <summary>
        /// Executa procedimentos, dependendo do tipo de conexão usada, passe um parametro como null
        /// </summary>
        /// <param colName="scriptSql"></param>
        /// <returns></returns>
        public DataTable ExecuteProcedure(String scriptSql, SqlParameter[] parametros, OracleParameter[] parametrosOracle)
        {
            SqlParameterCollection sqlParameterCollection =
                new SqlCommand().Parameters;

            OracleParameterCollection oracleParameterCollection =
                new OracleCommand().Parameters;

            if (typeConnection == TypeConnection.SqlServer)
            {
                if (parametros != null)
                {
                    foreach (SqlParameter p in parametros)
                    {
                        sqlParameterCollection.Add(p);
                    }
                }
                return ExecuteManipulation(CommandType.StoredProcedure, scriptSql, sqlParameterCollection, null);
            }
            else if (typeConnection == TypeConnection.Oracle)
            {
                if (typeConnection == TypeConnection.Oracle)
                {
                    if (parametrosOracle != null)
                    {
                        foreach (OracleParameter p in parametrosOracle)
                        {
                            oracleParameterCollection.Add(p);
                        }
                    }
                }
                return ExecuteManipulation(CommandType.StoredProcedure, scriptSql, null, oracleParameterCollection);
            }
            else return null;
        }


        public DataTable ExecuteProcedure(String scriptSql)
        {
            return ExecuteManipulation(CommandType.StoredProcedure, scriptSql, null, null);

        }

        /// <summary>
        /// Executa o comando ou procedimento no banco de dados. 
        /// </summary>
        /// <param colName="scriptSql"></param>
        /// <returns></returns>Retorna um datatable com as colunas e dados do banco
        public DataTable ExecuteManipulation(CommandType commandType, string scriptSql, SqlParameterCollection sqlParameterCollection, OracleParameterCollection oracleParameterCollection)
        {
            DataTable dataTable = new DataTable();

            try
            {
                if (OpenConnection())
                {
                    if (typeConnection == TypeConnection.SqlServer)
                    {
                        PrepareCommand(commandType, scriptSql);
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
                        adapter.Fill(dataTable);
                    }
                    else if (typeConnection == TypeConnection.Oracle)
                    {
                        PrepareCommand(commandType, scriptSql);
                        if (oracleParameterCollection != null)
                        {
                            foreach (OracleParameter p in oracleParameterCollection)
                            {
                                this.oracleCommand.Parameters.Add(new OracleParameter(p.ParameterName, p.Value));
                            }
                            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                            oracleDataAdapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageIts.MensagemExcecao(ex, "Falha na conexão com o banco de dados");
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (IsOpen())
            {
                this.CloseConnection();
            }
            GC.SuppressFinalize(this);
        }*/

    }
}