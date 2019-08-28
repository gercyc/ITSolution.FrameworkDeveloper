using DevExpress.XtraEditors;
using System.Collections.Generic;

namespace ITSolution.Framework.GuiUtil
{
    public class GridLookUpUtil
    {
        /// <summary>
        /// Faz o GridLookUpEdit inicia com o valor default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridLookUp"></param>
        public static void SelectItem<T>(GridLookUpEdit gridLookUp, T t) where T : new()
        {
            gridLookUp.Properties.DataSource = null;
            var lista = new List<T>();
            lista.Add(t);
            gridLookUp.Properties.DataSource = lista;
            //gridLookUp.EditValue = t != null ? t.ToString() : "";//somente display
            gridLookUp.Select(0, 0);
            gridLookUp.Refresh();

        }

        /// <summary>
        /// Faz o GridLookUpEdit inicia com o valor default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridLookUp"></param>
        public static void Fill<T>(GridLookUpEdit gridLookUp, List<T> lista) where T : new()
        {
            gridLookUp.Properties.DataSource = lista;
            if (lista.Count > 0)
            {
                //gridLookUp.EditValue = t != null ? t.ToString() : "";//somente display
                gridLookUp.Select(0, 0);
                gridLookUp.Refresh();
            }
        }
    }
}
