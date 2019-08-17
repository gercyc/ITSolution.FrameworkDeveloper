
using DevExpress.XtraGrid;
using ITSolution.Framework.Mensagem;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ITSolution.Framework.Arquivos;


namespace ITSolution.Framework.Util
{
    /// <summary>
    /// Provem acesso a leitura de arquivos .xls, xlsx, .dbs em objeto DataTable e DataSet
    /// Um DataTable é uma estrutura de tabela
    /// Um DataSet é um conjunto de tabelas (DataTables)
    /// </summary>
    public class ConnectionExcel : ConnectionFile
    {
        /// <summary>
        /// Construtor padrão para conexão ao arquivo
        /// </summary>
        /// <param name="file">Arquivo do excel xls, xlsx</param>
        public ConnectionExcel(string file)
            : base(GetConnectionStringExcel(file), file)
        {
        }

        /// <summary>
        /// Chamado internamente 
        /// </summary>
        /// <param colName="excelFile"></param> Arquivo do excel
        /// <returns></returns>
        public static string GetConnectionStringExcel(string file)
        {
            string connectionString =
                string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        + file + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'");

            return connectionString;
        }

        /// <summary>
        /// Cria um Adaptor OleDbAdapter para obter os dados da Planilha do excel
        /// </summary>
        /// <param colName="scriptSql"></param>
        /// <param colName="excelFile"></param>
        /// <returns></returns>
        public OleDbDataAdapter CreateOleDBAdapater(string query)
        {
            try
            {
                //abrindo a connectionString com o excel
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, this.ConnectionString);

                return dataAdapter;
            }
            catch (SystemException ex)
            {
                XMessageIts.ExceptionMessage(ex);
                return null;
            }

        }

        /// <summary>
        /// Retorna um DataSet contendo os dados de cada guia da planilha
        /// 
        /// <param colName="excelFile"></param> Arquivo do excel xls, xlsx. 
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet()
        {
            //Cria o objeto dataset para receber o conteúdo do arquivo Excel
            DataSet ds = new DataSet();

            try
            {
                using (var connection = new OleDbConnection(this.ConnectionString))
                {

                    connection.Open();
                    //DataTable worksheets = connection.GetSchema("Tables");

                    var dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //new object[] { null, null, null, "TABLE" });

                    foreach (DataRow row in dt.Rows)
                    {
                        // obtem o noma da planilha corrente
                        string sheet = row["TABLE_NAME"].ToString();

                        // obtem todas as linhas da planilha corrente
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", connection);
                        cmd.CommandType = CommandType.Text;

                        //adaptador com todos os dados
                        var da = new OleDbDataAdapter(cmd);

                        if (!sheet.Contains("_xlnm#_FilterDatabase") && !sheet.Contains("FilterDatabase") && !sheet.Contains("_xlnm#Print_Area"))
                        {
                            Console.WriteLine(sheet);

                            // copia os dados da planilha para o datatable
                            DataTable outputTable = new DataTable(sheet);

                            //preenche o Data Table
                            da.Fill(outputTable);

                            //add a tabela no Data Set
                            ds.Tables.Add(outputTable);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XMessageIts.Mensagem(ex.Message);
            }
            return ds;
        }

        /// <summary>
        /// Retorna um DataTable com os todos dados de todas as guias da planilha
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable()
        {
            //Data Table
            DataTable table = new DataTable();
            try
            {

                using (var connection = new OleDbConnection(this.ConnectionString))
                {

                    connection.Open();
                    DataTable worksheets = connection.GetSchema("Tables");

                    var dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //new object[] { null, null, null, "TABLE" });

                    foreach (DataRow row in dt.Rows)
                    {
                        // obtem o noma da planilha corrente
                        string sheet = row["TABLE_NAME"].ToString();

                        Console.WriteLine(sheet);

                        if (!sheet.Contains("_xlnm#_FilterDatabase") && !sheet.Contains("FilterDatabase") && !sheet.Contains("_xlnm#Print_Area"))
                        {
                            // obtem todas as linhas da planilha corrente
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", connection);
                            cmd.CommandType = CommandType.Text;

                            //adaptador com todos os dados
                            var da = new OleDbDataAdapter(cmd);

                            //preenche o Data Table
                            da.Fill(table);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XMessageIts.Mensagem(ex.Message);
            }
            return table;
        }

        /// <summary>
        /// Obtem o DataTable a partir do índice da planilha 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(int index)
        {
            //Data Table

            try
            {
                DataTable table = new DataTable();
                using (var connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    //DataTable worksheets = connection.GetSchema("Tables");

                    var dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //new object[] { null, null, null, "TABLE" });

                    if (index >= dt.Rows.Count || index < 0)

                        throw new Exception("Índice " + index + " está fora do intervalo.\n" +
                            "Índice deve estar entre 0 e " + (dt.Rows.Count - 1) +
                            "\n\nArquivo: \"" + this.PathFile + "\"");

                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (i == index)
                        {
                            // obtem o noma da planilha corrente
                            string sheet = row["TABLE_NAME"].ToString();

                            Console.WriteLine(sheet);

                            if (!sheet.Contains("_xlnm#_FilterDatabase"))
                            {
                                // obtem todas as linhas da planilha corrente
                                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", connection);
                                cmd.CommandType = CommandType.Text;

                                //adaptador com todos os dados
                                var da = new OleDbDataAdapter(cmd);

                                //preenche o Data Table
                                da.Fill(table);
                            }
                            return table;
                        }
                        i++;

                    }
                }
                return table;
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Retorna um DataSet com os dados de uma planilha do excel a partir do scriptSql específico.
        /// </summary>
        /// <param colName="excelFile">Arquivo do excel xls, xlsx</param> 
        /// <param colName="scriptSql">Exemplo: "select * from [{0}$]", "NomePlanilha"</param>
        /// <param name="query"></param>
        /// <returns>DataSet preenchido</returns>
        public DataSet GetDataSetFromQuery(string query)
        {
            //abrindo a connectionString com o excel
            OleDbDataAdapter dataAdapter = CreateOleDBAdapater(query);
            DataSet dataSet = new DataSet();
            if (dataAdapter != null)
            {
                dataAdapter.Fill(dataSet);
            }
            return dataSet;
        }

        /// <summary>
        /// Retorna um DataTable com os dados de uma planilha do excel a partir do scriptSql específico.
        /// </summary>
        /// <param colName="excelFile"></param> Arquivo do excel xls, xlsx
        /// <param colName="worksheet">String de Conexão Excel</param>
        /// <param colName="scriptSql">Query a ser executada. OBS.: Envolver o colName da "tabela" com []. Ex.: "SELECT * FROM [NOME_TABELA]" on de [NOME_TABELA] é o colName da planilha</param>
        /// <param name="excelFile"></param>
        /// <param name="query"></param>
        /// <returns>O DataTable preenchido</returns>
        public DataTable GetDataTable(string excelFile, string query)
        {

            DataTable dt = new DataTable();

            //abrindo a connectionString com o excel
            OleDbDataAdapter dataAdapter = CreateOleDBAdapater(query);
            if (dataAdapter != null)
            {
                dataAdapter.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Retorna um DataTable com todos os dados da planilha do índice 0, independentemente do colName da mesma
        /// <param colName="excelFile"></param> Arquivo do excel xls, xlsx. 
        /// </summary>
        /// <returns>Objeto DataTable preenchido</returns>
        public DataTable GetDataTableFromIndexZero()
        {

            DataTable dataTable = new DataTable();

            try
            {

                using (var connection = new OleDbConnection(this.ConnectionString))
                {

                    connection.Open();
                    DataTable worksheets = connection.GetSchema("Tables");

                    if ((worksheets != null) && (worksheets.Rows.Count > 0))
                    {

                        var rows = worksheets.Rows;
                        var tableName = worksheets.Rows[0]["TABLE_NAME"].ToString();

                        // Seleciono todos os dados de uma determinada planilha do arquivo, independentemente do colName da mesma
                        var da = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", tableName), this.ConnectionString);

                        da.Fill(dataTable);
                    }
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
                return dataTable;
            }
        }

        /// <summary>
        /// Retorna um DataTable com todos os dados de uma determinada planilha do arquivo, independentemente do colName da mesma
        /// <param colName="worksheet">Índice da planilha a ser consultada. Ex: Plan1, índice 0, Plan2 índice 1, etc. Por padrão o índice é 0.</param>
        /// </summary>
        /// <returns>Objeto DataTable preenchido</returns>
        public DataTable GetDataTableFromWorksheet(int worksheet)
        {

            DataTable dataTable = new DataTable();

            try
            {
                DataTable worksheets;
                using (var connection = new OleDbConnection(this.ConnectionString))
                {
                    connection.Open();
                    worksheets = connection.GetSchema("Tables");
                }

                if ((worksheets != null) && (worksheets.Rows.Count > 0))
                {
                    var tableName = worksheets.Rows[worksheet]["TABLE_NAME"].ToString();

                    // Seleciono todos os dados de uma determinada planilha do arquivo, independentemente do colName da mesma
                    var da = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", tableName), this.ConnectionString);

                    da.Fill(dataTable);
                }

                return dataTable;
            }
            catch
            {
                return dataTable;
            }
        }

        /// <summary>
        /// Indexa o DataGridView com os dados do arquivo do excel
        /// </summary>
        /// <param colName="dgvExcelFile">XGridViewUtil a ser indexado</param>
        /// <param colName="excelFile">Arquivo do excel </param>
        /// <param name="dgv"></param>
        public void FillDataGridView(DataGridView dgv)
        {
            dgv.DataSource = GetDataTableFromIndexZero();
        }

        /// <summary>
        /// Indexa o GridView do gridControl informado com os dados do arquivo do excel
        /// </summary>
        /// <param colName="dgvExcelFile">GridControl a ser indexado</param>
        /// <param colName="excelFile">Arquivo do excel </param>
        /// <param name="gridControl"></param>
        public void FillGridControl(GridControl gridControl)
        {
            gridControl.DataSource = GetDataTableFromIndexZero();
        }
        
    }
}
