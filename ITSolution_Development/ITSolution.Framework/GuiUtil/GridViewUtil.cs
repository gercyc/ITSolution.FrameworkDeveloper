using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using ITSolution.Framework.Arquivos;

namespace ITSolution.Framework.GuiUtil
{
    public static class GridViewUtil
    {

        public static void FocusFirstRow(this GridView gridView)
        {
            gridView.FocusedRowHandle = 0;
        }

        public static void FocusCurrentRow(this GridView gridView)
        {
            int index = gridView.DataRowCount - 1;

            /*int[] selectIndex = gridView.GetSelectedRows();

            if (selectIndex.Length > 0)
                //use o primeiro indice das linhas selecionada sempre sera o primeira
                index = selectIndex[0];
            */

            gridView.FocusedRowHandle = index;
            //atualize a linha -> notifica alteração nas celulas daquela linha
            gridView.RefreshRow(index);

        }

        public static void FocusLastRow(this GridView gridView)
        {
            int rows = gridView.DataRowCount;
            gridView.FocusedRowHandle = rows - 1;
        }

        /// <summary>
        /// Ajusta o alinhamento do cabecalho e das celulas do grid.
        /// O datatable ja deve estar setado.
        /// </summary>
        /// <param name="gridView"></param>
        public static void CustomGridView(GridView gridView)
        {

            if (gridView != null)
            {

                foreach (GridColumn gridColumn in gridView.Columns)
                {
                    //gridColumn.Caption = "Nome Alias";
                    //gridColumn.FieldName = "Nome da coluna no banco";
                    //gridColumn.Name = "colNomeColunaBanco";
                    gridColumn.AppearanceCell.Options.UseTextOptions = true;
                    gridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridColumn.AppearanceHeader.Options.UseTextOptions = true;
                    gridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                    gridColumn.OptionsColumn.AllowEdit = false;
                    gridColumn.OptionsColumn.ReadOnly = true;
                    gridColumn.Visible = true;
                    //gridColumn.Width = 133;
                }
            }

        }

        public static T GetRow<T>(this GridView gridView, int rowHandle) where T : class
        {
            if (gridView.IsEmpty)
                return null;

            return gridView.GetRow(rowHandle) as T;
        }

        /// <summary>
        /// Retorna o objeto tipado
        /// </summary>
        /// <typeparam name="T"></typeparam> Tipagem
        /// <param name="gridView"></param>GridView
        /// <returns></returns>O objeto do grid em tipo T
        public static T GetFocusedRow<T>(this GridView gridView) where T : class
        {
            return gridView.GetFocusedRow() as T;
        }

        /// <summary>
        /// Os objetos das celulas da linha especifica.
        /// </summary>
        /// <param colName="gridView"></param>
        /// <param colName="rowIndex"></param>
        /// <param name="gridView"></param>
        /// <returns></returns>
        public static object[] GetRowObjects(GridView gridView, int index)
        {
            try
            {

                int rowCount = gridView.DataRowCount;

                if (rowCount < 1)
                {
                    return null;
                }
                int columnCount = gridView.Columns.Count;
                object[] result = new object[columnCount];

                DataRowView drv = gridView.GetRow(index) as DataRowView;

                DataRow dr = drv.Row;

                for (int i = 0; i < columnCount; i++)
                {
                    try
                    {
                        object o = dr.ItemArray[i];

                        result[i] = (o != null) ? o.ToString() : null;

                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine("Falha ao obter os valores das celulas do gridview");
                        LoggerUtilIts.ShowExceptionLogs(ex);
                        return null;
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter o valor da celula=>" + ex.Message);
                return null;
            }
        }

        public static void SaveLayout(this GridView gridView, string layoutName, string path = null)
        {
            if (path == null)
            {
                string layouts = Path.Combine(Application.ExecutablePath, "Layouts");
                if (Directory.Exists(layouts))
                    Directory.CreateDirectory(layouts);
                //barBtnSalvar_ItemClick(null, null);

                layoutName = layoutName.Replace(".xml", "");

                string xml = Path.Combine(layouts, layoutName + ".xml");
                FileManagerIts.DeleteFile(xml);
                //OptionsLayoutBase.FullLayout
                gridView.SaveLayoutToXml(xml);
            }

        }

        /// <summary>
        /// Obtem os valores das celulas da tabela
        /// </summary>
        /// <param colName="gridView"></param>
        /// <returns> OS valores da linha selecionada </returns> 
        public static object[] GetSelectedRowObjects(GridView gridView)
        {
            int[] selectedRows = gridView.GetSelectedRows();
            if (selectedRows.Length <= 0)
            {
                return null;
            }
            int columnCount = gridView.Columns.Count;
            object[] result = new object[columnCount];
            int rowHandle = selectedRows[0];
            DataRowView drv = gridView.GetRow(rowHandle) as DataRowView;
            DataRow dr = drv.Row;

            for (int i = 0; i < columnCount; i++)
            {
                try
                {
                    Object o = dr.ItemArray[i];
                    result[i] = o != null ? o : null;
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param colName="gridView"></param>
        /// <returns></returns>
        public static bool IsSelectRow(this GridView gridView)
        {
            if (gridView.IsEmpty)
            {
                return false;
            }

            var row = gridView.GetFocusedRow();

            if (row == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica e exibe mensagem sobre o grid
        /// Permite a selecao de uma linha por vez
        /// </summary>
        /// <param colName="gridView"></param>
        /// <returns></returns>
        public static bool IsSelectOneRowWarning(this GridView gridView)
        {
            if (gridView.IsEmpty)
            {
                XMessageIts.Mensagem("Não há registros na tabela.");
                return false;
            }
            var selected = gridView.SelectedRowsCount;
            var row = gridView.GetFocusedRow();

            if (row == null || selected == 0)
            {
                XMessageIts.Mensagem("Nenhuma linha selecionada");
                return false;
            }

            var selectRowsCount = gridView.GetSelectedRows();

            if (selectRowsCount.Length > 1)
            {
                XMessageIts.Advertencia("É perimita a seleção de uma única linha.", "Múltiplas linhas selecionadas");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Verifica e exibe mensagem sobre o grid
        /// </summary>
        /// <param colName="gridView"></param>
        /// <returns></returns>
        public static bool IsEmptyWarning(this GridView gridView)
        {
            if (gridView.IsEmpty)
            {
                XMessageIts.Mensagem("Não há registros na tabela.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Nome das colunas do GridView
        /// </summary>
        /// <param colName="gridView"></param>
        /// <returns></returns>
        public static string[] GetColumnsName(this GridView gridView)
        {
            int t = gridView.Columns.Count;
            String[] columns = new String[t];
            for (int i = 0; i < t; i++)
            {
                String x = gridView.Columns[i].Name;
                columns[i] = x;
            }
            return columns;
        }

        public static DataRow GetDataRow(this GridView gridView)
        {
            DataRow dr = gridView.GetFocusedDataRow();
            return dr;
        }

        public static DataRowView GetDataRowView(this GridView gridView)
        {
            DataRowView drv = gridView.GetFocusedRow() as DataRowView;
            return drv;
        }

        public static DataGridView GetDataGridView(this GridView gridView)
        {
            DataGridView dataGridView = gridView.DataSource as DataGridView;
            return dataGridView;
        }

        /// <summary>
        /// Obtem o valor da celular selecionada
        /// </summary>
        /// <param name="gridView"></param>
        /// <returns></returns>
        public static object GetSelectedCellValue(this GridView gridView)
        {
            return gridView.FocusedValue;
        }

        /// <summary>
        /// Obtem o data table do gridView
        /// </summary>
        /// <param name="gridView"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable(this GridView gridView)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                dt.Columns.Add("" + gridView.Columns[i]);
            }
            for (int i = 0; i < gridView.RowCount; i++)
            {
                DataRow dr = dt.NewRow();
                var row = gridView.GetDataRow(i);

                for (int j = 0; j < gridView.Columns.Count; j++)
                {
                    dr[dt.Columns[j]] = row.ItemArray[j];
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// Deleta a(s) linha(s) selecionadas do gridView e foca a proxima linha
        ///Use o metodo gridView.DeleteSelectedRows();
        /// </summary>
        /// <param name="gridView"></param>
        public static void DeleteRow(this GridView gridView)
        {
            var indexs = gridView.GetSelectedRows();

            foreach (var i in indexs)
            {
                gridView.SelectRows(i, i);
                gridView.DeleteRow(i);
            }
            //gridView.DeleteSelectedRows();
            gridView.RefreshData();

        }

        public static void FocusTop(this GridView gridView)
        {
            gridView.SelectRows(0, 0);
            gridView.Focus();
        }

        /// <summary>
        /// Seta o foco na primeira linha da tabela
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="rowIndex"></param>
        public static void SetSelectRow(GridView gridView, int rowIndex = 0)
        {
            try
            {

                int selectRow = gridView.FocusedRowHandle;

                if (rowIndex >= 0)
                {
                    gridView.FocusedRowHandle = rowIndex;
                    gridView.SelectRow(rowIndex);
                }
                else
                {
                    gridView.FocusedRowHandle = selectRow;
                    gridView.SelectRow(selectRow);
                }
                gridView.Focus();
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
        }

        /// <summary>
        /// Seleciona todas as linhas do grid view
        /// </summary>
        /// <param name="gridView"></param>
        public static void SelectAllRow(this GridView gridView)
        {
            try
            {
                gridView.SelectRange(0, gridView.RowCount - 1);
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
        }

        /// <summary>
        /// Seleciona todas as linhas do grid view
        /// </summary>
        /// <param name="gridView"></param>
        public static void UnSelectAllRow(this GridView gridView)
        {
            try
            {
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    gridView.UnselectRow(i);
                }
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
        }

        /// <summary>
        /// Selecionar a coluna epecifica do grid View
        /// </summary>
        /// <param name="gridView"></param>GridView
        /// <param name="gridColumn"></param>Coluna a ser selecionad
        /// <param name="rowIndex"></param>Index da coluna
        public static void SetSelectColumn(GridView gridView, GridColumn gridColumn = null, int rowIndex = 0)
        {
            try
            {
                gridView.SelectRow(rowIndex);
                if (gridColumn == null)
                {
                    gridColumn = gridView.Columns[0];
                }
                gridView.FocusedColumn = gridColumn;
                gridView.RefreshData();
                gridView.Focus();

            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
            }

        }

        /// <summary>
        /// Exibe ou oculta o painel de pesquisa do gridView
        /// </summary>
        /// <param name="gridView"></param> GridView
        public static void ShowHideFindPanel(GridView gridView)
        {
            if (gridView.IsFindPanelVisible == false)
                gridView.ShowFindPanel();
            else
                gridView.HideFindPanel();
        }

        /// <summary>
        /// Obtem a lista das linhas do grid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridView"></param>
        /// <returns></returns>
        public static List<T> GetItens<T>(this GridView gridView) where T : class
        {
            //Tirado do site do DevExpress
            List<T> lista = new List<T>();
            int rowCount = gridView.RowCount;

            for (int i = 0; i < rowCount; i++)
            {
                var p = gridView.GetRow(i) as T;
                lista.Add(p);
            }

            return lista;
        }

        /// <summary>
        /// Obtem a lista das linhas selecionadas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridView"></param>
        /// <returns></returns>
        public static List<T> GetSelectedItens<T>(this GridView gridView) where T : class
        {
            //Tirado do site do DevExpress
            List<T> lista = new List<T>();
            int[] rowIndex = gridView.GetSelectedRows();
            int rowCount = gridView.SelectedRowsCount;
            for (int i = 0; i < rowCount; i++)
            {
                var p = gridView.GetRow(rowIndex[i]) as T;
                lista.Add(p);
            }

            return lista;
        }

        /// <summary>
        /// Seta  o layout no gridview usando o recurso do projeto da solução
        /// 
        /// Obseravação: 
        ///     O recurso devem ser marcado no Properties: Build Action => Embedded Resource
        /// </summary>
        /// <param name="gridView"></param>GridView
        /// <param name="assembly"></param> Chame o metodo Assembly.GetExecutingAssembly()
        /// <param name="resourceName"></param>Nome do recurso
        public static Stream GetLayoutStreamFromResource(Assembly assembly, string resourceName)
        {
            try
            {
                Stream _layoutStream = assembly.GetManifestResourceStream(resourceName);

                return _layoutStream;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao obter stream de recurso\nError accessing resources!\n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Seta  o layout no gridview usando o recurso do projeto da solução
        /// 
        /// Obseravação: 
        /// 
        /// Os os recursos devem ser marcado no Properties: Build Action => Embedded Resource
        /// </summary>
        /// <param name="gridView"></param>GridView
        /// <param name="assembly"></param> Chame o metodo Assembly.GetExecutingAssembly()
        /// <param name="resourceName"></param>Nome do recurso
        public static void RestoreViewFromResource(this GridView gridView, Assembly assembly, string resourceName)
        {
            try
            {
                //Esse exemplo so funciona se implementado no projeto onde os recursos estao
                //Assembly _assembly = Assembly.GetExecutingAssembly(); 
                ////var x = _assembly.GetManifestResourceNames();
                //Stream _layoutStream = _assembly.GetManifestResourceStream(resourceName);
                //gridView.RestoreLayoutFromStream(_layoutStream, OptionsLayoutBase.FullLayout);


                Stream _layoutStream = assembly.GetManifestResourceStream(resourceName);
                gridView.RestoreLayoutFromStream(_layoutStream, OptionsLayoutBase.FullLayout);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao setar o recurso\nError accessing resources!\n" + ex.Message);
            }
        }

        public static void ExpandAllMasterRow(this GridView view, bool expand = true)
        {
            view.BeginUpdate();
            try
            {
                int dataRowCount = view.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                    view.SetMasterRowExpanded(rHandle, expand);
            }
            finally
            {
                view.EndUpdate();
            }
        }

        /// <summary>
        /// Exportar os dados para uma planilha .xlsx localizada no Desktop
        /// 
        /// O metodo de exportação pertence ao gridControl
        /// </summary>
        /// <param name="gridView"></param>
        public static void ExportXlsxDirect(this GridView gridView)
        {

            if (gridView.IsEmpty)
            {
                XMessageIts.Mensagem("Nada a exportar !");
            }
            else
            {
                if (gridView.DataSource != null)
                {
                    string excelName = "ExportExcel-" + DataUtil.ToDateSql();
                    string excel = Path.Combine(FileManagerIts.DeskTopPath, excelName) + ".xlsx";
                    FileManagerIts.DeleteFile(excel);

                    gridView.ExportToXlsx(excel);
                    FileManagerIts.OpenFromSystem(excel);
                }
            }
        }

        /// <summary>
        /// Exportar os dados para uma planilha .xlsx, para o local informado.
        /// </summary>
        /// <param name="gridView"></param>
        public static void ExportXlsxToDisk(this GridView gridView)
        {
            if (gridView.IsEmpty)
            {
                XMessageIts.Mensagem("Nada a exportar !");
            }
            else
            {
                var save = new SaveFileDialog
                {
                    Title = @"Exportar dados para o excel",
                    FileName = "ExcelExport.xlsx",
                    Filter = FileManagerIts.DocumentFilterExcel
                };

                if (save.ShowDialog() == DialogResult.OK)
                {
                    string pathExcel = save.FileName;
                    if (pathExcel != null)
                    {
                        if (!pathExcel.EndsWith(".xlsx"))
                            pathExcel = pathExcel + ".xlsx";

                        gridView.ExportToXlsx(pathExcel);

                        FileManagerIts.OpenFromSystem(pathExcel);

                    }
                    else
                        XMessageIts.Advertencia("Falha no caminho do arquivo .xlsx.", "Operação cancelada!");
                }

            }
        }
    }
}