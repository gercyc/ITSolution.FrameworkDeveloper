using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;

namespace ITSolution.Framework.Eventos.GridViewEvents
{
    public interface IMasterRowEvent
    {
        int MasterRowGetRelationCount();

        string MasterRowGetRelationName();

        IList MasterRowGetChildList(MasterRowGetChildListEventArgs e);

        bool MasterRowEmpty(MasterRowEmptyEventArgs e);
    }
}
