using DevExpress.XtraGrid.Views.Grid;
using ITSolution.Framework.Util;
using System.Drawing;

namespace ITSolution.Framework.Eventos.GridViewEvents
{
    /// <summary>
    /// Evento para customização da celula do gridView
    /// </summary>
    public class RowCellStyleEvent
    {
        /// <summary>
        /// Add o Evento RowCellStyle ao gridView
        /// Pintas os valores numericos negativos de vermelho
        /// </summary>
        public static void AddPaintCellDecimalValue(GridView gridView)
        {
            //pinte os valores das celulas tipo decimal de vermelho
            gridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView_RowCellStyle);
        }


        /// <summary>
        /// Pintas os valores numericos de negativos de vermelho
        /// Disparado ao iniciar o GridControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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

    }
}
