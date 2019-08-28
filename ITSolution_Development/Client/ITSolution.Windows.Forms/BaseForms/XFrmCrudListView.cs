using DevExpress.XtraBars;

// Classe esqueleto de CRUD
// Os botoes foram ocultados
// ToolBarLocation
// ShowApplicationButton
namespace ITSolution.Framework.Forms
{
    public partial class XFrmCrudListView : DevExpress.XtraBars.Ribbon.RibbonForm, DaoActionItemClick
    {
        private DaoActionItemClick _daoAction;

        public XFrmCrudListView()
        {
            InitializeComponent();
        }

        public XFrmCrudListView(DaoActionItemClick e):this()
        {
            this._daoAction = e;
        }

        #region Ações dos botoes - Metodos que devem ser reescritos 

        public virtual void SaveItemClick() { }
        public virtual void UpdateItemClick() { }
        public virtual void DeleteItemClick() { }
        public virtual void RefreshItemClick() { }
        public virtual void PrintItemClick() { }

        #endregion Metodos que devem ser reescritos  


        private void barBtnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_daoAction == null)

                SaveItemClick();
            else
            {
                _daoAction.SaveItemClick();
            }
        }

        private void barBtnEditar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_daoAction == null)
                UpdateItemClick();
            else
            {
                _daoAction.UpdateItemClick();
            }
        }

        private void barBtnRemover_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_daoAction == null)
                DeleteItemClick();
            else
            {
                _daoAction.DeleteItemClick();
            }
        }

        private void barBtnAtualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_daoAction == null)
                RefreshItemClick();
            else
            {
                _daoAction.RefreshItemClick();
            }
        }

        private void barBtnVisualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_daoAction == null)
                PrintItemClick();
            else
                _daoAction.PrintItemClick();
            //this.gridView1.ShowPrintPreview();
        }

    }
}