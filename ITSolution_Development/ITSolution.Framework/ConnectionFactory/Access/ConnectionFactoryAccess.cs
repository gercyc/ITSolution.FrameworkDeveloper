using ITSolution.Framework.Util;
using System.Data;
using System.Data.OleDb;

namespace ITSolution.Framework.ConnectionFactory.Access
{
    public class ConnectionFactoryAccess  
    {
        private const string fileAccess = @"D:\Jorge\Narcos\Narcos.dados.accdb";
        public ConnectionFactoryAccess()

            
        {
        }

        public void Fill(DevExpress.XtraGrid.GridControl gridControl)
        {
            //Define a string de conexão PARA O OFFICE 2013
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Jorge\\Narcos\\Narcos.dados.accdb;Persist Security Info=False;";

            string sql = @"SELECT
  tblPacientes.strNome
 ,tblPacientes.strCirurgiao
 ,tblPacientes.strSenha
 ,tblPacientes.strAnestesista
 ,tblDados.strCPF
 ,tblDados.strCRM
 ,tblPacientes.dtData
 ,IIF(tblPacientes.strAcomodacao = 'apartamento', 2, 1) AS Acomodação
 , tblPacientes.dtDataGuia
 ,tblPacientes.numCarteira
 ,tblPacientes.dtValidade
 ,tblPacientes.strInicio
 ,tblPacientes.strFinal
 ,tblPacientes.id
 ,cstGuiaPromedTotal.Total
FROM tblPacientes
LEFT JOIN tblDados
  ON tblPacientes.strAnestesista = tblDados.strMédico
LEFT JOIN cstGuiaPromedTotal
  ON tblPacientes.id = cstGuiaPromedTotal.Chave
WHERE tblPacientes.strConvenio = 'promed';";

            sql = "select * from tblpacientes";

            //Cria o DataAdapter
            OleDbDataAdapter da = new OleDbDataAdapter();

            //Data Table
            DataTable table = new DataTable();
            //Atribui o dataAdapter a string SQL e a string de conexão
            da = new OleDbDataAdapter(sql, connectionString);

            //Cria a dataTable
            //DataTable dt = new DataTable();  
            DataSet dt = new DataSet();

            //Preenche o dataAdapter com a dataTable
            da.Fill(dt);

            gridControl.DataSource = dt;


        }

    }
}
