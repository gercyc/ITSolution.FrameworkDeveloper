using DevExpress.XtraGrid.Views.Grid;
using ITSolution.Framework.GuiUtil;
using System.Collections;
using ITSolution.Framework.Eventos.GridViewEvents;

namespace ITSolution.Framework.Listeners.GridViewEvents
{
    //https://documentation.devexpress.com/WindowsForms/5495/Controls-and-Libraries/Data-Grid/Master-Detail/Binding-to-Data-Specifics/Implement-Master-Detail-Relationships-for-Objects-Using-the-IRelationList-Interface
    public abstract class AbstractMasterRow : IMasterRowEvent
    {
        //View a ser manipulado
        protected readonly GridView _gridView;
        protected readonly string _relationName;
        /// <summary>
        /// Notifica o MasterRowGetChildList que os filhos foram modificados
        /// </summary>
        public bool ChildChanged { get; set; }

        /// <summary>
        /// Detail list
        /// </summary>
        //public abstract IList ChildList { get; set; } 

        /// <summary>
        /// Retorna o objeto selecionado master row ou null se não selecionado.
        /// </summary>
        public object FocusedChildRow { get; protected set; }

        /// <summary>
        /// true se o Master Row está vazio caso contrário false.
        /// </summary>
        public bool IsEmpty { get; protected set; }

        /// <summary>
        /// true se o Master Row está expandido caso contrário false.
        /// </summary>
        public bool IsExpandRows { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridView">GridView</param>
        /// <param name="relationName">Nome do owner com os details</param>
        protected AbstractMasterRow(GridView gridView, string relationName)
        {
            this._gridView = gridView;
            this._relationName = relationName;
            this.IsExpandRows = false;

            InitMasterRowController();
        }

        /// <summary>
        /// Expande os grupos do MasterRow
        /// </summary>
        public void ExpandAllRows()
        {
            this.IsExpandRows = true;
            _gridView.ExpandAllMasterRow(IsExpandRows);
        }

        /// <summary>
        /// Recolher os grupos do MasterRow
        /// </summary>
        public void CollapseAllRows()
        {
            this.IsExpandRows = false;
            _gridView.ExpandAllMasterRow(IsExpandRows);
        }

        /// <summary>
        /// Expande ou recolher o MasterRow
        /// </summary>
        public void ExpandCollapseAllRows()
        {
            this.IsExpandRows = !this.IsExpandRows;
            _gridView.ExpandAllMasterRow(IsExpandRows);
        }

        public void NotifyChidlChanged()
        {
            //permissao para atualiza o objeto do grid
            this.ChildChanged = true;
            var indexs = _gridView.GetSelectedRows();
            foreach (var i in indexs)
            {
                //esses eventos disparam o MasterRowGetChild
                _gridView.CollapseMasterRow(i);
                _gridView.ExpandMasterRow(i);
                //apos isso o detail ira redesenhara o detail na tela
            }
            this.ChildChanged = false;
        }

        #region Interface

        public virtual int MasterRowGetRelationCount()
        {
            return 1;
        }

        public string MasterRowGetRelationName()
        {
            return _relationName;
        }

        public abstract IList MasterRowGetChildList(MasterRowGetChildListEventArgs e);

        public abstract bool MasterRowEmpty(MasterRowEmptyEventArgs e);

        #endregion

        #region Eventos
        private void gridView_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = MasterRowGetRelationCount();
        }

        private void gridView_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = this._relationName;
        }

        private void gridView1_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            e.ChildList = MasterRowGetChildList(e);
        }

        private void gridView_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            this.IsEmpty = e.IsEmpty = MasterRowEmpty(e);
        }

        private void gridView_detailGridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (sender != null)
            {
                GridView detailView = sender as GridView;
                //int i = detailView.SourceRowHandle;
                this.FocusedChildRow = detailView.GetFocusedRow();
            }
        }
        #endregion

        private void InitMasterRowController()
        {
            _gridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView_detailGridView_RowClick);
            _gridView.MasterRowEmpty += new DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventHandler(gridView_MasterRowEmpty);
            _gridView.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gridView1_MasterRowGetChildList);
            _gridView.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(gridView_MasterRowGetRelationName);
            _gridView.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(gridView_MasterRowGetRelationCount);
        }

    }

}

