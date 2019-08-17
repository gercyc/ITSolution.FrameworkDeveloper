using ITSolution.Framework.Entities;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.Windows.Forms;
using ITSolution.Framework.Arquivos;
using System.Text;

namespace ITSolution.Framework.Dao.Contexto
{
    /// <summary>
    /// Controle sobre o App.config 
    /// A string a ser utilizada é sempre a primeira string declarada no arquivo de configuração.
    /// 
    /// Sofreu alteração redefinir os metodos 
    /// </summary>
    public class AppConfigDefaultManager
        : IConfigurationService
    {

        /*private static readonly string appcfg = Application.ExecutablePath + ".config";
        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(appcfg);*/
        //Alterando a string de conexão em tempo de execução
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        #region Singleton

        private static AppConfigDefaultManager instance;

        public static AppConfigDefaultManager Configuration
        {
            get
            {
                if (instance == null)
                    instance = new AppConfigDefaultManager();
                return instance;
            }
        }

        private AppConfigDefaultManager()
        {
            this.Names = NamesConnectionStrings.ToArray();
            this.ConnectionString = GetConnectionString(FirstNameConnectionString);
        }
        #endregion

        public string[] Names { get; }

        public string FirstNameConnectionString { get { return Names[0]; } }

        /// <summary>
        /// Retorna a primeira string do App.config.
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Retorna a primeira string do App.config do modo debug
        /// </summary>
        public string ConnectionStringRuntime { get { return config.ConnectionStrings.ConnectionStrings[Names[0]].ConnectionString; } }

        /// <summary>
        /// Todo os nomes das conexões declarada do App config exceto as conexões locais:
        ///     LocalSqlServer
        ///     LocalMySqlServer
        /// </summary>
        /// <returns>Lista das conexões do App.config</returns>
        private List<string> NamesConnectionStrings
        {
            get
            {
                Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var lista = cfg.ConnectionStrings.ConnectionStrings;
                var connections = new List<string>();
                for (int i = 0; i < lista.Count; i++)
                {
                    ConnectionStringSettings c = lista[i];

                    if (!c.Name.ToLower().StartsWith("local"))
                    {
                        connections.Add(c.Name);
                    }
                }

                return connections;
            }
        }

        /// <summary>
        /// O path do arquivo de configuração de conexão
        /// </summary>
        public string ConnectionConfigPath
        {
            get
            {
                return Application.ExecutablePath + ".config";
            }
        }

        #region Métodos para App.config
        private bool IsAppFile(string appFile)
        {
            if (!appFile.ToLower().EndsWith(".config"))
            {
                XMessageIts.Advertencia("Selecione o arquivo de configuração do seu projeto App.config.");
            }
            else if (FileManagerIts.IsEmpty(appFile))
            {
                XMessageIts.Erro("Arquivo de configuração está vazio.");
            }
            else
            {
                return true;
            }
            return false;
        }

        public void Alter(string appFile)
        {
            if (IsAppFile(appFile))
            {
                //avisa o arquivo para alterar durante a execução
                //AppConfigDefaultManager.Configuration.ChangeConnectionStringRuntimeByConnectionString(connString);

            }
        }

        /// <summary>
        /// A string de conexão completa
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConnectionString(string key)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            catch (Exception)
            {
                try
                {
                    //primeira string conexao do arquivo
                    return ConfigurationManager.ConnectionStrings[Names[0]].ConnectionString;
                }
                catch
                {
                    throw new Exception("Falha ao obter a string de conexão");
                }
            }

        }

        /// <summary>
        /// Todas as conexões declaradas no App.config
        /// </summary>
        /// <returns></returns>
        public static List<string> ConnectionStringToList()
        {
            var lista = new List<string>();
            foreach (ConnectionStringSettings c in ConfigurationManager.ConnectionStrings)
            {
                if (!c.Name.ToLower().StartsWith("local"))
                {
                    lista.Add(c.ConnectionString);
                }
            }

            return lista;
        }

        /// <summary>
        /// Altera a primeira tag de conexão em tempo de execução.
        /// </summary>
        /// <param name="connectionString">String a ser utilizada</param>
        public void ChangeConnectionStringRuntime(string name, string connectionString)
        {
            //setando a string a ser utilizada em tempo de execução
            var cfg = config.ConnectionStrings.ConnectionStrings[name];

            cfg.ConnectionString = connectionString;

            // Salva o que foi modificado
            config.Save(ConfigurationSaveMode.Modified);

            // Atualiza no app o bloco connectionStrings
            ConfigurationManager.RefreshSection("connectionStrings");

            // Recarrega os dados de conexão
            Properties.Settings.Default.Reload();
        }

        /// <summary>
        /// Altera a string de conexão utilizando o nome.
        /// </summary>
        public void ChangeConnectionString(string name,string connectionString)
        {
            //setando a string a ser utilizada em tempo de execução
            config.ConnectionStrings.ConnectionStrings[name].ConnectionString = connectionString;

            // Salva as alterações
            config.Save(ConfigurationSaveMode.Modified);

            // Atualiza no app o bloco connectionStrings
            ConfigurationManager.RefreshSection("connectionStrings");

            // Recarrega os dados de conexão
            Properties.Settings.Default.Reload();
        }

        public void ChangeConnectionStringByName(string name)
        {
            //recupera a string de conexao pelo nome
            string connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;

            //setando a string a ser utilizada em tempo de execução
            config.ConnectionStrings.ConnectionStrings[0].ConnectionString = connectionString;

            // Salva as alterações
            config.Save(ConfigurationSaveMode.Modified);

            // Atualiza no app o bloco connectionStrings
            ConfigurationManager.RefreshSection("connectionStrings");

            // Recarrega os dados de conexão
            Properties.Settings.Default.Reload();
        }

        public static void AddConnectionStringRuntimenString(AppConfigIts app)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(app.User))
                    app.User = "";
                if (string.IsNullOrWhiteSpace(app.Password))
                    app.Password = "";

                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder
                {
                    DataSource = app.ServerName,
                    InitialCatalog = app.Database,
                    UserID = app.User,
                    Password = app.Password,
                    IntegratedSecurity = string.IsNullOrEmpty(app.User.Trim())
                };

                // Criar Conexão
                config.ConnectionStrings.ConnectionStrings.Add(
                    new ConnectionStringSettings
                    {
                        Name = app.ConnectionName,
                        ConnectionString = scsb.ConnectionString,
                        ProviderName = "System.Data.SqlClient"
                    });

                // SaveLayout Conexão
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Entrada já adicionada !");
            }
        }

        #endregion

    }
}
