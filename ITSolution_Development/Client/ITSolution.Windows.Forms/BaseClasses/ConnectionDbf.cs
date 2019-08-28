using DevExpress.XtraGrid;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace ITSolution.Framework.Util
{
    public class ConnectionDbf : ConnectionFile
    {
        public ConnectionDbf(string file)
            : base(getConnectionStringDbf(file), file)
        {
        }

        /// <summary>
        /// Chamado internamente 
        /// </summary>
        /// <param colName="excelFile"></param> Arquivo do excel
        /// <returns></returns>
        private static String getConnectionStringDbf(String fileDbf)
        {
            try
            {
                var dir = Path.GetFullPath(fileDbf).Replace(Path.GetFileName(fileDbf), "");

                String connectionString = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dir
                    + ";Extended Properties=dBASE IV;User ID=Admin;Password=;");
                return connectionString;
            }catch(Exception)
            {
                return "";
            }
        }

        public DataTable GetDataTable()
        {
            var fileName = Path.GetFileName(this.PathFile);

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                var sql = "select * from " + fileName;
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet(); ;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = new DataTable();
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return new DataTable();
            }
            /*Deu pau
           var path = Path.GetFullPath(fileDbf).Replace(Path.GetFileName(fileDbf),"");
           OdbcConnection conn = new OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" 
               + path + ";Exclusive=No");
           conn.Open();
           string strConsulta = "SELECT * FROM [" + Path.GetFileName(fileDbf) + "]";
           OdbcDataAdapter adapter = new OdbcDataAdapter(strConsulta, conn);
           System.Data.DataSet ds = new System.Data.DataSet();
           adapter.Fill(ds);
           return ds.Tables[0]; */
        }


        /// <summary>
        /// Indexa o DataGridView com os dados do arquivo do excel
        /// </summary>
        /// <param colName="dgvExcelFile">XGridViewUtil a ser indexado</param>
        /// <param colName="excelFile">Arquivo do excel </param>
        public void FillDataGridView(DataGridView dgv)
        {
            dgv.DataSource = GetDataTable();
        }

        /// <summary>
        /// Indexa o GridView do gridControl informado com os dados do arquivo do excel
        /// </summary>
        /// <param colName="dgvExcelFile">GridControl a ser indexado</param>
        /// <param colName="excelFile">Arquivo do excel </param>
        public void FillGridControl(GridControl gridControl)
        {
            gridControl.DataSource = GetDataTable();
        }

    }
}
