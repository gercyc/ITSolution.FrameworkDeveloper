using DevExpress.XtraGrid.Views.Grid;
using ITSolution.Framework.Util;
using System.Drawing;

namespace ITSolution.Framework.Eventos.GridViewEvents
{
    /// <summary>
    /// Evento para controle de foco do gridView
    /// </summary>
    public class FocusRowChangedEvent
    {
        //View a ser manipulado
        private GridView gridView;
        private int prevFocusedRowHandle;



        /// <summary>
        /// Add o evento FocusedRowChanged para controle do foco sobre o view
        /// </summary>
        public FocusRowChangedEvent(GridView gridView)
        {
            this.gridView = gridView;
            this.gridView.FocusedRowChanged += FocusedRowChanged;
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
            gridView.FocusedRowHandle = prevFocusedRowHandle;
        }


        /// <summary>
        /// Seta o foco na ultima linha focada anteriormente no grid.
        /// </summary>
        /// <param name="sender"></param>object
        /// <param name="e"></param>FocusedRowChangedEventArgs 
        private void FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //salva o foco da linha anterior
            this.prevFocusedRowHandle = e.PrevFocusedRowHandle;

        }
    }
}
