using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ITSolution.Framework.Mensagem;

namespace ITSolution.Framework.Components.Table.Model
{
    /// <summary>
    /// Filipe
    /// Classe de controle SQL para um DataSet
    /// </summary>
    public class DataSetSql : DataSet
    {
        private readonly SqlConnection _connectionSql;
        private BindingSource _bindingSource;
        private DataTable _dataTable;
        private SqlDataAdapter _adapter;
        private SqlCommand _sqlCommand;

        public DataSetSql(string connectionstring)
        {
            InitComponents();
            this._connectionSql = new SqlConnection(connectionstring);

        }

        public DataSetSql(SqlConnection connectionSql)
        {
            InitComponents();
            this._connectionSql = connectionSql;
        }

        private void InitComponents()
        {
            this._bindingSource = new BindingSource();
            this._adapter = new SqlDataAdapter();

        }

        public void Fill(string command, GridControl gridControl, BindingSource bs)
        {
            this.Fill(command, gridControl);

            if (bs != null)
            {
                this._bindingSource = bs;
            }
            else
            {
                throw new System.NullReferenceException("BindingSource não informado");

            }
        }

        public void Fill(string command, GridControl gridControl)
        {
            Fill(command);
            //add os dados no gridView do gridControl
            gridControl.DataSource = this._dataTable;
            //add um controlador bindingsource
            gridControl.DataSource = _bindingSource;

        }

        public void Fill(string command, DataGridView dataGridView)
        {
            Fill(command);

            dataGridView.DataSource = this._dataTable;

            //Atribui o BindingSource ao DataGridView
            dataGridView.DataSource = _bindingSource;

        }

        //O source do gridView eh um DataGridView -> gridView.DataSource as DataGridView
        public void Fill(string command, GridView gridView)
        {
            DataGridView dataGridView = gridView.DataSource as DataGridView;

            Fill(command, dataGridView);

        }

        public void FillAsync(string command, GridControl gridControl)
        {
            Fill(command);

            //add os dados no gridView do gridControl
            gridControl.DataSource = this._dataTable;
            //add um controlador bindingsource
            gridControl.DataSource = _bindingSource;

        }
        public void Select(string command)
        {
            if (_connectionSql == null)
            {
                XMessageIts.Erro("Conexão SQL não foi informada ao DataSetSQl");
            }
            else
            {
                this.Select(command, _connectionSql);
            }
        }

        public void Select(string command, SqlConnection connectionSql)
        {
            try
            {
                this._sqlCommand = new SqlCommand(command, connectionSql);
                _sqlCommand.CommandType = CommandType.Text;
                this._adapter.SelectCommand = _sqlCommand;
            }
            catch (SqlException sqlex)
            {
                XMessageIts.ExceptionJustMessage(sqlex, "Falha com SQL ao preencher a tabela",
                    "Falha no comando scriptSql: " + command);
                throw sqlex;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionJustMessage(ex, "Falha ao preencher a tabela");
                throw ex;

            }


        }

        //Inicializa todos os componentes necessarios para o DataSet funcionar
        private void Fill(string command)
        {
            try
            {
                this.Clear();
                this.Select(command);
                this._adapter.Fill(this);

                if (this.Tables.Count > 0)
                {
                    this._dataTable = Tables[0];
                }
                else
                {
                    this._dataTable = new DataTable();

                }

                //aqui eu pego os dados da tabela
                this._bindingSource.DataSource = this._dataTable;

                //aqui eu falo pro bs que ele vai existir no grid
                //atribui o dataset ao DataSource do BindingSource
                _bindingSource.DataSource = this;

                //essa linha fala que eu qro usar o bs pra navegar
                //essa linha tinha sumido nao sei pq
                //atribui o BindingSource ao BindingNavigator
                _bindingSource.DataMember = _dataTable.TableName;

            }
            catch (SqlException sqlex)
            {
                XMessageIts.ExceptionJustMessage(sqlex, "Falha com SQL ao preencher a tabela",
                    "Falha no comando scriptSql: " + command);
                throw sqlex;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionJustMessage(ex, "Falha ao preencher a tabela");
                throw ex;

            }

        }

        /**Travou por causa da chaves estrangeiras ainda nao sei tratar
      public void Fill<T>(List<T> lista, GridControl gridControl) where T : new()
      {
          this.Clear();

          this.DataTable = new DataGridViewUtil().ConvertToDataTable<T>(lista);

          if (DataTable == null)
          {
              this.DataTable = new DataTable();
          }

          //add os dados no gridView do gridControl
          gridControl.DataSource = this.DataTable;
          //add um controlador bindingsource
          gridControl.DataSource = BindingSource;

      }  public List<T> GetList<T>() where T : new()
         {
             List<T> lista = new DataGridViewUtil().ConvertToList<T>(DataTable);

             if (lista == null)
             {
                 MessageIts.Mensagem("Nenhum registro encontrado");
                 lista = new List<T>();
             }
             return lista;
         }*/

    }
}
