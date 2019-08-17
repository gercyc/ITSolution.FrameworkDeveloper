using DevExpress.XtraPrinting;
using ITSolution.Framework.ConnectionFactory;
using ITSolution.Framework.Mensagem;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.GuiUtil;
using ITSolution.Admin.Forms.ContextUtil;
using System.Threading.Tasks;
using DevExpress.XtraTreeList.Nodes;
using System.Text;
using DevExpress.XtraTreeList;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Dao.Contexto;

namespace ITSolution.Admin.Forms.Util
{
    public partial class XFrmQueryEditor : DevExpress.XtraEditors.XtraForm
    {
        private const string keywords = "@@identity all alter and any as asc authorization avg backup begin between break browse bulk by cascade case check checkpoint close clustered coalesce collate column commit compute constraint contains containstable continue convert count create cross current current_date current_time current_timestamp current_user cursor database databasepassword dateadd datediff datename datepart dbcc deallocate declare default delete deny desc disk distinct distributed double drop dump else  encryption errlvl escape except exec execute exists exit expression fetch file fillfactor for foreign freetext freetexttable from full function goto grant group having holdlock identity identity_insert identitycol if in index inner insert intersect into is join key kill left like lineno load max min national nocheck nonclustered not null nullif of off offsets on open opendatasource openquery openrowset openxml option or  order over percent plan precision primary print proc procedure public raiserror read readtext reconfigure references replication restore restrict return revoke right rollback rowcount rowguidcol rule save schema select session_user set setuser shutdown some statistics sum system_user table textsize then to top tran transaction trigger truncate tsequal union unique update updatetext use user values varying view waitfor when where while with writetext abort abs absolute access action ada add admin after aggregate alias all allocate also alter always analyse analyze and any are array as asc asensitive assertion assignment asymmetric at atomic attribute attributes authorization avg backward before begin bernoulli between bigint binary bit bitvar bit_length blob boolean both breadth by c cache call called cardinality cascade cascaded case cast catalog catalog_name ceil ceiling chain char character characteristics characters character_length character_set_catalog character_set_name character_set_schema char_length check checked checkpoint class class_origin clob close cluster coalesce cobol collate collation collation_catalog collation_name collation_schema collect column column_name command_function command_function_code comment commit committed completion condition condition_number connect connection connection_name constraint constraints constraint_catalog constraint_name constraint_schema constructor contains continue conversion convert copy corr corresponding count covar_pop covar_samp create createdb createuser cross csv cube cume_dist current current_date current_default_transform_group current_path current_role current_time current_timestamp current_transform_group_for_type current_user cursor cursor_name cycle data database date datetime_interval_code datetime_interval_precision day deallocate dec decimal declare default defaults deferrable deferred defined definer degree delete delimiter delimiters dense_rank depth deref derived desc describe descriptor destroy destructor deterministic diagnostics dictionary disconnect dispatch distinct do domain double drop dynamic dynamic_function dynamic_function_code each element else encoding encrypted end end-exec equals escape every except exception exclude excluding exclusive exec execute existing exists exp explain external extract false fetch filter final first float floor following for force foreign fortran forward found free freeze from full function fusion g general generated get global go goto grant granted group grouping handler having hierarchy hold host hour identity ignore ilike immediate immutable implementation implicit in including increment index indicator infix inherits initialize initially inner inout input insensitive insert instance instantiable instead int integer intersect intersection interval into invoker is isnull isolation iterate join k key key_member key_type lancompiler language large last lateral leading left length less level like limit listen ln load local localtime localtimestamp location locator lock lower m map match matched max maxvalue member merge message_length message_octet_length message_text method min minute minvalue mod mode modifies modify module month more move multiset mumps name names national natural nchar nclob nesting new next no nocreatedb nocreateuser none normalize normalized not nothing notify notnull nowait null nullable nullif nulls number numeric object octets octet_length of off offset oids old on only open operation operator option options or order ordering ordinality others out outer output over overlaps overlay overriding owner pad parameter parameters parameter_mode parameter_name parameter_ordinal_position parameter_specific_catalog parameter_specific_name parameter_specific_schema partial partition pascal password path percentile_cont percentile_disc percent_rank placing pli position postfix power preceding precision prefix preorder prepare preserve primary prior privileges procedural procedure public quote range rank read reads real recheck recursive ref references referencing regr_avgx regr_avgy regr_count regr_intercept regr_r2 regr_slope regr_sxx regr_sxy regr_syy reindex relative release rename repeatable replace reset restart restrict result return returned_cardinality returned_length returned_octet_length returned_sqlstate returns revoke right role rollback rollup routine routine_catalog routine_name routine_schema row rows row_count row_number rule savepoint scale schema schema_name scope scope_catalog scope_name scope_schema scroll search second section security select self sensitive sequence serializable server_name session session_user set setof sets share show similar simple size smallint some source space specific specifictype specific_name sql sqlcode sqlerror sqlexception sqlstate sqlwarning sqrt stable start state statement static statistics stddev_pop stddev_samp stdin stdout storage strict structure style subclass_origin sublist submultiset substring sum symmetric sysid system system_user table tablesample tablespace table_name temp template temporary terminate than then ties time timestamp timezone_hour timezone_minute to toast top_level_count trailing transaction transactions_committed transactions_rolled_back transaction_active transform transforms translate translation treat trigger trigger_catalog trigger_name trigger_schema trim true truncate trusted type uescape unbounded uncommitted under unencrypted union unique unknown unlisten unnamed unnest until update upper usage user user_defined_type_catalog user_defined_type_code user_defined_type_name user_defined_type_schema using vacuum valid validator value values varchar variable varying var_pop var_samp verbose view volatile when whenever where width_bucket window with within without work write year zone";
        //"Data Source=(local);Initial Catalog=database;Integrated Security=True;User ID=sa;Password=a123";
        private List<Mensagem> _messages;
        private string _tables;
        private bool _collapsed;
        //seta o banco na caixa de combinação
        private delegate void SetDatabaseDelegate(List<AppConfigIts> app);

        public XFrmQueryEditor()
        {
            InitializeComponent();
            init();
        }

        public XFrmQueryEditor(string file) : this()
        {
            this.scintilla.Text = FileManagerIts.GetDataStringFile(file);
        }

        #region Metodos

        private void init()
        {

            this._messages = new List<Mensagem>();
            this.gridControlErrorMsgs.DataSource = this._messages;
            //index at loading
            //this.repositoryItemConnection.Items.AddRange(AppConfigManager.Configuration.AppConfigList);

            scintilla.Text = "SELECT * FROM TABLE_NAME";
            scintilla.ShowLines(0, scintilla.Lines.Count);

            scintilla.ConfigureHighlightingSql();

        }

        private ConnectionFactoryIts createConnection()
        {
            var app = barEditItemConnection.EditValue != null
                ? barEditItemConnection.EditValue as AppConfigIts
                : new AppConfigIts();

            if (barEditDataBases.EditValue != null)
                app.Database = barEditDataBases.EditValue.ToString();

            return new ConnectionFactoryIts(app.ConnectionString);
        }

        //private void fillTreeList()
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    // seu processo....

        //    treeListConnection.ClearNodes();
        //    treeListConnection.BeginUnboundLoad();
        //    Console.WriteLine("Loading ....");

        //    Task taskFill = Task.Run(()=>TaskFillTreeList());

        //    var r = taskFill;


        //    treeListConnection.ExpandAll();
        //    treeListConnection.EndUnboundLoad();

        //    // Entao você volta ao normal...
        //    this.Cursor = Cursors.Default;

        //}

        private void TaskFillTreeList()
        {

            AppConfigManager.Configuration.Reload();
            var connections = AppConfigManager.Configuration.AppConfigList;


            SetDatabaseDelegate loadApp = new SetDatabaseDelegate(loadConnections);

            //dispara uma ação segura
            //new SetDatabaseDelegate(loadConnections).DynamicInvoke(connections);
            if (this.InvokeRequired)
                this.Invoke(loadApp, new object[] { connections });

            //eu quero somentes os servidores que nao se repetem
            var serverList = from c in connections
                             group c by new { c.ServerName } //or group by new {p.ID, p.Name, p.Whatever}
                into servers
                             select servers.FirstOrDefault();

            treeListConnection.BeginInvoke(new Action(async () =>
           {
               // Create a root node .
               TreeListNode parentForRootNodes = null;

               // Creating more nodes
               foreach (var server in serverList)
               {
                   //connection
                   //connection.database
                   //connection.database.tables
                   //....
                   var node = new NodConnection(server).Node;


                   //coloca o node do nome da conexao
                   TreeListNode rootNode = treeListConnection.AppendNode(node, parentForRootNodes);
                   rootNode.ImageIndex = 0;
                   rootNode.SelectImageIndex = 0;

                   using (var connection = new ConnectionFactoryIts(server.ConnectionString))
                   {
                       //coloque os banco
                       Task<string[]> taskDatabases = Task.Run(() => connection.DataBases);

                       //DoWorking ....

                       var databases = await taskDatabases;
                       server.DatabaseList.AddRange(databases);

                       foreach (var db in databases)
                       {
                           // Create a child of the rootNode
                           var child = treeListConnection.AppendNode(new object[] { db }, rootNode);
                           child.ImageIndex = 1;
                           child.SelectImageIndex = 1;
                           var childChild = treeListConnection.AppendNode(new object[] { "Tables" }, child);
                           //tabelas
                           Task<string[]> taskTables = Task.Run(() => connection.Tables);

                           var tables = await taskTables;

                           childChild.ImageIndex = 2;
                           childChild.SelectImageIndex = 2;

                           //colocas as tabelas 
                           foreach (var tb in tables)
                           {
                               //coloque as tabelas daquele banco
                               var child3 = treeListConnection.AppendNode(new object[] { tb }, childChild);
                               child3.ImageIndex = 3;
                               child3.SelectImageIndex = 3;

                               //treeListConnection.EndUnboundLoad();
                           }
                           treeListConnection.BeginUnboundLoad();
                           treeListConnection.EndUnboundLoad();
                       }
                   }
                   //apos isso faço tudo denovo em cada string de conexão

               }

           }));

        }

        private void loadConnections(List<AppConfigIts> app)
        {
            this.repositoryItemConnection.Items.AddRange(app);

            if (this.repositoryItemConnection.Items.Count > 0)
                barEditItemConnection.EditValue = AppConfigManager.Configuration.AppConfig;

        }

        private void loadDatabases()
        {
            try
            {

                repItemDatabases.Items.Clear();
                var connection = barEditItemConnection.EditValue as AppConfigIts;
                var app = AppConfigManager.Configuration.GetConnection(connection);

                barEditDataBases.EditValue = app.Database;

                repItemDatabases.Items.AddRange(app.DatabaseList);

            }
            catch (Exception ex)
            {
                memoOutput.BeginInvoke(new Action(() =>
                {
                    memoOutput.Text += ex.Message + "\r\n";

                }));

            }
            //try
            //{

            //    //cancela a referencia do banco atual
            //    barEditDataBases.EditValue = null;
            //    using (var con = createConnection())
            //    {

            //        repItemDatabases.Items.Clear();
            //        repItemDatabases.Items.AddRange(con.DataBases);
            //        var connection = barEditItemConnection.EditValue as AppConfigIts;
            //        var app = AppConfigManager.Configuration.GetConnection(connection);

            //        barEditDataBases.EditValue = app.Database;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    memoOutput.BeginInvoke(new Action(() =>
            //    {
            //        memoOutput.Text += ex.Message + "\r\n";

            //    }));

            //}
        }

        #endregion

        #region Eventos

        private void btnExecutar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string scriptText = scintilla.SelectedText.Length > 0
                ? scintilla.SelectedText
                : scintilla.Text;

            try
            {
                using (var con = createConnection())
                {
                    var tables = new StringBuilder();
                    string[] tbs = con.Tables;
                    for (int i = 0; i < tbs.Length; i++)
                    {
                        tables.Append(tbs[i]);
                        if (i < tbs.Length - 1)
                            tables.Append(" ");
                    }
                    this._tables = tables.ToString();
                    this.gridViewResults.Columns.Clear();
                    this.gridControlResults.DataSource = null;
                    var dt = con.ExecuteQueryDataTable(scriptText);

                    if (dt.Rows.Count == 0)
                    {
                        this.gridControlResults.DataSource = dt;
                        this.xtraTabControl1.SelectedTabPageIndex = 0;
                    }
                    else
                    {
                        this.gridControlResults.DataSource = dt;
                        //atualiza o grid resultado
                        this.gridControlResults.RefreshDataSource();
                        //ajuste o tamanhos das colunas ao texto da celula
                        this.gridViewResults.BestFitColumns();
                    }
                    this.memoOutput.Text += "Query executed sucessfully\r\n";

                    //alinhas todas as colunas no inicio da celula
                    foreach (GridColumn c in gridViewResults.Columns)
                    {
                        c.AppearanceCell.Options.UseTextOptions = true;
                        c.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                        c.AppearanceHeader.Options.UseTextOptions = true;
                        c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

                    }

                }
            }
            catch (SqlException ex)
            {
                this.memoOutput.Text += ex.Message + "\r\n";
                this.xtraTabControl1.SelectedTabPageIndex = 1;
                this._messages.Add(new Mensagem(ex.Message));

                //ajuste o tamanhos das colunas ao texto da celula
                this.gridViewErrorMsgs.BestFitColumns();

                //alinhas todas as colunas no inicio da celula
                foreach (GridColumn c in gridViewErrorMsgs.Columns)
                {
                    c.AppearanceCell.Options.UseTextOptions = true;
                    c.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    c.AppearanceHeader.Options.UseTextOptions = true;
                    c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

                }

                //atualiza o grid mensagens
                this.gridControlErrorMsgs.DataSource = this._messages;

                //atualiza o grid avisos
                this.gridControlErrorMsgs.RefreshDataSource();

                //mostra o panel
                this.dockPanelOutput.Show();

                //direcionar o foco de volta ao editor
                this.scintilla.Focus();

            }

        }

        private void scintilla_CharAdded(object sender, CharAddedEventArgs e)
        {
            // Find the word start
            var currentPos = scintilla.CurrentPosition;
            var wordStartPos = scintilla.WordStartPosition(currentPos, true);

            // Display the autocompletion list
            var lenEntered = currentPos - wordStartPos;
            if (lenEntered > 0)
            {
                string autoComplete = keywords + " " + _tables;

                if (!scintilla.AutoCActive)
                    scintilla.AutoCShow(lenEntered, autoComplete);
            }
        }

        private void btnExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files(2007)| *.xlsx";
            saveFileDialog.FileName = "Export_Result_" + Guid.NewGuid().ToString();
            var op = saveFileDialog.ShowDialog();
            if (op == DialogResult.OK)
            {
                var path = saveFileDialog.FileName;
                var t = new XlsxExportOptions();
                t.SheetName = "QueryResult";
                t.ShowGridLines = false;
                gridControlResults.ExportToXlsx(path, t);
            }
        }

        private void btnExportToPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files| *.pdf";
            saveFileDialog.FileName = "Export_Result_" + Guid.NewGuid().ToString();
            var op = saveFileDialog.ShowDialog();
            if (op == DialogResult.OK)
            {
                var path = saveFileDialog.FileName;
                gridControlResults.ExportToPdf(path);
            }
        }

        private void XFrmMenuNav_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.L)
            {
                gridControlResults.DataSource = null;
                gridViewResults.RefreshData();
            }

            if (e.KeyCode == Keys.F8)
                btnExecutar_ItemClick(null, null);

            if (e.KeyCode == Keys.F5)
            {
                //aperto F5 eh pra executar tudo
                this.scintilla.SelectionStart = 0;
                btnExecutar_ItemClick(null, null);
            }
        }

        private void btnDataBases_EditValueChanged(object sender, EventArgs e)
        {
            scintilla.Focus();
        }

        private void barBtnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XMessageIts.Advertencia("Não nao implementado");
        }

        private void barBtnRefreshConnections_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task.Run(()=>TaskFillTreeList());
        }

        private void barBtnCreateConnection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var xFrmApp = new XFrmAppConfig();

            xFrmApp.ShowDialog();

            if (xFrmApp.AppConfig != null)
            {
                var appConfig = xFrmApp.AppConfig;
                this.barEditItemConnection.EditValue = appConfig.ConnectionName;
                this.barEditDataBases.EditValue = appConfig.Database;
            }
        }

        private void barBtnOpenFileSql_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (openFileSql.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string xmlFile = openFileSql.FileName;

                if (!xmlFile.ToLower().EndsWith(".sql"))
                {
                    XMessageIts.Advertencia("Selecione o arquivo de configuração .xml");
                }
                else if (FileManagerIts.IsEmpty(xmlFile))
                {
                    XMessageIts.Erro("Arquivo de configuração está vazio.");
                }
                else
                {

                    scintilla.Text = FileManagerIts.GetDataStringFile(openFileSql.FileName);
                }
            }
        }

        private void barEditItemConnection_HiddenEditor(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadDatabases();
        }

        private void barBtnExpandCollapse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_collapsed)
            {
                treeListConnection.ExpandAll();
                _collapsed = true;
            }
            else
            {
                treeListConnection.CollapseAll();
                _collapsed = true;
            }
        }

        private void barBtnRetrieveData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var node = this.treeListConnection.FocusedNode;

            //se ej o ultimo node eh a a tabela
            if (node != null && node.Level == 3)
            {

                string scriptText = "SELECT * FROM " + node.GetValue("ConnectionName");

                if (string.IsNullOrEmpty(scintilla.Text))
                {
                    scintilla.AppendText(scriptText + "\n");
                    scintilla.SetSelection(scriptText.Length, 0);
                    btnExecutar_ItemClick(null, null);

                }
                else
                {
                    scintilla.AppendText("\n" + scriptText + "\n");
                    //nao sei selecionar
                }

                //btnExecutar_ItemClick(null, null);
            }
        }

        private void treeListConnection_MouseUp(object sender, MouseEventArgs e)
        {
            //https://www.devexpress.com/Support/Center/Question/Details/A915/implementing-context-menus-for-treelist-nodes
            TreeList tree = sender as TreeList;

            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None
                && tree.State == TreeListState.Regular)
            {

                Point pt = tree.PointToClient(MousePosition);

                TreeListHitInfo info = tree.CalcHitInfo(pt);

                if (info.HitInfoType == HitInfoType.Cell)
                {
                    tree.FocusedNode = info.Node;
                    popupMenu1.ShowPopup(MousePosition);

                }

            }
        }

        private void XFrmQueryEditor_Shown(object sender, EventArgs e)
        {
            Task.Run(() => TaskFillTreeList());
        }

        #endregion

        #region Internal Class

        private class NodConnection
        {
            public object[] Node { get; private set; }

            public NodConnection(dynamic o)
            {
                this.Node = new object[] { o.ServerName };
            }

        }
        #endregion

    }
}

