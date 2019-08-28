using DevExpress.Utils;
using DevExpress.XtraBars;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Forms;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Util;
using ITSolution.Framework.Listeners;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolution.Framework.Beans.Forms
{
    public partial class XFrmFindEntity : DevExpress.XtraEditors.XtraForm
    {
        #region Variaveis
        public dynamic TEntity { get; private set; }
        public List<dynamic> TList { get; private set; }

        /// <summary>
        /// Botao abstrato, pode ser customizavel
        /// </summary>
        public BarButtonItem BarBtnActionPerformed { get { return this.batBtnActionPerformed; } }

        // Declare a delegate type for processing
        private Delegate actionDelegate;
        /// <summary>
        /// Itens selecionados
        /// </summary>
        public List<dynamic> TListSelect
        {
            get
            {
                return this.gridViewResults.GetSelectedItens<dynamic>();
            }
        }

        public bool IsCancel { get; private set; }
        #endregion

        #region Construtores

        private XFrmFindEntity()
        {
            InitializeComponent();
            this.TList = new List<dynamic>();
        }

        #endregion

        #region Metodos - Retorna um elemento dinamico

        //REVISADO EM 31/07/2017 - Gercy Campos, task 140
        /// <summary>
        /// Chama a tela de pesquisa de objetos. Montar os parametros através da classe ParamsFindEntity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static dynamic ShowDialogFindEntity<T>(ParamsFindEntity parameters) where T : class
        {
            XFrmFindEntity xFrmFindEntity = initListaDinamica<T>(
               context: parameters.Context,
               columnsView: parameters.Columns,
               orderBy: parameters.Order,
               whereConditions: parameters.WhereCondition,
               title: parameters.Title,
               tipo: parameters.DynamicObject);

            if (parameters.Layout != null)
                xFrmFindEntity.gridViewResults.RestoreLayoutFromStream(parameters.Layout, OptionsLayoutBase.FullLayout);


            xFrmFindEntity.ShowDialog();

            return xFrmFindEntity.TEntity;
        }

        /// <summary>
        /// Metodo com nome errado (repetido se renomear)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="columnsView"></param>
        /// <param name="tipo"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static dynamic ShowDiaglogFindEntity<T>(DbContextIts context,
            string[] columnsView, T tipo, string title = "Localizar:") where T : class
        {
            XFrmFindEntity xFrmFindEntity = initListaDinamica<T>(context, columnsView, title, tipo);

            xFrmFindEntity.ShowDialog();

            return xFrmFindEntity.TEntity;
        }

        /// <summary>
        /// Passar uma array de string com as colunas que deseja exibir
        /// </summary>
        /// <typeparam name="T">Entidade</typeparam>
        /// <param name="context">Contexto</param>
        /// <param name="columnsView">Array de colunas</param>
        /// <param name="title">Titulo da janela</param>
        /// <returns></returns>
        public static dynamic ShowDiaglogFindEntity<T>(DbContextIts context,
            string[] columnsView, T tipo, Stream layoutStream, string title = "Localizar:", Delegate action = null) where T : class
        {
            XFrmFindEntity xFrmFindEntity = initListaDinamica<T>(context, columnsView, title, tipo);

            if (layoutStream != null)
                xFrmFindEntity.gridViewResults.RestoreLayoutFromStream(layoutStream, OptionsLayoutBase.FullLayout);

            xFrmFindEntity.ShowDialog();

            xFrmFindEntity.setDelegateActionPerfomed(action);

            return xFrmFindEntity.TEntity;
        }

        public static dynamic ShowDiaglogFindEntity<T>(DbContextIts context,
       string[] columnsView, T tipo, string xmlFile, string title = "Localizar:") where T : class
        {
            XFrmFindEntity xFrmFindEntity = initListaDinamica<T>(context, columnsView, title, tipo);

            if (xmlFile != null)
                xFrmFindEntity.gridViewResults.RestoreLayoutFromXml(xmlFile, OptionsLayoutBase.FullLayout);

            xFrmFindEntity.ShowDialog();

            return xFrmFindEntity.TEntity;
        }

        public static T ShowDialogFindTEntity<T>(DbContextIts ctx, Stream layoutStream) where T : class
        {

            XFrmFindEntity xFrmFindEntity = new XFrmFindEntity();
            var x = new GenericContextIts<T>(ctx.NameOrConnectionString);
            xFrmFindEntity.gridControlResults.DataSource = x.Dao.FindAll();
            xFrmFindEntity.TEntity = xFrmFindEntity.gridViewResults.GetFocusedRow() as T;

            if (layoutStream != null)
                xFrmFindEntity.gridViewResults.RestoreLayoutFromStream(layoutStream, OptionsLayoutBase.FullLayout);

            xFrmFindEntity.ShowDialog();

            return xFrmFindEntity.gridViewResults.GetFocusedRow<T>();

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>A lista a ser exibida no grid
        /// <param name="layoutStream"></param>Layout
        /// <param name="title"></param>Titulo
        /// <param name="action"></param>Ação a ser disparada pelo botão extra
        /// <returns></returns>A entidade selecionada no grid
        public static T ShowDiaglogFindEntityFromList<T>(List<T> lista, Stream layoutStream, string title = "Localizar:",
            Delegate action = null) where T : class
        {
            XFrmFindEntity xFrmFindEntity = new XFrmFindEntity();

            xFrmFindEntity.gridControlResults.DataSource = lista;
            if (layoutStream != null)
                xFrmFindEntity.gridViewResults.RestoreLayoutFromStream(layoutStream, OptionsLayoutBase.FullLayout);

            xFrmFindEntity.ShowDialog();

            xFrmFindEntity.setDelegateActionPerfomed(action);

            if (xFrmFindEntity.IsCancel)
                return null;

            return xFrmFindEntity.gridViewResults.GetFocusedRow<T>();
        }

        #endregion

        #region Metodos - Retorna uma lista dinamica

        public static List<dynamic> ShowDialogFindListEntity<T>(DbContextIts context, string[] columnsView, T tipo,
            Stream layoutStream, string title = "Localizar:") where T : class
        {
            XFrmFindEntity xFrmFindEntity = initListaDinamica<T>(context, columnsView, title, tipo);
            xFrmFindEntity.gridViewResults.OptionsSelection.MultiSelect = true;

            if (layoutStream != null)
                xFrmFindEntity.gridViewResults.RestoreLayoutFromStream(layoutStream, OptionsLayoutBase.FullLayout);

            xFrmFindEntity.ShowDialog();

            return xFrmFindEntity.gridViewResults.GetSelectedItens<dynamic>();
        }

        public static List<dynamic> ShowDialogFindListEntity<T>(DbContextIts context, string[] columnsView,
            Stream layoutStream, string title = "Localizar:") where T : class
        {
            //sobre carga do metodo acima
            return XFrmFindEntity.ShowDialogFindListEntity<T>(context, columnsView, null, layoutStream, title);

        }

        public static List<dynamic> ShowDialogFindListEntity<T>(List<T> lista, string xmlFile, string title = "Localizar:") where T : class
        {
            XFrmFindEntity xFrmFindEntity = new XFrmFindEntity();

            xFrmFindEntity.Text = title;
            xFrmFindEntity.gridControlResults.DataSource = lista;
            xFrmFindEntity.gridViewResults.OptionsSelection.MultiSelect = true;

            if (xmlFile != null)
                xFrmFindEntity.gridViewResults.RestoreLayoutFromXml(xmlFile, OptionsLayoutBase.FullLayout);

            xFrmFindEntity.ShowDialog();

            return xFrmFindEntity.gridViewResults.GetSelectedItens<dynamic>();
        }

        public static List<T> ShowDialogFindListEntity<T>(DbContextIts ctx, Stream layoutStream, bool lazy = true) where T : class
        {

            XFrmFindEntity xFrmFindEntity = new XFrmFindEntity();
            var x = new GenericContextIts<T>(ctx.NameOrConnectionString);

            x.LazyLoading(lazy);

            xFrmFindEntity.gridControlResults.DataSource = x.Dao.FindAll();

            xFrmFindEntity.TEntity = xFrmFindEntity.gridViewResults.GetFocusedRow() as T;

            if (layoutStream != null)
                xFrmFindEntity.gridViewResults.RestoreLayoutFromStream(layoutStream, OptionsLayoutBase.FullLayout);

            xFrmFindEntity.ShowDialog();

            return xFrmFindEntity.gridViewResults.GetSelectedItens<T>();

        }


        #endregion

        #region Chamada interna

        private void setDelegateActionPerfomed(Delegate action)
        {
            this.BarBtnActionPerformed.Visibility = BarItemVisibility.Always;
            this.actionDelegate = action;
        }

        /// <summary>
        /// Faz a chamada da lista dinamica, este metodo não requer condicoes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="columnsView"></param>
        /// <param name="title"></param>
        /// <param name="tipo"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        private static XFrmFindEntity initListaDinamica<T>(DbContextIts context,
            string[] columnsView, string title, T tipo, string orderBy = "") where T : class
        {
            XFrmFindEntity xFrmFindEntity = new XFrmFindEntity();

            //Colunas que serão exibidas no grid
            var filter = "new ({0})";
            var cols = "";
            foreach (var c in columnsView)
            {
                if (columnsView.Count() > 1)
                {
                    if (c != columnsView.Last())
                    {
                        cols += "TEntity." + c + ",";
                    }
                    else
                    {
                        cols += "TEntity." + c;
                    }
                }
                else
                {
                    cols += "TEntity." + c;
                }
            }

            filter = String.Format(filter, cols);

            //Query linq dinamica
            var query = (from TEntity in context.Set<T>()
                         select new { TEntity }).AsQueryable();



            //Selecionando somente as colunas que quero exibir
            IQueryable iq = query.Select(filter);

            //ordenacao da lista - task 122 - gercy 10/10/2017
            if (orderBy != "")
            {
                iq = iq.OrderBy(orderBy);
            }

            //Lista tipada dinamica
            List<dynamic> list = new List<dynamic>();

            //Fill List
            foreach (var item in iq)
            {
                list.Add(item);
                //guarda a referencia da lista carregada
                xFrmFindEntity.TList.Add(item);
            }

            //Cria uma linha tipada pro grid
            //guarda a referencia da lista carrega em uma lista tipada
            if (tipo != null)
            {
                var lista = new List<T>();

                //adiciona o tipo informado
                lista.Add(tipo);

                //novo query
                query = (from TEntity in lista select new { TEntity }).AsQueryable();

                //atualizando dados
                iq = query.Select(filter);

                //atualizando a lista
                list.Clear();

                //reindexando
                foreach (var item in iq)
                {
                    list.Add(item);
                }
            }


            //seta o elemento
            xFrmFindEntity.Text = title;
            xFrmFindEntity.gridControlResults.DataSource = list;
            xFrmFindEntity.gridViewResults.BestFitColumns();
            xFrmFindEntity.TEntity = xFrmFindEntity.gridViewResults.GetFocusedRow();

            return xFrmFindEntity;

        }

        /// <summary>
        /// Faz a chamada da lista dinamica, este metodo requer uma string com as condicoes (WHERE)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="columnsView"></param>
        /// <param name="orderBy"></param>
        /// <param name="whereConditions"></param>
        /// <param name="title"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private static XFrmFindEntity initListaDinamica<T>(DbContextIts context,
            string[] columnsView, string orderBy, string whereConditions, string title, T tipo) where T : class
        {
            XFrmFindEntity xFrmFindEntity = new XFrmFindEntity();
            IQueryable query;

            //Colunas que serão exibidas no grid
            var filter = "new ({0})";
            var cols = "";
            foreach (var c in columnsView)
            {
                if (columnsView.Count() > 1)
                {
                    if (c != columnsView.Last())
                    {
                        cols += "TEntity." + c + ",";
                    }
                    else
                    {
                        cols += "TEntity." + c;
                    }
                }
                else
                {
                    cols += "TEntity." + c;
                }
            }

            filter = String.Format(filter, cols);


            //se recebeu as condicoes, aplique-as
            if (!whereConditions.IsNullOrEmpty())
            {
                query = (from TEntity in context.Set<T>().Where(whereConditions)
                         select new { TEntity }).AsQueryable();
            }
            else
            {
                query = (from TEntity in context.Set<T>()
                         select new { TEntity }).AsQueryable();
            }

            //Selecionando somente as colunas que quero exibir
            IQueryable iq = query.Select(filter);

            //ordenacao da lista - task 122 - gercy 10/10/2017
            if (!orderBy.IsNullOrEmpty())
            {
                iq = iq.OrderBy(orderBy);
            }

            //Lista tipada dinamica
            List<dynamic> list = new List<dynamic>();

            //Fill List
            foreach (var item in iq)
            {
                list.Add(item);
                //guarda a referencia da lista carregada
                xFrmFindEntity.TList.Add(item);
            }

            //Cria uma linha tipada pro grid
            //guarda a referencia da lista carrega em uma lista tipada
            if (tipo != null)
            {
                var lista = new List<T>();

                //adiciona o tipo informado
                lista.Add(tipo);

                //novo query
                query = (from TEntity in lista select new { TEntity }).AsQueryable();

                //atualizando dados
                iq = query.Select(filter);

                //atualizando a lista
                list.Clear();

                //reindexando
                foreach (var item in iq)
                {
                    list.Add(item);
                }
            }
            //seta o elemento
            xFrmFindEntity.Text = title;
            xFrmFindEntity.gridControlResults.DataSource = list;
            xFrmFindEntity.gridViewResults.BestFitColumns();
            xFrmFindEntity.TEntity = xFrmFindEntity.gridViewResults.GetFocusedRow();

            return xFrmFindEntity;

        }

        #endregion

        #region Eventos

        private void XFrmFindEntity_Shown(object sender, EventArgs e)
        {
            this.txtFindString.Links.Add(this.txtFindString, true);
            if (this.txtFindString.Links.Count > 0)
                this.txtFindString.Links[0].Focus();
        }

        private void btnSelectItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.TEntity = this.gridViewResults.GetFocusedRow();
            //permite 0 ou N linhas
            if (this.gridViewResults.OptionsSelection.MultiSelect)
            {
                this.Close();
            }
            else
            {
                //permite pelo menos uma linha
                if (this.gridViewResults.IsSelectOneRowWarning())
                    this.Close();
            }

        }

        private void txtFindString_EditValueChanged(object sender, EventArgs e)
        {
            if (txtFindString.EditValue != null)
                gridViewResults.FindFilterText = txtFindString.EditValue.ToString();
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFindString.EditValue != null)
                gridViewResults.FindFilterText = txtFindString.EditValue.ToString();
        }

        private void gridControlResults_DoubleClick(object sender, EventArgs e)
        {
            btnSelectItem_ItemClick(null, null);
        }

        private void XFrmFindEntity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                barBtnCancelar_ItemClick(null, null);

            else if (e.KeyCode == Keys.F5)
                barBtnAtualizar_ItemClick(null, null);

            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
            {
                if (this.txtFindString.Links.Count > 0)
                    this.txtFindString.Links[0].Focus();
            }
        }

        private void gridControlResults_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnSelectItem_ItemClick(null, null);

            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
            {
                if (this.txtFindString.Links.Count > 0)
                    this.txtFindString.Links[0].Focus();
            }

        }

        private void barBtnAtualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtFindString.EditValue = "";
            this.gridControlResults.DataSource = this.TList;
        }

        private void batBtnActionPerformed_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (actionDelegate != null)
                actionDelegate.DynamicInvoke();

        }

        private void barBtnCancelar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.IsCancel = true;
            this.TEntity = null;
            this.Dispose();
        }

        private void XFrmFindEntity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                var sd = new SaveFileDialog();
                sd.Filter = "XML File |.xml";
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    string xml = sd.FileName;

                    gridViewResults.SaveLayoutToXml(xml);

                }
            }
        }
        #endregion
 
    }
}


