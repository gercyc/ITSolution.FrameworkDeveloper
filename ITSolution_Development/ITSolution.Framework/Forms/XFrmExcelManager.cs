using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;

namespace ITSolution.Framework.Forms
{
    public partial class XFrmExcelManager : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected ConnectionExcel manager;

        protected Stream layoutResult;

        //Valor a ser lido da memoria principal
        private static volatile int INDEX = 0;

        //Tabela para os dados de todas as guias da planilha
        private DataTable table;

        //Vetor de tabelas
        private DataSet ds = new DataSet();

        //Indice de navegacao no dataset
        private readonly IndexAction indexAction;

        protected bool IsValido { get; set; }
        public virtual bool IsSaveLayout { get; set; }

        /// <summary>
        /// Número de indices da tabela importada
        /// </summary>
        public int IndexCount
        {
            get
            {
                if (ds != null)
                    return ds.Tables.Count;
                return 0;
            }
        }

        public XFrmExcelManager()
        {
            this.InitializeComponent();
            this.indexAction = IndexAction.Home;
        }

        public XFrmExcelManager(string file) : this()
        {
            this.txtExcelFile.Text = file;
            this.manager = new ConnectionExcel(file);
        }

        public void ModoCompacto()
        {
            this.barSubItemOpcoes.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barBtnExportToExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barBtnExportToPdf.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public XFrmExcelManager(string file, int worksheet) : this(file)
        {
            this.barIndex.EditValue = worksheet;
        }

        public void FillGrid<T>(GenericContextIts<T> ctx) where T : class
        {
            gridControlBase.DataSource = ctx.Dao.FindAll();
        }

        public async void FillGridAsync<T>(GenericContextIts<T> ctx) where T : class
        {
            gridControlBase.DataSource = await ctx.Dao.FindAllAsync();
        }

        public void FillGrid(ICollection collection)
        {
            this.gridControlBase.DataSource = collection;
        }

        public void ExportarExcel(string filename)
        {
            gridControlBase.ExportToXlsx(filename);

        }

        public void ExportarExcelTo(string filename)
        {
            OpenFileDialog op = new OpenFileDialog { FileName = FileManagerIts.DocumentFilterExcel };

            if (op.ShowDialog() == DialogResult.OK)
            {
                gridControlBase.ExportToXlsx(op.FileName);

            }
        }

        public void ShowHideOptions(bool visible)
        {
            this.ribbonControl1.Visible = visible;
            this.panelControl1.Visible = visible;
        }

        #region Metodos que podem ser reescritos

        public virtual void Novo() { }

        public virtual void Alterar() { }

        public virtual void Salvar() { }

        public virtual void PreVisualizarValidar()
        {
            if (!string.IsNullOrEmpty(txtExcelFile.Text))
            {
                this.xtraTabPageResult.PageVisible = false;
                this.xtraTabPageErrors.PageVisible = false;
                this.IsValido = true;
                this.barBtnSalvar.Enabled = true;
            }
            else
            {
                XMessageIts.Advertencia("Informe o arquivo .xls ou .xlsx", "Arquivo do excel não informado!");
            }
        }

        public void SaveLayout()
        {
            gridViewResult.SaveLayout(this.Text);
        }


        #endregion

        #region Metodos interno

        private void loadFromFile()
        {
            this.gridControlBase.BeginInvoke(new Action(() =>
            {
                inflateLayoutViewResult();
                //verifica se o deseja concatenar as planilhas
                bool action = barToggleSwitchAllOne.Checked;

                //acao de concatenar as planilhas em uma unica tabela
                if (action)
                    this.table = manager.GetDataTable();
                else
                    this.ds = manager.GetDataSet();

                this.indexGrid(indexAction);

            }));

        }

        private void indexGrid(IndexAction index)
        {
            this.xtraTabPageResult.PageVisible = false;
            this.xtraTabPageErrors.PageVisible = false;
            string file = txtExcelFile.Text;
            if (!string.IsNullOrEmpty(file))
            {
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPageExcel;
                //se TEM UM "index" entao eh uma planilha so
                if (index == IndexAction.Index)
                {

                    indexarFromIndex(file);

                    this.table = null;

                }
                else
                {
                    //verifica se o deseja concatenar as planilhas
                    //acao de concatenar as planilhas em uma unica tabela
                    if (this.table != null)
                    {
                        this.gridControlBase.DataSource = manager.GetDataTable();
                        this.gridViewBase.BestFitColumns();
                    }
                    else
                    {
                        //inicializa o dataset
                        if (this.ds == null)
                            this.ds = manager.GetDataSet();

                        //se o index eh valido
                        if (INDEX >= 0 && INDEX < ds.Tables.Count)
                        {
                            DataTable dt = new DataTable();

                            try
                            {
                                switch (index)
                                {
                                    case IndexAction.Previous:

                                        if (INDEX >= 1)
                                            INDEX--;
                                        else
                                            return;
                                        break;

                                    case IndexAction.Next:
                                        if (INDEX < ds.Tables.Count - 1)

                                            INDEX++;
                                        else
                                            return;
                                        break;


                                    default:
                                        INDEX = 0;
                                        break;
                                }
                                dt = ds.Tables[INDEX];

                            }
                            catch (Exception)
                            {

                                INDEX = 0;
                                dt = ds.Tables[INDEX];

                            }
                            //this.gridView1.Columns.Clear();
                            this.gridControlBase.DataSource = dt;
                            this.gridViewBase.BestFitColumns();

                        }
                    }
                }
                this.gridViewBase.OptionsSelection.MultiSelect = true;
                this.gridViewBase.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            }
        }

        protected virtual void inflateLayoutViewResult()
        {
            if (layoutResult != null)
                gridViewBase.RestoreLayoutFromStream(layoutResult, OptionsLayoutBase.FullLayout);
        }

        private void indexarFromIndex(string file)
        {
            int i = ParseUtil.ToInt(barIndex.EditValue);
            try
            {
                inflateLayoutViewResult();
                this.gridViewBase.Columns.Clear();
                this.gridControlBase.DataSource = null;
                this.gridControlBase.DataSource = manager.GetDataTable(i);

            }
            catch (Exception ex)
            {
                XMessageIts.Advertencia(ex.Message, "Atenção");

            }
        }

        public void ShowResult<T>(HashSet<T> result, HashSet<T> erros = null) where T : class
        {
            this.Enabled = true;
            this.xtraTabPageResult.PageVisible = true;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageResult;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageResult;
            this.gridControlResult.DataSource = result;

            if (erros != null && erros.Count > 0)
                ShowErrors<T>(erros);

        }

        public void ShowErrors<T>(HashSet<T> erros)
        {
            this.xtraTabPageErrors.PageVisible = true;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageErrors;
            this.gridViewError.Columns.Clear();
            this.gridControlError.DataSource = erros;
        }

        #endregion

        #region Eventos

        private void barBtnPreviousPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            indexGrid(IndexAction.Previous);

        }

        private void barBtnNextPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            indexGrid(IndexAction.Next);
        }

        private void barBtnHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            indexGrid(IndexAction.Home);
        }

        protected void barToggleSwitchAllOne_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtExcelFile.Text))
            {
                btnSelectFile_Click(null, null);
            }
            //confirma se setei
            if (!string.IsNullOrEmpty(txtExcelFile.Text))
            {
                var status = barToggleSwitchAllOne.Checked;

                barBtnPreviousPlan.Enabled = !status;
                barBtnNextPlan.Enabled = !status;
                barBtnHome.Enabled = !status;

                barBtnAtualizar_ItemClick(null, null);
            }
        }

        private void barBtnIndexFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtExcelFile.Text))
                indexGrid(IndexAction.Index);
            else
                XMessageIts.Advertencia("Selecione o arquivo a ser carregado.");
        }

        private void barBtnRemoveRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewBase.DeleteSelectedRows();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var ext = Path.GetExtension(openFileDialog1.FileName);
                if (ext.EndsWith("xls") || ext.EndsWith("xlsx"))
                {
                    txtExcelFile.Text = openFileDialog1.FileName;
                    this.manager = new ConnectionExcel(txtExcelFile.Text);
                    barBtnAtualizar_ItemClick(null, null);
                }
                else
                {
                    XMessageIts.Advertencia("Extensão não aceita", "Atenção");
                }
            }
        }

        protected async void barBtnAtualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.xtraTabPageResult.PageVisible = false;
            this.xtraTabPageErrors.PageVisible = false;
            if (!String.IsNullOrWhiteSpace(txtExcelFile.Text) && File.Exists(txtExcelFile.Text))
                await Task.Run(() => loadFromFile());
            else
                XMessageIts.Advertencia("Selecione o arquivo a ser carregado.");
        }

        private void XFrmExcelManager_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExcelFile.Text) && File.Exists(txtExcelFile.Text))
                barBtnAtualizar_ItemClick(null, null);

        }

        private void barBtnNovo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewBase.AddNewRow();
            Novo();

        }

        private void barBtnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Alterar();
        }

        private void barBtnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveLayout();
            Salvar();
        }

        private void barBtnExportarPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewBase.IsEmpty)
            {
                XMessageIts.Mensagem("Nada a exportar !");
            }
            else
            {
                if (gridViewBase.DataSource != null)
                {
                    string pdfName = "export_pdf" + DataUtil.ToDateSql();
                    string pdf = Path.Combine(FileManagerIts.DeskTopPath, pdfName) + ".pdf";
                    FileManagerIts.DeleteFile(pdf);

                    gridControlBase.ExportToPdf(pdf);
                    FileManagerIts.OpenFromSystem(pdf);
                }
            }
        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
                barBtnRemoveRow_ItemClick(null, null);
        }

        private void barBtnExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewBase.ExportXlsxToDisk();
        }

        private void barBtnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PreVisualizarValidar();
        }

        #endregion

        #region Enum

        private enum IndexAction
        {
            Home = 0,
            Previous = 1,
            Next = 2,
            Index = 3,
        }

        #endregion

        /* 
         * Usei isso pra gerar os nomes da colunas em declaração em codigo
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string prop = "const string " + e.Column.ToString().ToUpper()
               + " = \"" + e.Column + "\"";

            Console.WriteLine(prop);
        }*/
    }
}