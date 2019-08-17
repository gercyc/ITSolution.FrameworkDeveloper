using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Framework.Beans.Forms;

namespace ITSolution.Admin.Forms.ContextUtil
{
    public partial class XFrmContextUtil : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly StringBuilder _strContext;
        private readonly List<FileClass> _fileClassList;
        private bool _empty;

        public XFrmContextUtil()
        {
            InitializeComponent();
            this._empty = true;
            this._fileClassList = new List<FileClass>();
            this._strContext = new StringBuilder();
            //this.scintilla1.ConfigureHighlightingXML();

        }

        #region Metodos

        public void Run()
        {
            this.ShowDialog();
        }

        /// <summary>
        /// Indexa o grid com as classes
        /// </summary>
        /// <param name="files"></param>
        /// true para adicionar e false limpar
        private void addFilecs(List<string> files)
        {
            var flag = barToggleSwitchReplace.Checked;

            //se o flag for true limpa a lista
            if (flag)
                this._fileClassList.Clear();

            int i = 1;
            //ocorrencias de classes .cs
            files.ForEach(delegate (string fileCs)
            {
                if (fileCs.EndsWith(".cs"))
                {
                    FileClass fc = new FileClass(i++, fileCs, Path.GetFileNameWithoutExtension(fileCs));
                    _fileClassList.Add(fc);
                }

            });


            if (_fileClassList.Count == 0)
                this._empty = true;
            else
                this._empty = false;


            this.gridControl1.DataSource = _fileClassList;
            this.gridControl1.Refresh();
            this.gridControl1.RefreshDataSource();
        }

        private void generatePropDao(StringBuilder sb, FileClass item)
        {
            //public Dao<T> TDao { get { return new Dao<T>(this); }  }		
            sb.Append("        public Dao");
            sb.Append("<");
            sb.Append(item.ToString());
            sb.Append(">");
            sb.Append(item.ToString());
            sb.Append("Dao");
            sb.Append(" { get { return new Dao<");
            sb.Append(item.ToString());
            sb.Append(">");
            sb.AppendLine("(this); }  }");
        }

        private void generatePropPrivateDao(StringBuilder sb, FileClass item)
        {
            sb.Append("        private Dao");
            sb.Append("<");
            sb.Append(item.ToString());
            sb.Append(">");
            sb.Append(" ");
            //poe a primeira em minuscula
            string classe = item.ToString().FirstCharToLower();
            sb.Append(classe);
            sb.AppendLine("Dao;");
        }

        private void generateInitDao(StringBuilder sb, FileClass item)
        {
            //this.tDao = new Dao<T>(this);
            //poe a primeira em minuscula
            string classe = item.ToString().FirstCharToLower();

            sb.Append("			this.");
            sb.Append(classe);
            sb.Append("Dao");
            sb.Append(" = ");
            sb.Append("new Dao<");
            sb.Append(item.ToString());
            sb.Append(">");
            sb.AppendLine("(this);");

        }

        private void generateMetodoDao(StringBuilder sb, FileClass item)
        {

            //public Dao<T> TDao { get { return tDao; }  }
            string classe = item.ToString();
            sb.Append("        public Dao");
            sb.Append("<");
            sb.Append(classe);
            sb.Append(">");
            sb.Append(" ");
            sb.Append(classe);
            sb.Append("Dao");
            sb.Append("{ get {");
            sb.Append("return ");
            //poe novamente a primeira em minuscula
            classe = classe.FirstCharToLower();
            sb.Append(classe);
            sb.Append("Dao");
            sb.AppendLine(";}  }");
        }

        private void generateDbSet(StringBuilder sb, FileClass item)
        {
            //public virtual DbSet<T> TEntity { get; set; }     
            //poe novamente a primeira em maiuscula
            string classe = item.ToString();
            sb.Append("        public virtual DbSet");
            sb.Append("<");
            sb.Append(classe);
            sb.Append(">");
            sb.Append(" ");

            if (classe.EndsWith("ao"))
            {
                string plural = classe.RemoverLastCharCount(2);
                sb.Append(plural);
                sb.Append("oes");//pluraliza
            }
            else if (classe.EndsWith("l"))
            {
                string plural = classe.RemoverLastCharCount(2);
                sb.Append(plural);
                sb.Append("ais");//pluraliza
            }
            else if (classe.EndsWith("r"))
            {
                string plural = classe + "es";
                sb.Append(plural);//pluraliza   
            }
            else if (classe.EndsWith("s"))
            {
                string plural = classe.PluralizeStringOnUpperCase();
                sb.Append(plural);//pluraliza
            }
            else
            {
                sb.Append(classe);
                sb.Append("s");//pluraliza
            }
            sb.AppendLine("{ get; set; } ");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>true Permissao para criptografar
        public void SelectAppConfigFile(bool flag)
        {
            //string local = Application.StartupPath;
            //string appConfigName = "ITE.Forms.exe.config";
            //..\ITSolution\ITSolution.Admin\bin\Debug
            //..\ITE\ITE.Forms\bin\Debug\
            //local = local.Replace(@"\ITSolution\ITSolution.Admin", @"\ITE\ITE.Forms");
            //local = local.Replace(@"ITE.Teste", @"ITE.Forms");

            //string appConfig = Path.Combine(local, appConfigName);

            if (openFileAppConfig.ShowDialog() == DialogResult.OK)
            {
                string appFile = openFileAppConfig.FileName;

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

                }
            }
        }

        private async Task updateStatusConvertendo()
        {
            //show flag por 3 segs
            this.barStaticNone.Visibility = BarItemVisibility.Never;
            this.barStaticConvertendo.Visibility = BarItemVisibility.Always;

            var done = await Task.Run(() => timer());

            if (done)
            {
                //hide flag 
                this.barStaticConvertendo.Visibility = BarItemVisibility.Never;
            }
            done = await Task.Run(() => timer());

            if (done)
            {
                //hide flag
                this.barStaticOk.Visibility = BarItemVisibility.Never;

                //switch flag
                this.barStaticNone.Visibility = BarItemVisibility.Always;

            }

        }

        private bool timer()
        {
            int i = 0;

            while (i < 30)
            {
                Thread.Sleep(100);
                //tempo limitado a 5 secs
                i++;
            }
            return true;
        }

        private void generateContext(List<string> template, StringBuilder propPrivateDao,
                                                            StringBuilder initDao, StringBuilder metodoDao, StringBuilder dbSet)
        {

            foreach (var item in template)
            {

                if (item.Trim().Equals("private Dao<T> tDao;"))
                {
                    _strContext.AppendLine(propPrivateDao.ToString());
                }

                else if (item.Trim().Equals("this.tDao = new Dao<T>(this);"))
                {
                    _strContext.AppendLine(initDao.ToString());
                }

                else if (item.Trim().Equals("public Dao<T> TDao { get { return tDao; }  }"))
                {
                    _strContext.AppendLine(metodoDao.ToString());
                }
                else if (item.Trim().Equals("public virtual DbSet<T> TEntity { get; set; }"))
                {
                    _strContext.AppendLine(dbSet.ToString());
                }
                else
                {
                    _strContext.AppendLine(item);
                }

            }
        }
        private void generateContextOptimizado(List<string> template, StringBuilder propDao, StringBuilder dbSet)
        {

            foreach (var item in template)
            {
                if (item.Trim().Equals("public Dao<T> TDao { get { return new Dao<T>(this); } }"))
                {
                    _strContext.AppendLine(propDao.ToString());
                }

                else if (item.Trim().Equals("public virtual DbSet<T> TEntity { get; set; }"))
                {
                    _strContext.AppendLine(dbSet.ToString());
                }
                else
                {
                    _strContext.AppendLine(item);
                }

            }
        }

        #endregion

        #region Eventos

        private void barBtnSelecionarFileCs_ItemClick(object sender, ItemClickEventArgs e)
        {
            var op = openFileCs.ShowDialog();

            if (op == DialogResult.OK)
            {

                var files = openFileCs.FileNames.ToList();

                addFilecs(files);
                this.gridViewClasses.SelectAllRow();
            }
        }

        private void barBtnSelectDir_ItemClick(object sender, ItemClickEventArgs e)
        {
            var op = fBrowserFileCs.ShowDialog();

            if (op == DialogResult.OK)
            {
                this._fileClassList.Clear();

                var files = FileManagerIts.ToFiles(fBrowserFileCs.SelectedPath, new string[] { ".cs" });
                addFilecs(files);
                this.gridViewClasses.SelectAllRow();
            }
        }

        private void barBtnGerarContexto_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._empty || this._fileClassList.Count == 0)
            {
                XMessageIts.Mensagem("Nenhuma arquivo .cs adicionado.");
            }
            else
            {
                Task.Run(updateStatusConvertendo);

                var mode = barToggleSwitchModo.Checked;

                byte[] bytesContext = null;
                //string templatePath = Application.StartupPath + "\\template_context";

                if (mode)
                    //templatePath = Application.StartupPath + "\\template_context2";
                    bytesContext = Properties.Resources.context2_template;
                else
                    bytesContext = Properties.Resources.context_template;

                var template = FileManagerIts.GetDataFromBytes(bytesContext);

                this._strContext.Clear();

                var propDao = new StringBuilder();
                var propPrivateDao = new StringBuilder();
                var initDao = new StringBuilder();
                var metodoDao = new StringBuilder(); ;
                var dbSet = new StringBuilder();

                //pegue os arquivos selecionados
                var lista = gridViewClasses.GetSelectedItens<FileClass>();

                if (lista.Count == 0)
                    lista = _fileClassList;

                foreach (var item in lista)
                {
                    generatePropDao(propDao, item);

                    generatePropPrivateDao(propPrivateDao, item);

                    generateInitDao(initDao, item);

                    generateMetodoDao(metodoDao, item);

                    generateDbSet(dbSet, item);
                }

                if (mode)
                    generateContextOptimizado(template, propDao, dbSet);
                else
                    generateContext(template, propPrivateDao, initDao, metodoDao, dbSet);

                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string ctxPath = Path.Combine(desktop, "Contexto.cs");

                FileManagerIts.OverWriteOnFile(ctxPath, new string[] { _strContext.ToString() });

                if (File.Exists(ctxPath))
                {

                    this.barStaticOk.Visibility = BarItemVisibility.Always;
                    //XMessageIts.Mensagem("Contexto gerado em: \n\n" + ctxPath, "Contexto gerado com sucesso");
                    //barBtnShowResult_ItemClick(null, null);

                    var op = XMessageIts.Confirmacao("Contexto gerado em: \n\n"
                                + ctxPath
                                + "\n\nVisualizar contexto ?\n", "Contexto gerado com sucesso");
                    if (op == DialogResult.Yes)
                    {
                        //FileManagerIts.View(ctxPath);
                        barBtnShowResult_ItemClick(null, null);

                    }
                }

            }
        }

        private void barBtnShowResult_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = _strContext.ToString();

            if (!String.IsNullOrEmpty(result))
            {
                new XFrmHighlighting(result, ScintillaNET.Lexer.Cpp).ShowDialog();
            }
            else
            {
                XMessageIts.Mensagem("Nada a ser visualizado.");
            }
        }

        private void barBtnCreateAppConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            new XFrmAppConfig().ShowDialog();
        }

        private void barBtnConfigAppXml_ItemClick(object sender, ItemClickEventArgs e)
        {
            new XFrmAppConfig(AppConfigManager.Configuration.ConnectionConfigPath).ShowDialog();
        }

        private void gridViewClasses_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (this._fileClassList.Count == 0)
                this._empty = true;
            else
                this._empty = false;
        }

        private void barBtnSetConnString_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barBtnCriptografarString_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barBtnDescriptografarString_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        #endregion

        #region  Classe controle interno
        private class FileClass
        {
            public int ID { get; set; }
            public string Path { get; set; }
            public string ClassName { get; set; }

            public FileClass(int id, string path, string className)
            {
                this.ID = id;
                this.Path = path;
                this.ClassName = className;
            }

            public override string ToString()
            {
                return ClassName;
            }
        }

        #endregion

      
    }

}
