using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Windows.Forms;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Entities;

namespace ITSolution.Framework.Dao.Contexto
{
    /// <summary>
    /// Controle sobre o App.xml
    /// A string a ser utilizada é sempre a primeira string declarada no arquivo de configuração.
    /// </summary>
    public class AppConfigManager
        : IConfigurationService, ICollection<AppConfigIts>
    {
        #region Singleton

        private static AppConfigManager _instance;

        public static AppConfigManager Configuration
        {
            get
            {
                if (_instance == null)
                    _instance = new AppConfigManager();
                return _instance;
            }
        }

        /// <summary>
        /// Construtor singleton
        /// </summary>
        /// 
        private AppConfigManager()
        {
            this.AppConfigList = new List<AppConfigIts>();

            //inicializa a conexão default
            //a string de conexão
            //e todos os outros atributos da classe
            initialize(this.ConnectionConfigPath);
        }

        #endregion

        #region Propperties 

        public int ServerPort { get; set; }

        /// <summary>
        /// String de conexão lida da memória principal
        /// </summary>
        private volatile AppConfigIts _appConfig;


        /// <summary>
        /// A conexão com a tag defaultConnection do arquivo de configuração
        /// </summary>
        public AppConfigIts AppConfig
        {
            get
            {
                return _appConfig;
            }
            set
            {
                _appConfig = value;
            }
        }

        /// <summary>
        /// Conexões disponíveis carregads do .xml
        /// </summary>
        public List<AppConfigIts> AppConfigList { get; private set; }

        /// <summary>
        /// Retorna a string de conexão completa do App.xml
        /// </summary>
        public string ConnectionString { get { return _appConfig.ConnectionString; } }

        /// <summary>
        /// O path do arquivo de configuração de conexão
        ///     Observação: O arquivo App.xml está localizado em ITSolution.Framework
        /// </summary>
        public string ConnectionConfigPath
        {
            get
            {
                //Path.Combine("Config", ITSolution.Framework.Properties.Settings.Default.DefaultConnectionFile);
                string xmlPath = Path.Combine(Application.StartupPath, "Config", ITSolution.Framework.Properties.Settings.Default.DefaultConnectionFile);
                return xmlPath;
            }
        }

        #endregion 

        #region Controle XML

        /// <summary>
        /// Initialize all class
        /// </summary>
        /// <param name="xmlFile"></param>
        private void initialize(string xmlFile)
        {
            XElement xml = XElement.Load(xmlFile);

            var elements = xml.Elements();
            string serverType = "MSSQL";
            string defaultConnection = null;

            this.AppConfigList.Clear();

            foreach (XElement x in elements)
            {
                try
                {
                    //tag 1
                    if (x.Name.LocalName.Equals("serverType"))
                    {
                        serverType = x.Attribute("typeName").Value;
                    }
                    //tag 2
                    else if (x.Name.LocalName.Equals("defaultConnection"))
                    {
                        defaultConnection = x.Attribute("name").Value;
                    }
                    //tag 2
                    else if (x.Name.LocalName.Equals("connectionStrings"))
                    {

                        //percorre os itens do xml
                        foreach (XNode e in x.Nodes())
                        {
                            if (e.GetType() == typeof(XElement))
                            {
                                var i = e as XElement;
                                AppConfigIts app = new AppConfigIts();
                                app.Default = defaultConnection;
                                app.ServerType = serverType;
                                app.ConnectionName = i.Attribute("name").Value;
                                app.ServerName = i.Attribute("serverName").Value;
                                app.Database = i.Attribute("database").Value;

                                try
                                {
                                    app.User = i.Attribute("user").Value;
                                    app.Password = i.Attribute("password").Value;
                                    //o appconfig decide o integrated security
                                    //app.IntegratedSecurity = i.Attribute("security").Value;

                                    //tentar descriptografar o appconfig
                                    DecodedAppConfig.Instance.AppConfig(app);
                                }
                                catch (NullReferenceException)
                                {
                                    Console.WriteLine("Windows Authentication ...");
                                }

                                //cria a string de conexão
                                app.RebuildConnectionString();

                                //add a conexão
                                this.AppConfigList.Add(app);
                            }

                        }
                    }
                    //porta do servidor de aplicacao
                    else if (x.Name.LocalName.Equals("serverPort"))
                    {
                        int port = 9000;
                        int.TryParse(x.Attribute("name").Value, out port);
                        ServerPort = port;
                    }
                }
                catch (Exception ex)
                {
                    XMessageIts.ExceptionMessageDetails(ex, "Tag inválida no arquivo de configuração: \"" + x.Name + "\"",
                        "Falha no App.xml");
                }

            }
            //ative a string de conexão default
            if (this.IsReadOnly)
            {
                _appConfig = this.AppConfigList.First(a => a.Default == a.ConnectionName);
                //acessa a string de conexão criada 
                //this.ConnectionString = this._appConfig.ConnectionString;
            }
        }

        public AppConfigIts GetConnection(AppConfigIts app)
        {

            if (Contains(app))
                return this.AppConfigList.First(a => a.ConnectionName == app.ConnectionName);
            else
                return app;

        }

        /// <summary>
        /// Carrega todas as conexões do arquivo App.xml
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <returns></returns>
        public void Load(string xmlFile)
        {
            this.Clear();

            initialize(xmlFile);
        }

        /// <summary>
        /// Altera a conexão do arquivo de configuração.
        /// </summary>
        /// <param name="app"></param>
        public bool Alter(AppConfigIts app)
        {
            try
            {
                //carrega o xml
                XElement xml = XElement.Load(this.ConnectionConfigPath);

                XElement nodeDefault = xml.Elements().Where(e => e.Name.LocalName == "defaultConnection").First();

                //essa sera a conexão default e eh sempre o primeiro atributo
                nodeDefault.FirstAttribute.SetValue(app.ConnectionName);

                //tag com as conexões
                XElement node = xml.Elements().Where(e => e.Name.LocalName == "connectionStrings").First();
                var connections = node.Elements().Where(x => x.Name.LocalName == "connection");

                foreach (var i in connections)
                {
                    //altere essa conexão
                    if (i.Attribute("name").Value.Equals(app.ConnectionName))
                    {
                        //garante todas as tag desse atributo
                        initializeTagConnection(i);

                        i.Attribute("name").SetValue(app.ConnectionName);
                        i.Attribute("serverName").SetValue(app.ServerName);
                        i.Attribute("database").SetValue(app.Database);

                        if (app.User.IsNullOrEmpty())
                        {
                            //pode ter ou nao usuario
                            i.Attribute("user").Remove();
                            i.Attribute("password").Remove();
                            //sempre vai existir
                            i.Attribute("security").SetValue("True");
                        }
                        else
                        {
                            i.Attribute("user").SetValue(app.User);
                            i.Attribute("password").SetValue(app.Password);
                            i.Attribute("security").SetValue("False");
                        }

                        //tentar descriptografar o appconfig
                        DecodedAppConfig.Instance.AppConfig(app);

                        //garante a string de conexão
                        app.RebuildConnectionString();

                        //atualiza o app config
                        this.AppConfig = app;

                        //salva as alterações
                        xml.Save(ConnectionConfigPath);
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Tag inválida durante alteração no arquivo de configuração", "Falha ao alterar conexão no App.xml");
                return false;
            }
        }

        /// <summary>
        /// Recarregada todas as conexões no xml
        /// </summary>
        public void Reload()
        {
            Load(this.ConnectionConfigPath);
        }

        private void initializeTagConnection(XElement econnection)
        {
            //recupera as tags
            var name = econnection.Attribute("name");
            var server = econnection.Attribute("serverName");
            var database = econnection.Attribute("database");
            var attuser = econnection.Attribute("user");
            var attpw = econnection.Attribute("password");

            //se nao tem a tag
            if (name == null)
            {
                //add
                name = new XAttribute("name", "");
                econnection.Add(name);
            }
            //se nao tem a tag
            if (server == null)
            {
                //add
                server = new XAttribute("server", "");
                econnection.Add(server);
            }
            //se nao tem a tag
            if (database == null)
            {
                //add
                database = new XAttribute("database", "");
                econnection.Add(database);
            }
            //se nao tem a tag
            if (attuser == null)
            {
                //add
                attuser = new XAttribute("user", "");
                econnection.Add(attuser);
            }

            //se nao tem a tag
            if (attpw == null)
            {
                //add
                attpw = new XAttribute("password", "");
                econnection.Add(attpw);
            }

        }

        #endregion

        #region Interface Default

        /// <summary>
        /// Retorna a string de conexão pelo nome.
        /// </summary>
        /// <exception cref="">Exception</exception>
        /// <param name="key"></param>
        /// <returns>String de conexão</returns>
        public string GetConnectionString(string key)
        {
            try
            {
                var app = this.AppConfigList.Where(a => a.ConnectionName == key).First();
            }
            catch (Exception)
            {
                // Exceptions:
                //   T:System.ArgumentNullException:
                //     source is null.
                //
                //   T:System.InvalidOperationException:
                //     The source sequence is empty.

                throw new Exception("Não foi localizada nenhuma conexão com o nome \"" + key + "\"");
            }


            return AppConfig.ConnectionString;
        }

        #endregion

        #region Interface ICollection 

        /// <summary>
        /// Adiciona uma conexão no arquivo App.xml
        /// </summary>
        /// <param name="app"></param>
        public void Add(AppConfigIts app)
        {
            try
            {
                //carrega o xml
                XElement xml = XElement.Load(this.ConnectionConfigPath);

                //faço depois var s = xml.Elements().Where(e => e.Name.LocalName == "serverType").First();
                XElement node = xml.Elements().Where(e => e.Name.LocalName == "connectionStrings").First();


                //XElement t2 = new XElement("connectionStrings");
                XElement conn = new XElement("connection");

                conn.Add(new XAttribute("name", app.ConnectionName));
                conn.Add(new XAttribute("serverName", app.ServerName));
                conn.Add(new XAttribute("database", app.Database));

                if (!app.User.IsNullOrEmpty())
                {
                    conn.Add(new XAttribute("user", app.User));
                    conn.Add(new XAttribute("password", app.Password));
                    conn.Add(new XAttribute("security", "False"));
                }
                else
                {
                    conn.Add(new XAttribute("security", "True"));
                }

                node.Add(conn);

                //salva o xml
                xml.Save(ConnectionConfigPath);

                XMessageIts.Mensagem("Conexão \"" + app.ConnectionName + "\" adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Tag connectionString ausente no arquivo de configuração", "Falha ao criar conexão no App.xml");

            }

        }

        /// <summary>
        /// Remove uma conexão
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(AppConfigIts item)
        {
            try
            {

                //carrega o xml
                XElement xml = XElement.Load(this.ConnectionConfigPath);

                //tag com as conexões
                XElement node = xml.Elements().Where(e => e.Name.LocalName == "connectionStrings").First();
                XElement x = xml.Elements().Where(p => p.Attribute("name").Value.Equals(item.ConnectionName)).First();
                if (x != null)
                {
                    x.Remove();
                    return this.AppConfigList.Remove(item);
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Tag connectionString ausente no arquivo de configuração", "Falha ao remover conexão no App.xml");
            }
            return false;
        }

        /// <summary>
        /// Remove todas as conexões
        /// </summary>
        public void Clear()
        {
            this.AppConfigList.Clear();
        }

        /// <summary>
        /// Se contém conexão
        /// A conexão é validada pelo nome
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(AppConfigIts item)
        {
            try
            {
                this.AppConfigList.Where(i => i.ConnectionName == item.ConnectionName)
                    .First();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Número de conexõs
        /// </summary>
        public int Count
        {
            get
            {
                return this.AppConfigList.Count;
            }
        }

        /// <summary>
        /// Retorna true se possui conexões disponíveis caso contrário false
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                //true se maior que 0
                //false se menor ou igual 0
                return (this.Count > 0);
            }
        }

        public void CopyTo(AppConfigIts[] array, int arrayIndex)
        {
            throw new NotImplementedException("Método não implementado");
        }

        /// <summary>
        /// Todas as conexões declarada no App.xml
        /// </summary>
        /// <returns>Lista das conexões do App.xml</returns>
        public IEnumerator<AppConfigIts> GetEnumerator()
        {
            return this.AppConfigList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.AppConfigList.GetEnumerator();
        }

        #endregion

        //[Obsolete]
        //public static string BuilderConnectionString(string connectionFile)
        //{
        //    XmlDocument x = new XmlDocument();

        //    x.Load(connectionFile);

        //    var server = x.SelectSingleNode("ConfigDatabase").ChildNodes[1].InnerText;
        //    var database = x.SelectSingleNode("ConfigDatabase").ChildNodes[3].InnerText;
        //    var user = x.SelectSingleNode("ConfigDatabase").ChildNodes[4].InnerText;
        //    string pwd = x.SelectSingleNode("ConfigDatabase").ChildNodes[5].InnerText;
        //    string name = x.SelectSingleNode("ConfigDatabase").ChildNodes[6].InnerText;
        //    pwd = EncryptionUtil.Decoded(pwd);

        //    var mascara = string.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};",
        //        server, database, user, pwd);

        //    return mascara;
        //}
    }
}
