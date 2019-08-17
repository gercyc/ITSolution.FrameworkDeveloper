using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using ITSolution.Framework.Util;
using System.Drawing;

namespace ITSolution.Framework.Eventos.GridViewEvents
{
    /// <summary>
    /// Evento para controle de foco do gridView
    /// </summary>
    public class TreelistFocusRowChangedEvent
    {
        //View a ser manipulado
        private TreeList treeList;
        private TreeListNode prevFocusedRowHandle;
        
        /// <summary>
        /// Add o evento FocusedRowChanged para controle do foco sobre o view
        /// </summary>
        public TreelistFocusRowChangedEvent(TreeList treeList)
        {
            this.treeList = treeList;
            this.treeList.FocusedNodeChanged += FocusedRowChanged;
        }


        /// <summary>
        /// Pintas os valores numericos de negativos de vermelho
        /// Disparado ao iniciar o GridControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //pinte os valores das celulas tipo decimal de vermelho
            // Pintas os valores numericos de negativos de vermelho
            //pinte os valores das celulas de vermelho
            if (ParseUtil.InstanceOfDecimal(e.CellValue))
            {
                decimal value = ParseUtil.ToDecimal(e.CellValue);

                if (value < 0.0m)
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }


        /// <summary>
        /// Direciona o foco para linha que estava em foco anteriormente.
        /// </summary>
        public void KeepFocusedRowChanged()
        {
            treeList.FocusedNode = prevFocusedRowHandle;
        }


        /// <summary>
        /// Seta o foco na ultima linha focada anteriormente no grid.
        /// </summary>
        /// <param name="sender"></param>object
        /// <param name="e"></param>FocusedRowChangedEventArgs 
        private void FocusedRowChanged(object sender,
            DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if(e.Node!= null)
                if(e.Node.Id != 0)
            //salva o foco da linha anterior
            this.prevFocusedRowHandle = e.Node;

        }
    }
}
