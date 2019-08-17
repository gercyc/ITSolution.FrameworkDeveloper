using ITSolution.Framework.Mensagem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ITSolution.Framework.GuiUtil
{
    public class DataGridViewUtil
    {
        //Base: http://stackoverflow.com/questions/1427484/convert-datatable-to-listt

        /// <summary>
        /// Converter um DataTable em lista
        /// </summary>
        /// <typeparam colName="T">Tipo da lista</typeparam>
        /// <param colName="datatable">Datatable</param>
        /// <returns>Um lista tipada</returns>
        public static List<T> ConvertToList<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => ConvertToObject<T>(row, columnsNames));
                return Temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Converte um DataRow em uma em um tipo T
        /// </summary>
        /// <typeparam colName="T"></typeparam>
        /// <param colName="row">Linha da tabela</param>
        /// <param colName="columnsName">Nome das colunas da tabela</param>
        /// <returns></returns>
        public static T ConvertToObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();

                foreach (PropertyInfo objProperty in Properties)
                {

                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());

                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();

                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageIts.MensagemExcecao(ex, "Falha ao gerar objeto tipado pelo DataRow.",
                    "Falha na conversão do objeto da linha selecionada");

            }
            return obj;
        }

        /// <summary>
        /// Obtem o tipo da linha selecionada. Gera alertas
        /// </summary>
        /// <param colName="gridView"></param>
        /// <returns></returns>
        public static T ConvertToObject<T>(DataGridView dataGridView) where T : class
        {
            int selectRowsCount = dataGridView.SelectedRows.Count;

            if (IsEmpty(dataGridView))
            {
                MessageIts.Mensagem("Tabela vazia.");
            }

            else if (IsSelectRow(dataGridView) == false)
            {

                MessageIts.Mensagem("Nenhuma linha selecionada");
            }

            else
            {
                try
                {
                    T linha = (dataGridView.SelectedRows[0].DataBoundItem as T);
                    return linha;
                }
                catch (IndexOutOfRangeException ex)
                {

                    MessageIts.Mensagem("Falha ao obter o objeto do DataGridView" + ex.StackTrace + "\n" + ex.Message);
                }
            }
            return null;
        }

        /// <summary>
        ///Converte uma lista tipada para um DataTable por reflexão.
        ///
        /// A class POCO não pode conter propriedas de outras classes.
        /// 
        /// Exemplo: 
        ///     CentroCusto
        ///         string nome;
        ///         ....
        ///         //considerando uma classe com chave estrangeira
        ///         Lancamento lancamento;
        ///          public virtual ICollection<Lancamento> Lancamentos;
        ///     Caso haja o metódo irá falhas
        ///     
        /// </summary>
        /// <typeparam colName="T"></typeparam>
        /// <param colName="lista"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(List<T> lista) where T : new()
        {

            if (lista == null)
            {
                MessageIts.Mensagem("Lista não informada na conversão para DataTable");
                return new DataTable();
            }
            DataTable dataTable = new DataTable(typeof(T).Name);

            try
            {
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }

                foreach (T item in lista)
                {
                    try
                    {
                        var values = new object[Props.Length];

                        for (int i = 0; i < Props.Length; i++)
                        {
                            //inserting property values to datatable rows
                            values[i] = Props[i].GetValue(item, null);
                        }

                        dataTable.Rows.Add(values);
                    }
                    catch (Exception ex)
                    {
                        MessageIts.Mensagem("Falha na conversão do paramentro da lista em dados\n"
                            + ex.StackTrace + "\n\n" + ex.Message);

                        throw ex;
                    }


                }
            }
            catch (NullReferenceException ex)
            {
                MessageIts.Mensagem("Falha ao gerar DataTable através da lista\n" + ex.StackTrace + "\n" + ex.Message, "Falha");

            }

            //put first breakpoint here and check datatable
            return dataTable;
        }

        /// <summary>
        /// Converter um IEnumerable para DataTable
        /// </summary>
        /// <typeparam colName="T"></typeparam>
        /// <param colName="collection"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(IEnumerable<T> collection) where T : new()
        {

            DataTable dataTable = new DataTable();

            try
            {
                Type impliedType = typeof(T);
                PropertyInfo[] _propInfo = impliedType.GetProperties();
                foreach (PropertyInfo pi in _propInfo)
                    dataTable.Columns.Add(pi.Name, pi.PropertyType);

                foreach (T item in collection)
                {
                    DataRow newDataRow = dataTable.NewRow();
                    newDataRow.BeginEdit();
                    foreach (PropertyInfo pi in _propInfo)
                        newDataRow[pi.Name] = pi.GetValue(item, null);
                    newDataRow.EndEdit();
                    dataTable.Rows.Add(newDataRow);
                }
            }
            catch (Exception ex)
            {
                MessageIts.Mensagem("Falha ao gerar DataTable através da lista\n" + ex.StackTrace + "\n" + ex.Message);

            }
            return dataTable;

        }

        /// <summary>
        /// Os valores da linha selecionada do DataSet
        /// </summary>
        /// <param colName="ds"></param>
        /// <returns></returns>
        public static object[] GetRowValues(DataSet ds, int rowIndex)
        {
            DataTable dt = ds.Tables[0];
            //int rowCount = dt.Rows.Count;
            int columnCount = dt.Columns.Count;

            //vetor de objetos com
            object[] rowValue = new object[columnCount];

            if (ds.Tables.Count > 0)
            {
                //consideire apena um datable
                //pegue first linha inteira do datable
                DataRow row = dt.Rows[rowIndex];

                for (int j = 0; j < columnCount; j++)
                {
                    try
                    {
                        rowValue[j] = row.ItemArray[j];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        MessageBox.Show("Falha ao pegar o valor da linha do GridView\n" + ex.Message);
                    }
                }
                //fim da indexa da linha 
                return rowValue;


            }
            //poderia fazer desta forma
            /* foreach (DataTable table in ds.Tables)
             {
                 foreach (DataRow row in table.Rows)
                 {
                     if (j < columnCount)
                     {
                         try{
                            Object value = row.ItemArray[j];                             
                         } catch (IndexOutOfRangeException ex1){
                         }
                     }
                     j++;
                 }
                 j = 0;
                 rowIndex++;
             }
        */
            return rowValue;

        }

        /// <summary>
        /// O objeto da celula do DataGridView
        /// </summary>
        /// <param colName="gridView"></param>
        /// <param colName="colName"></param>
        /// <returns></returns>
        public static object GetCellRowValue(DataGridView gridView, String columnName)
        {
            Object o = gridView.CurrentRow.Cells[columnName].Value;

            return o != null ? o.ToString() : null;
        }

        /// <summary>
        /// Verifica se o DataGridView está vazio.
        /// </summary>
        /// <param colName="gridView"></param>
        /// <returns></returns>
        public static bool IsEmpty(DataGridView dataGridView)
        {
            int rowCount = dataGridView.RowCount;

            int selectRowsCount = dataGridView.SelectedRows.Count;

            return rowCount == 0;

        }

        /// <summary>
        /// Verifica se existe uma ou mais linhas no DataGridView esta selecionada
        /// </summary>
        /// <param colName="gridView"></param>
        /// <returns></returns>
        public static bool IsSelectRow(DataGridView dataGridView)
        {
            int selectRowsCount = dataGridView.SelectedRows.Count;

            return selectRowsCount > 0;

        }

        /// <summary>
        /// Nome das colunas do DataGridView
        /// </summary>
        /// <param colName="gridView"></param>
        /// <returns></returns>
        public static string[] GetColumnsName(DataGridView gridView)
        {
            int t = gridView.Columns.Count;
            String[] columns = new String[t];
            for (int i = 0; i < t; i++)
            {
                String x = gridView.Columns[i].Name;
                columns[i] = x;

                MessageIts.Mensagem(x);
            }
            return columns;
        }

        /// <summary>
        /// O valor do objeto no DataRow
        /// </summary>
        /// <param name="dataRow"></param>DataRow
        /// <param name="nomeColuna"></param>Nome da coluna
        /// <returns></returns>
        public static object GetValueDataRow(DataRow dataRow, string nomeColuna)
        {
            object o = dataRow[nomeColuna];
            return o != null ? o.ToString() : "";
        }


        /* Referencias:
        *   http://stackoverflow.com/questions/564366/convert-generic-list-enumerable-to-datatable 
        
        public static DataTable ToDataTable<T>(this IList<T> data)  where T : class
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }*/

        /// <summary>
        /// Obtem o valor de todas as coluna do DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>Um vetores de valores
        public static object[] GetColumnValues(DataTable dt)
        {
            int rowCount = dt.Rows.Count;
            //array dos periodos
            object[] values = new object[rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object o = "" + dt.Rows[i][j];

                    if (!string.IsNullOrWhiteSpace(o.ToString()))
                    {
                        string x = o.ToString().Trim();
                        values[i] = x;
                    }
                }
            }
            return values;
        }
    }
}
